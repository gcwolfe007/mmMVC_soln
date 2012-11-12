using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MM.Library.Entities;


namespace mmMVC.Controllers
{
    public class TenantController : Csla.Web.Mvc.Controller
    {
        //
        // GET: /Tenant/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tenant/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tenant/Create

        public ActionResult Create()
        {
            ViewData.Model = RenterAccountEdit.NewRenterAccountEdit();
            return View();
        }

        //
        // POST: /Tenant/Create

        [HttpPost]
        public ActionResult Create(RenterAccountEdit renterAccount)
        {
            if (SaveObject(renterAccount, false))
                return RedirectToAction("Index", new { id = renterAccount.RenterAccountID });
            else
                return View();
        }

        //
        // GET: /Tenant/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tenant/Edit/5

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
        // GET: /Tenant/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tenant/Delete/5

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
