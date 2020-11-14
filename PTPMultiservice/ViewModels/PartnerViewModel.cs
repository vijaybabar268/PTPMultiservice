using PTPMultiservice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PTPMultiservice.Models.ManageDependancyData;

namespace PTPMultiservice.ViewModels
{
    public class PartnerViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Partners";
            }
        }

        public IEnumerable<Partner> Partners { get; set; }
        public IEnumerable<Dropdown> EducationQualifications { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> MaritalStatus { get; set; }
        public IEnumerable<Dropdown> Genders { get; set; }
    }

    public class PartnerFormViewModel
    {
        public int partner_id { get; set; }

        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Display(Name = "Middle Name")]
        public string middle_name { get; set; }

        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Display(Name = "Mother Name")]
        public string mother_name { get; set; }

        [Display(Name = "Email Address")]
        public string email { get; set; }

        [Display(Name = "Mobile Number")]
        public string mobile { get; set; }

        [Display(Name = "Telephone")]
        public string tel { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime birth_date { get; set; }

        [Display(Name = "Select Education")]
        public int education_id { get; set; }

        [Display(Name = "Select Designation")]
        public int designation_id { get; set; }

        [Display(Name = "Select Marital Status")]
        public int marital_status_id { get; set; }

        [Display(Name = "Select Gender")]
        public int gender_id { get; set; }

        [Display(Name = "Joining Date")]
        public DateTime joining_date { get; set; }

        [Display(Name = "Present Address")]
        public string present_address { get; set; }

        [Display(Name = "Permanent Address")]
        public string permanent_address { get; set; }

        [Display(Name = "Identity Mark on Body")]
        public string identity_body_mark { get; set; }

        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        public int? document_id { get; set; }
        
        public int? bank_id { get; set; }
        
        public int? terms_condition_id { get; set; }
        
        public bool is_active { get; set; }
        
        public DateTime created_on { get; set; }

        public IEnumerable<Dropdown> EducationQualifications { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> MaritalStatus { get; set; }
        public IEnumerable<Dropdown> Genders { get; set; }

        public string Title { get; set; }
    }
}