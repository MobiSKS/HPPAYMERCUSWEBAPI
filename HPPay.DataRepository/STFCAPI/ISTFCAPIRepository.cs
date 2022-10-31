
using HPPay.DataModel.STFCAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
namespace HPPay.DataRepository.STFCAPI
{
    public interface ISTFCAPIRepository
    {

        Task<IEnumerable<GetCustResFinalOutput>> CreateCustomer([FromBody] STFCCreateCustomerModelInput ObjClass);
        Task<STFCCreateCardModelOutput> CreateCard([FromBody] STFCCreateCardModelInput ObjClass);
        Task<STFCAPIUpdateStatusModelMainOutput> UpdateStatus([FromBody] STFCUpdateStatusModelInput ObjClass);

        Task<STFCAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] STFCGetConsumptionDataModelInput ObjClass);
        Task<STFCGetCardHotlistStatusModelOutput> GetCardHotlistStatus([FromBody] STFCGetCardHotlistStatusModelInput ObjClass);
        Task<IEnumerable<STFCMAPSTFCCardlessModelOutput>> MAPSTFCCardless([FromBody] STFCMAPSTFCCardlessModelInput ObjClass);
        Task<STFCGetAllTransactionsModelFInalOutput> GetAllTransactions([FromBody] STFCGetAllTransactionsModelInput ObjClass);
        Task<STFCGetHotlistReactivateReasonModelOutput> GetHotlistReactivateReason([FromBody] STFCGetHotlistReactivateReasonModelInput ObjClass);
        Task<STFCGetCustomerHotlistStatusModelOutput> GetCustomerHotlistStatus([FromBody] STFCGetCustomerHotlistStatusModelInput ObjClass);

        Task<STFCDehotlistCustomerWithPANModelOutput> DehotlistCustomerWithPAN([FromBody] STFCDehotlistCustomerWithPANModelInput ObjClass);
        Task<STFCUpdateCardLimitinBulkModelOutput> UpdateCardLimitinBulk([FromBody] STFCUpdateCardLimitinBulkModelInput ObjClass);
    }
}
