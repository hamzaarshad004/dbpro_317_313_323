using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class TimeTableController : Controller
    {
        DB45Entities db = new DB45Entities();
        // GET: TimeTable
        public ActionResult Index()
        {
            var Data = db.TimeTables.ToList();
            List<TimeTableViewModel> timetable = new List<TimeTableViewModel>();
            foreach(var t in Data)
            {
                TimeTableViewModel TB = new TimeTableViewModel();
                TB.SubjectId = t.SubjectId;
                TB.SectionId = t.SectionId;
                TB.Day = t.Day;
                TB.StartTime = t.StartTime;
                TB.EndTime = t.EndTime;

                timetable.Add(TB);
            }
            return View(timetable);
        }

        // GET: TimeTable/Details/5
        public ActionResult Details(int id)
        {
            var d = db.TimeTables.First(x => x.timetableId == id);
            TimeTableViewModel tb = new TimeTableViewModel();
            tb.Day = d.Day;
            tb.SectionId = d.SectionId;
            tb.StartTime = d.StartTime;
            tb.SubjectId = d.SubjectId;
            tb.EndTime = d.EndTime;
            return View(tb);
           
        }

        // GET: TimeTable/Create
        public ActionResult Create()
        {
            TimeTableViewModel model = new TimeTableViewModel();
            model.allSection = db.Sections.ToList();
            model.allSubject = db.Subjects.ToList();

            return View("AddTimeTable", model);
        }

        // POST: TimeTable/Create
        [HttpPost]
        public ActionResult Create(TimeTableViewModel timetable)
        {
            try
            {

                TimeTable tb = new TimeTable();
                 
                tb.Day = timetable.Day;
                tb.EndTime = timetable.EndTime;
                tb.SectionId = timetable.SectionId;
                tb.SubjectId = timetable.SubjectId;
                tb.StartTime = timetable.StartTime;
                db.TimeTables.Add(tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeTable/Edit/5
        public ActionResult Edit(int id)
        {
            var d = db.TimeTables.First(x => x.timetableId == id);
            TimeTableViewModel tb = new TimeTableViewModel();
            tb.EndTime = d.EndTime;
            tb.Day = d.Day;
            tb.SectionId = d.SectionId;
            tb.StartTime = d.StartTime;
            tb.SubjectId = d.SubjectId;
            return View(tb);
        }

        // POST: TimeTable/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TimeTableViewModel timetable)
        {
            try
            {
                var d = db.TimeTables.First(x => x.timetableId == id);
                d.SubjectId = timetable.SubjectId;
                d.StartTime = timetable.StartTime;
                d.SectionId = timetable.SectionId;
                d.Day = timetable.Day;
                d.EndTime = timetable.EndTime;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeTable/Delete/5
        public ActionResult Delete(int id)
        {
            var d = db.TimeTables.First(x => x.timetableId == id);
            TimeTableViewModel tb = new TimeTableViewModel();
            tb.Day = d.Day;
            tb.SectionId = d.SectionId;
            tb.StartTime = d.StartTime;
            tb.SubjectId = d.SubjectId;
            tb.EndTime = d.EndTime;
            return View(tb);
        }

        // POST: TimeTable/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var d = db.TimeTables.First(x => x.timetableId == id);
                db.TimeTables.Remove(d);
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
