using HPPay.DataModel.HDFCPG;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.FSE
{
    public interface IFSERepository
    {
        public Task<IEnumerable<FSEVerifyTPModelOutPut>> FSEValidateOTP([FromBody] FSEVerifyTPModelInput ObjClass);
        public Task<IEnumerable<FSEGenerateOTPModelOutPut>> FSEGenerateOTP([FromBody] FSEGenerateOTPModelInput ObjClass);
        public Task<IEnumerable<FSEGetDetailsModelOutPut>> FSEViewMerchantDetails([FromBody] FSEGetDetailsModelInput ObjClass);
        public Task<FSEGetDashboardDetailsModelOutPut> FSEViewDashboardDetails([FromBody] FSEGetDashboardDetailsModelInput ObjClass);
        public Task<IEnumerable<FSEGetTicketsDetailsModelOutPut>> FSEGetTicketDetails([FromBody] FSEGetTicketsDetailsModelInput ObjClass);
    }
} 