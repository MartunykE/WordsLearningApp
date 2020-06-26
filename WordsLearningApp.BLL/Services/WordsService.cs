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

namespace WordsLearningApp.BLL.Services
{
    public class WordsService : IWordsService
    {
        IUntiOfWork db { get; set; }
        Timer timer;

        public WordsService(IUntiOfWork untiOfWork)
        {
            double a = 5;
            timer = new Timer();
            
            db = untiOfWork;
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
        
        public WordDTO SendMessage()
        {
            //DateTime.Now. 


            return GetWord(1);
        }

        //TODO: Add method for sending word in schedule (Timer)
    }
}
