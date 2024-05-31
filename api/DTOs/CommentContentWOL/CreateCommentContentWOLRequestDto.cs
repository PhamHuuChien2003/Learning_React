using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CommentContentWOL
{
    public class CreateCommentContentWOLRequestDto
    {
        public int? CommentPostID { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "Content must be at least 5 character")]
        [MaxLength(280,ErrorMessage = "Content cannot be over 280 character")]
        public string CommentContent { get; set; } = string.Empty;
    }
}