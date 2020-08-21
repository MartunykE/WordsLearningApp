using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.BLL.BussinesModels;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.Models;
using System.Linq;
using System.Timers;
using System.Diagnostics;
using System.Data.Common;
using System.Threading.Tasks;

namespace WordsLearningApp.BLL.Services
{
    public class WordsService : IWordsService
    {
        IUntiOfWork db { get; set; }
        List<User> scheduledUsers;
        Timer timer;

        public Timer Timer { get { return timer; } }

        public WordsService(IUntiOfWork untiOfWork)
        {
            db = untiOfWork;
            scheduledUsers = new List<User>();

            //10 sec
            timer = new Timer(10000);
            timer.Elapsed += new ElapsedEventHandler(GetScheduledUsers);
            //timer.Start();

        }

        public void CreateWord(WordDTO wordDTO)
        {
            Word word = null;
            try
            {
                word = db.Words.Find(p => p.Name == wordDTO.Name).FirstOrDefault();

            }
            catch
            {

            }
            User user = db.Users.Find(p => p.ChatId == wordDTO.UserChatId).FirstOrDefault();
            if (word == null)
            {
                word = new Word();
                word.Name = wordDTO.Name;
                db.Words.Create(word);
            }

            word.UserWords.Add(new UsersWords { User = user, Word = word });
            db.Save();

        }

        public void DeleteWord(int id)
        {
            db.Words.Delete(id);
            db.Save();
        }

        public Task<int> EditWord(WordDTO wordDTO)
        {
            //Think about automapper
            Word word = db.Words.Find(w => w.Id == wordDTO.Id).SingleOrDefault();
            if (word == null)
            {
                return Task.FromResult(-1);
            }
            word.Name = wordDTO.Name;
            db.Words.Update(word);
            db.Save();
            return Task.FromResult(1);

        }

        public WordDTO GetWord(int id)
        {
            WordDTO wordDTO = new WordDTO();
            try
            {
                Word word = db.Words.Find(w => w.Id == id).SingleOrDefault();
                wordDTO.Id = word.Id;
                wordDTO.Name = word.Name;
            }
            catch
            {
                return null;
            }
            return wordDTO;
        }
        //public IEnumerable<WordDTO> GetWords()
        //{
        //    automapper!
        //        return db.Words.GetAll();
        //}

        private void GetScheduledUsers(object sender, ElapsedEventArgs e)
        {
            scheduledUsers = db.Users.Find(user =>
               user.StartSendWordsTime.TimeOfDay < DateTime.Now.TimeOfDay &&
               user.FinishSendWordsTime.TimeOfDay > DateTime.Now.TimeOfDay).ToList();

        }

        public List<SendMessagePackage> GetSendMessagePackages()
        {
            var sendMessagePackages = new List<SendMessagePackage>();

            foreach (var user in scheduledUsers)
            {
                Word word = user.UserWords.OrderBy(p => p.LearningLevel).FirstOrDefault().Word;
                WordDTO wordDTO = new WordDTO();
                wordDTO.Name = word.Name;
                wordDTO.Id = word.Id;

                wordDTO.LearningLevel = ++user.UserWords.Where(p => p.User == user && p.Word == word).FirstOrDefault().LearningLevel;
                EditWord(wordDTO);

                SendMessagePackage sendMessagePackage = new SendMessagePackage((long)user.ChatId, wordDTO.Name);
                sendMessagePackages.Add(sendMessagePackage);
            }


            return sendMessagePackages;
        }


    }
}
