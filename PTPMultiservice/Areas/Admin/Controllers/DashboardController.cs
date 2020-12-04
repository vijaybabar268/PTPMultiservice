using PTPMultiservice.Models;
using PTPMultiservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTPMultiservice.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                Partners = _context.Partners.ToList(),
                Clients = _context.Clients.ToList(),
                Employees = _context.Employees.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.RemoveAll();

            return RedirectToAction("Index", "Login");
        }
    }
}