using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RelationshipMember
    {
        public int? UserId { get; set; }
        public User? User{ get; set; }
        public int? RelationshipId { get; set; }
        public Relationship? Relationship { get; set; }
    }
}