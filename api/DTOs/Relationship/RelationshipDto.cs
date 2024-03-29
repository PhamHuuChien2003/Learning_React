using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Relationship
{
    public class RelationshipDto
    {
        public int RelationshipId { get; set; }
        public DateTime StartTime { get; set;} = DateTime.Now ;
        public string Type { get; set; } = string.Empty;
    }
}