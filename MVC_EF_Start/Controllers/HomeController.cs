using Microsoft.AspNetCore.Mvc;
using MVC_EF_Start.Models;
using MVC_EF_Start.DataAccess;
using System.Linq;
using MVC_EF_Start.APIHandlerManager;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_EF_Start.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            Sentry();
            return View();
        }

        public PartialViewResult SignUp()
        {
            Person myperson = new Person();
            return PartialView("_SignUpForm");
        }

        [HttpPost]
        public IActionResult SignUp(Person myperson)
        {
            dbContext.People.Add(myperson);
            dbContext.SaveChanges();
            return View("Index");
        }

        public IActionResult Sentry()
        {
            //this will prob need to be changed so as to load only a few objects or something
            //APIHandler is a class
            APIHandler webHandler = new APIHandler();
            SentryObject sentryData = webHandler.GetSentryObjects();

            foreach (Sentry s in sentryData.data)
            {
                dbContext.SentryEntries.Add(s);
            }
            dbContext.SaveChanges();

            return View(sentryData);
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
