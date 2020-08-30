using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WordsLearningApp.BLL;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.BLL.Services;
using WordsLearningApp.BLL.DictionaryAPI;
using WordsLearningApp.DAL;
using WordsLearningApp.DAL.EF;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.UnitOfWork;
namespace WordsLearningApp.Root
{
    public class DependenciesRoot
    {
        public static void InjectDependencies(IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<WordContext>(options => options.UseSqlServer(dbConnection));
            services.AddTransient<IUntiOfWork, UnitOfWork>();
            services.AddTransient<IWordsService, WordsService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILanguageDictionary, EnglishDictionary>();

        }
    }
}
