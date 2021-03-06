﻿using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.DAL.Interfaces
{
    public interface IUntiOfWork
    {
        IRepository<Word> Words { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
