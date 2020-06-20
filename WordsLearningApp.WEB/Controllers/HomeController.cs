using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordsLearningApp.DAL.EF;
using WordsLearningApp.WEB.Models;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        WordContext context;

        public HomeController(WordContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            context.Users.Add(new User { Name = 22 });
            context.SaveChanges();
            User user = context.Users.Where(p => p.Id == 1).SingleOrDefault();
            Debug.WriteLine(user.Name);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
