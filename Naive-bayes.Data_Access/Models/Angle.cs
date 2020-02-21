using Naive_bayes.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class Angle
    {
        public int Id { get; set; }
        public string angle { get; set; }

        public virtual ICollection<PenetrationDataPoint> PenetrationData { get; set; }

        internal AngleDto ToDto()
        {
            var dto = new AngleDto()
            {
                Id = this.Id,
                Angle = this.angle
            };
            return dto;
        }
    }
}
