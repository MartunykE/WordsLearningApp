using AutoMapper;
using System.Collections.Generic;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.BLL.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<WordDTO, Word>();
            CreateMap<Word, WordDTO>();
            //CreateMap<List<Word>, List<WordDTO>>();
            //CreateMap<List<WordDTO>, List<Word>>();

        }
    }
}
