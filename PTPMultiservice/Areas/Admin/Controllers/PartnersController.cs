using PTPMultiservice.Models;
using PTPMultiservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTPMultiservice.Areas.Admin.Controllers
{
    public class PartnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartnersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            try
            {
                var partners = _context.Partners.ToList();

                PartnerViewModel viewModel = new PartnerViewModel
                {
                    Partners = partners,
                    EducationQualifications = ManageDependancyData.GetEducationQualification(),
                    Designations = ManageDependancyData.GetDesignations(),
                    MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                    Genders = ManageDependancyData.GetGenders(),
                    Documents = _context.Documents.ToList()
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
            PartnerFormViewModel viewModel = new PartnerFormViewModel
            {
                partner_id = 0,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                Title = "New Partner"
            };

            return View("PartnerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PartnerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("PartnerForm", viewModel);
            }

            if (viewModel.partner_id == 0)
            {
                Partner partner = new Partner
                {
                    first_name = viewModel.first_name,
                    middle_name = viewModel.middle_name,
                    last_name = viewModel.last_name,
                    mother_name = viewModel.mother_name,
                    education_id = viewModel.education_id,
                    designation_id = viewModel.designation_id,
                    marital_status_id = viewModel.marital_status_id,
                    gender_id = viewModel.gender_id,
                    email = viewModel.email,
                    birth_date = (DateTime)viewModel.birth_date,
                    joining_date = (DateTime)viewModel.joining_date,
                    present_address = viewModel.present_address,
                    permanent_address = viewModel.permanent_address,
                    mobile = viewModel.mobile,
                    tel = viewModel.tel,
                    identity_body_mark = viewModel.identity_body_mark,
                    remarks = viewModel.remarks,
                    is_active = true,
                    created_on = DateTime.Now
                };

                _context.Partners.Add(partner);
            }
            else
            {
                Partner partnerInDb = _context.Partners.Where(x => x.partner_id == viewModel.partner_id).FirstOrDefault();

                if (partnerInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("PartnerForm", viewModel);
                }

                partnerInDb.first_name = viewModel.first_name;
                partnerInDb.middle_name = viewModel.middle_name;
                partnerInDb.last_name = viewModel.last_name;
                partnerInDb.mother_name = viewModel.mother_name;
                partnerInDb.education_id = viewModel.education_id;
                partnerInDb.designation_id = viewModel.designation_id;
                partnerInDb.marital_status_id = viewModel.marital_status_id;
                partnerInDb.gender_id = viewModel.gender_id;
                partnerInDb.email = viewModel.email;
                partnerInDb.birth_date = (DateTime)viewModel.birth_date;
                partnerInDb.joining_date = (DateTime)viewModel.joining_date;
                partnerInDb.present_address = viewModel.present_address;
                partnerInDb.permanent_address = viewModel.permanent_address;
                partnerInDb.mobile = viewModel.mobile;
                partnerInDb.tel = viewModel.tel;
                partnerInDb.identity_body_mark = viewModel.identity_body_mark;
                partnerInDb.remarks = viewModel.remarks;

                _context.Entry(partnerInDb).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Partner partnerInDb = _context.Partners.Where(x => x.partner_id == id).FirstOrDefault();

            if (partnerInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("PartnerForm", partnerInDb);
            }

            PartnerFormViewModel viewModel = new PartnerFormViewModel
            {
                partner_id = partnerInDb.partner_id,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),                                
                first_name = partnerInDb.first_name,
                middle_name = partnerInDb.middle_name,
                last_name = partnerInDb.last_name,
                mother_name = partnerInDb.mother_name,
                education_id = partnerInDb.education_id,
                designation_id = partnerInDb.designation_id,
                marital_status_id = partnerInDb.marital_status_id,
                gender_id = partnerInDb.gender_id,
                email = partnerInDb.email,
                birth_date = (DateTime)partnerInDb.birth_date,
                joining_date = (DateTime)partnerInDb.joining_date,
                present_address = partnerInDb.present_address,
                permanent_address = partnerInDb.permanent_address,
                mobile = partnerInDb.mobile,
                tel = partnerInDb.tel,
                identity_body_mark = partnerInDb.identity_body_mark,
                remarks = partnerInDb.remarks,
                Title = "Edit Partner"
            };

            return View("PartnerForm", viewModel);
        }

        public ActionResult ToggleStatus(int id)
        {
            Partner partnerInDb = _context.Partners.Where(x => x.partner_id == id).FirstOrDefault();

            if (partnerInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("PartnerForm", partnerInDb);
            }

            if (partnerInDb.is_active)
                partnerInDb.is_active = false;
            else
                partnerInDb.is_active = true;

            _context.Entry(partnerInDb).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Partner partnerInDb = _context.Partners.Where(x => x.partner_id == id).FirstOrDefault();

            if (partnerInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("PartnerForm", partnerInDb);
            }

            _context.Partners.Remove(partnerInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Partner partnerInDb = _context.Partners.Where(x => x.partner_id == id).FirstOrDefault();

            if (partnerInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("PartnerForm", partnerInDb);
            }

            PartnerFormViewModel viewModel = new PartnerFormViewModel
            {
                partner_id = partnerInDb.partner_id,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                first_name = partnerInDb.first_name,
                middle_name = partnerInDb.middle_name,
                last_name = partnerInDb.last_name,
                mother_name = partnerInDb.mother_name,
                education_id = partnerInDb.education_id,
                designation_id = partnerInDb.designation_id,
                marital_status_id = partnerInDb.marital_status_id,
                gender_id = partnerInDb.gender_id,
                email = partnerInDb.email,
                birth_date = (DateTime)partnerInDb.birth_date,
                joining_date = (DateTime)partnerInDb.joining_date,
                present_address = partnerInDb.present_address,
                permanent_address = partnerInDb.permanent_address,
                mobile = partnerInDb.mobile,
                tel = partnerInDb.tel,
                identity_body_mark = partnerInDb.identity_body_mark,
                remarks = partnerInDb.remarks,
                Title = "Partner Details"
            };
                        
            return View("PartnerForm", viewModel);
        }


        // Manage Partner Documnets
        public ActionResult PartnerDocumentsIndex(int partner_id)
        {
            try
            {
                List<Document> documents = _context.Documents.Where(d => d.partner_id == partner_id).ToList();

                DocumentViewModel viewModel = new DocumentViewModel
                {
                    DocumentTypes = ManageDependancyData.DocumentTypes(),
                    Documents = documents
                };

                Session["PartnerId"] = partner_id;

                var partner = _context.Partners.FirstOrDefault(p => p.partner_id == partner_id);
                ViewBag.Title = "Manage Documents For " + partner.first_name + " " + partner.middle_name + " " + partner.last_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult PartnerDocumentsNew()
        {
            DocumentFormViewModel viewModel = new DocumentFormViewModel
            {
                DocTypes = ManageDependancyData.DocumentTypes(),
                Title = "New Document"
            };

            return View("DocumentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartnerDocumentsSave(DocumentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("DocumentForm", viewModel);
            }

            if (viewModel.document_id == 0)
            {
                Document document = new Document
                {
                    type = viewModel.type,
                    name = viewModel.name,
                    number = viewModel.number,
                    birthdate = viewModel.birthdate,
                    address = viewModel.address,
                    partner_id = int.Parse(Session["PartnerId"].ToString())
                };

                _context.Documents.Add(document);
                _context.SaveChanges();
            }
            else
            {
                Document documentInDb = _context.Documents.Where(x => x.document_id == viewModel.document_id).FirstOrDefault();

                if (documentInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("DocumentForm", viewModel);
                }

                documentInDb.type = viewModel.type;
                documentInDb.name = viewModel.name;
                documentInDb.number = viewModel.number;
                documentInDb.birthdate = viewModel.birthdate;
                documentInDb.address = viewModel.address;

                _context.Entry(documentInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("PartnerDocumentsIndex", 
                new { partner_id = int.Parse(Session["PartnerId"].ToString()) });
        }

        public ActionResult PartnerDocumentsEdit(int id)
        {
            Document documentInDb = _context.Documents.Where(x => x.document_id == id).FirstOrDefault();

            if (documentInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("DocumentForm", documentInDb);
            }

            DocumentFormViewModel viewModel = new DocumentFormViewModel
            {
                document_id = documentInDb.document_id,
                DocTypes = ManageDependancyData.DocumentTypes(),
                type = documentInDb.type,
                name = documentInDb.name,
                number = documentInDb.number,
                birthdate = documentInDb.birthdate,
                address = documentInDb.address,
                partner_id = int.Parse(Session["PartnerId"].ToString()),
                Title = "Edit Document"
            };

            return View("DocumentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartnerDocumentsDelete(int id)
        {
            Document documentInDb = _context.Documents.Where(x => x.document_id == id).FirstOrDefault();

            if (documentInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("DocumentForm", documentInDb);
            }

            _context.Documents.Remove(documentInDb);
            _context.SaveChanges();

            return RedirectToAction("PartnerDocumentsIndex", 
                new { partner_id = int.Parse(Session["PartnerId"].ToString()) });
        }
    }
}