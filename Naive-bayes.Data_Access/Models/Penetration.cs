using Naive_bayes.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class Penetration
    {
        public int Id { get; set; }
        public string penetration { get; set; }

        public virtual ICollection<PenetrationDataPoint> PenetrationData { get; set; }

        public PenetrationDto ToDto()
        {
            var dto = new PenetrationDto()
            {
                Id = this.Id,
                Penetration = this.penetration
            };
            return dto;
        }
    }
}
