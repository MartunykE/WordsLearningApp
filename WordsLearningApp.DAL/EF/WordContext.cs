using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public WordContext()
        {

        }
        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=wordsDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsersWords>().HasKey(p => new { p.WordId, p.UserId });
            modelBuilder.Entity<UsersWords>().HasOne(uw => uw.User).WithMany(p => p.UserWords).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<UsersWords>().HasOne(uw => uw.Word).WithMany(p => p.UserWords).HasForeignKey(w => w.WordId);
         
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
