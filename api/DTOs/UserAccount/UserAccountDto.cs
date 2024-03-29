using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.UserAccount
{
    public class UserAccountDto
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}