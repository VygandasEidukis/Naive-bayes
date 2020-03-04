using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public interface IShellType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
