using NotesApp.MVC.Models;
namespace NotesApp.MVC.Services
{
    public class NoteService
    {
        private List<Note> notes = new List<Note>();
        public Note AddNote(string title, string content, List<string> tags)
        {
            var note = new Note {
                Id = notes.Count + 1,
                Title = title,
                Content = content ?? string.Empty,
                Tags = tags ?? new List<string>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow         
            };

            notes.Add(note);
            return note;

        }

        public List<Note> SearchNotes(string query)
        {
            if (query == null || query.Length == 0)
                return new List<Note>();

            var results = new List<Note>();

            foreach (var note in notes)
            {
                if (note.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    note.Content.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    note.Tags != null && note.Tags.Any(tag => tag.Contains(query, StringComparison.OrdinalIgnoreCase)))
                    
                    results.Add(note); 

            }
            return results;
        }

        public List<Note> FilterByTags(List<string> selectedTags)
        {
            if (selectedTags == null || selectedTags.Count == 0)
                return notes;
            var results = new List<Note>();
            foreach (var note in notes)
            {
                if (note.Tags != null && note.Tags.Any(tag => selectedTags.Contains(tag, StringComparer.OrdinalIgnoreCase)))
                    results.Add(note);
            }
            return results;
        }
    }
}
   
  

