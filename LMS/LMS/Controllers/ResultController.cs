using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class ResultController : Controller
    {
        DB45Entities db = new DB45Entities();
        // GET: Result
        public ActionResult Index(int id)
        {
            var getData = (from r in db.Results
                           join s in db.Subjects
                           on r.SubjectId equals s.SubjectId
                           join exam in db.Exams
                           on r.ExamId equals exam.ExamId
                           where r.StudentId == id
                           select new
                           {
                               subjectId = s.SubjectId,
                               subjectName = s.SubjectName,
                               examId = exam.ExamId,
                               examName = exam.Name,
                               studentId = id,
                               marks = r.ObtainedMarks
                           }).ToList();

            List<ResultViewModel> models = new List<ResultViewModel>();

            foreach (var g in getData)
            {
                ResultViewModel model = new ResultViewModel();
                model.ExamId = g.examId;
                model.ExamName = g.examName;
                model.StudentId = g.studentId;
                model.SubjectId = g.subjectId;
                model.SubjectName = g.subjectName;
                model.ObtainedMarks = g.marks;

                models.Add(model);
            }
            ViewBag.id = id;
            return View(models);
        }

        public ActionResult AddResult(int id)
        {
            ResultViewModel model = new ResultViewModel();
            model.StudentId = id;
            model.ExamNames = db.Exams.ToList();
            var getData = (from e in db.StudentSubjects
                           join s in db.Subjects
                           on e.SubjectId equals s.SubjectId
                           where e.StudentId == id
                           select new
                           {
                               subjectId = e.SubjectId,
                               subjectName = s.SubjectName
                           }).ToList();

            List<Subject> subjects = new List<Subject>();
            var examSubjects = db.ExamBySubjects.ToList();
            List<int> ids = examSubjects.Select(c => c.SubjectId).ToList();
            var get = getData.Where(i => ids.Contains(i.subjectId));

            foreach (var g in get)
            {
                Subject S = new Subject();
                S.SubjectId = g.subjectId;
                S.SubjectName = g.subjectName;

                subjects.Add(S);
            }

            model.SubjectNames = subjects;
            return View("AddResult", model);
        }

        [HttpPost]
        public ActionResult AddResult(int id, ResultViewModel model)
        {
            var getResults = db.Results.ToList();
            foreach (var g in getResults)
            {
                if (g.ExamId == model.ExamId && g.StudentId == model.StudentId && g.SubjectId == model.SubjectId)
                {
                    return RedirectToAction("Index", id);
                }
            }

            Result result = new Result();
            result.ExamId = model.ExamId;
            result.SubjectId = model.SubjectId;
            result.StudentId = id;
            result.ObtainedMarks = model.ObtainedMarks;

            db.Results.Add(result);
            db.SaveChanges();
            return RedirectToAction("Index", id);
        }

        public ActionResult EditResult(int ExamId, int SubjectId, int StudentId)
        {
            var getData = db.Results.Where(c => c.ExamId == ExamId && c.StudentId == StudentId && c.SubjectId == SubjectId).FirstOrDefault();
            var ExamName = db.Exams.FirstOrDefault(c => c.ExamId == ExamId);
            var SubjectName = db.Subjects.FirstOrDefault(c => c.SubjectId == SubjectId);

            ResultViewModel model = new ResultViewModel();
            model.ExamId = ExamId;
            model.StudentId = StudentId;
            model.SubjectId = SubjectId;
            model.ObtainedMarks = getData.ObtainedMarks;
            model.SubjectName = SubjectName.SubjectName;
            model.ExamName = ExamName.Name;

            return View("EditResult", model);
        }

        [HttpPost]
        public ActionResult EditResult(int ExamId, int SubjectId, int StudentId, ResultViewModel model)
        {
            var getResults = db.Results.ToList();


            var getData = db.Results.Where(c => c.ExamId == ExamId && c.StudentId == StudentId && c.SubjectId == SubjectId).FirstOrDefault();
            getData.ObtainedMarks = model.ObtainedMarks;
            db.SaveChanges();

            return RedirectToAction("Index", StudentId);
        }

        public ActionResult Delete(int ExamId, int SubjectId, int StudentId)
        {
            var getData = db.Results.Where(c => c.ExamId == ExamId && c.StudentId == StudentId && c.SubjectId == SubjectId).FirstOrDefault();
            db.Results.Remove(getData);
            db.SaveChanges();
            return RedirectToAction("Index", StudentId);
        }

    }
}