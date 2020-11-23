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
                    Genders = ManageDependancyData.GetGenders()
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
                    pPhoto = viewModel.photo;
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
    }
}