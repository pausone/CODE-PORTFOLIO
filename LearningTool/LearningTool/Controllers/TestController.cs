using LearningTool.Models;
using LearningTool.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LearningTool.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext _context;

        public TestController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Test test = _context.Tests.Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            var QuestionsList = new List<QuestionAndAnswer>();

            QuestionsList.AddRange(_context.QuestionAndAnswers.Where(g => g.TestId == id));

            var testVM = new TestDetailsViewModel
            {
                TestId = id.Value,
                TestSubject = test.Subject,
                Questions = QuestionsList
            };


            return View(testVM);
        }

        [Authorize]
        public ActionResult TestMode(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Test test = _context.Tests.Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            var QuestionsList = new List<QuestionAndAnswer>();

            QuestionsList.AddRange(_context.QuestionAndAnswers.Where(g => g.TestId == id));

            var testVM = new TestDetailsViewModel
            {
                TestId = id.Value,
                TestSubject = test.Subject,
                Questions = QuestionsList
            };


            return View(testVM);
        }

        [Authorize]
        public ActionResult CreateTest()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTest(TestFormViewModel testModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateTest", testModel);
            }

            var test = new Test
            {
                UserId = User.Identity.GetUserId(),
                Subject = testModel.Subject
            };

            _context.Tests.Add(test);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult AddQuestion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QnAFormViewModel QnA = new QnAFormViewModel();

            QnA.TestId = id.Value;

            return View(QnA);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestion([Bind(Include = "TestId,Question,Answer,Hint,Mnemonic")]QnAFormViewModel QnAModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddQuestion", QnAModel);
            }

            var QnA = new QuestionAndAnswer
            {
                TestId = QnAModel.TestId,
                Question = QnAModel.Question,
                Answer = QnAModel.Answer,
                Hint = QnAModel.Hint,
                Mnemonic = QnAModel.Mnemonic
            };

            _context.QuestionAndAnswers.Add(QnA);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = QnA.TestId });
        }
        
        [Authorize]
        public ActionResult EditTestSubject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Test test = _context.Tests.Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            return View(test);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTestSubject([Bind(Include = "Id,User,UserId,Subject,Questions")]Test test)
        {
            if (!ModelState.IsValid)
            {
                return View("EditTestSubject", test);
            }

            _context.Entry(test).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = test.Id });

        }

        [Authorize]
        public ActionResult EditQuestion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuestionAndAnswer QnA = _context.QuestionAndAnswers.Find(id);

            if (QnA == null)
            {
                return HttpNotFound();
            }

            return View(QnA);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQuestion([Bind(Include = "Id,TestId,Question,Answer,Hint,Mnemonic")]QuestionAndAnswer QnA)
        {
            if (!ModelState.IsValid)
            {
                return View("EditQuestion", QnA);
            }

            _context.Entry(QnA).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = QnA.TestId });
        
        }

        [Authorize]
        public ActionResult DeleteQuestion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuestionAndAnswer QnA = _context.QuestionAndAnswers.Find(id);

            if (QnA == null)
            {
                return HttpNotFound();
            }

            return View(QnA);
        }

        [Authorize]
        [HttpPost, ActionName("DeleteQuestion")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {

            QuestionAndAnswer QnA = _context.QuestionAndAnswers.Find(id);
            _context.QuestionAndAnswers.Remove(QnA);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = QnA.TestId });
        }

        [Authorize]
        public ActionResult DeleteTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Test test = _context.Tests.Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            var QuestionsList = new List<QuestionAndAnswer>();

            QuestionsList.AddRange(_context.QuestionAndAnswers.Where(g => g.TestId == id));

            var testVM = new TestDetailsViewModel
            {
                TestId = id.Value,
                TestSubject = test.Subject,
                Questions = QuestionsList
            };

            return View(testVM);
        }

        [Authorize]
        [HttpPost, ActionName("DeleteTest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTestConfirmed(int? id)
        {

            Test test = _context.Tests.Find(id);
            _context.Tests.Remove(test);
            //FIXA!!
            //QuestionAndAnswer QnA = _context.QuestionAndAnswers.Find(id);

            var QuestionsList = new List<QuestionAndAnswer>();

            QuestionsList.AddRange(_context.QuestionAndAnswers.Where(g => g.TestId == id));

            if (QuestionsList != null)
            {
                _context.QuestionAndAnswers.RemoveRange(_context.QuestionAndAnswers.Where(g => g.TestId == id));
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}