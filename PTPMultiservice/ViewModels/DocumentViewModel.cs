using PTPMultiservice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PTPMultiservice.Models.ManageDependancyData;

namespace PTPMultiservice.ViewModels
{
    public class DocumentViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Documents";
            }
        }

        public IEnumerable<Document> Documents { get; set; }
        public IEnumerable<Dropdown> DocumentTypes { get; set; }
    }

    public class DocumentFormViewModel
    {
        public int document_id { get; set; }
        
        [Display(Name ="Document Type")]
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
}