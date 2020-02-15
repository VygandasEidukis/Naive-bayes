using Naive_bayes.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class PenetrationDataPoint : BaseModel
    {
        public bool? WillPen { get; set; }

        public Armor Armor { get; set; }
        public Angle Angle { get; set; }
        public Penetration Penetration { get; set; }
        public ShellSize ShellSize { get; set; }
        public ShellType ShellType { get; set; }

        public PenetrationDataPointDto ToDto()
        {
            var dto = new PenetrationDataPointDto()
            {
                Id = this.Id,
                Angle = new AngleDto() { Id = this.Angle.Id, Angle = this.Angle.angle },
                Armor = new ArmorDto() { Id = this.Armor.Id, Armor = this.Armor.armor }, 
                Penetration = new PenetrationDto() { Id = this.Penetration.Id, Penetration = this.Penetration.penetration }, 
                ShellSize = new ShellSizeDto() {  Id = this.ShellSize.Id, Size = this.ShellSize.Size },
                ShellType = new ShellTypeDto() { Id = this.ShellType.Id, Type = this.ShellType.Type }
            };
            return dto;
        }
    }
}
