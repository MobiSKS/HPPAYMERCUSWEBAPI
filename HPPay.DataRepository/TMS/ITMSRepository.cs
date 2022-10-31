using HPPay.DataModel.TMS;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.TMS
{
    public interface ITMSRepository
    {
        public Task<IEnumerable<GetEnrollTransportManagementSystemModelOutput>> GetEnrollTransportManagementSystem([FromBody] GetEnrollTransportManagementSystemModelInput ObjClass);
        public Task<IEnumerable<GetEnrollmentStatusModelOutput>> GetEnrollmentStatus([FromBody] GetEnrollmentStatusModelInput ObjClass);
        public Task<GetEnrollVehicleModelOutput> GetEnrollVehicle([FromBody] GetEnrollVehicleModelInput ObjClass);
        public Task<IEnumerable<GetManageEnrollmentsModelOutput>> GetManageEnrollments([FromBody] GetManageEnrollmentsModelInput ObjClass);

        public void InsertAPIRequestResponse([FromBody] ApiRequestResponse ObjClass);
        public Task<IEnumerable<CargoFlRegisterTrucker>> GetCargoFlRegisterTruckerDetail([FromBody] string CustomerId);
        public Task<IEnumerable<GetCustomerDetailForEnrollmentApprovalOutput>> GetCustomerDetailForEnrollmentApproval([FromBody] GetCustomerDetailForEnrollmentApprovalInput ObjClass);
        public Task<IEnumerable<UpdateCustomerDetailForEnrollmentApprovalModelOutput>> UpdateCustomerDetailForEnrollmentApproval([FromBody] UpdateCustomerDetailForEnrollmentApprovalModelInput ObjClass);

        public Task<IEnumerable<GetEnrollmentStatusModelOutput>> GetEnrollmentStatus();
        public Task<IEnumerable<TMSUpdateEnrollmentStatusModelOutput>> TMSInsertCustomerTracking([FromBody] TMSUpdateEnrollmentStatusModelInput ObjClass,string ApiUrl);
        public Task<IEnumerable<GetEnrollVehicleManagementModeloutput>> GetEnrollVehicleManagementDetail([FromBody] GetEnrollVehicleManagementModelInput ObjClass);
        public Task<IEnumerable<GetEnrollVehicleManagementStatusOutput>> GetEnrollVehicleManagementStatus();
        public Task<IEnumerable<InsertVehicleEnrollmentStatusOutput>> InsertVehicleEnrollmentStatus(InsertVehicleEnrollmentStatusInput ObjClass);
        public Task<IEnumerable<GetTransportManagementSystemModelOutput>> GetActiveApprovedCustomer(GetTransportManagementSystemModelInput ObjClass);
        public Task<IEnumerable<BindEnrollTransportManagementSystemModelOutput>> BindEnrollTransportManagementSystem(BindEnrollTransportManagementSystemModelInput ObjClass);
        public Task<IEnumerable<GetDetailsForCustomerUpdateModelOutput>> GetDetailsForCustomerUpdate(GetDetailsForCustomerUpdateModelInput ObjClass);
        public Task<IEnumerable<UpdateCustomerAddressModelOutput>> UpdateCustomerAddress(UpdateCustomerAddressModelInput ObjClass);

    }
}
