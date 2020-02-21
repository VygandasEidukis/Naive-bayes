using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public class ArmorDto
    {
        public int Id { get; set; }
        public string Armor { get; set; }

        public override string ToString()
        {
            return Armor;
        }
    }
}
