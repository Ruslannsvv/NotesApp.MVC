using Microsoft.AspNetCore.Mvc;
using NotesApp.MVC.Models;
using NotesApp.MVC.Services;

namespace NotesApp.MVC.Controllers
{
    public class NotesController : Controller
    {
        NoteService noteService = new NoteService();

        public IActionResult Index()
        {
            var notes = noteService.GetAllNotes();
            return View(notes);

        }
    }
    

}
