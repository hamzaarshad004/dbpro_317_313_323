using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class SectionController : Controller
    {
        DB45Entities db = new DB45Entities();
        // GET: Section
        public ActionResult Index()
        {
            List<Section> sections = db.Sections.ToList();
            List<SectionViewModel> sectionViews = new List<SectionViewModel>();
            foreach(Section s in sections)
            {
                SectionViewModel model = new SectionViewModel();
                model.SectionId = s.SectionId;
                model.SectionName = s.SectionName;
                model.Batch = s.Batch;
                model.TotalStudents = s.TotalStudents ?? 0;

                sectionViews.Add(model);
            }
            return View(sectionViews);
        }

        // GET: Section/Details/5
        public ActionResult Details(int id)
        {
            Section section = db.Sections.First(c => c.SectionId == id);
            var Students = section.Students;
            List<StudentViewModel> StudentsView = new List<StudentViewModel>();
            foreach(var S in Students)
            {
                StudentViewModel student = new StudentViewModel();
                Person P = db.People.Where(c => c.PersonId == S.StudentId).First();

                student.Name = P.Name;
                student.RollNo = S.RollNo;
                student.Batch = S.Batch;

                StudentsView.Add(student);
            }
            return View(StudentsView);
        }

        // GET: Section/Create
        public ActionResult Create()
        {
            return View("AddSection");
        }

        // POST: Section/Create
        [HttpPost]
        public ActionResult Create(SectionViewModel section)
        {
            try
            {
                // TODO: Add insert logic here

                Section s = new Section();
                s.SectionName = section.SectionName;
                s.Batch = section.Batch;
                s.TotalStudents = 0;

                db.Sections.Add(s);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Section/Edit/5
        public ActionResult Edit(int id)
        {
            var S = db.Sections.First(c => c.SectionId == id);
            SectionViewModel section = new SectionViewModel();

            section.SectionId = S.SectionId;
            section.SectionName = S.SectionName;
            section.Batch = S.Batch;

            return View("EditSection", section);
        }

        // POST: Section/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SectionViewModel section)
        {
            try
            {
                // TODO: Add update logic here

                var model = db.Sections.First(c => c.SectionId == id);

                model.SectionName = section.SectionName;
                model.Batch = section.Batch;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Section/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Sections.First(c => c.SectionId == id);

            SectionViewModel section = new SectionViewModel();
            section.SectionId = model.SectionId;
            section.SectionName = model.SectionName;
            section.Batch = model.Batch;
            section.TotalStudents = model.TotalStudents ?? 0;



            return View(section);
        }

        // POST: Section/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var model = db.Sections.First(c => c.SectionId == id);

                db.Sections.Remove(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
