namespace BummashTestApplication
{
    public interface IDetailService
    {
        public IDetailModel CalculateDetail(IInitialDetailModel initDetail, IDetailModel detail);
    }
}
