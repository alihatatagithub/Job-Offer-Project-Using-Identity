using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_AmarPC.Models;

namespace Test_AmarPC.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Result()
        {
            return View();
        }

        public ActionResult Detials(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = job.Id;
            return View(job);
            
        }
        
        public ActionResult Apply()
        {

            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Apply(string _Message)

        {
            string _UserId = User.Identity.GetUserId();
            int _jobId = int.Parse(Session["JobId"].ToString());
           
            var check = db.ApplyForJobs.Where(a => a.JobId == _jobId && a.UserId == _UserId).ToList();
            if (check.Count<1)
            {
                ApplyForJob NewJobApplyer = new ApplyForJob() { UserId = _UserId, Message = _Message, JobId = _jobId, ApplyDate = DateTime.Now };
                db.ApplyForJobs.Add(NewJobApplyer);
                db.SaveChanges();
                ViewBag.result = "You Are Applied SuccessFully";

            }
            else
                ViewBag.result = "Sorry You Are Already Applied For This Job";




            return RedirectToAction("Result");
        }
        [Authorize]
        public ActionResult GetJobByUserId()
        {
            string UserId = User.Identity.GetUserId();
            var jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
            return View(jobs.ToList());
        }
        [Authorize]
        public ActionResult GetJobByPuplisher()
        {
            string UserId = User.Identity.GetUserId();
            var jobs = from apply in db.ApplyForJobs
                       join job in db.Jobs
                       on apply.JobId equals job.Id
                       where job.User.Id ==UserId
                       select apply;
            return View(jobs.ToList());
        }

        public ActionResult DetailsOfJos(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = job.Id;
            return View(job);

        }

        // GET: DashBoard/Category/Edit/5
        public ActionResult EditOfJos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplyForJob job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: DashBoard/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOfJos(ApplyForJob Apply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Apply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobByUserId");
            }
            return View(Apply);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplyForJob job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: DashBoard/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplyForJob job = db.ApplyForJobs.Find(id);
            db.ApplyForJobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Jobs.Where(a => a.JobTitle.Contains(searchName)
            || a.JobContent.Contains(searchName)
            || a.Category.CategoryName.Contains(searchName)
            || a.Category.CategoryDescription.Contains(searchName)).ToList();
            return View(result);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}