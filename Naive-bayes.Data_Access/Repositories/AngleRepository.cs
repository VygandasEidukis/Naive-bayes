using Naive_bayes.Common.Models;
using Naive_bayes.Common.Repositories;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Repositories
{
    public class AngleRepository : GenericRepository<Angle>, IAngleRepository
    {
        public AngleRepository(PenetrationDataContext context) : base(context)
        {

        }

        public async System.Threading.Tasks.Task<IEnumerable<AngleDto>> GetAsync()
        {
            var angles = await this.GetAll();
            List<AngleDto> angleDtos = new List<AngleDto>();
            foreach (var point in angles)
                angleDtos.Add(point.ToDto());

            return angleDtos;
        }
    }
}
