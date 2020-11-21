using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTPMultiservice.Models
{
    [Table("clients")]
    public class Client
    {
        [Key]
        public int client_id { get; set; }
        public string client_name { get; set; }
        public int region_id { get; set; }
        public string branch { get; set; }
        public int industry_id { get; set; }
        public string site_address { get; set; }
        public string corporate_office_address { get; set; }
        public string remarks { get; set; }        
        public DateTime created_on { get; set; }
        public bool is_active { get; set; }
    }

    [Table("client_contact_details")]
    public class ClientContactDetail
    {
        [Key]
        public int contact_id { get; set; }
        public string contact_name { get; set; }
        public int designation_id { get; set; }
        public int management_level_id { get; set; }
        public int department_id { get; set; }
        public string reporting_manager { get; set; }
        public DateTime? birthdate { get; set; }
        public string email_id { get; set; }
        public string mobile_no { get; set; }
        public string tel_no { get; set; }
        public int client_id { get; set; }
    }

    [Table("client_relations")]
    public class ClientRelation
    {
        [Key]
        public int relation_id { get; set; }
        public string relation_name { get; set; }
        public string remarks { get; set; }
        public int client_id { get; set; }
    }
}