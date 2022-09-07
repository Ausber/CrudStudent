using Microsoft.AspNetCore.Mvc;
using SingleResponsability.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Controllers
{
    public class NotesController : Controller
    {
        NoteService noteService = new NoteService();
        public IActionResult Index()
        {
            var oLista = noteService.List();
            return View();
        }
    }
}
