using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserAccount
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
    }
}