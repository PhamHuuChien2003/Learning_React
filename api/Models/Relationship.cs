using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace api.Models
{
    public class Relationship
    {
        public int RelationshipId { get; set; }
        public DateTime StartTime { get; set;} = DateTime.Now ;
        public string Type { get; set; } = string.Empty;
        public List<RelationshipMember> RelationshipMembers { get; set; } = new List<RelationshipMember>() ;

    }
}