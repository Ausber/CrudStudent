using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingleResponsability.Models;
using SingleResponsability.Models.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Controllers
{
    public class NotesController : Controller
    {
        NoteService noteService = new NoteService();
        StudentService studentService = new StudentService();
        SubjectServices subjectServices = new SubjectServices();
        public IActionResult Index()
        {
            dynamic myModel = new ExpandoObject();
            myModel.Students = studentService.List();
            //var oLista = noteService.List();
            return View(myModel);
        }

        [HttpPost]
        public IActionResult GetSubject()
        {
            var oSubjects = subjectServices.List();
            var json = JsonConvert.SerializeObject(oSubjects);
            return Ok(json);
        }

        [HttpPost]
        public string GetNotes(int student_id)
        {
            var oNotes = noteService.List(student_id);
            var json = JsonConvert.SerializeObject(oNotes);
            return json;
        }

        [HttpPost]
        public IActionResult SaveNote(int student_id, int subject_id, float note)
        {
            NoteViewModel oNote = new NoteViewModel();
            oNote.subject_id = subject_id;
            oNote.student_id = student_id;
            oNote.note = note;
            oNote.name = null;
            Console.WriteLine(oNote);
            if (!ModelState.IsValid)
                return View("Index");

            var oNotes = noteService.Create(oNote);
            if(oNotes)
                return RedirectToAction("Index");
            else
                return View("Index");
        }
    }
}
