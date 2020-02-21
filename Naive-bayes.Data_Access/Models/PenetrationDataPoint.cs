using Naive_bayes.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naive_bayes.Data_Access.Models
{
    public class PenetrationDataPoint : BaseModel
    {
        public bool? WillPen { get; set; }

        public int armorId { get; set; }
        public int angleId { get; set; }
        public int penetrationId { get; set; }
        public int shellSizeId { get; set; }
        public int shellTypeId { get; set; }

        public Armor armor { get; set; }
        public Angle angle { get; set; }
        public Penetration penetration { get; set; }
        public ShellSize shellSize { get; set; }
        public ShellType shellType { get; set; }

        public PenetrationDataPoint(){}

        public PenetrationDataPoint(PenetrationDataPointDto dto)
        {
            Reset();
            armor.Id = dto.Armor.Id;
            angle.Id = dto.Angle.Id;
            penetration.Id = dto.Penetration.Id;
            shellSize.Id = dto.ShellSize.Id;
            shellType.Id = dto.ShellType.Id;
        }

        private void Reset()
        {
            armor = new Armor();
            angle = new Angle();
            penetration = new Penetration();
            shellSize = new ShellSize();
            shellType = new ShellType();
        }

        public PenetrationDataPointDto ToDto()
        {
            var dto = new PenetrationDataPointDto()
            {
                Id = this.Id,
                Angle = new AngleDto() { Id = this.angle.Id, Angle = this.angle.angle },
                Armor = new ArmorDto() { Id = this.armor.Id, Armor = this.armor.armor }, 
                Penetration = new PenetrationDto() { Id = this.penetration.Id, Penetration = this.penetration.penetration }, 
                ShellSize = new ShellSizeDto() {  Id = this.shellSize.Id, Size = this.shellSize.Size },
                ShellType = new ShellTypeDto() { Id = this.shellType.Id, Type = this.shellType.Type }
            };
            return dto;
        }
    }
}
