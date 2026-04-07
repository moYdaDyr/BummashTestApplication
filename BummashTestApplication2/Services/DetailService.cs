namespace BummashTestApplication
{
    public class DetailService : IDetailService
    {
        public IDetailModel CalculateDetail(IInitialDetailModel initDetail, IDetailModel detail)
        {
            detail.CalculateModel(initDetail);
            return detail;
        }
    }
}
