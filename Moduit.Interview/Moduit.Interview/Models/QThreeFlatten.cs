using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moduit.Interview.Models
{
    public class QThreeFlatten
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string Footer { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool ShouldSerializeTags()
        {
            return Tags != null || Tags.Any();
        }
    }
}
