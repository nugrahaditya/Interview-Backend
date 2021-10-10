using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moduit.Interview.Models
{
    public class QThree
    {
        public QThree()
        {
            Items = new List<QThreeItem>();
        }

        public int Id { get; set; }
        public int Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QThreeItem> Items { get; set; }
        public List<string> Tags { get; set; }
    }

    public class QThreeItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
    }
}
