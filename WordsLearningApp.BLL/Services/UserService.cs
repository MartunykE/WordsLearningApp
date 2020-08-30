using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.Models;
using System.Security.Cryptography;
using AutoMapper;
using WordsLearningApp.BLL.AutoMapper;

namespace WordsLearningApp.BLL.Services
{
    public class UserService : IUserService
    {
        IUntiOfWork db;
        IMapper mapper;
        public UserService(IUntiOfWork untiOfWork, IMapper mapper)
        {
            db = untiOfWork;
            this.mapper = mapper;
        }
        public void CreateUser(UserDTO userDTO)
        {
            User user = new User();

            if (string.IsNullOrWhiteSpace(userDTO.Password) && userDTO.ChatId == null)
            {
                throw new Exception("Password or ChatId is Required");
            }
            if (db.Users.Find(u => u.Username == userDTO.Username).Count() != 0)
            {
                throw new Exception($"Username {userDTO.Username} is already taken");
            }
            user.ChatId = userDTO.ChatId;
            user.Username = userDTO.Username;
            byte[] passwordHash;
            byte[] passwordSalt;

            CreatePasswordHash(userDTO.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            db.Users.Create(user);
            db.Save();
        }

        public UserDTO Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            var user = db.Users.Find(p => p.Username == username).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            //TODO: Use AutoMapper
            var userDTO = mapper.Map<UserDTO>(user);
            //UserDTO userDTO = new UserDTO
            //{
            //    Username = user.Username
            //};
            return userDTO;

        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void DeleteUser(int chatId)
        {
            db.Users.Delete(chatId);
        }

        public void EditUser(UserDTO userDTO)
        {
            User user = db.Users.Find(p => p.ChatId == userDTO.ChatId).FirstOrDefault();
            user.Username = userDTO.Username;

            DateTime dateTime = default;
            if (userDTO.StartSendWordTime != dateTime)
            {
                user.StartSendWordsTime = (DateTime)userDTO.StartSendWordTime;
            }
            if (userDTO.FinishSendWordTime != dateTime)
            {
                user.FinishSendWordsTime = (DateTime)userDTO.FinishSendWordTime;
            }
            db.Users.Update(user);
            db.Save();
        }

        public UserDTO GetUser(int id)
        {
            UserDTO userDTO = new UserDTO();
            User user = db.Users.Get(id);
            var all = db.Users.GetAll().ToList();

            if (user == null)
            {
                return null;
            }
            userDTO.ChatId = user.ChatId;
            userDTO.Username = user.Username;
            return userDTO;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public IEnumerable<UsersWords> GetUsersWords(int userId)
        {
            //think how to get words
            var words = db.Users.Get(userId).UserWords;
            return words;

        }
        //public void Dispose()
        //{
        //    db.Dispose();
        //}
    }
}
