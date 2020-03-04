using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Naive_bayes.Common.Models
{
    public static class NaiveBayes
    {
        private static List<PenetrationDataPointDto> _data { get; set; }
        private static PenetrationDataPointDto _dataPoint { get; set; }
        private static int _overallData { get; set; }
        private static int _positiveData { get; set; }
        private static int _negativeData { get; set; }

        #region positive/negative variables
        private static float _positiveAngle { get; set; }
        private static float _negativeAngle { get; set; }
        private static float _positiveArmor { get; set; }
        private static float _negativeArmor { get; set; }
        private static float _positivePenetration { get; set; }
        private static float _negativePenetration { get; set; }
        private static float _positiveShellSize { get; set; }
        private static float _negativeShellSize { get; set; }
        private static float _positiveShellType { get; set; }
        private static float _negativeShellType { get; set; }
        #endregion

        public static bool CanPenetrate(ICollection<PenetrationDataPointDto> data, PenetrationDataPointDto dataPoint)
        {
            _dataPoint = dataPoint;

            _data = new List<PenetrationDataPointDto>();
            foreach(var d in data)
            {
                _data.Add(d);
            }

            ExtractInitialData();
            GetPenetrationProbabilities();

            float overallPositive = _positiveAngle * _positiveArmor * _positivePenetration * _positiveShellSize * _positiveShellType;
            float overallNegative = _negativeAngle * _negativeArmor * _negativePenetration * _negativeShellSize * _negativeShellType;

            return overallPositive > overallNegative;
        }

        private static void GetPenetrationProbabilities()
        {
            GetAngleProbability();
            GetArmorProbability();
            GetPenetrationProbability();
            GetShellSizeProbability();
            GetShellTypeProbability();
        }

        private static void GetShellTypeProbability()
        {
            var evaluationShellType = _data.Where(x => x.ShellType.Id == _dataPoint.ShellType.Id && x.WillPen != null);

            float a = evaluationShellType.Where(x => x.WillPen == true).Count();
            float b = _data.Where(x => x.WillPen == true).Count();
            _positiveShellType = a / b;

            a = evaluationShellType.Where(x => x.WillPen == false).Count();
            b = _data.Where(x => x.WillPen == false).Count();
            _negativeShellType = a / b;
        }

        private static void GetShellSizeProbability()
        {
            var evaluationShellSizes = _data.Where(x => x.ShellSize.Id == _dataPoint.ShellSize.Id && x.WillPen != null);
            float a = _data.Where(x => x.WillPen == true).Count();
            float b = evaluationShellSizes.Where(x => x.WillPen == true).Count();
            _positiveShellSize = a / b;


            a = evaluationShellSizes.Where(x => x.WillPen == false).Count();
            b = _data.Where(x => x.WillPen == false).Count();
            _negativeShellSize = a / b;
        }

        private static void GetPenetrationProbability()
        {
            var evaluatedPenetrations = _data.Where(x => x.Penetration.Id == _dataPoint.Penetration.Id && x.WillPen != null);

            float a = evaluatedPenetrations.Where(x => x.WillPen == true).Count();
            float b = _data.Where(x => x.WillPen == true).Count();
            _positivePenetration = a / b;

            a = evaluatedPenetrations.Where(x => x.WillPen == false).Count();
            b = _data.Where(x => x.WillPen == false).Count();
            _negativePenetration = a / b;
        }

        private static void GetArmorProbability()
        {
            var evaluatedArmors = _data.Where(x => x.Armor.Id == _dataPoint.Armor.Id && x.WillPen != null);
            float a = evaluatedArmors.Where(x => x.WillPen == true).Count();
            float b = _data.Where(x => x.WillPen == true).Count();
            _positiveArmor = a / b;

            a = evaluatedArmors.Where(x => x.WillPen == false).Count();
            b = _data.Where(x => x.WillPen == false).Count();
            _negativeArmor = a / b;
        }

        private static void GetAngleProbability()
        {
            var evaluatedAngles = _data.Where(x => x.Angle.Id == _dataPoint.Angle.Id && x.WillPen != null);
            float a = evaluatedAngles.Where(x => x.WillPen == true).Count();
            float b = _data.Where(x => x.WillPen == true).Count();
            _positiveAngle = a / _data.Where(x => x.WillPen == true).Count();

            a = evaluatedAngles.Where(x => x.WillPen == false).Count();
            b = _data.Where(x => x.WillPen == false).Count();
            _negativeAngle = a / b;
        }

        private static void ExtractInitialData()
        {
            _positiveData = _data.Where(x => x.WillPen == true).Count();
            _negativeData = _data.Where(x => x.WillPen == false).Count();
            _overallData = _positiveData + _negativeData;
        }
    }
}
