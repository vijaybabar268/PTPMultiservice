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
                    ClientContactDetails = _context.ClientContactDetails.ToList(),
                    ClientRelations = _context.ClientRelations.ToList()
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

        #region Manage Client Contacts
        public ActionResult ClientContactsIndex(int client_id)
        {
            try
            {
                List<ClientContactDetail> clientContacts = _context.ClientContactDetails.Where(d => d.client_id == client_id).ToList();

                ClientContactViewModel viewModel = new ClientContactViewModel
                {
                    ClientContactDetails = clientContacts,
                    Departments = ManageDependancyData.GetDepartments(),
                    Designations = ManageDependancyData.GetDesignations(),
                    ManagementLevels = ManageDependancyData.GetManagementLevels()
                };

                Session["ClientId"] = client_id;

                var client = _context.Clients.FirstOrDefault(p => p.client_id == client_id);
                ViewBag.Title = "Manage Contacts For " + client.client_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult ClientContactsNew()
        {
            ClientContactFormViewModel viewModel = new ClientContactFormViewModel
            {
                Title = "Add Client Contact",
                Departments = ManageDependancyData.GetDepartments(),
                Designations = ManageDependancyData.GetDesignations(),
                ManagementLevels = ManageDependancyData.GetManagementLevels()
            };

            return View("ClientContactForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientContactsSave(ClientContactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ClientContactForm", viewModel);
            }

            if (viewModel.contact_id == 0)
            {
                ClientContactDetail clientContactDetail = new ClientContactDetail
                {
                    contact_name = viewModel.contact_name,
                    designation_id = viewModel.designation_id,
                    management_level_id = viewModel.management_level_id,
                    department_id = viewModel.department_id,
                    reporting_manager = viewModel.reporting_manager,
                    birthdate = viewModel.birthdate,
                    email_id = viewModel.email_id,
                    mobile_no = viewModel.mobile_no,
                    tel_no = viewModel.tel_no,
                    client_id = int.Parse(Session["ClientId"].ToString())
                };

                _context.ClientContactDetails.Add(clientContactDetail);
                _context.SaveChanges();
            }
            else
            {
                ClientContactDetail clientContactInDb = _context.ClientContactDetails.Where(x => x.contact_id == viewModel.contact_id).FirstOrDefault();

                if (clientContactInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("ClientContactForm", viewModel);
                }

                clientContactInDb.contact_id = viewModel.contact_id;
                clientContactInDb.contact_name = viewModel.contact_name;
                clientContactInDb.designation_id = viewModel.designation_id;
                clientContactInDb.management_level_id = viewModel.management_level_id;
                clientContactInDb.department_id = viewModel.department_id;
                clientContactInDb.reporting_manager = viewModel.reporting_manager;
                clientContactInDb.birthdate = viewModel.birthdate;
                clientContactInDb.email_id = viewModel.email_id;
                clientContactInDb.mobile_no = viewModel.mobile_no;
                clientContactInDb.tel_no = viewModel.tel_no;

                _context.Entry(clientContactInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("ClientContactsIndex",
                new { client_id = int.Parse(Session["ClientId"].ToString()) });
        }

        public ActionResult ClientContactsEdit(int id)
        {
            ClientContactDetail clientInDb = _context.ClientContactDetails.Where(x => x.contact_id == id).FirstOrDefault();

            if (clientInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientContactForm", clientInDb);
            }

            ClientContactFormViewModel viewModel = new ClientContactFormViewModel
            {
                contact_id = clientInDb.contact_id,
                contact_name = clientInDb.contact_name,
                designation_id = clientInDb.designation_id,
                management_level_id = clientInDb.management_level_id,
                department_id = clientInDb.department_id,
                reporting_manager = clientInDb.reporting_manager,
                birthdate = clientInDb.birthdate,
                email_id = clientInDb.email_id,
                mobile_no = clientInDb.mobile_no,
                tel_no = clientInDb.tel_no,
                client_id = clientInDb.client_id,
                Departments = ManageDependancyData.GetDepartments(),
                Designations = ManageDependancyData.GetDesignations(),
                ManagementLevels = ManageDependancyData.GetManagementLevels(),
                Title = "Edit Client Contact"
            };

            return View("ClientContactForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientContactsDelete(int id)
        {
            ClientContactDetail clientInDb = _context.ClientContactDetails.Where(x => x.contact_id == id).FirstOrDefault();

            if (clientInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientContactForm", clientInDb);
            }

            _context.ClientContactDetails.Remove(clientInDb);
            _context.SaveChanges();

            return RedirectToAction("ClientContactsIndex",
                new { client_id = int.Parse(Session["ClientId"].ToString()) });
        }
        #endregion

        #region Manage Client Relations
        public ActionResult ClientRelationsIndex(int client_id)
        {
            try
            {
                List<ClientRelation> clientRelations = _context.ClientRelations.Where(d => d.client_id == client_id).ToList();

                ClientRelationViewModel viewModel = new ClientRelationViewModel
                {
                    ClientRelations = clientRelations,
                    Relations = ManageDependancyData.GetRelations()
                };

                Session["ClientId"] = client_id;

                var client = _context.Clients.FirstOrDefault(p => p.client_id == client_id);
                ViewBag.Title = "Manage Relations For " + client.client_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult ClientRelationsNew()
        {
            ClientRelationFormViewModel viewModel = new ClientRelationFormViewModel
            {
                Title = "Add Client Relation",
                Relations = ManageDependancyData.GetRelations()
            };

            return View("ClientRelationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientRelationsSave(ClientRelationFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ClientRelationForm", viewModel);
            }

            if (viewModel.relation_id == 0)
            {
                ClientRelation clientRelation = new ClientRelation
                {
                    relation_name = viewModel.relation_name,
                    remarks = viewModel.remarks,
                    client_id = int.Parse(Session["ClientId"].ToString())
                };

                _context.ClientRelations.Add(clientRelation);
                _context.SaveChanges();
            }
            else
            {
                ClientRelation clientRelationInDb = _context.ClientRelations.Where(x => x.relation_id == viewModel.relation_id).FirstOrDefault();

                if (clientRelationInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("ClientRelationForm", viewModel);
                }

                clientRelationInDb.relation_name = viewModel.relation_name;
                clientRelationInDb.remarks = viewModel.remarks;

                _context.Entry(clientRelationInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("ClientRelationsIndex",
                new { client_id = int.Parse(Session["ClientId"].ToString()) });
        }

        public ActionResult ClientRelationsEdit(int id)
        {
            ClientRelation clientRelationInDb = _context.ClientRelations.Where(x => x.relation_id == id).FirstOrDefault();

            if (clientRelationInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientRelationForm", clientRelationInDb);
            }

            ClientRelationFormViewModel viewModel = new ClientRelationFormViewModel
            {
                relation_id = clientRelationInDb.relation_id,
                relation_name = clientRelationInDb.relation_name,
                remarks = clientRelationInDb.remarks,
                Relations = ManageDependancyData.GetRelations(),
                Title = "Edit Client Relation"
            };

            return View("ClientRelationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientRelationsDelete(int id)
        {
            ClientRelation clientRelationInDb = _context.ClientRelations.Where(x => x.relation_id == id).FirstOrDefault();

            if (clientRelationInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("ClientRelationForm", clientRelationInDb);
            }

            _context.ClientRelations.Remove(clientRelationInDb);
            _context.SaveChanges();

            return RedirectToAction("ClientRelationsIndex",
                new { client_id = int.Parse(Session["ClientId"].ToString()) });
        }
        #endregion
    }
}