using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Message
{
    public class CreateMessagerequestDto
    {
        [Required]
        [MinLength(5,ErrorMessage = "Content must be at least 5 character")]
        [MaxLength(280,ErrorMessage = "Content cannot be over 280 character")]
        public string Content { get; set; } = string.Empty;
        public DateTime SendMessageTime { get; set; } = DateTime.Now ;
        public int? RelationshipMemberId { get; set; }
    }
}