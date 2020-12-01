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

        public IEnumerable<ClientContactDetail> ClientContactDetails { get; set; }
        public IEnumerable<ClientRelation> ClientRelations { get; set; }
        public IEnumerable<ClientEmployeesMapping> MappedEmployees { get; set; }
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


    public class ClientContactViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Client Contacts";
            }
        }

        public IEnumerable<ClientContactDetail> ClientContactDetails { get; set; }
        public IEnumerable<Dropdown> Designations { get; set; }
        public IEnumerable<Dropdown> ManagementLevels { get; set; }
        public IEnumerable<Dropdown> Departments { get; set; }
    }

    public class ClientContactFormViewModel
    {
        public int contact_id { get; set; }

        [Display(Name = "Contact Name")]
        public string contact_name { get; set; }

        public IEnumerable<Dropdown> Designations { get; set; }
        [Display(Name = "Designation")]
        public int designation_id { get; set; }

        public IEnumerable<Dropdown> ManagementLevels { get; set; }
        [Display(Name = "Management Level")]
        public int management_level_id { get; set; }

        public IEnumerable<Dropdown> Departments { get; set; }
        [Display(Name = "Department")]
        public int department_id { get; set; }

        [Display(Name = "Reorting Manager")]
        public string reporting_manager { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime? birthdate { get; set; }

        [Display(Name = "Email Address")]
        public string email_id { get; set; }

        [Display(Name = "Mobile Number")]
        public string mobile_no { get; set; }

        [Display(Name = "Tel Number")]
        public string tel_no { get; set; }

        public int client_id { get; set; }

        public string Title { get; set; }
    }

    public class ClientRelationViewModel
    {
        public string Title
        {
            get
            {
                return "Manage Client Relations";
            }
        }

        public IEnumerable<ClientRelation> ClientRelations { get; set; }
        public IEnumerable<Dropdown> Relations { get; set; }
    }

    public class ClientRelationFormViewModel
    {
        public int relation_id { get; set; }

        [Display(Name = "Relation Name")]
        public string relation_name { get; set; }

        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        public int client_id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Dropdown> Relations { get; set; }
    }

    public class MapEmployeesToClientViewModel
    {
        public string Title
        {
            get
            {
                return "Map Employees to Client";
            }
        }

        public IEnumerable<ClientEmployeesMapping> ClientEmployeesMappings { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }

    public class MapEmployeesToClientFormViewModel
    {
        public int client_employee_map_id { get; set; }
        
        public int client_id { get; set; }

        [Display(Name = "Select Employee")]
        public int employee_id { get; set; }

        public DateTime created_on { get; set; }
        public bool is_active { get; set; }

        public string Title { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }

}