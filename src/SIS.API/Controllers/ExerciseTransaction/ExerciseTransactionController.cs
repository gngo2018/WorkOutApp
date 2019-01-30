using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkOut.API.Controllers.ExerciseTransaction
{
    public class ExerciseTransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    //TODO: Don't forget to add Manager and Repository to Startup.cs after stuff gets added in
    //TODO: Don't forget to set Mapping for CRU
}