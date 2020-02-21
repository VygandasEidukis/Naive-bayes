namespace Naive_bayes.Common.Models
{
    public class PenetrationDataPointDto
    {
        public int Id { get; set; }
        public bool? WillPen { get; set; }

        public virtual ArmorDto Armor { get; set; }
        public virtual AngleDto Angle { get; set; }
        public virtual PenetrationDto Penetration { get; set; }
        public virtual ShellSizeDto ShellSize { get; set; }
        public virtual ShellTypeDto ShellType { get; set; }

        public override string ToString()
        {
            if(WillPen == null)
                return $"{Armor} => {Angle} => {Penetration} => {ShellSize} => {ShellType} = Unknown";
            return $"{Armor} => {Angle} => {Penetration} => {ShellSize} => {ShellType} = {WillPen}";
        }
    }
}
