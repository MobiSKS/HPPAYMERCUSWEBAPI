using HPPay.DataModel.CustomerRelationship;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CustomerRelationship
{
    public interface ICustomerRelationshipRepository
    {
        public Task<IEnumerable<CustomerRelationshipPaymentTermsTypeModelOutput>> PaymentTermsType([FromBody] CustomerRelationshipPaymentTermsTypeModelInput ObjClass);
        public Task<IEnumerable<CustomerRelationshipPaymentTermsModeModelOutput>> PaymentTermsMode([FromBody] CustomerRelationshipPaymentTermsModeModelInput ObjClass);
        public Task<IEnumerable<CustomerRelationshipSegmentServedModelOutput>> SegmentServed([FromBody] CustomerRelationshipSegmentServedModelInput ObjClass);
        public  Task<IEnumerable<CustomerRelationshipUsageTypeModelOutput>> UsageType([FromBody] CustomerRelationshipUsageTypeModelInput ObjClass);
        public  Task<BusinessSolicitationCallReportModelOutput> BusinessSolicitationCallReport([FromBody] BusinessSolicitationCallReportModelInput ObjClass);
        public  Task<IEnumerable<CustomerRelationshipCustomerCategoryModelOutput>> CustomerCategory([FromBody] CustomerRelationshipCustomerCategoryModelInput ObjClass);
        public  Task<IEnumerable<CustomerRelationshipFleetSizeValueModelOutput>> FleetSizeValue([FromBody] CustomerRelationshipFleetSizeValueModelInput ObjClass);
        public Task<IEnumerable<CustomerRelationshipGetDealerMappingInputModelOutput>> GetDealerMappingInput([FromBody] CustomerRelationshipGetDealerMappingInputModelInput ObjClass);
        public Task<IEnumerable<CustomerRelationshipListAllTrackIdModelOutput>> ListAllTrackId([FromBody] CustomerRelationshipListAllTrackIdModelInput ObjClass);
        public Task<IEnumerable<CustomerRelationshipUpdateBusinessSolicitationCallReportModelOutput>> UpdateBusinessSolicitationCallReport([FromBody] CustomerRelationshipUpdateBusinessSolicitationCallReportModelInput ObjClass);
        public Task<IEnumerable<CustomerRelationshipBusinessSolicitationCallReportModelOutput>> CustomerRelationshipBusinessSolicitationCallReport([FromBody] CustomerRelationshipBusinessSolicitationCallReportModelInput ObjClass);
        public Task<IEnumerable<CustomerRelationshipMonthModelOutput>> CustomerRelationshipMonth([FromBody] CustomerRelationshipMonthModelInput ObjClass);
        public  Task<CustomerRelationshipgetcallstatusmonthModelOutput> getcallstatusmonth([FromBody] CustomerRelationshipgetcallstatusmonthModelInput ObjClass);
        public  Task<GetRelationshipManagementCallModelOutput> GetRelationshipManagementCall([FromBody] GetRelationshipManagementCallModelInput ObjClass);


    }
}
