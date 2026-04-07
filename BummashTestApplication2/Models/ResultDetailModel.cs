using BummashTestApplication.ModelPrototypes;

namespace BummashTestApplication
{
    public class ResultDetailModel : IResultDetailModel
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

        public int DiameterOuterProbe { get; set; }
        public int DiameterOuterBlankProbe { get; set; }
        public int DiameterOuterBlankDeltaProbe { get; set; }

        public int DiameterInnerProbe { get; set; }
        public int DiameterInnerBlankProbe { get; set; }
        public int DiameterInnerBlankDeltaProbe { get; set; }

        public int HeightProbe { get; set; }
        public int HeightBlankProbe { get; set; }
        public int HeightBlankDeltaProbe { get; set; }

        public float MassNominalProbe { get; set; }
        public float MassMaximalProbe { get; set; }

        public ResultDetailModel(IDetailModel detail1,  IDetailModel detail2)
        {
            DiameterOuter = detail1.DiameterOuter;
            DiameterOuterBlank = detail1.DiameterOuterBlank;
            DiameterOuterBlankDelta = detail1.DiameterOuterBlankDelta;

            DiameterInner = detail1.DiameterInner;
            DiameterInnerBlank = detail1.DiameterInnerBlank;
            DiameterInnerBlankDelta = detail1.DiameterInnerBlankDelta;

            Height = detail1.Height;
            HeightBlank = detail1.HeightBlank;
            HeightBlankDelta = detail1.HeightBlankDelta;

            MassNominal = detail1.MassNominal;
            MassMaximal = detail1.MassMaximal;

            // 

            DiameterOuterProbe = detail2.DiameterOuter;
            DiameterOuterBlankProbe = detail2.DiameterOuterBlank;
            DiameterOuterBlankDeltaProbe = detail2.DiameterOuterBlankDelta;

            DiameterInnerProbe = detail2.DiameterInner;
            DiameterInnerBlankProbe = detail2.DiameterInnerBlank;
            DiameterInnerBlankDeltaProbe = detail2.DiameterInnerBlankDelta;

            HeightProbe = detail2.Height;
            HeightBlankProbe = detail2.HeightBlank;
            HeightBlankDeltaProbe = detail2.HeightBlankDelta;

            MassNominalProbe = detail2.MassNominal;
            MassMaximalProbe = detail2.MassMaximal;
        }
    }
}
