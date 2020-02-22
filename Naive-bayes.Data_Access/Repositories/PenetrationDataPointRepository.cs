using Naive_bayes.Common.Models;
using Naive_bayes.Common.Repositories;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Naive_bayes.Data_Access.Repositories
{
    public class PenetrationDataPointRepository : GenericRepository<PenetrationDataPoint>, IPenetraionDataPointRepository
    {
        public PenetrationDataPointRepository(PenetrationDataContext context) :base(context)
        {

        }

        public async Task<IEnumerable<PenetrationDataPointDto>> GetAsync()
        {
            var dataPoints = Context.PenetrationDataPoints
                .Include(x => x.angle)
                .Include(a => a.armor)
                .Include(b => b.penetration)
                .Include(c => c.shellSize)
                .Include(d => d.shellType);

            List<PenetrationDataPointDto> dataPointDtos = new List<PenetrationDataPointDto>();
            foreach (var point in dataPoints)
            {
                var dPoint = point.ToDto();
                dataPointDtos.Add(dPoint);
            }
                

            return dataPointDtos;
        }

        public async Task CreateNewDataPoint(PenetrationDataPointDto penetrationDataPoint)
        {
            var dataPoint = new PenetrationDataPoint()
            {
                angleId = penetrationDataPoint.Angle.Id, 
                armorId = penetrationDataPoint.Armor.Id,
                penetrationId = penetrationDataPoint.Penetration.Id,
                shellSizeId = penetrationDataPoint.ShellSize.Id,
                shellTypeId = penetrationDataPoint.ShellType.Id,
                WillPen = penetrationDataPoint.WillPen,
                angle = await Context.Angles.FirstOrDefaultAsync(a => a.Id == penetrationDataPoint.Angle.Id),
                armor = await Context.Armors.FirstOrDefaultAsync(a => a.Id == penetrationDataPoint.Armor.Id),
                penetration = await Context.Penetrations.FirstOrDefaultAsync(a => a.Id == penetrationDataPoint.Penetration.Id),
                shellSize = await Context.ShellSizes.FirstOrDefaultAsync(a => a.Id == penetrationDataPoint.ShellSize.Id),
                shellType = await Context.ShellTypes.FirstOrDefaultAsync(a => a.Id == penetrationDataPoint.ShellType.Id)
            };
            await Add(dataPoint).ConfigureAwait(true);
            await SaveChanges();
        }
    }
}
