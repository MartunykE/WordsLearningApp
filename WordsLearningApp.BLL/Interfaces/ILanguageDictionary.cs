using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using WordsLearningApp.BLL.DTO;

namespace WordsLearningApp.BLL.Interfaces
{
    public interface ILanguageDictionary
    {
        public string GetWordDefinition(string word);
    }
}
