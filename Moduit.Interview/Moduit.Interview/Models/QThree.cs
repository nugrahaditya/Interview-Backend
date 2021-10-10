﻿using System;
using System.Collections.Generic;

namespace Moduit.Interview.Models
{
    public class QThree
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string Footer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
