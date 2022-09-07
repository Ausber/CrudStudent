using Microsoft.AspNetCore.Mvc;
using SingleResponsability.Models;
using SingleResponsability.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Controllers
{
    public class SubjectController : Controller
    {
        SubjectServices subjectServices = new SubjectServices();
        public IActionResult Index()
        {
            var oLista = subjectServices.List();
            return View(oLista);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveSubject(SubjectViewModel subject)
        {
            if (!ModelState.IsValid)
                return View("Add");

            var resp = subjectServices.Create(subject);
            if (resp)
                return RedirectToAction("Index");
            else
                return View("Add");
        }
    }
}
