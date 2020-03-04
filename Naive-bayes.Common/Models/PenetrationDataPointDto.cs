namespace Naive_bayes.Common.Models
{
    public class PenetrationDataPointDto : IPenetrationDataPoint
    {
        public int Id { get; set; }
        public bool? WillPen { get; set; }

        public ArmorDto Armor { get; set; }
        public AngleDto Angle { get; set; }
        public PenetrationDto Penetration { get; set; }
        public ShellSizeDto ShellSize { get; set; }
        public ShellTypeDto ShellType { get; set; }

        public override string ToString()
        {
            if(WillPen == null)
                return $"{Armor} => {Angle} => {Penetration} => {ShellSize} => {ShellType} = Unknown";
            return $"{Armor} => {Angle} => {Penetration} => {ShellSize} => {ShellType} = {WillPen}";
        }
    }
}
