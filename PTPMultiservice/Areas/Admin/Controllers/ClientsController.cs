using PTPMultiservice.Models;
using PTPMultiservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTPMultiservice.Areas.Admin.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        #region Client info
        public ActionResult Index()
        {
            try
            {
                var clients = _context.Clients.ToList();

                ClientViewModel viewModel = new ClientViewModel
                {
                    Clients = clients,
                    Regions = ManageDependancyData.GetRegions(),
                    Industries = ManageDependancyData.GetIndustryTypes(),
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult New()
        {
            ClientFormViewModel viewModel = new ClientFormViewModel
            {
                client_id = 0,
                Regions = ManageDependancyData.GetRegions(),
                Industries = ManageDependancyData.GetIndustryTypes(),
                Title = "New Client"
            };

            return View("ClientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ClientForm", viewModel);
            }

            if (viewModel.client_id == 0)
            {
                Client client = new Client
                {
                    client_name = viewModel.client_name,
                    region_id = viewModel.region_id,
                    branch = viewModel.branch,
                    industry_id = viewModel.industry_id,
                    site_address = viewModel.site_address,
                    corporate_office_address = viewModel.corporate_office_address,
                    remarks = viewModel.remarks,
                    is_active = true,
                    created_on = DateTime.Now
                };

                _context.Clients.Add(client);
            }
            else
            {
                Client clientInDb = _context.Clients.Where(x => x.client_id == viewModel.client_id).FirstOrDefault();

                if (clientInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("ClientForm", viewModel);
                }

                clientInDb.client_name = viewModel.client_name;
                clientInDb.region_id = viewModel.region_id;
                clientInDb.branch = viewModel.branch;
                clientInDb.industry_id = viewModel.industry_id;
                clientInDb.site_address = viewModel.site_address;
                clientInDb.corporate_office_address = viewModel.corporate_office_address;
                clientInDb.remarks = viewModel.remarks;

                _context.Entry(clientInDb).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Client clientInDb = _context.Clients.Where(x => x.client_id == id).FirstOrDefault();

            if (clientInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientForm", clientInDb);
            }

            ClientFormViewModel viewModel = new ClientFormViewModel
            {
                client_id = clientInDb.client_id,
                client_name = clientInDb.client_name,
                Regions = ManageDependancyData.GetRegions(),
                Industries = ManageDependancyData.GetIndustryTypes(),
                branch = clientInDb.branch,
                region_id = clientInDb.region_id,
                industry_id = clientInDb.region_id,
                site_address = clientInDb.site_address,
                remarks = clientInDb.remarks,
                corporate_office_address = clientInDb.corporate_office_address,
                Title = "Edit Client"
            };

            return View("ClientForm", viewModel);
        }

        public ActionResult ToggleStatus(int id)
        {
            Client clientInDb = _context.Clients.Where(x => x.client_id == id).FirstOrDefault();

            if (clientInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientForm", clientInDb);
            }

            if (clientInDb.is_active)
                clientInDb.is_active = false;
            else
                clientInDb.is_active = true;

            _context.Entry(clientInDb).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Client clientInDb = _context.Clients.Where(x => x.client_id == id).FirstOrDefault();

            if (clientInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientForm", clientInDb);
            }

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Client clientInDb = _context.Clients.Where(x => x.client_id == id).FirstOrDefault();

            if (clientInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientForm", clientInDb);
            }

            ClientFormViewModel viewModel = new ClientFormViewModel
            {
                client_id = clientInDb.client_id,
                client_name = clientInDb.client_name,
                Regions = ManageDependancyData.GetRegions(),
                Industries = ManageDependancyData.GetIndustryTypes(),
                branch = clientInDb.branch,
                region_id = clientInDb.region_id,
                industry_id = clientInDb.region_id,
                site_address = clientInDb.site_address,
                remarks = clientInDb.remarks,
                corporate_office_address = clientInDb.corporate_office_address,
                Title = "Client Details"
            };

            return View("ClientForm", viewModel);
        }
        #endregion
    }
}