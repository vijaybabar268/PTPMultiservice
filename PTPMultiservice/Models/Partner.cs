using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTPMultiservice.Models
{
    [Table("partner_master")]
    public class Partner
    {
        [Key]
        public int partner_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string mother_name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string tel { get; set; }
        public DateTime birth_date { get; set; }
        public int education_id { get; set; }
        public int designation_id { get; set; }
        public int marital_status_id { get; set; }
        public int gender_id { get; set; }
        public DateTime joining_date { get; set; }
        public string present_address { get; set; }
        public string permanent_address { get; set; }
        public string identity_body_mark { get; set; }
        public string remarks { get; set; }        
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
    }

    [Table("partner_document_detail")]
    public class PartnerDocument
    {
        [Key]
        public int document_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public DateTime? birthdate { get; set; }
        public string address { get; set; }
        public int partner_id { get; set; }
    }

    [Table("partner_bank_detail")]
    public class PartnerBankDetail
    {
        [Key]
        public int bank_id { get; set; }
        public string account_no { get; set; }
        public string bank_holder_name { get; set; }
        public string bank_name { get; set; }
        public string ifsc_code { get; set; }
        public string branch_name { get; set; }
        public int partner_id { get; set; }
    }

    [Table("partner_tearms_condition")]
    public class PartnerTermsCondition
    {
        [Key]
        public int terms_condition_id { get; set; }
        public float pl_sharing_percent { get; set; }
        public float monthly_incentives { get; set; }
        public float yearly_incentives { get; set; }
        public float other_perks { get; set; }
        public int notice_period_in_days { get; set; }
        public string other_terms { get; set; }
        public int partner_id { get; set; }
    }
}