using HPPay.DataModel.MerchantDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.MerchantDashboard
{
    public interface IMerchantDashboardRepository
    {
        public Task<IEnumerable<MerchantDashboardKeyInformationModelOutput>> MerchantDashboardKeyInformation([FromBody] MerchantDashboardKeyInformationModelInput ObjClass);
        public Task<IEnumerable<MerchantDashboardLastTransactionModelOutput>> MerchantDashboardLastTransaction([FromBody] MerchantDashboardLastTransactionModelInput ObjClass);
        public Task<IEnumerable<MerchantDashboardLastBatchDeatilsModelOutput>> MerchantDashboardLastBatchDeatils([FromBody] MerchantDashboardLastBatchDeatilsModelInput ObjClass);
        public Task<IEnumerable<MerchantDashboardLastSaleReloadEarningDetailsModelOutput>> MerchantDashboardLastSaleReloadEarningDetails([FromBody] MerchantDashboardLastSaleReloadEarningDetailsModelInput ObjClass);
        public Task<IEnumerable<MerchantDashboardKeyEventsAndFiguresModelOutput>> MerchantDashboardKeyEventsAndFigures([FromBody] MerchantDashboardKeyEventsAndFiguresModelInput ObjClass);
        public Task<IEnumerable<MerchantDashboardTodaysTransactionSummaryModelOutput>> MerchantDashboardTodaysTransactionSummary([FromBody] MerchantDashboardTodaysTransactionSummaryModelInput ObjClass);
    }
}
