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

        //Base URL for the IEXTrading API. Method specific URLs are appended to this base URL.
        string BASE_URL = "https://api.iextrading.com/1.0/";
        HttpClient httpClient;

        public IActionResult Index()
        {
            return View();
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
    }
}