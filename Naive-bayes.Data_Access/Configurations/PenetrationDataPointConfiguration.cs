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
            Property(x => x.WillPen).IsOptional();
        }
    }
}
