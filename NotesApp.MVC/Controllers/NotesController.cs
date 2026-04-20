using Microsoft.AspNetCore.Mvc;
using NotesApp.MVC.Models;
using NotesApp.MVC.Services;

namespace NotesApp.MVC.Controllers
{
    public class NotesController : Controller
    {
        NoteService noteService = new NoteService();

        public IActionResult Index(string search, string tag, string sort)
        {
            var notes = noteService.GetAllNotes();

            if (!string.IsNullOrWhiteSpace(search))
            {
                notes = noteService.SearchNotes(search);
            }

            if (!string.IsNullOrWhiteSpace(tag))
            {
                notes = noteService.FilterByTags(new List<string> { tag });
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                notes = sort switch
                {
                    "data_asc" => notes.OrderBy(n => n.CreatedAt).ToList(),
                    "data_desc" => notes.OrderByDescending(n => n.CreatedAt).ToList(),
                    _ => notes
                };
            }
            
            return View(notes);
        }


        [HttpGet]
        public IActionResult Create()
        {
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

        public IActionResult Delete(int id)
        {
            noteService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var note = noteService.GetNoteById(id);
            if (note == null)
                return NotFound();
            return View(note);
        }

        [HttpPost]

        public IActionResult Edit(int id, string title, string content, string tags)
        {
            var tagList = tags != null && tags != ""
                ? tags.Split(',').Select(t => t.Trim()).ToList()
                : new List<string>();
            noteService.UpdateNote(id, title, content, tagList);
            return RedirectToAction("Index");


        }

    }
}
