using PTPMultiservice.Models;
using System.Collections.Generic;

namespace PTPMultiservice.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Partner> Partners { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}