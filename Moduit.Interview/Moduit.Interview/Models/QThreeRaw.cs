using System;
using System.Collections.Generic;

namespace Moduit.Interview.Models
{
    public class QThreeRaw
    {
        public QThreeRaw()
        {
            Items = new List<QThreeRawItem>();
        }

        public int Id { get; set; }
        public int Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QThreeRawItem> Items { get; set; }
        public List<string> Tags { get; set; }
    }

    public class QThreeRawItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
    }
}
