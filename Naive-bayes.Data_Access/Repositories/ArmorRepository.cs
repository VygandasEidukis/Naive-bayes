﻿using Naive_bayes.Common.Models;
using Naive_bayes.Common.Repositories;
using Naive_bayes.Data_Access.Contexts;
using Naive_bayes.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Repositories
{
    public class ArmorRepository : GenericRepository<Armor>, IArmorRepository
    {
        public ArmorRepository(PenetrationDataContext context) : base(context)
        {

        }

        public async System.Threading.Tasks.Task<IEnumerable<ArmorDto>> GetAsync()
        {
            var arnors = await this.GetAll();
            List<ArmorDto> armorDtos = new List<ArmorDto>();
            foreach (var armor in arnors)
                armorDtos.Add(armor.ToDto());

            return armorDtos;
        }

    }
}
