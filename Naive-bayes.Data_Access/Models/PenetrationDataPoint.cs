using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class PenetrationDataPoint
    {
        public int Id { get; set; }
        public bool? WillPen { get; set; }

        public Armor Armor { get; set; }
        public Angle Angle { get; set; }
        public Penetration Penetration { get; set; }
        public ShellSize ShellSize { get; set; }
        public ShellType ShellType { get; set; }
    }
}
