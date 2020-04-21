using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_EF_Start.DataAccess;

namespace MVC_EF_Start.Controllers
{
    [Produces("application/json")]
    [Route("api/ImpactData")]
    public class ImpactDataController : Controller
    {
        public ApplicationDbContext dbContext;

        public ImpactDataController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult ImpactData()
        {
            return View();
        }
    }
}
