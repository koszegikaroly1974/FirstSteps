using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSteps.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
