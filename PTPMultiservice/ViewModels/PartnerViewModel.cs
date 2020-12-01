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

        public IEnumerable<PartnerDocument> PartnerDocuments { get; set; }
        public IEnumerable<PartnerBankDetail> PartnerBankDetails { get; set; }
        public IEnumerable<PartnerTermsCondition> PartnerTermsConditions { get; set; }
        public IEnumerable<PartnerClientsMapping> MappedClients { get; set; }
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


    public class PartnerDocumentViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Documents";
            }
        }

        public IEnumerable<PartnerDocument> Documents { get; set; }
        public IEnumerable<Dropdown> DocumentTypes { get; set; }
    }

    public class PartnerDocumentFormViewModel
    {
        public int document_id { get; set; }

        [Display(Name = "Document Type")]
        public string type { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Number")]
        public string number { get; set; }

        [Display(Name = "Bithdate")]
        public DateTime? birthdate { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        public int partner_id { get; set; }

        public IEnumerable<Dropdown> DocTypes { get; set; }

        public string Title { get; set; }
    }

    public class PartnerBankDetailViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Bank Details";
            }
        }

        public IEnumerable<PartnerBankDetail> bankDetails { get; set; }
    }

    public class PartnerBankDetailFormViewModel
    {
        public int bank_id { get; set; }

        [Display(Name = "Account Number")]
        public string account_no { get; set; }

        [Display(Name = "Bank Holder Name")]
        public string bank_holder_name { get; set; }

        [Display(Name = "Bank Name")]
        public string bank_name { get; set; }

        [Display(Name = "IFSC Code")]
        public string ifsc_code { get; set; }

        [Display(Name = "Branch Name")]
        public string branch_name { get; set; }

        public int partner_id { get; set; }

        public string Title { get; set; }
    }


    public class PartnerTermsConditionViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Bank Details";
            }
        }

        public IEnumerable<PartnerTermsCondition> TermsConditions { get; set; }
    }

    public class PartnerTermsConditionFormViewModel
    {
        public int terms_condition_id { get; set; }

        [Display(Name = "PL Sharing Percent")]
        public float pl_sharing_percent { get; set; }

        [Display(Name = "Monthly Incentives")]
        public float monthly_incentives { get; set; }

        [Display(Name = "Yearly Incentives")]
        public float yearly_incentives { get; set; }

        [Display(Name = "Other Perks")]
        public float other_perks { get; set; }

        [Display(Name = "Notice Period in Days")]
        public int notice_period_in_days { get; set; }

        [Display(Name = "Any Other Terms and Conditions")]
        public string other_terms { get; set; }

        public int partner_id { get; set; }

        public string Title { get; set; }
    }

    public class MapClientsToPartnerViewModel
    {
        public string Title
        {
            get
            {
                return "Map Clients to Partner";
            }
        }

        public IEnumerable<PartnerClientsMapping> PartnerClientsMappings { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }

    public class MapClientsToPartnerFormViewModel
    {
        public int partner_client_map_id { get; set; }
        public int partner_id { get; set; }

        [Display(Name = "Select Client")]
        public int client_id { get; set; }
        public DateTime created_on { get; set; }
        public bool is_active { get; set; }

        public string Title { get; set; }

        public IEnumerable<Client> Clients { get; set; }
    }
}