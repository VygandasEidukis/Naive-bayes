using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public interface IPenetration
    {
        public int Id { get; set; }
        public string Penetration { get; set; }
    }
}
