using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class ExamController : Controller
    {
        DB45Entities db = new DB45Entities();
        // GET: Exam
        public ActionResult Index()
        {
            var TotalExams = db.Exams.ToList();
            List<ExamViewModel> models = new List<ExamViewModel>();

            foreach (var TE in TotalExams)
            {
                ExamViewModel model = new ExamViewModel();
                model.ExamId = TE.ExamId;
                model.Name = TE.Name;

                models.Add(model);
            }

            return View(models);
        }

        public ActionResult Create()
        {
            return View("Add_EditExam");
        }

        [HttpPost]
        public ActionResult Create(ExamViewModel model)
        {
            try
            {
                var check = db.Exams.ToList();
                foreach (var c in check)
                {
                    if (c.Name == model.Name)
                    {
                        return RedirectToAction("Index");
                    }
                }

                Exam exam = new Exam();
                exam.Name = model.Name;
                db.Exams.Add(exam);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var exam = db.Exams.FirstOrDefault(c => c.ExamId == id);
            ExamViewModel model = new ExamViewModel();
            model.ExamId = exam.ExamId;
            model.Name = exam.Name;

            return View("Add_EditExam", model);
        }

        [HttpPost]
        public ActionResult Edit(int id, ExamViewModel model)
        {
            var check = db.Exams.ToList();
            foreach (var c in check)
            {
                if (c.Name == model.Name)
                {
                    return RedirectToAction("Index");
                }
            }

            var exam = db.Exams.FirstOrDefault(c => c.ExamId == id);
            exam.Name = model.Name;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var Result = db.Results.Where(c => c.ExamId == id).ToList();
            foreach (var R in Result)
            {
                db.Results.Remove(R);
            }

            var SubjectExams = db.ExamBySubjects.Where(c => c.ExamId == id).ToList();
            foreach (var SE in SubjectExams)
            {
                db.ExamBySubjects.Remove(SE);
            }

            var exam = db.Exams.FirstOrDefault(c => c.ExamId == id);
            db.Exams.Remove(exam);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DateSheetIndex(int id)
        {
            var getExams = (from e in db.ExamBySubjects
                            join eId in db.Exams on e.ExamId equals eId.ExamId
                            join s in db.Subjects on e.SubjectId equals s.SubjectId
                            where eId.ExamId == id
                            select new
                            {
                                ExamIdent = e.ExamId,
                                SubjectIdent = e.SubjectId,
                                ExamName = eId.Name,
                                SubjectName = s.SubjectName,
                                StartTime = e.StartDateTime,
                                EndTime = e.EndTime,
                                Marks = e.TotalMarks
                            }).ToList();

            List<ExamSubjectsViewModel> models = new List<ExamSubjectsViewModel>();
            foreach (var g in getExams)
            {
                ExamSubjectsViewModel model = new ExamSubjectsViewModel();
                model.ExamId = g.ExamIdent;
                model.SubjectId = g.SubjectIdent;
                model.SubjectName = g.SubjectName;
                model.ExamName = g.ExamName;
                model.StartDateTime = g.StartTime;
                model.EndTime = g.EndTime;
                model.TotalMarks = g.Marks;

                models.Add(model);
            }

            ViewBag.ExamId = id;

            return View(models);
        }


        public ActionResult AddDateSheet(int id)
        {
            ExamSubjectsViewModel model = new ExamSubjectsViewModel();
            model.ExamId = id;
            model.ExamNames = db.Exams.ToList();
            model.SubjectNames = db.Subjects.ToList();

            return View("AddDateSheet", model);
        }

        [HttpPost]
        public ActionResult AddDateSheet(ExamSubjectsViewModel model)
        {
            try
            {
                var Programs = db.Subjects.FirstOrDefault(c => c.SubjectId == model.SubjectId);
                int ProgramId = Programs.ProgramId;

                var Subjects = db.Subjects.Where(c => c.ProgramId == ProgramId).ToList();

                List<int> Ids = Subjects.Select(s => s.SubjectId).ToList();

                var ExamSubjects = db.ExamBySubjects.Where(i => Ids.Contains(i.SubjectId) && i.ExamId == model.ExamId);

                foreach (var E in ExamSubjects)
                {
                    if (E.StartDateTime == model.StartDateTime)
                    {
                        return RedirectToAction("DateSheetIndex");
                    }
                }

                ExamBySubject exam = new ExamBySubject();
                exam.SubjectId = model.SubjectId;
                exam.ExamId = model.ExamId;
                exam.StartDateTime = model.StartDateTime;
                exam.EndTime = model.EndTime;
                exam.TotalMarks = model.TotalMarks;

                db.ExamBySubjects.Add(exam);
                db.SaveChanges();

                return RedirectToAction("DateSheetIndex", new { id = model.ExamId});
            }
            catch
            {
                return RedirectToAction("DateSheetIndex", new { id = model.ExamId });
            }
        }

        public ActionResult EditDateSheet(int ExamId, int SubjectId)
        {
            var getData = db.ExamBySubjects.Where(c => c.ExamId == ExamId && c.SubjectId == SubjectId).FirstOrDefault();
            var getExamName = db.Exams.FirstOrDefault(c => c.ExamId == ExamId);
            var getSubjectName = db.Subjects.FirstOrDefault(c => c.SubjectId == SubjectId);

            ExamSubjectsViewModel model = new ExamSubjectsViewModel();

            model.ExamName = getExamName.Name;
            model.SubjectName = getSubjectName.SubjectName;

            model.ExamId = ExamId;
            model.SubjectId = SubjectId;
            model.StartDateTime = getData.StartDateTime;
            model.EndTime = getData.EndTime;
            model.TotalMarks = getData.TotalMarks;

            return View("EditDateSheet", model);
        }

        [HttpPost]
        public ActionResult EditDateSheet(int ExamId, int SubjectId, ExamSubjectsViewModel model)
        {
            try
            {
                var Programs = db.Subjects.FirstOrDefault(c => c.SubjectId == model.SubjectId);
                int ProgramId = Programs.ProgramId;

                var Subjects = db.Subjects.Where(c => c.ProgramId == ProgramId).ToList();

                List<int> Ids = Subjects.Select(s => s.SubjectId).ToList();

                var ExamSubjects = db.ExamBySubjects.Where(i => Ids.Contains(i.SubjectId) && i.ExamId == model.ExamId);

               

                var getData = db.ExamBySubjects.Where(c => c.ExamId == ExamId && c.SubjectId == SubjectId).FirstOrDefault();
                getData.TotalMarks = model.TotalMarks;
                getData.StartDateTime = model.StartDateTime;
                getData.EndTime = model.EndTime;

                db.SaveChanges();

                return RedirectToAction("DateSheetIndex", new { id = ExamId });
            }
            catch
            {
                return RedirectToAction("DateSheetIndex", new { id = ExamId });
            }
        }

        public ActionResult DeleteDateSheet(int ExamId, int SubjectId)
        {
            var getData = db.ExamBySubjects.Where(c => c.ExamId == ExamId && c.SubjectId == SubjectId).FirstOrDefault();
            var getResultData = db.Results.Where(c => c.ExamId == ExamId && c.SubjectId == SubjectId).ToList();

            foreach (var g in getResultData)
            {
                db.Results.Remove(g);
            }

            db.ExamBySubjects.Remove(getData);

            db.SaveChanges();

            return RedirectToAction("DateSheetIndex", new { id = ExamId });
        }
    }
}
