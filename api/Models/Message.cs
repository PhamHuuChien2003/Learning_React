using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Message
    {
        public int MessageId { get; set; }  
        public string Content { get; set; } = string.Empty;
        public DateTime SendMessageTime { get; set; } = DateTime.Now ;
        public int? RelationshipMemberId { get; set; }
        public RelationshipMember? RelationshipMember { get; set; }
    }
}