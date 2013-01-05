using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MM.Library.Entities;
using MM.Library.Collections;
using mmMVC.ViewModels;

namespace mmMVC.Controllers
{
    public class RenterController : Csla.Web.Mvc.Controller
    {
        //
        // GET: /Renter/
       
        public ActionResult Index()
        {

            var user = Csla.ApplicationContext.User;
            
            ViewData.Model = TenantInfoList.GetProjectList();
            return View();
        }

        //
        // GET: /Renter/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Renter/Create

        public ActionResult Create()
        {
            ViewData.Model = new RenterViewModel();

            
            return View();
        }

        //
        // POST: /Renter/Create

        [HttpPost]
        public ActionResult Create(RenterViewModel personedit)
        {

            var myContext = new Models.UsersContext();
            personedit.ModelObject.CreateUser = myContext.GetUserID(Csla.ApplicationContext.User.Identity.Name);
           
            
            if (personedit.Save(ModelState, false))
            {
                return RedirectToAction("Index", new { id = personedit.ModelObject.RenterID });
            }
            else
            {
                ViewData.Model = personedit;
                return View();
            }          
            
            
            
            //try
            //{
            //    if (SaveObject(personedit, false))
            //    return RedirectToAction("Index", new { id = personedit.RenterID });
            //else
            //    return View();
            //}
            //catch
            //{
            //    return View();
            //}
        }

        //
        // GET: /Renter/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData.Model = RenterAccountEdit.GetRenterAccountEdit(id);
            return View();
        }

        //
        // POST: /Renter/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Renter/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Renter/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
