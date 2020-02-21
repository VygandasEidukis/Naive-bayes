using Naive_bayes.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Naive_bayes.Data_Access.Configurations
{
    public class PenetrationDataPointConfiguration : EntityTypeConfiguration<PenetrationDataPoint>
    {
        internal PenetrationDataPointConfiguration()
        {
            HasRequired(a => a.angle);
            HasRequired(a => a.armor);
            HasRequired(a => a.penetration);
            HasRequired(a => a.shellSize);
            HasRequired(a => a.shellType);
        }
    }
}
