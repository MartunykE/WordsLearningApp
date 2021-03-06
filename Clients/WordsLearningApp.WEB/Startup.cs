using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordsLearningApp.TelegramBot.Models;
using WordsLearningApp.BLL.Interfaces;
using WordsLearningApp.BLL.Services;
using WordsLearningApp.BLL.DictionaryAPI;
using WordsLearningApp.Root;
using WordsLearningApp.DAL.Interfaces;
using AutoMapper;

namespace WordsLearningApp.TelegramBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            DependenciesRoot.InjectDependencies(services, connection);
            services.AddAutoMapper(typeof(Startup));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IWordsService wordsService, IUserService userService, IMapper mapper, ILanguageDictionary languageDictionary)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseStaticFiles();

            Bot.GetBotClientAsync(wordsService, userService, mapper, languageDictionary);



        }
    }
}
