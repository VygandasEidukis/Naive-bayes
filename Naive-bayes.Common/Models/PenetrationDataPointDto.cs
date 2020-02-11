using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public class PenetrationDataPointDto
    {
        public int Id { get; set; }
        public bool? WillPen { get; set; }

        public ArmorDto Armor { get; set; }
        public AngleDto Angle { get; set; }
        public PenetrationDto Penetration { get; set; }
        public ShellSizeDto ShellSize { get; set; }
        public ShellTypeDto ShellType { get; set; }
    }
}
