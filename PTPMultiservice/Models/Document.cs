using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTPMultiservice.Models
{
    [Table("document_master")]
    public class Document
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
}