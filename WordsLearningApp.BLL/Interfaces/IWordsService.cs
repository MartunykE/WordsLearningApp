using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.BLL.DTO;

namespace WordsLearningApp.BLL.Interfaces
{
    interface IWordsService
    {
        // return result??
        void CreateWord(WordDTO word);

        void EditWord(WordDTO word);
        WordDTO GetWord(int id);
        void DeleteWord(int id);
        void ChangeShowFrequency(ShowFrequency showFrequencyLevel);

    }
}
