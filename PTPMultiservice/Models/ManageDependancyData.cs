using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTPMultiservice.Models
{
    public class ManageDependancyData
    {
        public class Dropdown
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class CustomDropdown
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public static IEnumerable<Dropdown> YesNos()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Yes"},
                new Dropdown {Id =2, Name = "No"},
            };
        }

        public static IEnumerable<Dropdown> MinorMajor()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "MINOR"},
                new Dropdown {Id =2, Name = "MAJOR"},
            };
        }

        public static IEnumerable<Dropdown> DocumentTypes()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "PAN CARD"},
                new Dropdown {Id =2, Name = "ADHAR CARD"},
                new Dropdown {Id =3, Name = "PASSPORT"},
            };
        }

        public static IEnumerable<Dropdown> GetRegions()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "East"},
                new Dropdown {Id =2, Name = "West"},
                new Dropdown {Id =3, Name = "North"},
                new Dropdown {Id =4, Name = "South"}
            };
        }

        public static IEnumerable<Dropdown> GetBranchLocations()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Mumbai"},
                new Dropdown {Id =2, Name = "Tardev"},
                new Dropdown {Id =3, Name = "Vashi"},
                new Dropdown {Id =4, Name = "Andheri"}
            };
        }

        public static IEnumerable<Dropdown> GetIndustryTypes()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Corporate"},
                new Dropdown {Id =2, Name = "Manufacturing Unit"},
                new Dropdown {Id =3, Name = "Institute"},
                new Dropdown {Id =4, Name = "Bank"},
                new Dropdown {Id =5, Name = "Retail"},
                new Dropdown {Id =6, Name = "Healthcare"},
                new Dropdown {Id =7, Name = "Residential"},
                new Dropdown {Id =8, Name = "Educational"},
                new Dropdown {Id =9, Name = "Commercial"}
            };
        }

        public static IEnumerable<Dropdown> GetRoleResponsibilities()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Finance"},
                new Dropdown {Id =2, Name = "Administration"},
                new Dropdown {Id =3, Name = "Operations"},
                new Dropdown {Id =4, Name = "Facility Management"},
                new Dropdown {Id =5, Name = "Procurement"},
                new Dropdown {Id =6, Name = "Human Resource"}
            };
        }

        public static IEnumerable<Dropdown> GetDesignations()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Jr. Executive"},
                new Dropdown {Id =2, Name = "Executive"},
                new Dropdown {Id =3, Name = "Sr. Executive"},
                new Dropdown {Id =4, Name = "Deputy Manager"},
                new Dropdown {Id =5, Name = "Manager"},
                new Dropdown {Id =6, Name = "General Manager"},
                new Dropdown {Id =7, Name = "AVP"},
                new Dropdown {Id =8, Name = "VP"},
                new Dropdown {Id =9, Name = "Security Guard"},
                new Dropdown {Id =10, Name = "Partner"}
            };
        }

        public static IEnumerable<Dropdown> GetDepartments()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Finance"},
                new Dropdown {Id =2, Name = "Administration"},
                new Dropdown {Id =3, Name = "Operations"},
                new Dropdown {Id =4, Name = "Facility Management"},
                new Dropdown {Id =5, Name = "Procurement"},
                new Dropdown {Id =6, Name = "Human Resource"}
            };
        }

        public static IEnumerable<Dropdown> GetRelations()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Weak"},
                new Dropdown {Id =2, Name = "Developing"},
                new Dropdown {Id =3, Name = "Strong"},
                new Dropdown {Id =4, Name = "Excellent"}
            };
        }

        public static IEnumerable<Dropdown> GetManagementLevels()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name = "Junior"},
                new Dropdown {Id =2, Name = "Middle"},
                new Dropdown {Id =3, Name = "Senior"},
                new Dropdown {Id =4, Name = "Corporate"}
            };
        }


        // Employee Details
        public static IEnumerable<Dropdown> GetEducationQualification()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name="SSC"},
                new Dropdown {Id =2, Name="HSC"},
                new Dropdown {Id =3, Name="Graduate"}
            };
        }

        public static IEnumerable<Dropdown> GetMaritalStatus()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name="Married"},
                new Dropdown {Id =2, Name="Unmarried"},
                new Dropdown {Id =3, Name="Unknown"}
            };
        }

        public static IEnumerable<Dropdown> GetGenders()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name="Male"},
                new Dropdown {Id =2, Name="Famale"}
            };
        }

        public static IEnumerable<Dropdown> GetDisability()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name="NA"},
                new Dropdown {Id =2, Name="Hard of Hearing"},
                new Dropdown {Id =3, Name="Physical Disability"},
                new Dropdown {Id =3, Name="Vision Impairment"}
            };
        }

        public static IEnumerable<Dropdown> GetBloodRelations()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name="Mother"},
                new Dropdown {Id =2, Name="Father"},
                new Dropdown {Id =3, Name="Brother"},
                new Dropdown {Id =4, Name="Sister"},
                new Dropdown {Id =5, Name="Doughter"},
                new Dropdown {Id =6, Name="Wife"},
                new Dropdown {Id =6, Name="Son"}
            };
        }

        public static IEnumerable<Dropdown> GetMinorMajors()
        {
            return new List<Dropdown>()
            {
                new Dropdown {Id =1, Name="Minor"},
                new Dropdown {Id =2, Name="Major"}
            };
        }
    }
}