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

namespace WordsLearningApp.BLL.Services
{
    public class WordsService : IWordsService
    {
        IUntiOfWork db { get; set; }
         Timer timer;

        public Timer Timer { get { return timer; } }
        //TODO:method for initializing timer. event if schedule was updated
        public WordsService(IUntiOfWork untiOfWork)
        {
            db = untiOfWork;


            timer = new Timer(300);
            InitializeTimer();

        }
        public void ChangeShowFrequency(ShowFrequency showFrequencyLevel)
        {
            throw new NotImplementedException();
        }

        public void CreateWord(WordDTO wordDTO)
        {
            Word word = new Word()
            {
                Name = wordDTO.Name
            };
            db.Words.Create(word);

            //TODO: Add condition for save
            db.Save();

        }

        public void DeleteWord(int id)
        {
            db.Words.Delete(id);
            db.Save();
        }

        public void EditWord(WordDTO wordDTO)
        {
            //Think about automapper
            Word word = db.Words.Find(w=> w.Id == wordDTO.Id).SingleOrDefault();
            word.Name = wordDTO.Name;
            db.Words.Update(word);
            db.Save();
        }

        public WordDTO GetWord(int id)
        {
            WordDTO wordDTO = new WordDTO();
            Word word = db.Words.Find(w=> w.Id == wordDTO.Id).SingleOrDefault();
            wordDTO.Id = word.Id;
            wordDTO.Name = word.Name;
            return wordDTO;
        }
        
        //on reply send definition
        public WordDTO InitializeTimer()
        {
            //think about comparer or own sort 
            var usersList = db.Users.GetAll().ToList();
            //User user = usersList.Where(p => p.ShowWordSchedule == p.ShowWordSchedule.Min()).Min();
            //foreach (var user2 in usersList)
            //{
            //   var messageTime = user2.ShowWordSchedule.Min();
            //}
            //Debug.WriteLine("000");

            timer.Interval = 300;
            WordDTO wordDTO = new WordDTO();
            wordDTO.Name = "INIT timer";
            timer.Start();
            return wordDTO;
        }
        
        public WordDTO SendMessage()
        {
            //DateTime.Now. 


            return GetWord(1);
        }

        //TODO: Add method for sending word in schedule (Timer)
    }
}
