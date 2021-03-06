﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public class PenetrationDto : IPenetration
    {
        public int Id { get; set; }
        public string Penetration { get; set; }

        public override string ToString()
        {
            return Penetration;
        }
    }
}
