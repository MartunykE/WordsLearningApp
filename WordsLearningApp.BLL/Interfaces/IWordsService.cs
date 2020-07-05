﻿using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.BussinesModels;
using System.Timers;
using System.Collections.Generic;

namespace WordsLearningApp.BLL.Interfaces
{
    public interface IWordsService
    {
        // return result??

        public Timer Timer { get; }
        public void CreateWord(WordDTO word);

        public void EditWord(WordDTO word);
        public WordDTO GetWord(int id);
        public void DeleteWord(int id);
        public List<SendMessagePackage> GetSendMessagePackages();

    }
}
