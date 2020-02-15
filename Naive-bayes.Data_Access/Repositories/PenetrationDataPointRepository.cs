using Naive_bayes.Common.Models;
using Naive_bayes.Common.Repositories;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Repositories
{
    public class PenetrationDataPointRepository : GenericRepository<PenetrationDataPoint>, IPenetraionDataPointRepository
    {
        public PenetrationDataPointRepository(PenetrationDataContext context) :base(context)
        {

        }

        public async System.Threading.Tasks.Task<IEnumerable<PenetrationDataPointDto>> GetAsync()
        {
            var dataPoints = await this.GetAll();
            List<PenetrationDataPointDto> dataPointDtos = new List<PenetrationDataPointDto>();
            foreach (var point in dataPoints)
                dataPointDtos.Add(point.ToDto());

            return dataPointDtos;
        }
    }
}
