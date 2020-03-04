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

        public static bool CanPenetrate(List<PenetrationDataPointDto> data, PenetrationDataPointDto dataPoint)
        {
            _dataPoint = dataPoint;
            _data = data;

            ExtractInitialData();
            GetPenetrationProbabilities();

            return true;
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
            _positiveShellType = evaluationShellType.Where(x => x.WillPen == true).Count() / _data.Where(x => x.WillPen == true).Count();
            _negativeShellType = evaluationShellType.Where(x => x.WillPen == false).Count() / _data.Where(x => x.WillPen == false).Count();
        }

        private static void GetShellSizeProbability()
        {
            var evaluationShellSizes = _data.Where(x => x.ShellSize.Id == _dataPoint.ShellSize.Id && x.WillPen != null);
            _positiveShellSize = evaluationShellSizes.Where(x => x.WillPen == true).Count() / _data.Where(x => x.WillPen == true).Count();
            _negativeShellSize = evaluationShellSizes.Where(x => x.WillPen == false).Count() / _data.Where(x => x.WillPen == false).Count();
        }

        private static void GetPenetrationProbability()
        {
            var evaluatedPenetrations = _data.Where(x => x.Penetration.Id == _dataPoint.Penetration.Id && x.WillPen != null);
            _positivePenetration = evaluatedPenetrations.Where(x => x.WillPen == true).Count() / _data.Where(x => x.WillPen == true).Count();
            _negativePenetration = evaluatedPenetrations.Where(x => x.WillPen == false).Count() / _data.Where(x => x.WillPen == false).Count();
        }

        private static void GetArmorProbability()
        {
            var evaluatedArmors = _data.Where(x => x.Armor.Id == _dataPoint.Armor.Id && x.WillPen != null);
            _positiveArmor = evaluatedArmors.Where(x => x.WillPen == true).Count() / _data.Where(x => x.WillPen == true).Count();
            _negativeArmor = evaluatedArmors.Where(x => x.WillPen == false).Count() / _data.Where(x => x.WillPen == false).Count();
        }

        private static void GetAngleProbability()
        {
            var evaluatedAngles = _data.Where(x => x.Angle.Id == _dataPoint.Angle.Id && x.WillPen != null);
            _positiveAngle = evaluatedAngles.Where(x => x.WillPen == true).Count() / _data.Where(x => x.WillPen == true).Count();
            _negativeAngle = evaluatedAngles.Where(x => x.WillPen == false).Count() / _data.Where(x => x.WillPen == false).Count();
        }

        private static void ExtractInitialData()
        {
            _positiveData = _data.FindAll(x => x.WillPen == true).Count;
            _negativeData = _data.FindAll(x => x.WillPen == false).Count;
            _overallData = _positiveData + _negativeData;
        }
    }
}
