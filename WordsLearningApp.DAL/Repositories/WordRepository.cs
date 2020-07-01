using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsLearningApp.DAL.EF;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.DAL.Repositories
{
    class WordRepository : IRepository<Word>
    {
        private WordContext db;
        public WordRepository(WordContext context)
        {
            db = context;
        }
        public void Create(Word item)
        {
            db.Words.Add(item);
        }

        public void Delete(int id)
        {
            Word word = db.Words.Find(id);
            db.Words.Remove(word);
        }

        public IEnumerable<Word> Find(Func<Word, bool> predicate)
        {
            //look at collection users
            return db.Words.Include(p => p.UserWords).Where(predicate).ToList();
        }

        public Word Get(int id)
        {
            return db.Words.Find(id);
        }

        public IEnumerable<Word> GetAll()
        {
            return db.Words.Include(p => p.Id).ToList();
        }

        public void Update(Word item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
