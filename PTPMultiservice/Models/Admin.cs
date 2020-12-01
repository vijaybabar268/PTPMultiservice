using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PTPMultiservice.Models
{
    [Table("admin_master")]
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime created_on { get; set; }
        public bool is_active { get; set; }
    }
}