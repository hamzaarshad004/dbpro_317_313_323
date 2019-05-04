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
                return View("AddSection");
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

        [HttpGet]
        public ActionResult StudentAttendance(int id)
        {
            StudentAttendanceModel attendance = new StudentAttendanceModel();
            var Students = db.Students.ToList();
            var Section = db.Sections.First(c => c.SectionId == id);
            var StudentsInSection = Section.Students;
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (Student S in StudentsInSection)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = S.StudentId,
                    Display = S.RollNo,
                    IsChecked = false 
                });
            }
            attendance.Students = checkBoxListItems;
            return View(attendance);
        }

        [HttpPost]
        public ActionResult StudentAttendance(StudentAttendanceModel model)
        {
            int CurrentId = checkDateInDb(model.SelectedDate);
            var Students = model.Students;

            

            foreach(var S in Students)
            {
                var checkMarked = db.DailyAttendanceStudents.Where(c => c.StudentId == S.ID && c.DateId == CurrentId).FirstOrDefault();
                if (checkMarked != null)
                {
                    if (S.IsChecked)
                    {
                        checkMarked.AttendanceStatus = "Present";
                    }
                    else
                    {
                        checkMarked.AttendanceStatus = "Absent";
                    }
                    db.SaveChanges();
                }
                else
                {
                    DailyAttendanceStudent attendanceStudent = new DailyAttendanceStudent();
                    StudentFine fine = new StudentFine();
                    attendanceStudent.DateId = CurrentId;
                    attendanceStudent.StudentId = S.ID;
                    if (S.IsChecked)
                    {
                        attendanceStudent.AttendanceStatus = "Present";
                    }
                    else
                    {
                        attendanceStudent.AttendanceStatus = "Absent";
                    }
                    db.DailyAttendanceStudents.Add(attendanceStudent);
                }

               
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        int checkDateInDb(System.DateTime currentDate)
        {
            var check = db.DateKeepers.FirstOrDefault(c => c.CurrentDate == currentDate);
            if (check != null)
            {
                return check.Id;
            }
            else
            {
                DateKeeper date = new DateKeeper();
                date.CurrentDate = currentDate;
                db.DateKeepers.Add(date);
                db.SaveChanges();

                return date.Id;
            }

        }
    }
}
