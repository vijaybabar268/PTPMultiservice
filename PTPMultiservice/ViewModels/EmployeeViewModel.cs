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

        public IEnumerable<EmployeeDocumentDetail> EmployeeDocumentDetails { get; set; }
        public IEnumerable<EmployeeBankDetail> EmployeeBankDetails { get; set; }
        public IEnumerable<EmployeePfDetail> EmployeePFDetails { get; set; }
        public IEnumerable<EmployeeStateInsuranceDetail> EmployeeStateInsuranceDetails { get; set; }
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

        [Display(Name = "Permanent Address")]
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

    public class EmployeeDocumentViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Employee Documents";
            }
        }

        public IEnumerable<EmployeeDocumentDetail> EmployeeDocumentDetails { get; set; }
        public IEnumerable<Dropdown> DocTypes { get; set; }
    }

    public class EmployeeDocumentFormViewModel
    {
        public int document_id { get; set; }

        [Display(Name = "Document Type")]
        public int type { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Number")]
        public string number { get; set; }

        [Display(Name = "Bithdate")]
        public DateTime birthdate { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        public int employee_id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Dropdown> DocTypes { get; set; }
    }

    public class EmployeeBankDetailViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Employee Bank Details";
            }
        }

        public IEnumerable<EmployeeBankDetail> EmployeeBankDetails { get; set; }
    }

    public class EmployeeBankDetailFormViewModel
    {
        public int bank_id { get; set; }

        [Display(Name = "Account No")]
        public string account_no { get; set; }

        [Display(Name = "Account Holder Name")]
        public string bank_holder_name { get; set; }

        [Display(Name = "Bank Name")]
        public string bank_name { get; set; }

        [Display(Name = "IFSC Code")]
        public string ifsc_code { get; set; }

        [Display(Name = "Branch Name")]
        public string branch_name { get; set; }

        public int employee_id { get; set; }

        public string Title { get; set; }
    }

    public class EmployeePfDetailViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Employee PF Details";
            }
        }

        public IEnumerable<EmployeePfDetail> EmployeePfDetails { get; set; }
    }

    public class EmployeePfDetailFormViewModel
    {
        public int pf_id { get; set; }

        [Display(Name = "Previous UAN No")]
        public string previous_uan_no { get; set; }

        [Display(Name = "Previous Account No")]
        public string previous_account_no { get; set; }

        [Display(Name = "Previous Company DOJ")]
        public DateTime previous_doj_company { get; set; }

        [Display(Name = "Previous Company DOL")]
        public DateTime previous_dol_company { get; set; }

        public int employee_id { get; set; }

        public string Title { get; set; }
    }

    public class EmployeeStateInsuranceDetailViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Employee State Insurance Details";
            }
        }

        public IEnumerable<EmployeeStateInsuranceDetail> EmployeeStateInsuranceDetails { get; set; }
        public IEnumerable<EmployeeStateInsuranceFamilyDetail> EmployeeStateInsuranceFamilyDetails { get; set; }
        public IEnumerable<Dropdown> Disabilities { get; set; }
        public IEnumerable<Dropdown> NomineeRelations { get; set; }
    }

    public class EmployeeStateInsuranceDetailFormViewModel
    {
        public int emp_state_insurance_id { get; set; }

        [Display(Name = "Disability")]
        public int disability_id { get; set; }

        [Display(Name = "Previous Employer Code")]
        public string previous_employer_code { get; set; }

        [Display(Name = "Previous Employer Name")]
        public string previous_employer_name { get; set; }

        [Display(Name = "Previous Employer Address")]
        public string previous_employer_address { get; set; }

        [Display(Name = "Previous IP No")]
        public string previous_ip_no { get; set; }

        [Display(Name = "Nominee Name")]
        public string nominee_name { get; set; }

        [Display(Name = "Nominee Address")]
        public string nominee_address { get; set; }

        [Display(Name = "Nominee Relation")]
        public int relation_with_nominee_id { get; set; }

        [Display(Name = "Sharing Percent Nominee")]
        public float per_share_towards_nominee { get; set; }

        public int employee_id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Dropdown> Disabilities { get; set; }
        public IEnumerable<Dropdown> NomineeRelations { get; set; }
    }

    public class EmployeeStateInsuranceFamilyDetailViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Employee State Insurance Family Details";
            }
        }

        public IEnumerable<EmployeeStateInsuranceFamilyDetail> EmployeeStateInsuranceFamilyDetails { get; set; }
        public IEnumerable<Dropdown> NomineeRelations { get; set; }
        public IEnumerable<Dropdown> YesNos { get; set; }
        public IEnumerable<Dropdown> MinorMajor { get; set; }
    }

    public class EmployeeStateInsuranceFamilyDetailFormViewModel
    {
        public int emp_state_insu_fam_id { get; set; }

        [Display(Name = "Full Name")]
        public string full_name { get; set; }

        [Display(Name = "Relation with IP")]
        public string relation_with_ip { get; set; }

        [Display(Name = "Minor/Major")]
        public string minor_major_id { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime birthdate { get; set; }

        [Display(Name = "Is Residing with IP")]
        public string is_residing_with_ip { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "District")]
        public string district { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        public int emp_state_insurance_id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Dropdown> NomineeRelations { get; set; }
        public IEnumerable<Dropdown> YesNos { get; set; }
        public IEnumerable<Dropdown> MinorMajor { get; set; }
    }
}