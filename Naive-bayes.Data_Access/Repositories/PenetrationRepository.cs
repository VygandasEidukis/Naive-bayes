using Naive_bayes.Common.Models;
using Naive_bayes.Common.Repositories;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Naive_bayes.Data_Access.Repositories
{
    public class PenetrationRepository : GenericRepository<Penetration>, IPenetrationRepository
    {
        public PenetrationRepository(PenetrationDataContext context) : base(context)
        {
            
        }

        public async Task<PenetrationDto> Get(int id)
        {
            var pen = await Find(id);
            return pen.ToDto();
        }

        public async System.Threading.Tasks.Task<IEnumerable<PenetrationDto>> GetAsync()
        {
            var penetrations = await this.GetAll();
            List<PenetrationDto> penetrationDtos = new List<PenetrationDto>();
            foreach (var penetration in penetrations)
                penetrationDtos.Add(penetration.ToDto());

            return penetrationDtos;
        }
    }
}
