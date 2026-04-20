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


        [HttpGet]
        public IActionResult Create() { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string content, string tags)
        {
            var tagList = tags != null && tags != ""
                ? tags.Split(',').Select(t => t.Trim()).ToList()
                : new List<string>();

            noteService.AddNote(title, content, tagList);

            return RedirectToAction("Index");
        }
    }
    

}
