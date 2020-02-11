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
    }
}
