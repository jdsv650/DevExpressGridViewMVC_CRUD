using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DXWebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private Services.NoteService _noteService = new Services.NoteService();


        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";
             //Nothing Here
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()   // INDEX CALL 
        {
            var result = _noteService.GetAllNotes();

            return PartialView("_GridViewPartial", result);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(DXWebApplication2.Models.NoteViewModel item)
        {
       
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    _noteService.AddNote(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", _noteService.GetAllNotes());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(DXWebApplication2.Models.NoteViewModel item)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    _noteService.UpdateNote(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", _noteService.GetAllNotes());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 NoteId)
        {
          
            if (NoteId >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    _noteService.DeleteNote(NoteId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", _noteService.GetAllNotes());
        }
    }
}