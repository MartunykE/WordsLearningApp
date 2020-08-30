using AutoMapper;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.BLL.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
