namespace BummashTestApplication
{
    public interface IInitialDetailModel
    {
        public int DiameterOuter { get; set; }

        public int DiameterInner { get; set; }

        public int Height { get; set; }

        public int NumberOfDetails { get; set; }

        public int CutLength { get; set; }

        public int ProbingOverlap { get; set; }

        public int ThermoOverlap { get; set; }
    }
}
