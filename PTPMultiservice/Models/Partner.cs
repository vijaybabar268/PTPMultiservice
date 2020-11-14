using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTPMultiservice.Models
{
    [Table("partners")]
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
        public int? document_id { get; set; }
        public int? bank_id { get; set; }
        public int? terms_condition_id { get; set; }
        public bool is_active { get; set; }
        public DateTime created_on { get; set; }
    }
}