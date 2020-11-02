using PTPMultiservice.Models;
using PTPMultiservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTPMultiservice.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexProcess(AdminFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Invalid Credentials, Try Again.");
                    return View("Index", model);
                }

                var admin = _context.Admins.FirstOrDefault(a => a.email.Trim().ToLower() == model.email.Trim().ToLower() &&
                                                                a.password.Trim().ToLower() == model.password.Trim().ToLower());

                if (admin == null)
                {
                    ModelState.AddModelError("", "Invalid Credentials, Try Again.");
                    return View("Index", model);
                }

                Session["AdminId"] = admin.admin_id;
                Session["AdminEmail"] = admin.email;

                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {

            }

            return View("Index", model);
        }
    }
}