using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class ProgramController : Controller
    {
        DB45Entities db = new DB45Entities();
        // GET: Program
        public ActionResult Index()
        {

            var Data = db.Programs.ToList();
            List<ProgramViewModel> Programs = new List<ProgramViewModel>();
            foreach (var d in Data)
            {
                ProgramViewModel PM = new ProgramViewModel();
                PM.ProgramId = d.ProgramId;
                PM.Name = d.Name;
                PM.AdmissionEnd = d.AdmissionEnd;
                PM.AdmissionStart = d.AdmissionStart;
                PM.ClassesStart = d.ClassesStart;

                Programs.Add(PM);
            }
            return View(Programs);
        }

        // GET: Program/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Program/Create
        public ActionResult Create()
        {
            return View("AddProgram");
        }

        // POST: Program/Create
        [HttpPost]
        public ActionResult Create(ProgramViewModel program)
        {
            try
            {
                Program P = new Program();
                P.Name = program.Name;
                P.ClassesStart = program.ClassesStart;
                P.AdmissionEnd = program.AdmissionEnd;
                P.AdmissionStart = program.AdmissionStart;

                db.Programs.Add(P);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Program/Edit/5
        public ActionResult Edit(int id)
        {
            var d = db.Programs.First(x => x.ProgramId == id);
            ProgramViewModel PM = new ProgramViewModel();

            PM.ProgramId = d.ProgramId;
            PM.Name = d.Name;
            PM.AdmissionEnd = d.AdmissionEnd;
            PM.AdmissionStart = d.AdmissionStart;
            PM.ClassesStart = d.ClassesStart;


            return View("EditProgram",PM);
        }

        // POST: Program/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgramViewModel program)
        {
            try
            {
                // TODO: Add update logic here

                Program P = db.Programs.First(x => x.ProgramId == id);

                P.Name = program.Name;
                P.ClassesStart = program.ClassesStart;
                P.AdmissionEnd = program.AdmissionEnd;
                P.AdmissionStart = program.AdmissionStart;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Program/Delete/5
        public ActionResult Delete(int id)
        {
            var d = db.Programs.First(x => x.ProgramId == id);
            ProgramViewModel PM = new ProgramViewModel();

            PM.ProgramId = d.ProgramId;
            PM.Name = d.Name;
            PM.AdmissionEnd = d.AdmissionEnd;
            PM.AdmissionStart = d.AdmissionStart;
            PM.ClassesStart = d.ClassesStart;

            return View(PM);
        }

        // POST: Program/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var d = db.Programs.First(x => x.ProgramId == id);
                db.Programs.Remove(d);
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
