using PTPMultiservice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PTPMultiservice.Models.ManageDependancyData;

namespace PTPMultiservice.ViewModels
{
    public class EmployeeViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Employees";
            }
        }

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Dropdown> EducationQualifications { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> MaritalStatus { get; set; }
        public IEnumerable<Dropdown> Genders { get; set; }

    }

    public class EmployeeFormViewModel
    {
        public int employee_id { get; set; }

        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Display(Name = "Middle Name")]
        public string middle_name { get; set; }

        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Display(Name = "Mother Name")]
        public string mother_name { get; set; }

        [Display(Name = "Education")]
        public int education_id { get; set; }

        [Display(Name = "Designation")]
        public int designation_id { get; set; }

        [Display(Name = "Marital Status")]
        public int marital_status_id { get; set; }

        [Display(Name = "Gender")]
        public int gender_id { get; set; }

        [Display(Name = "Email Address")]
        public string email_address { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime birthdate { get; set; }

        [Display(Name = "Joining Date")]
        public DateTime joining_date { get; set; }

        [Display(Name = "Present Address")]
        public string present_address { get; set; }

        [Display(Name = "Permanent Name")]
        public string permanent_address { get; set; }

        [Display(Name = "Mobile No")]
        public string mobile_no { get; set; }

        [Display(Name = "Tel No")]
        public string tel_no { get; set; }

        [Display(Name = "Mark on Body")]
        public string mark_on_body { get; set; }

        [Display(Name = "Name & Reference 1")]
        public string name_and_contact_reference_1 { get; set; }

        [Display(Name = "Name & Reference 2")]
        public string name_and_contact_reference_2 { get; set; }

        [Display(Name = "Upload Photo")]
        public string photo { get; set; }

        public DateTime created_on { get; set; }

        public bool is_active { get; set; }

        public string Title { get; set; }

        public IEnumerable<Dropdown> EducationQualifications { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> MaritalStatus { get; set; }
        public IEnumerable<Dropdown> Genders { get; set; }
    }
}