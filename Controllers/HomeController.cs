using System.Collections.Generic;
using StudentApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using StudentApplication.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApplication.Controllers
{
    public class HomeController : Controller
    {
        
        SchoolContext db = new SchoolContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

    }
}