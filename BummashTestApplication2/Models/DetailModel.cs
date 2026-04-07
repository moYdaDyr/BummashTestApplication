using BummashTestApplication;

namespace BummashTestApplication
{
    public class DetailModel : IDetailModel
    {
        public int DiameterOuter { get; set; }
        public int DiameterOuterBlank { get; set; }
        public int DiameterOuterBlankDelta { get; set; }

        public int DiameterInner { get; set; }
        public int DiameterInnerBlank { get; set; }
        public int DiameterInnerBlankDelta { get; set; }

        public int Height { get; set; }
        public int HeightBlank { get; set; }
        public int HeightBlankDelta { get; set; }

        public float MassNominal { get; set; }
        public float MassMaximal { get; set; }

        public void CalculateModel(IInitialDetailModel initDetail)
        {
            DiameterOuter = initDetail.DiameterOuter + initDetail.ThermoOverlap;
            DiameterInner = initDetail.DiameterInner - initDetail.ThermoOverlap;
            Height = initDetail.Height;

            var tolerances = ConfigurationsSingleton.Instance.ToleranceData.GetToleranceValueFromTable(Height, DiameterOuter);
            int b = tolerances.Item1;
            int delta = tolerances.Item2;

            HeightBlank = initDetail.Height * initDetail.NumberOfDetails + initDetail.CutLength * (initDetail.NumberOfDetails - 1) + initDetail.ThermoOverlap;
            HeightBlankDelta = delta;

            DiameterOuterBlank = DiameterOuter + b + initDetail.ThermoOverlap;
            DiameterOuterBlankDelta = delta;

            DiameterInnerBlank = DiameterInner - b;
            DiameterInnerBlankDelta = 3 * delta;

            float diskMassNominal, diskMassMaximal;
            float holeMassNominal, holeMassMaximal;

            diskMassNominal = ConfigurationsSingleton.Instance.SteelDensity * (ConfigurationsSingleton.Instance.Pi * (DiameterOuterBlank / 2) * (DiameterOuterBlank / 2) * HeightBlank);
            diskMassMaximal = ConfigurationsSingleton.Instance.SteelDensity * (ConfigurationsSingleton.Instance.Pi * ((DiameterOuterBlank + DiameterOuterBlankDelta) / 2) * ((DiameterOuterBlank + DiameterOuterBlankDelta) / 2) * (HeightBlank + HeightBlankDelta));

            holeMassNominal = ConfigurationsSingleton.Instance.SteelDensity * (ConfigurationsSingleton.Instance.Pi * (DiameterInnerBlank / 2) * (DiameterInnerBlank / 2) * HeightBlank);
            holeMassMaximal = ConfigurationsSingleton.Instance.SteelDensity * (ConfigurationsSingleton.Instance.Pi * ((DiameterInnerBlank - DiameterInnerBlankDelta) / 2) * ((DiameterInnerBlank - DiameterInnerBlankDelta) / 2) * (HeightBlank + HeightBlankDelta));

            MassNominal = diskMassNominal - holeMassNominal;
            MassMaximal = diskMassMaximal - holeMassMaximal;
        }
    }
}
