using Naive_bayes.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class ShellSize
    {
        public int Id { get; set; }
        public string Size { get; set; }

        public virtual ICollection<PenetrationDataPoint> PenetrationData { get; set; }

        internal ShellSizeDto ToDto()
        {
            var dto = new ShellSizeDto()
            {
                Id = this.Id,
                Size = this.Size
            };
            return dto;
        }
    }
}
