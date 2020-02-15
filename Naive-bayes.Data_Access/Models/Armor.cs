using Naive_bayes.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class Armor
    {
        public int Id { get; set; }
        public string armor { get; set; }

        internal ArmorDto ToDto()
        {
            var dto = new ArmorDto()
            {
                Id = this.Id,
                Armor = this.armor
            };
            return dto;
        }
    }
}
