using HPPay.DataModel.CustomerAPI;
using HPPay.DataModel.SFLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.SFLAPI
{
    public interface ISFLAPIRepository
    {
        Task<IEnumerable<SFLAPIMapDTPlusCustomerModelOutput>> MapDTPlusCustomer([FromBody] SFLAPIMapDTPlusCustomerModelInput ObjClass);
        Task<SFLAPICreateCardModelOutput> CreateCard([FromBody] SFLAPICreateCardModelInput ObjClass);

        Task<SFLAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] SFLAPIGetConsumptionDataModelInput ObjClass);
        Task<SFLAPIUpdateStatusModelOutputMain> UpdateStatus([FromBody] SFLAPIUpdateStatusModelInput ObjClass);
        Task<SFLAPIGetCardHotlistStatusModelOutput> GetCardHotlistStatus([FromBody] SFLAPIGetCardHotlistStatusModelInput ObjClass);
        Task<SFLAPIGetCustomerHotlistStatusModelOutput> GetCustomerHotlistStatus([FromBody] SFLAPIGetCustomerHotlistStatusModelInput ObjClass);

        Task<SFLAPIGetHotlistReactivateReasonModelOutput> GetHotlistReactivateReason([FromBody] SFLAPIGetHotlistReactivateReasonModelInput ObjClass);
    }
}
