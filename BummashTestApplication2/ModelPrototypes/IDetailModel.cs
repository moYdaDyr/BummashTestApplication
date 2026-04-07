using BummashTestApplication;

namespace BummashTestApplication
{
    public interface IDetailModel
    {
        public int DiameterOuter {  get; set; }
        public int DiameterOuterBlank { get; set; }
        public int DiameterOuterBlankDelta { get; set; }

        public int DiameterInner { get; set; }
        public int DiameterInnerBlank { get; set; }
        public int DiameterInnerBlankDelta { get; set; }

        public int Height { get; set; }
        public int HeightBlank { get; set; }
        public int HeightBlankDelta { get; set; }

        public float MassNominal {  get; set; }
        public float MassMaximal { get; set; }

        public void CalculateModel(IInitialDetailModel initDetail);
    }
}
