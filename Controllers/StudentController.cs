using Microsoft.AspNetCore.Mvc;
using SingleResponsability.Models;
using SingleResponsability.Models.Services;
using System;

namespace SingleResponsability.Controllers
{
    public class StudentController : Controller
    {
        StudentService studentService = new StudentService();
        public IActionResult List()
        {
            var oLista = studentService.List();
            return View("Index", oLista);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return View("Add");
            var resp = studentService.Create(student);
            if (resp)
                return RedirectToAction("List");
            else
                return View("Add");          
        }
    }
}
