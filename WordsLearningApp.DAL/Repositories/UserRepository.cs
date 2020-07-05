using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void Delete(int chatId)
        {
            User user = db.Users.Find(chatId);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            var a = db.Users.Include(p => p.CommonUserWords).ThenInclude(o=>o.Word).Where(predicate).ToList();
            return a;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = db.Users;
            return users;
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
