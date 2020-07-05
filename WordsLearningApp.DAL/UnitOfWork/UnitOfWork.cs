using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.DAL.EF;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.Models;
using WordsLearningApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
namespace WordsLearningApp.DAL.UnitOfWork
{
    public class UnitOfWork : IUntiOfWork
    {
        WordContext db;
        WordRepository wordRepository;
        UserRepository userRepository;
        public IRepository<Word> Words 
        {
            get 
            {
                if (wordRepository == null)
                {
                    wordRepository = new WordRepository(db);
                }
                return wordRepository;
            } 
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public UnitOfWork(DbContextOptions<WordContext> options)
        {
            db = new WordContext(options);
        }

        public async void Save()
        {
           await db.SaveChangesAsync();
        }
    }
}
