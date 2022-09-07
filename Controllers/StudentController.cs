using Microsoft.AspNetCore.Mvc;
using SingleResponsability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save(StudentViewModel student)
        {
            return RedirectToAction("Index");
            //return View();
        }
    }
}
