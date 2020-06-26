using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public UserDTO GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
