using PTPMultiservice.Models;
using PTPMultiservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTPMultiservice.Areas.Admin.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        #region Employee info
        public ActionResult Index()
        {
            try
            {
                var employees = _context.Employees.ToList();

                EmployeeViewModel viewModel = new EmployeeViewModel
                {
                    Employees = employees,
                    EducationQualifications = ManageDependancyData.GetEducationQualification(),
                    Designations = ManageDependancyData.GetDesignations(),
                    MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                    Genders = ManageDependancyData.GetGenders(),
                    EmployeeDocumentDetails = _context.EmployeeDocumentDetails.ToList(),
                    EmployeeBankDetails = _context.EmployeeBankDetails.ToList(),
                    EmployeePFDetails = _context.EmployeePfDetails.ToList(),
                    EmployeeStateInsuranceDetails = _context.EmployeeStateInsuranceDetails.ToList()
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
            EmployeeFormViewModel viewModel = new EmployeeFormViewModel
            {
                employee_id = 0,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                Title = "New Employee"
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EmployeeFormViewModel viewModel, HttpPostedFileBase Photo)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeForm", viewModel);
            }

            if (viewModel.employee_id == 0)
            {

                if (Photo == null)
                {
                    ModelState.AddModelError("Photo", "Photo can't be blank");
                    return View("EmployeeForm", viewModel);
                }

                if (Photo.ContentLength > 2000000)
                {
                    ModelState.AddModelError("Photo", "Photo can't be more than 2Mb Size.");
                    return View("EmployeeForm", viewModel);
                }

                string basePath = Server.MapPath("~");
                string folderPath = "Assets\\Upload\\";
                string folderFullPath = basePath + "" + folderPath;
                string fillName = string.Format(DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + Path.GetExtension(Photo.FileName));

                if (!Directory.Exists(folderFullPath))
                {
                    Directory.CreateDirectory(folderFullPath);
                }

                Bitmap bmpPostedImage = new System.Drawing.Bitmap(Photo.InputStream);
                var image = ScaleImage(bmpPostedImage, 320, null);

                image.Save(Path.Combine(folderFullPath, fillName));
                viewModel.photo = folderPath + "" + fillName;

                Employee employee = new Employee
                {
                    first_name = viewModel.first_name,
                    middle_name = viewModel.middle_name,
                    last_name = viewModel.last_name,
                    mother_name = viewModel.mother_name,
                    education_id = viewModel.education_id,
                    designation_id = viewModel.designation_id,
                    marital_status_id = viewModel.marital_status_id,
                    gender_id = viewModel.gender_id,
                    email_address = viewModel.email_address,
                    birthdate = (DateTime)viewModel.birthdate,
                    joining_date = (DateTime)viewModel.joining_date,
                    present_address = viewModel.present_address,
                    permanent_address = viewModel.permanent_address,
                    mobile_no = viewModel.mobile_no,
                    tel_no = viewModel.tel_no,
                    mark_on_body = viewModel.mark_on_body,
                    photo = viewModel.photo,
                    name_and_contact_reference_1 = viewModel.name_and_contact_reference_1,
                    name_and_contact_reference_2 = viewModel.name_and_contact_reference_2,
                    is_active = true,
                    created_on = DateTime.Now
                };

                _context.Employees.Add(employee);
            }
            else
            {
                Employee employeeInDb = _context.Employees.Where(x => x.employee_id == viewModel.employee_id).FirstOrDefault();

                if (employeeInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("EmployeeForm", viewModel);
                }

                employeeInDb.first_name = viewModel.first_name;
                employeeInDb.middle_name = viewModel.middle_name;
                employeeInDb.last_name = viewModel.last_name;
                employeeInDb.mother_name = viewModel.mother_name;
                employeeInDb.education_id = viewModel.education_id;
                employeeInDb.designation_id = viewModel.designation_id;
                employeeInDb.marital_status_id = viewModel.marital_status_id;
                employeeInDb.gender_id = viewModel.gender_id;
                employeeInDb.email_address = viewModel.email_address;
                employeeInDb.birthdate = (DateTime)viewModel.birthdate;
                employeeInDb.joining_date = (DateTime)viewModel.joining_date;
                employeeInDb.present_address = viewModel.present_address;
                employeeInDb.permanent_address = viewModel.permanent_address;
                employeeInDb.mobile_no = viewModel.mobile_no;
                employeeInDb.tel_no = viewModel.tel_no;
                employeeInDb.mark_on_body = viewModel.mark_on_body;
                
                string pPhoto = string.Empty;
                
                if (viewModel.photo != null)
                {                    
                    if (Photo.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Photo", "Photo can't be more than 2Mb Size.");
                        return View("EmployeeForm", viewModel);
                    }

                    string basePath = Server.MapPath("~");
                    string folderPath = "Assets\\Upload\\";
                    string folderFullPath = basePath + "" + folderPath;
                    string fillName = string.Format(DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + Path.GetExtension(Photo.FileName));

                    if (!Directory.Exists(folderFullPath))
                    {
                        Directory.CreateDirectory(folderFullPath);
                    }

                    Bitmap bmpPostedImage = new System.Drawing.Bitmap(Photo.InputStream);
                    var image = ScaleImage(bmpPostedImage, 320, null);

                    image.Save(Path.Combine(folderFullPath, fillName));
                    pPhoto = folderPath + "" + fillName;
                }
                else
                {
                    pPhoto = employeeInDb.photo;
                }
                employeeInDb.photo = pPhoto;

                employeeInDb.name_and_contact_reference_1 = viewModel.name_and_contact_reference_1;
                employeeInDb.name_and_contact_reference_2 = viewModel.name_and_contact_reference_2;

                _context.Entry(employeeInDb).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private static Image ScaleImage(Image image, int maxHeight, int? maxWidth)
        {
            if (!maxWidth.HasValue)
            {
                var ratio = (double)maxHeight / image.Height;
                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);

                var newImage = new Bitmap(newWidth, newHeight);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                }
                return newImage;
            }
            else
            {
                var newImage = new Bitmap((int)maxWidth, maxHeight);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, (int)maxWidth, maxHeight);
                }
                return newImage;
            }
        }

        public ActionResult Edit(int id)
        {
            Employee employeeInDb = _context.Employees.Where(x => x.employee_id == id).FirstOrDefault();

            if (employeeInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeForm", employeeInDb);
            }

            EmployeeFormViewModel viewModel = new EmployeeFormViewModel
            {
                employee_id = employeeInDb.employee_id,
                first_name = employeeInDb.first_name,
                middle_name = employeeInDb.middle_name,
                last_name = employeeInDb.last_name,
                mother_name = employeeInDb.mother_name,
                education_id = employeeInDb.education_id,
                designation_id = employeeInDb.designation_id,
                marital_status_id = employeeInDb.marital_status_id,
                gender_id = employeeInDb.gender_id,
                email_address = employeeInDb.email_address,
                birthdate = (DateTime)employeeInDb.birthdate,
                joining_date = (DateTime)employeeInDb.joining_date,
                present_address = employeeInDb.present_address,
                permanent_address = employeeInDb.permanent_address,
                mobile_no = employeeInDb.mobile_no,
                tel_no = employeeInDb.tel_no,
                mark_on_body = employeeInDb.mark_on_body,
                photo = employeeInDb.photo,
                name_and_contact_reference_1 = employeeInDb.name_and_contact_reference_1,
                name_and_contact_reference_2 = employeeInDb.name_and_contact_reference_2,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                Title = "Edit Employee"
            };

            return View("EmployeeForm", viewModel);
        }

        public ActionResult ToggleStatus(int id)
        {
            Employee employeeInDb = _context.Employees.Where(x => x.employee_id == id).FirstOrDefault();

            if (employeeInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeForm", employeeInDb);
            }

            if (employeeInDb.is_active)
                employeeInDb.is_active = false;
            else
                employeeInDb.is_active = true;

            _context.Entry(employeeInDb).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Employee employeeInDb = _context.Employees.Where(x => x.employee_id == id).FirstOrDefault();

            if (employeeInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeForm", employeeInDb);
            }

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee employeeInDb = _context.Employees.Where(x => x.employee_id == id).FirstOrDefault();

            if (employeeInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeForm", employeeInDb);
            }

            EmployeeFormViewModel viewModel = new EmployeeFormViewModel
            {
                employee_id = employeeInDb.employee_id,
                first_name = employeeInDb.first_name,
                middle_name = employeeInDb.middle_name,
                last_name = employeeInDb.last_name,
                mother_name = employeeInDb.mother_name,
                education_id = employeeInDb.education_id,
                designation_id = employeeInDb.designation_id,
                marital_status_id = employeeInDb.marital_status_id,
                gender_id = employeeInDb.gender_id,
                email_address = employeeInDb.email_address,
                birthdate = (DateTime)employeeInDb.birthdate,
                joining_date = (DateTime)employeeInDb.joining_date,
                present_address = employeeInDb.present_address,
                permanent_address = employeeInDb.permanent_address,
                mobile_no = employeeInDb.mobile_no,
                tel_no = employeeInDb.tel_no,
                mark_on_body = employeeInDb.mark_on_body,
                photo = employeeInDb.photo,
                name_and_contact_reference_1 = employeeInDb.name_and_contact_reference_1,
                name_and_contact_reference_2 = employeeInDb.name_and_contact_reference_2,
                EducationQualifications = ManageDependancyData.GetEducationQualification(),
                Designations = ManageDependancyData.GetDesignations(),
                MaritalStatus = ManageDependancyData.GetMaritalStatus(),
                Genders = ManageDependancyData.GetGenders(),
                Title = "Employee Details"
            };

            return View("EmployeeForm", viewModel);
        }
        #endregion

        #region Manage Employee Documnets Details
        public ActionResult EmployeeDocumentsIndex(int employee_id)
        {
            try
            {
                List<EmployeeDocumentDetail> documents = _context.EmployeeDocumentDetails.Where(d => d.employee_id == employee_id).ToList();

                EmployeeDocumentViewModel viewModel = new EmployeeDocumentViewModel
                {
                    DocTypes = ManageDependancyData.DocumentTypes(),
                    EmployeeDocumentDetails = documents
                };

                Session["EmployeeId"] = employee_id;

                var employee = _context.Employees.FirstOrDefault(p => p.employee_id == employee_id);
                ViewBag.Title = "Manage Employee Documents For " + employee.first_name + " " + employee.middle_name + " " + employee.last_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult EmployeeDocumentsNew()
        {
            EmployeeDocumentFormViewModel viewModel = new EmployeeDocumentFormViewModel
            {
                DocTypes = ManageDependancyData.DocumentTypes(),
                Title = "New Document"
            };

            return View("EmployeeDocumentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeDocumentsSave(EmployeeDocumentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeDocumentForm", viewModel);
            }

            if (viewModel.document_id == 0)
            {
                EmployeeDocumentDetail document = new EmployeeDocumentDetail
                {
                    type = viewModel.type,
                    name = viewModel.name,
                    number = viewModel.number,
                    birthdate = viewModel.birthdate,
                    address = viewModel.address,
                    employee_id = int.Parse(Session["EmployeeId"].ToString())
                };

                _context.EmployeeDocumentDetails.Add(document);
                _context.SaveChanges();
            }
            else
            {
                EmployeeDocumentDetail documentInDb = _context.EmployeeDocumentDetails.Where(x => x.document_id == viewModel.document_id).FirstOrDefault();

                if (documentInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("EmployeeDocumentForm", viewModel);
                }

                documentInDb.type = viewModel.type;
                documentInDb.name = viewModel.name;
                documentInDb.number = viewModel.number;
                documentInDb.birthdate = viewModel.birthdate;
                documentInDb.address = viewModel.address;

                _context.Entry(documentInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("EmployeeDocumentsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }

        public ActionResult EmployeeDocumentsEdit(int id)
        {
            EmployeeDocumentDetail documentInDb = _context.EmployeeDocumentDetails.Where(x => x.document_id == id).FirstOrDefault();

            if (documentInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeDocumentForm", documentInDb);
            }

            EmployeeDocumentFormViewModel viewModel = new EmployeeDocumentFormViewModel
            {
                document_id = documentInDb.document_id,
                type = documentInDb.type,
                name = documentInDb.name,
                number = documentInDb.number,
                birthdate = documentInDb.birthdate,
                address = documentInDb.address,
                employee_id = int.Parse(Session["EmployeeId"].ToString()),
                DocTypes = ManageDependancyData.DocumentTypes(),
                Title = "Edit Document"
            };

            return View("EmployeeDocumentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeDocumentsDelete(int id)
        {
            EmployeeDocumentDetail documentInDb = _context.EmployeeDocumentDetails.Where(x => x.document_id == id).FirstOrDefault();

            if (documentInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeDocumentForm", documentInDb);
            }

            _context.EmployeeDocumentDetails.Remove(documentInDb);
            _context.SaveChanges();

            return RedirectToAction("EmployeeDocumentsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }
        #endregion

        #region Manage Employee Bank Details
        public ActionResult EmployeeBankDetailsIndex(int employee_id)
        {
            try
            {
                List<EmployeeBankDetail> bankDetails = _context.EmployeeBankDetails.Where(d => d.employee_id == employee_id).ToList();

                EmployeeBankDetailViewModel viewModel = new EmployeeBankDetailViewModel
                {
                    EmployeeBankDetails = bankDetails  
                };

                Session["EmployeeId"] = employee_id;

                var employee = _context.Employees.FirstOrDefault(p => p.employee_id == employee_id);
                ViewBag.Title = "Manage Bank Details For " + employee.first_name + " " + employee.middle_name + " " + employee.last_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult EmployeeBankDetailsNew()
        {
            EmployeeBankDetailFormViewModel viewModel = new EmployeeBankDetailFormViewModel
            {
                Title = "New Bank Detail"
            };

            return View("EmployeeBankDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeBankDetailsSave(EmployeeBankDetailFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeBankDetailForm", viewModel);
            }

            if (viewModel.bank_id == 0)
            {
                EmployeeBankDetail bankDetail = new EmployeeBankDetail
                {
                    account_no = viewModel.account_no,
                    bank_holder_name = viewModel.bank_holder_name,
                    bank_name = viewModel.bank_name,
                    ifsc_code = viewModel.ifsc_code,
                    branch_name = viewModel.branch_name,
                    employee_id = int.Parse(Session["EmployeeId"].ToString())
                };

                _context.EmployeeBankDetails.Add(bankDetail);
                _context.SaveChanges();
            }
            else
            {
                EmployeeBankDetail bankDetailsInDb = _context.EmployeeBankDetails.Where(x => x.bank_id == viewModel.bank_id).FirstOrDefault();

                if (bankDetailsInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("EmployeeBankDetailForm", viewModel);
                }

                bankDetailsInDb.account_no = viewModel.account_no;
                bankDetailsInDb.bank_holder_name = viewModel.bank_holder_name;
                bankDetailsInDb.bank_name = viewModel.bank_name;
                bankDetailsInDb.ifsc_code = viewModel.ifsc_code;
                bankDetailsInDb.branch_name = viewModel.branch_name;

                _context.Entry(bankDetailsInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("EmployeeBankDetailsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }

        public ActionResult EmployeeBankDetailsEdit(int id)
        {
            EmployeeBankDetail bankDetailsInDb = _context.EmployeeBankDetails.Where(x => x.bank_id == id).FirstOrDefault();

            if (bankDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeBankDetailForm", bankDetailsInDb);
            }

            EmployeeBankDetailFormViewModel viewModel = new EmployeeBankDetailFormViewModel
            {
                bank_id = bankDetailsInDb.bank_id,
                account_no = bankDetailsInDb.account_no,
                bank_holder_name = bankDetailsInDb.bank_holder_name,
                bank_name = bankDetailsInDb.bank_name,
                ifsc_code = bankDetailsInDb.ifsc_code,
                branch_name = bankDetailsInDb.branch_name,
                employee_id = int.Parse(Session["EmployeeId"].ToString()),
                Title = "Edit Bank Details"
            };

            return View("EmployeeBankDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeBankDetailsDelete(int id)
        {
            EmployeeBankDetail bankDetailsInDb = _context.EmployeeBankDetails.Where(x => x.bank_id == id).FirstOrDefault();

            if (bankDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeBankDetailForm", bankDetailsInDb);
            }

            _context.EmployeeBankDetails.Remove(bankDetailsInDb);
            _context.SaveChanges();

            return RedirectToAction("EmployeeBankDetailsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }
        #endregion

        #region Manage Employee PF Details
        public ActionResult EmployeePfDetailsIndex(int employee_id)
        {
            try
            {
                List<EmployeePfDetail> PfDetails = _context.EmployeePfDetails.Where(d => d.employee_id == employee_id).ToList();

                EmployeePfDetailViewModel viewModel = new EmployeePfDetailViewModel
                {
                    EmployeePfDetails = PfDetails
                };

                Session["EmployeeId"] = employee_id;

                var employee = _context.Employees.FirstOrDefault(p => p.employee_id == employee_id);
                ViewBag.Title = "Manage PF Details For " + employee.first_name + " " + employee.middle_name + " " + employee.last_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult EmployeePfDetailsNew()
        {
            EmployeePfDetailFormViewModel viewModel = new EmployeePfDetailFormViewModel
            {
                Title = "New PF Detail"
            };

            return View("EmployeePfDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeePfDetailsSave(EmployeePfDetailFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeePfDetailForm", viewModel);
            }

            if (viewModel.pf_id == 0)
            {
                EmployeePfDetail pfDetail = new EmployeePfDetail
                {
                    previous_uan_no = viewModel.previous_uan_no,
                    previous_account_no = viewModel.previous_account_no,
                    previous_doj_company = viewModel.previous_doj_company,
                    previous_dol_company = viewModel.previous_dol_company,
                    employee_id = int.Parse(Session["EmployeeId"].ToString())
                };

                _context.EmployeePfDetails.Add(pfDetail);
                _context.SaveChanges();
            }
            else
            {
                EmployeePfDetail pfDetailsInDb = _context.EmployeePfDetails.Where(x => x.pf_id == viewModel.pf_id).FirstOrDefault();

                if (pfDetailsInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("EmployeePfDetailForm", viewModel);
                }

                pfDetailsInDb.previous_uan_no = viewModel.previous_uan_no;
                pfDetailsInDb.previous_account_no = viewModel.previous_account_no;
                pfDetailsInDb.previous_doj_company = viewModel.previous_doj_company;
                pfDetailsInDb.previous_dol_company = viewModel.previous_dol_company;
                _context.Entry(pfDetailsInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("EmployeePfDetailsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }

        public ActionResult EmployeePfDetailsEdit(int id)
        {
            EmployeePfDetail pfDetailsInDb = _context.EmployeePfDetails.Where(x => x.pf_id == id).FirstOrDefault();

            if (pfDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeePfDetailForm", pfDetailsInDb);
            }

            EmployeePfDetailFormViewModel viewModel = new EmployeePfDetailFormViewModel
            {
                pf_id = pfDetailsInDb.pf_id,
                previous_uan_no = pfDetailsInDb.previous_uan_no,
                previous_account_no = pfDetailsInDb.previous_account_no,
                previous_doj_company = pfDetailsInDb.previous_doj_company,
                previous_dol_company = pfDetailsInDb.previous_dol_company,
                employee_id = int.Parse(Session["EmployeeId"].ToString()),
                Title = "Edit PF Details"
            };

            return View("EmployeePFDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeePfDetailsDelete(int id)
        {
            EmployeePfDetail pfDetailsInDb = _context.EmployeePfDetails.Where(x => x.pf_id == id).FirstOrDefault();

            if (pfDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeePfDetailForm", pfDetailsInDb);
            }

            _context.EmployeePfDetails.Remove(pfDetailsInDb);
            _context.SaveChanges();

            return RedirectToAction("EmployeePfDetailsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }
        #endregion

        #region Manage Employee State Insurance Details
        public ActionResult EmployeeStateInsuranceDetailsIndex(int employee_id)
        {
            try
            {
                List<EmployeeStateInsuranceDetail> StateInsuranceDetails = _context.EmployeeStateInsuranceDetails.Where(d => d.employee_id == employee_id).ToList();

                EmployeeStateInsuranceDetailViewModel viewModel = new EmployeeStateInsuranceDetailViewModel
                {
                    EmployeeStateInsuranceDetails = StateInsuranceDetails,
                    Disabilities = ManageDependancyData.GetDisability(),
                    NomineeRelations = ManageDependancyData.GetBloodRelations(),
                    EmployeeStateInsuranceFamilyDetails = _context.EmployeeStateInsuranceFamilyDetails.ToList()
                };

                Session["EmployeeId"] = employee_id;

                var employee = _context.Employees.FirstOrDefault(p => p.employee_id == employee_id);
                ViewBag.Title = "Manage State Insurance Details For " + employee.first_name + " " + employee.middle_name + " " + employee.last_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult EmployeeStateInsuranceDetailsNew()
        {
            EmployeeStateInsuranceDetailFormViewModel viewModel = new EmployeeStateInsuranceDetailFormViewModel
            {
                Title = "New State Insurance Detail",
                Disabilities = ManageDependancyData.GetDisability(),
                NomineeRelations = ManageDependancyData.GetBloodRelations()                
            };

            return View("EmployeeStateInsuranceDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeStateInsuranceDetailsSave(EmployeeStateInsuranceDetailFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeStateInsuranceDetailForm", viewModel);
            }

            if (viewModel.emp_state_insurance_id == 0)
            {
                EmployeeStateInsuranceDetail pfDetail = new EmployeeStateInsuranceDetail
                {
                    disability_id = viewModel.disability_id,
                    previous_employer_code = viewModel.previous_employer_code,
                    previous_employer_name = viewModel.previous_employer_name,
                    previous_employer_address = viewModel.previous_employer_address,
                    previous_ip_no = viewModel.previous_ip_no,
                    nominee_name = viewModel.nominee_name,
                    nominee_address = viewModel.nominee_address,
                    relation_with_nominee_id = viewModel.relation_with_nominee_id,
                    per_share_towards_nominee = viewModel.per_share_towards_nominee,
                    employee_id = int.Parse(Session["EmployeeId"].ToString())
                };

                _context.EmployeeStateInsuranceDetails.Add(pfDetail);
                _context.SaveChanges();
            }
            else
            {
                EmployeeStateInsuranceDetail stateInsuranceDetailsInDb = _context.EmployeeStateInsuranceDetails.Where(x => x.emp_state_insurance_id == viewModel.emp_state_insurance_id).FirstOrDefault();

                if (stateInsuranceDetailsInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("EmployeeStateInsuranceDetailForm", viewModel);
                }
                                
                stateInsuranceDetailsInDb.disability_id = viewModel.disability_id;
                stateInsuranceDetailsInDb.previous_employer_code = viewModel.previous_employer_code;
                stateInsuranceDetailsInDb.previous_employer_name = viewModel.previous_employer_name;
                stateInsuranceDetailsInDb.previous_employer_address = viewModel.previous_employer_address;
                stateInsuranceDetailsInDb.previous_ip_no = viewModel.previous_ip_no;
                stateInsuranceDetailsInDb.nominee_name = viewModel.nominee_name;
                stateInsuranceDetailsInDb.nominee_address = viewModel.nominee_address;
                stateInsuranceDetailsInDb.relation_with_nominee_id = viewModel.relation_with_nominee_id;
                stateInsuranceDetailsInDb.per_share_towards_nominee = viewModel.per_share_towards_nominee;

                _context.Entry(stateInsuranceDetailsInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("EmployeeStateInsuranceDetailsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }

        public ActionResult EmployeeStateInsuranceDetailsEdit(int id)
        {
            EmployeeStateInsuranceDetail stateInsuranceDetailsInDb = _context.EmployeeStateInsuranceDetails.Where(x => x.emp_state_insurance_id == id).FirstOrDefault();

            if (stateInsuranceDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeStateInsuranceDetailForm", stateInsuranceDetailsInDb);
            }

            EmployeeStateInsuranceDetailFormViewModel viewModel = new EmployeeStateInsuranceDetailFormViewModel
            {
                emp_state_insurance_id = stateInsuranceDetailsInDb.emp_state_insurance_id,
                disability_id = stateInsuranceDetailsInDb.disability_id,
                previous_employer_code = stateInsuranceDetailsInDb.previous_employer_code,
                previous_employer_name = stateInsuranceDetailsInDb.previous_employer_name,
                previous_employer_address = stateInsuranceDetailsInDb.previous_employer_address,
                previous_ip_no = stateInsuranceDetailsInDb.previous_ip_no,
                nominee_name = stateInsuranceDetailsInDb.nominee_name,
                nominee_address = stateInsuranceDetailsInDb.nominee_address,
                relation_with_nominee_id = stateInsuranceDetailsInDb.relation_with_nominee_id,
                per_share_towards_nominee = stateInsuranceDetailsInDb.per_share_towards_nominee,
                employee_id = int.Parse(Session["EmployeeId"].ToString()),
                Disabilities = ManageDependancyData.GetDisability(),
                NomineeRelations = ManageDependancyData.GetBloodRelations(),
                Title = "Edit State Insurance Details"
            };

            return View("EmployeeStateInsuranceDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeStateInsuranceDetailsDelete(int id)
        {
            EmployeeStateInsuranceDetail stateInsuranceDetailsInDb = _context.EmployeeStateInsuranceDetails.Where(x => x.emp_state_insurance_id == id).FirstOrDefault();

            if (stateInsuranceDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeStateInsuranceDetailForm", stateInsuranceDetailsInDb);
            }

            _context.EmployeeStateInsuranceDetails.Remove(stateInsuranceDetailsInDb);
            _context.SaveChanges();

            return RedirectToAction("EmployeeStateInsuranceDetailsIndex",
                new { employee_id = int.Parse(Session["EmployeeId"].ToString()) });
        }
        #endregion

        #region Manage Employee State Insurance Family Details
        public ActionResult EmployeeStateInsuranceFamilyDetailsIndex(int emp_state_insurance_id)
        {
            try
            {
                List<EmployeeStateInsuranceFamilyDetail> StateInsuranceFamilyDetails = _context.EmployeeStateInsuranceFamilyDetails.Where(d => d.emp_state_insurance_id == emp_state_insurance_id).ToList();

                EmployeeStateInsuranceFamilyDetailViewModel viewModel = new EmployeeStateInsuranceFamilyDetailViewModel
                {
                    EmployeeStateInsuranceFamilyDetails = StateInsuranceFamilyDetails,
                    NomineeRelations = ManageDependancyData.GetBloodRelations(),
                    YesNos = ManageDependancyData.YesNos()
                };

                Session["EmpStateInsuranceId"] = emp_state_insurance_id;

                var ip = _context.EmployeeStateInsuranceDetails.FirstOrDefault(p => p.emp_state_insurance_id == emp_state_insurance_id);
                var employee = _context.Employees.FirstOrDefault(p => p.employee_id == ip.employee_id);
                ViewBag.Title = "Manage Family Details For " + employee.first_name + " " + employee.middle_name + " " + employee.last_name;

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult EmployeeStateInsuranceFamilyDetailsNew()
        {
            EmployeeStateInsuranceFamilyDetailFormViewModel viewModel = new EmployeeStateInsuranceFamilyDetailFormViewModel
            {
                Title = "New State Insurance Family Detail",
                NomineeRelations = ManageDependancyData.GetBloodRelations(),
                YesNos = ManageDependancyData.YesNos()
            };

            return View("EmployeeStateInsuranceFamilyDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeStateInsuranceFamilyDetailsSave(EmployeeStateInsuranceFamilyDetailFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeStateInsuranceFamilyDetailForm", viewModel);
            }

            if (viewModel.emp_state_insu_fam_id == 0)
            {
                EmployeeStateInsuranceFamilyDetail familyDetail = new EmployeeStateInsuranceFamilyDetail
                {
                    full_name = viewModel.full_name,
                    relation_with_ip = viewModel.relation_with_ip,
                    minor_major_id = viewModel.minor_major_id,
                    birthdate = viewModel.birthdate,
                    is_residing_with_ip = viewModel.is_residing_with_ip,
                    state = viewModel.state,
                    district = viewModel.district,
                    city = viewModel.city,                    
                    emp_state_insurance_id = int.Parse(Session["EmpStateInsuranceId"].ToString())
                };

                _context.EmployeeStateInsuranceFamilyDetails.Add(familyDetail);
                _context.SaveChanges();
            }
            else
            {
                EmployeeStateInsuranceFamilyDetail stateInsuranceFamilyDetailsInDb = _context.EmployeeStateInsuranceFamilyDetails.Where(x => x.emp_state_insu_fam_id == viewModel.emp_state_insu_fam_id).FirstOrDefault();

                if (stateInsuranceFamilyDetailsInDb == null)
                {
                    ModelState.AddModelError("", "Bad request.");
                    return View("EmployeeStateInsuranceFamilyDetailForm", viewModel);
                }

                stateInsuranceFamilyDetailsInDb.full_name = viewModel.full_name;
                stateInsuranceFamilyDetailsInDb.relation_with_ip = viewModel.relation_with_ip;
                stateInsuranceFamilyDetailsInDb.minor_major_id = viewModel.minor_major_id;
                stateInsuranceFamilyDetailsInDb.birthdate = viewModel.birthdate;
                stateInsuranceFamilyDetailsInDb.is_residing_with_ip = viewModel.is_residing_with_ip;
                stateInsuranceFamilyDetailsInDb.state = viewModel.state;
                stateInsuranceFamilyDetailsInDb.district = viewModel.district;
                stateInsuranceFamilyDetailsInDb.city = viewModel.city;

                _context.Entry(stateInsuranceFamilyDetailsInDb).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("EmployeeStateInsuranceFamilyDetailsIndex",
                new { emp_state_insurance_id = int.Parse(Session["EmpStateInsuranceId"].ToString()) });
        }

        public ActionResult EmployeeStateInsuranceFamilyDetailsEdit(int id)
        {
            EmployeeStateInsuranceFamilyDetail stateInsuranceFamilyDetailsInDb = _context.EmployeeStateInsuranceFamilyDetails.Where(x => x.emp_state_insu_fam_id == id).FirstOrDefault();

            if (stateInsuranceFamilyDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeStateInsuranceFamilyDetailForm", stateInsuranceFamilyDetailsInDb);
            }

            EmployeeStateInsuranceFamilyDetailFormViewModel viewModel = new EmployeeStateInsuranceFamilyDetailFormViewModel
            {
                emp_state_insu_fam_id = stateInsuranceFamilyDetailsInDb.emp_state_insu_fam_id,
                full_name = stateInsuranceFamilyDetailsInDb.full_name,
                relation_with_ip = stateInsuranceFamilyDetailsInDb.relation_with_ip,
                minor_major_id = stateInsuranceFamilyDetailsInDb.minor_major_id,
                birthdate = stateInsuranceFamilyDetailsInDb.birthdate,
                is_residing_with_ip = stateInsuranceFamilyDetailsInDb.is_residing_with_ip,
                state = stateInsuranceFamilyDetailsInDb.state,
                district = stateInsuranceFamilyDetailsInDb.district,
                city = stateInsuranceFamilyDetailsInDb.city,
                emp_state_insurance_id = int.Parse(Session["EmpStateInsuranceId"].ToString()),
                NomineeRelations = ManageDependancyData.GetBloodRelations(),
                YesNos = ManageDependancyData.YesNos(),
                Title = "Edit State Insurance Family Details"
            };

            return View("EmployeeStateInsuranceFamilyDetailForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeStateInsuranceFamilyDetailsDelete(int id)
        {
            EmployeeStateInsuranceFamilyDetail stateInsuranceFamilyDetailsInDb = _context.EmployeeStateInsuranceFamilyDetails.Where(x => x.emp_state_insu_fam_id == id).FirstOrDefault();

            if (stateInsuranceFamilyDetailsInDb == null)
            {
                ModelState.AddModelError("", "Not found.");
                return View("EmployeeStateInsuranceFamilyDetailForm", stateInsuranceFamilyDetailsInDb);
            }

            _context.EmployeeStateInsuranceFamilyDetails.Remove(stateInsuranceFamilyDetailsInDb);
            _context.SaveChanges();

            return RedirectToAction("EmployeeStateInsuranceFamilyDetailsIndex",
                new { emp_state_insurance_id = int.Parse(Session["EmpStateInsuranceId"].ToString()) });
        }
        #endregion

    }
}