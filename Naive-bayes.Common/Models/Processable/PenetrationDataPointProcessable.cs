using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public class PenetrationDataPointProcessable : IPenetrationDataPoint
    {
        public float Positive { get; set; }
        public float Negative { get; set; }

        public int Id { get; set; }
        public bool? WillPen { get; set; }

        public ArmorDto Armor { get; set; }
        public AngleDto Angle { get; set; }
        public PenetrationDto Penetration { get; set; }
        public ShellSizeDto ShellSize { get; set; }
        public ShellTypeDto ShellType { get; set; }
    }
}
