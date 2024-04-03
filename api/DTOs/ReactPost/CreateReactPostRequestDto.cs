using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.ReactPost
{
    public class CreateReactPostRequestDto
    {
        public int? PostID { get; set; }
        public string Type { get; set; }  =  string.Empty;
        public int? UserID { get; set; }
    }
}