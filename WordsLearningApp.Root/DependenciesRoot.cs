using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WordsLearningApp.BLL;
using WordsLearningApp.DAL;
using WordsLearningApp.DAL.EF;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.BLL.Services;
using WordsLearningApp.DAL.Interfaces;
using WordsLearningApp.DAL.UnitOfWork;

namespace WordsLearningApp.Root
{
    public class DependenciesRoot
    {
        public static void InjectDependencies(IServiceCollection services, string connection)
        {

            services.AddDbContext<WordContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUntiOfWork, UnitOfWork>();
            services.AddTransient<IWordsService, WordsService>();
            services.AddTransient<IUserService, UserService>();

        }
    }
}
