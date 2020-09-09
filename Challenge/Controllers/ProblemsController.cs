using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Challenge.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace Challenge.Controllers
{
    public class ProblemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public int challengeId;

        // GET: Problems
        public ActionResult Index(int id)
        {
            if (id != 0)
            {
                challengeId = id;
            }
            ViewBag.ChallengeId = id;
            ICollection<Problem> problems = db.Problems.Where(problem => problem.ChallengeFK != 0 && problem.ChallengeFK == id)
                                                        .Select(problem => problem).ToList();
            return View(problems);
        }

        // GET: Problems/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            problem.ChallengeFK = id2 ?? 0;
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // GET: Problems/Create
        public ActionResult Create(int id)
        {
            Problem problem = new Problem() { ChallengeFK = id };
            return View(problem);
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ChallengeFK")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                db.Problems.Add(problem);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = problem.ChallengeFK });
            }

            return View(problem);
        }

        // GET: Problems/Edit/5
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            problem.ChallengeFK = id2 ?? 0;
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ChallengeFK")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = problem.ChallengeFK });
            }
            return View(problem);
        }

        // GET: Problems/Delete/5
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            problem.ChallengeFK = id2 ?? 0;
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problem problem = db.Problems.Find(id);
            db.Problems.Remove(problem);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = problem.ChallengeFK });
        }

        // Add new view for uploading a photo and send the viewmodel for user and problem
        // There should be a button for that in details of problems or in the index file

        public ActionResult AddSolutionToProblem(Problem model)
        {
            if (User.Identity.IsAuthenticated && db.Challenges.Find(model.ChallengeFK).Participants.Contains(db.Users.Find(User.Identity.GetUserId())))
            {
                ProblemUserModel problemUserModel = new ProblemUserModel() { Problem = model, ProblemFK = model.Id, User = db.Users.Find(User.Identity.GetUserId()), UserFK = User.Identity.GetUserId() };
                return View(problemUserModel);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult AddSolutionToProblem(ProblemUserModel model)
        {
            if (model.Solution == null)
            {
                return HttpNotFound();
            }
            Problem problem = db.Problems.Find(model.ProblemFK);
            problem.ImageLinks.Add(model.Solution);
            db.Solutions.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = problem.ChallengeFK });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
