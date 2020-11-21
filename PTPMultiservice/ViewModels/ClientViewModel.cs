using PTPMultiservice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTPMultiservice.Models.ManageDependancyData;

namespace PTPMultiservice.ViewModels
{
    public class ClientViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Clients";
            }
        }

        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Dropdown> Regions { get; set; }
        public IEnumerable<Dropdown> Industries { get; set; }
    }

    public class ClientFormViewModel
    {
        public int client_id { get; set; }

        [Display(Name = "Client Name")]
        public string client_name { get; set; }

        [Display(Name = "Region")]
        public int region_id { get; set; }

        [Display(Name = "Branch Name")]
        public string branch { get; set; }

        [Display(Name = "Industry")]
        public int industry_id { get; set; }

        [Display(Name = "Site Address")]
        public string site_address { get; set; }

        [Display(Name = "Corporate Office Address")]
        public string corporate_office_address { get; set; }

        [Display(Name = "Remarks")]
        public string remarks { get; set; }
        
        public DateTime created_on { get; set; }
        
        public bool is_active { get; set; }
        
        public string Title { get; set; }

        public IEnumerable<Dropdown> Regions { get; set; }

        public IEnumerable<Dropdown> Industries { get; set; }
    }
}