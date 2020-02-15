﻿using Naive_bayes.Common.Models;
using Naive_bayes.Common.Repositories;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Repositories
{
    public class ShellSizeRepository : GenericRepository<ShellSize>, IShellSizeRepository
    {
        public ShellSizeRepository(PenetrationDataContext context) : base(context)
        {

        }

        public async System.Threading.Tasks.Task<IEnumerable<ShellSizeDto>> GetAsync()
        {
            var shells = await this.GetAll();
            List<ShellSizeDto> shellDtos = new List<ShellSizeDto>();
            foreach (var shell in shells)
                shellDtos.Add(shell.ToDto());

            return shellDtos;
        }
    }
}
