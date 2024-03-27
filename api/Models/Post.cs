using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{ 
    public class Post
    {
        public int PostId { get; set; }
        public string  Type { get; set; } = string.Empty;
        public DateTime Posttime { get; set; }=DateTime.Now;
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}