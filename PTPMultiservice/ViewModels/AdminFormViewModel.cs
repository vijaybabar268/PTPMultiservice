using System;
using System.Linq;
using System.Web;

namespace PTPMultiservice.ViewModels
{
    public class AdminFormViewModel
    {
        public int admin_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime created_on { get; set; }
        public bool is_active { get; set; }
    }
}