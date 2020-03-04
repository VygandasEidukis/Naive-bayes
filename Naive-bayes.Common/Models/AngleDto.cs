﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public class AngleDto : IAngle
    {
        public int Id { get; set; }
        public string Angle { get; set; }

        public override string ToString()
        {
            return Angle;
        }
    }
}
