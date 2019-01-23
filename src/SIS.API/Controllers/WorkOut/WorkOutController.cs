using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkOut.API.Controllers.WorkOut
{
    public class WorkOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}