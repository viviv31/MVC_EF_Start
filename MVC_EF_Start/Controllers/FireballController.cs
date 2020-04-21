using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_EF_Start.Controllers
{
    public class FireballController : Controller
    {
        public ActionResult Fireball()
        {
            return View();
        }
    }
}