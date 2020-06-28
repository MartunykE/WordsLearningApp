using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.BLL.DTO;

namespace WordsLearningApp.BLL.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(UserDTO userDTO);

        public void EditUser(UserDTO userDTO);
        public UserDTO GetUser(int id);
        public void DeleteUser(int id);
        //public void SetWordShowTime(DateTime time, long chatId);
    }
}
