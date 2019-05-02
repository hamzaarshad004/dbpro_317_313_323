﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class StudentController : Controller
    {

        DB45Entities db = new DB45Entities();
        // GET: Student
        public ActionResult Index()
        {
            var Students = db.People.Join(db.Students, p => p.PersonId, s => s.StudentId, (p, s) => new { Id = p.PersonId, Name = p.Name, FName = p.FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, rollNo = s.RollNo, admDate = s.AdmissionDate, batch = s.Batch, fee = s.MonthlyFee, programId = s.ProgramId }).ToList();

            List<StudentViewModel> students = new List<StudentViewModel>();

            foreach (var S in Students)
            {
                StudentViewModel student = new StudentViewModel();
                student.PersonId = S.Id;
                student.Name = S.Name;
                student.FatherName = S.FName;
                student.Address = S.Address;
                student.Cnic = S.CNIC;
                student.Gender = S.Gender;
                student.ContactNo = S.Contact;

                student.RollNo = S.rollNo;
                student.AdmissionDate = S.admDate;
                student.Batch = S.batch;
                student.MonthlyFee = S.fee;
                student.ProgramId = S.programId;
                student.SectionAssigned = student.checkAssigned(S.Id);

                students.Add(student);
            }
            

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var Student = db.People.Join(db.Students.Where(x=>x.StudentId == id), p => p.PersonId, s => s.StudentId, (p, s) => new { Id = p.PersonId, Name = p.Name, FName = p.FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, rollNo = s.RollNo, admDate = s.AdmissionDate, batch = s.Batch, fee = s.MonthlyFee, programId = s.ProgramId });

            StudentViewModel student = new StudentViewModel();

            foreach (var S in Student)
            {
                student.PersonId = id;
                student.Name = S.Name;
                student.FatherName = S.FName;
                student.Address = S.Address;
                student.Cnic = S.CNIC;
                student.Gender = S.Gender;
                student.ContactNo = S.Contact;

                student.RollNo = S.rollNo;
                student.AdmissionDate = S.admDate;
                student.Batch = S.batch;
                student.MonthlyFee = S.fee;
                student.ProgramId = S.programId;

            }

            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            StudentViewModel model = new StudentViewModel();
            model.Programs = db.Programs.ToList();
            return View("AddStudent", model);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            try
            {
                // TODO: Add insert logic here

                Person P = new Person();
                P.Name = student.Name;
                P.FatherName = student.FatherName;
                P.Address = student.Address;
                P.Cnic = student.Cnic;
                P.Gender = student.Gender;
                P.ContactNo = student.ContactNo;

                db.People.Add(P);
                db.SaveChanges();

                Student S = new Student();

                int id = P.PersonId;

                S.StudentId = id;
                S.RollNo = student.RollNo;
                S.AdmissionDate = student.AdmissionDate;
                S.Batch = student.Batch;
                S.MonthlyFee = student.MonthlyFee;
                S.ProgramId = student.ProgramId;

                db.Students.Add(S);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var Student = db.People.Join(db.Students.Where(x => x.StudentId == id), p => p.PersonId, s => s.StudentId, (p, s) => new { Id = p.PersonId, Name = p.Name, FName = p.FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, rollNo = s.RollNo, admDate = s.AdmissionDate, batch = s.Batch, fee = s.MonthlyFee, programId = s.ProgramId });

            StudentViewModel student = new StudentViewModel();

            foreach (var S in Student)
            {
                student.PersonId = id;
                student.Name = S.Name;
                student.FatherName = S.FName;
                student.Address = S.Address;
                student.Cnic = S.CNIC;
                student.Gender = S.Gender;
                student.ContactNo = S.Contact;

                student.RollNo = S.rollNo;
                student.AdmissionDate = S.admDate;
                student.Batch = S.batch;
                student.MonthlyFee = S.fee;
                student.ProgramId = S.programId;

            }

            return View("EditStudent",student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentViewModel student)
        {
            try
            {
                // TODO: Add update logic here

                DB45Entities db = new DB45Entities();
                var S = db.Students.First(c => c.StudentId == id);

                S.RollNo = student.RollNo;
                S.Batch = student.Batch;
                S.MonthlyFee = student.MonthlyFee;

                db.SaveChanges();

                var P = db.People.First(c => c.PersonId == id);

                P.Name = student.Name;
                P.FatherName = student.FatherName;
                P.Address = student.Address;
                P.Cnic = student.Cnic;
                P.Gender = student.Gender;
                P.ContactNo = student.ContactNo;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditStudent");
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var Student = db.People.Join(db.Students.Where(x => x.StudentId == id), p => p.PersonId, s => s.StudentId, (p, s) => new { Id = p.PersonId, Name = p.Name, FName = p.FatherName, Address = p.Address, CNIC = p.Cnic, Contact = p.ContactNo, Gender = p.Gender, rollNo = s.RollNo, admDate = s.AdmissionDate, batch = s.Batch, fee = s.MonthlyFee, programId = s.ProgramId });

            StudentViewModel student = new StudentViewModel();

            foreach (var S in Student)
            {
                student.PersonId = id;
                student.Name = S.Name;
                student.FatherName = S.FName;
                student.Address = S.Address;
                student.Cnic = S.CNIC;
                student.Gender = S.Gender;
                student.ContactNo = S.Contact;

                student.RollNo = S.rollNo;
                student.AdmissionDate = S.admDate;
                student.Batch = S.batch;
                student.MonthlyFee = S.fee;
                student.ProgramId = S.programId;

            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var S = db.Students.First(c => c.StudentId == id);
                db.Students.Remove(S);
                db.SaveChanges();

                var P = db.People.First(c => c.PersonId == id);
                db.People.Remove(P);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AssignSection(int id)
        {
            SectionsList list = new SectionsList();
            Student student = db.Students.Where(c => c.StudentId == id).First();
            int batch = student.Batch;
            list.Sections = db.Sections.Where(c => c.Batch == batch);
            return View(list);
        }

        [HttpPost]
        public ActionResult AssignSection(int id, SectionsList model)
        {
            var S = db.Sections.Where(c => c.SectionId == model.SectionId).First();
            S.TotalStudents = S.TotalStudents + 1;
            S.Students.Add(db.Students.Where(c => c.StudentId == id).First());
           
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
