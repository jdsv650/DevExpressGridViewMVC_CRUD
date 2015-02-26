using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DXWebApplication2.Models;

namespace DXWebApplication2.Services
{
    public class NoteService
    {
        public List<Models.NoteViewModel> GetAllNotes()
        {
            var db = new DataAccess.Model1();

            var result = db.Notes.Select(n => new NoteViewModel()
            {
                NoteId = n.NoteId,
                Contents = n.Contents,
                DateCreated = n.DateCreated,
                DateModified = n.DateModified,
                Title = n.Title
            }).ToList();
          
            return result;
        }


        public bool AddNote(NoteViewModel item)
        {
            var db = new DataAccess.Model1();
            var note = new Notes();

            note.NoteId = item.NoteId;
            note.Contents = item.Contents;
            note.Title = item.Title;
            note.DateCreated = DateTime.Now;  //item.DateCreated;   // DateTime / DateTime2 ERROR ***********************
            note.DateModified = DateTime.Now; // item.DateModified;
            note.ApplicationUserId = "";
            db.Notes.Add(note);

            if (db.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public bool UpdateNote(NoteViewModel item)
        {
            var db = new DataAccess.Model1();

            var theNote = db.Notes.Where(n => n.NoteId == item.NoteId).SingleOrDefault();

            theNote.Contents = item.Contents;
            theNote.DateCreated = DateTime.Now;
            theNote.DateModified = DateTime.Now;  // Datetiem2  ERROR ******
            theNote.Title = item.Title;

            if (db.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public void DeleteNote(int NoteId)
        {
            var db = new DataAccess.Model1();

            var result = db.Notes.Where(n => n.NoteId == NoteId).SingleOrDefault();

            if (result != null)
            {
                db.Notes.Remove(result);
            }

            db.SaveChanges();

        }
    }
}
