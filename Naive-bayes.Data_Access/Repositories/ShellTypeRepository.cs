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
    public class ShellTypeRepository : GenericRepository<ShellType>, IShellTypeRepository
    {
        public ShellTypeRepository(PenetrationDataContext context) : base(context)
        {

        }

        public async Task<ShellTypeDto> Get(int id)
        {
            var pen = await Find(id);
            return pen.ToDto();
        }

        public async System.Threading.Tasks.Task<IEnumerable<ShellTypeDto>> GetAsync()
        {
            var shells = await this.GetAll();
            List<ShellTypeDto> shellDtos = new List<ShellTypeDto>();
            foreach (var shell in shells)
                shellDtos.Add(shell.ToDto());

            return shellDtos;
        }
    }
}
