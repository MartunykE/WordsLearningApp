using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.Models;
namespace WordsLearningApp.BLL.Services
{
    public class UserService : IUserService
    {
        IUntiOfWork db;
        public UserService(IUntiOfWork untiOfWork)
        {
            db = untiOfWork;
        }
        public void CreateUser(UserDTO userDTO)
        {
            User user = new User()
            {
                ChatId= userDTO.ChatId,
                Name = userDTO.Name
            };

            db.Users.Create(user);
            db.Save();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(UserDTO userDTO)
        {
            User user = db.Users.Find(p => p.ChatId == userDTO.ChatId).FirstOrDefault();
            user.Name = userDTO.Name;
            if (userDTO.StartSendWordTime != null)
            {
                user.StartSendWordsTime = userDTO.StartSendWordTime;
            }
            if (userDTO.FinishSendWordTime != null)
            {
                user.FinishSendWordsTime = userDTO.FinishSendWordTime;
            }
            db.Users.Update(user);
            db.Save();
        }

        public UserDTO GetUser(int id)
        {
            throw new NotImplementedException();
        }

       
      






        //public void SetWordShowTime(DateTime time, long chatId)
        //{
        //    User user = db.Users.Find(p => p.ChatId == chatId).FirstOrDefault();
        //    if (user.ShowWordSchedule == null)
        //    {
        //        user.ShowWordSchedule = new List<Schedule>();
        //    }

        //    user.ShowWordSchedule.Add(new Schedule { Time = time}) ;
        //    db.Users.Update(user);
        //    db.Save();
        //}

        
    }
}
