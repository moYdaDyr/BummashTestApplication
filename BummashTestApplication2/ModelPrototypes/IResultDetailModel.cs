namespace BummashTestApplication.ModelPrototypes
{
    public interface IResultDetailModel
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
    }
}
