using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ReactPost
    {
        public int ReactPostID { get; set; }    
        public int? PostID { get; set; }
        public Post? Post { get; set; }
        public string Type { get; set; }  =  string.Empty;
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}