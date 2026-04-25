# NotesApp (MVC)

##  Project Description

NotesApp is a web application for creating and managing notes, implemented using the MVC (Model-View-Controller) architecture.

The user can create, edit, delete, and view notes, as well as perform search, filtering by tags, and sorting.

---

##  Features

*  Create notes
*  View notes list
*  Edit notes
*  Delete notes
*  Search (by title, content, tags)
*  Filter by tags
*  Sort by creation date

---

##  Architecture (MVC)

###  Model

The `Note` model represents the structure of a note:

* Id
* Title
* Content
* Tags (List<string>)
* CreatedAt
* UpdatedAt

---

###  Service

`NoteService` contains the business logic:

* adding notes
* updating notes
* deleting notes
* searching
* filtering

Data is stored in memory (in-memory list).

---

###  Controller

`NotesController` handles HTTP requests:

* `Index` — displays notes with search, filtering, and sorting
* `Create` — creates a new note
* `Edit` — updates an existing note
* `Delete` — deletes a note

---

###  View

Views are implemented using Razor:

* `Index.cshtml` — notes list
* `Create.cshtml` — create form
* `Edit.cshtml` — edit form

---

##  Search and Filtering

Search works by:

* title
* content
* tags

Filtering allows displaying notes by a specific tag.

---

##  Sorting

Sorting is implemented by creation date:

* ascending
* descending

---

##  Technologies

* ASP.NET Core MVC
* C#
* Razor
* HTML / CSS

---

##  Notes

* Data is not stored in a database (in-memory only)
* Simple and user-friendly interface
* Demonstrates basic MVC principles

---

##  Conclusion

This project implements a full CRUD application using the MVC architecture.
It demonstrates request handling, separation of concerns, and UI rendering.
