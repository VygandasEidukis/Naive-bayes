using Naive_bayes.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class ShellType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        internal ShellTypeDto ToDto()
        {
            var dto = new ShellTypeDto()
            {
                Id = this.Id,
                Type = this.Type
            };
            return dto;
        }
    }
}
