using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.BLL.BussinesModels;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.Models;
namespace WordsLearningApp.BLL.Services
{
    public class WordsService : IWordsService
    {
        IUntiOfWork db { get; set; }

        public WordsService(IUntiOfWork untiOfWork)
        {
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
            throw new NotImplementedException();
        }

        public void EditWord(WordDTO word)
        {
            throw new NotImplementedException();
        }

        public WordDTO GetWord(int id)
        {
            throw new NotImplementedException();
        }
    }
}
