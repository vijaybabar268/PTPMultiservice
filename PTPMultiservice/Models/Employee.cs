using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PTPMultiservice.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string mother_name { get; set; }
        public int education_id { get; set; }
        public int designation_id { get; set; }
        public int marital_status_id { get; set; }
        public int gender_id { get; set; }
        public string email_address { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime joining_date { get; set; }
        public string present_address { get; set; }
        public string permanent_address { get; set; }
        public string mobile_no { get; set; }
        public string tel_no { get; set; }
        public string mark_on_body { get; set; }
        public string name_and_contact_reference_1 { get; set; }
        public string name_and_contact_reference_2 { get; set; }
        public string photo { get; set; }
        public DateTime created_on { get; set; }
        public bool is_active { get; set; }
    }
    
    [Table("emp_document_details")]
    public class EmployeeDocumentDetail
    {
        [Key]
        public int document_id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public DateTime birthdate { get; set; }
        public string address { get; set; }

        public int employee_id { get; set; }
    }

    [Table("emp_bank_details")]
    public class EmployeeBankDetail
    {
        [Key]
        public int bank_id { get; set; }
        public string account_no { get; set; }
        public string bank_holder_name { get; set; }
        public string bank_name { get; set; }
        public string ifsc_code { get; set; }
        public string branch_name { get; set; }

        public int employee_id { get; set; }
    }

    [Table("emp_pf_details")]
    public class EmployeePfDetail
    {
        [Key]
        public int pf_id { get; set; }
        public string previous_uan_no { get; set; }
        public string previous_account_no { get; set; }
        public DateTime previous_doj_company { get; set; }
        public DateTime previous_dol_company { get; set; }

        public int employee_id { get; set; }
    }

    [Table("emp_state_insurance_details")]
    public class EmployeeStateInsuranceDetail
    {
        [Key]
        public int emp_state_insurance_id { get; set; }
        public int disability_id { get; set; }
        public string previous_employer_code { get; set; }
        public string previous_employer_name { get; set; }
        public string previous_employer_address { get; set; }
        public string previous_ip_no { get; set; }
        public string nominee_name { get; set; }
        public string nominee_address { get; set; }
        public int relation_with_nominee_id { get; set; }
        public float per_share_towards_nominee { get; set; }

        public int employee_id { get; set; }    
    }

    [Table("emp_state_insurance_family_details")]
    public class EmployeeStateInsuranceFamilyDetail
    {
        [Key]
        public int emp_state_insu_fam_id { get; set; }
        public string full_name { get; set; }
        public string relation_with_ip { get; set; }
        public string minor_major_id { get; set; }
        public DateTime birthdate { get; set; }
        public string is_residing_with_ip { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string city { get; set; }

        public int emp_state_insurance_id { get; set; }
    }


}