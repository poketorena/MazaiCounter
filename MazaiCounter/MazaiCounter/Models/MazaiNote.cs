using System;
using System.Collections.Generic;
using System.Text;

namespace MazaiCounter.Models
{
    public class MazaiNote
    {
        public DateTime Date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public MazaiType Type { get; set; }
        public string Memo { get; set; }
    }
}
