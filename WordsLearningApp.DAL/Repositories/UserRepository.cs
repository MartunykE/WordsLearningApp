using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsLearningApp.DAL.EF;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private WordContext db;
        public UserRepository(WordContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Include(p => p.Words).Where(predicate).ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
