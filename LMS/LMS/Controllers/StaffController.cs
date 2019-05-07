using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            DB45Entities db = new DB45Entities();
            List<StaffViewModel> staffs = new List<StaffViewModel>();
            var getData = db.People.Join(db.Staffs, p => p.PersonId, s => s.StaffId, (p, s) => new {Id = p.PersonId, Name =  p.Name, FName =  p. FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, Designation = s.Designation, HireDate = s.HireDate, Salary = s.MonthlySalary }).ToList();
            foreach(var g in getData)
            {
                StaffViewModel staff = new StaffViewModel();

                staff.PersonId = g.Id;
                staff.Name = g.Name;
                staff.FatherName = g.FName;
                staff.Address = g.Address;
                staff.Cnic = g.CNIC;
                staff.Gender = g.Gender;
                staff.ContactNo = g.Contact;

                staff.MonthlySalary = g.Salary;
                staff.HireDate = g.HireDate;
                staff.Designation = g.Designation;

                staffs.Add(staff);
            }
            return View(staffs);
        }

        // GET: Staff/Details/5
        /*public ActionResult Details(int id)
        {
            DB45Entities db = new DB45Entities();
            var get = db.People.Join(db.Staffs.Where(x => x.StaffId == id), p => p.PersonId, s => s.StaffId, (p, s) => new { Id = p.PersonId, Name = p.Name, FName = p.FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, Designation = s.Designation, HireDate = s.HireDate, Salary = s.MonthlySalary });
            StaffViewModel staff = new StaffViewModel();

            foreach (var g in get)
            {
                staff.PersonId = g.Id;
                staff.Name = g.Name;
                staff.FatherName = g.FName;
                staff.Address = g.Address;
                staff.Cnic = g.CNIC;
                staff.Gender = g.Gender;
                staff.ContactNo = g.Contact;

                staff.MonthlySalary = g.Salary;
                staff.HireDate = g.HireDate;
                staff.Designation = g.Designation;
            }

            return View(staff);
        }*/

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View("AddStaff");
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(StaffViewModel staff)
        {
            try
            {
                // TODO: Add insert logic here

                var db = new DB45Entities();

                Person P = new Person();
                P.Name = staff.Name;
                P.FatherName = staff.FatherName;
                P.Address = staff.Address;
                P.Cnic = staff.Cnic;
                P.Gender = staff.Gender;
                P.ContactNo = staff.ContactNo;

                db.People.Add(P);
                db.SaveChanges();

                int id = P.PersonId;

                Staff S = new Staff();

                S.StaffId = id;
                S.Designation = staff.Designation;
                S.HireDate = staff.HireDate;
                S.MonthlySalary = staff.MonthlySalary;

                db.Staffs.Add(S);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }

                return View("AddStaff");
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            DB45Entities db = new DB45Entities();
            var get = db.People.Join(db.Staffs.Where(x=>x.StaffId == id ), p => p.PersonId, s => s.StaffId, (p, s) => new { Id = p.PersonId, Name = p.Name, FName = p.FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, Designation = s.Designation, HireDate = s.HireDate, Salary = s.MonthlySalary });
            StaffViewModel staff = new StaffViewModel();
            
            foreach(var g in get)
            {
                staff.PersonId = g.Id;
                staff.Name = g.Name;
                staff.FatherName = g.FName;
                staff.Address = g.Address;
                staff.Cnic = g.CNIC;
                staff.Gender = g.Gender;
                staff.ContactNo = g.Contact;

                staff.MonthlySalary = g.Salary;
                staff.HireDate = g.HireDate;
                staff.Designation = g.Designation;
            }

            return View(staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StaffViewModel staff)
        {
            try
            {
                DB45Entities db = new DB45Entities();
                var P = db.People.First(c => c.PersonId == id);
                var S = db.Staffs.First(c => c.StaffId == id);

                P.Name = staff.Name;
                P.FatherName = staff.FatherName;
                P.Address = staff.Address;
                P.Cnic = staff.Cnic;
                P.Gender = staff.Gender;
                P.ContactNo = staff.ContactNo;
   
                db.SaveChanges();

                S.Designation = staff.Designation;
                S.HireDate = staff.HireDate;
                S.MonthlySalary = staff.MonthlySalary;

                db.SaveChanges();

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            DB45Entities db = new DB45Entities();
            var get = db.People.Join(db.Staffs.Where(x => x.StaffId == id), p => p.PersonId, s => s.StaffId, (p, s) => new { Id = p.PersonId, Name = p.Name, FName = p.FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, Designation = s.Designation, HireDate = s.HireDate, Salary = s.MonthlySalary });
            StaffViewModel staff = new StaffViewModel();

            foreach (var g in get)
            {
                staff.PersonId = g.Id;
                staff.Name = g.Name;
                staff.FatherName = g.FName;
                staff.Address = g.Address;
                staff.Cnic = g.CNIC;
                staff.Gender = g.Gender;
                staff.ContactNo = g.Contact;

                staff.MonthlySalary = g.Salary;
                staff.HireDate = g.HireDate;
                staff.Designation = g.Designation;
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DB45Entities db = new DB45Entities();

                var S = db.Staffs.First(c => c.StaffId == id);
                db.Staffs.Remove(S);
                db.SaveChanges();

                var P = db.People.First(c => c.PersonId == id);
                db.People.Remove(P);
                db.SaveChanges();

                

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult StaffSubject(int id)
        {
            try
            {
                var db = new DB45Entities();
                var data = db.Staffs.First(x => x.StaffId == id);
                CourseTeacherViewModel ctvm = new CourseTeacherViewModel();
                if ((data.Designation == "Lecturer" || data.Designation == "Professor" || data.Designation == "Assistant Professor" || data.Designation == "Associate Professor" || data.Designation == "Industrial"))
                {
                    //var c = db.Staffs.Where(x => x.StaffId == id && (x.Designation == "Lecturer" || x.Designation == "Professor" || x.Designation == "Assistant Professor" || x.Designation == "Associate Professor" || x.Designation == "Industrial"));


                    ctvm.StaffId = data.StaffId;

                    var sbj = db.Subjects.ToList();
                    ctvm.allsubjects = sbj;
                    SubjectList staffsubjectlist = new SubjectList();
                    staffsubjectlist.Subjects = db.Subjects;
                    //data.Subjects.Add();
                }
                //else
                //{
                //    TempData["msg"] = "<script>alert('Subjects Can only be added for teachers');</script>";
                //}

                return View("StaffSubject", ctvm);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Invalid  Entry');</script>";
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult StaffSubject(int id , SubjectList stsl)
        {
            try
            {
                // TODO: Add insert logic here

                var db = new DB45Entities();

                var s = db.Subjects.Where(c=>c.SubjectId == stsl.SubjectId);
               


                //SubjectList sa = new SubjectList();
                //sa.SubjectId = ctvm.SubjectId;


                //var S = db.Sections.Where(c => c.SectionId == model.SectionId).First();
                //S.TotalStudents = S.TotalStudents + 1;
                //S.Students.Add(db.Students.Where(c => c.StudentId == id).First());

                //db.SaveChanges();
                //StudentSubject asss = new StudentSubject();
                //asss.StudentId = assign.StudentId;
                //asss.SubjectId = assign.SubjectId;
                //db.StudentSubjects.Add(asss);
                //db.SaveChanges();



                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }

                return View("AddStaff");
            }
        }



        public ActionResult StaffAttendance()
        {
            StaffAttendanceModel model = new StaffAttendanceModel();
            DB45Entities db = new DB45Entities();
            var getData = db.People.Join(db.Staffs, p => p.PersonId, s => s.StaffId, (p, s) => new { Id = s.StaffId, Name = p.Name, Designation = s.Designation }).ToList();
            List<CheckBoxListItemStaff> StaffView = new List<CheckBoxListItemStaff>();
            foreach(var g in getData)
            {
                StaffView.Add(new CheckBoxListItemStaff()
                {
                    ID = g.Id,
                    Display = g.Name,
                    DisplayDesignation = g.Designation,
                    IsChecked = false
                });
            }
            model.Staffs = StaffView;
            return View(model);
        }

        [HttpPost]
        public ActionResult StaffAttendance(StaffAttendanceModel model)
        {
            int CurrentId = checkDateInDb(model.SelectedDate);
            var Staffs = model.Staffs;

            DB45Entities db = new DB45Entities();

            foreach (var S in Staffs)
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
                    DailyAttendanceStaff attendanceStaff = new DailyAttendanceStaff();
                    attendanceStaff.DateId = CurrentId;
                    attendanceStaff.StaffId = S.ID;
                    if (S.IsChecked)
                    {
                        attendanceStaff.AttendanceStatus = "Present";
                    }
                    else
                    {
                        attendanceStaff.AttendanceStatus = "Absent";
                    }
                    db.DailyAttendanceStaffs.Add(attendanceStaff);
                }


            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        int checkDateInDb(System.DateTime currentDate)
        {
            DB45Entities db = new DB45Entities();
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
