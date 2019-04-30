using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class SubjectController : Controller
    {
         DB45Entities db = new DB45Entities();
        // GET: Subject
        public ActionResult Index()
        {
            var list = db.Subjects.ToList();
            //var db = new DB45Entities();
            //SubjectViewModel model = new SubjectViewModel();
            
            //model.allPrograms = db.Programs.ToList();
            return View("ViewSubjects"  , list);
        }

        // GET: Subject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            SubjectViewModel model = new SubjectViewModel();

            model.allPrograms = db.Programs.ToList();



            return View("AddSubjects" , model);
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(SubjectViewModel col)
        {
            try
            {
                // TODO: Add insert logic here
                Subject s = new Subject();
                s.ProgramId = col.ProgramId;
                //s.SubjectId = col.SubjectId;
                s.SubjectName = col.SubjectName;

                db.Subjects.Add(s);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id)
        {
            //var d = db.Programs.First(x => x.ProgramId == id);
            //ProgramViewModel PM = new ProgramViewModel();

            //PM.ProgramId = d.ProgramId;
            //PM.Name = d.Name;
            //PM.AdmissionEnd = d.AdmissionEnd;
            //PM.AdmissionStart = d.AdmissionStart;
            //PM.ClassesStart = d.ClassesStart;

            var d = db.Subjects.First(x => x.SubjectId == id);
            SubjectViewModel svm = new SubjectViewModel();
            svm.SubjectId = d.SubjectId;
            svm.ProgramId = d.ProgramId;
            svm.SubjectName = d.SubjectName;

            return View("EditSubjects" , svm);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SubjectViewModel col)
        {
            try
            {
                // TODO: Add update logic here
                Subject s = db.Subjects.First(x => x.SubjectId == id);

                s.ProgramId = col.ProgramId;
                s.SubjectName = col.SubjectName;
                db.SaveChanges();

                return RedirectToAction("Index" );
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            Subject s = db.Subjects.Find(id);
            db.Subjects.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
