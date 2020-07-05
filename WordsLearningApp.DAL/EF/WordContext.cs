using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.DAL.EF
{
    public class WordContext : DbContext
    {
        //check connection string 
        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersWords>().HasKey(p => new { p.WordId, p.UserId });
            modelBuilder.Entity<UsersWords>().HasOne(uw => uw.User).WithMany(p => p.UserWords).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<UsersWords>().HasOne(uw => uw.Word).WithMany(p => p.UserWords).HasForeignKey(w => w.WordId);
         
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
