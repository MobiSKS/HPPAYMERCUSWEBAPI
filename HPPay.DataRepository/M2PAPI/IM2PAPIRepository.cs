using HPPay.DataModel.CustomerAPI;
using HPPay.DataModel.M2PAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.M2PAPI
{
    public interface IM2PAPIRepository
    {

        Task<M2PAPIUpdateStatusModelMainOutput> UpdateStatus([FromBody] M2PAPIUpdateStatusModelInput ObjClass);
        Task<M2PAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] M2PAPIGetConsumptionDataModelInput ObjClass);

        Task<M2PAPIGetCardHotlistStatusModelOutput> GetCardHotlistStatus([FromBody] M2PAPIGetCardHotlistStatusModelInput ObjClass);
        Task<M2PAPIGetAllTransactionsModelFInalOutput> GetAllTransactions([FromBody] M2PAPIGetAllTransactionsModelInput ObjClass);
        Task<IEnumerable<MAPM2PCardlessModelOutput>> MAPM2PCardless([FromBody] MAPM2PCardlessModelInput ObjClass);
        Task<M2PAPICreateCardModelOutput> CreateCard([FromBody] M2PAPICreateCardModelInput ObjClass);

        Task<IEnumerable<GetCustResFinalOutput>> CreateCustomer([FromBody] M2PAPICreateCustomerModelInput ObjClass);
    }
}
