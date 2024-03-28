using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace api.Models
{
    public class CommentPost
    {
        public int CommentPostID { get; set; }
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}