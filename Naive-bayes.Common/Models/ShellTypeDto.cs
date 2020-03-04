﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public class ShellTypeDto : IShellType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}
