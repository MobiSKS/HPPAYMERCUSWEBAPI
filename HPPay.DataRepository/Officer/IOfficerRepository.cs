using HPPay.DataModel.Officer;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Officer
{
    public interface IOfficerRepository
    {
        public Task<IEnumerable<OfficerInsertModelOutput>> InsertOfficer([FromBody] OfficerInsertModelInput ObjClass);
        public Task<IEnumerable<GetOfficerModelOutput>> GetOfficerDetail([FromBody] GetOfficerModelInput ObjClass);
        public Task<IEnumerable<OfficerUpdateModelOutput>> UpdateOfficer([FromBody] OfficerUpdateModelInput ObjClass);
        public Task<IEnumerable<DeleteOfficerModelOutput>> DeleteOfficer([FromBody] DeleteOfficerModelInput ObjClass);
        public Task<IEnumerable<CheckOfficerModelOutput>> ChkUserName([FromBody] CheckOfficerModelInput ObjClass);
        public Task<IEnumerable<ChkUserNameForLoginModelOutput>> ChkUserNameForLogin([FromBody] ChkUserNameForLoginModelInput ObjClass);
        public Task<IEnumerable<OfficerLocationMappingModelOutput>> InsertOfficerLocationMapping([FromBody] OfficerLocationMappingModelInput ObjClass);
        public Task<IEnumerable<OfficerDeleteLocationMappingModelOutput>> DeleteOfficerLocationMapping([FromBody] OfficerDeleteLocationMappingModelInput ObjClass);

        public Task<IEnumerable<GetOfficerModelOutput>> BindOfficer([FromBody] BindOfficerModelInput ObjClass);

        public Task<IEnumerable<GetOfficerSubTypeModelOutput>> GetOfficerSubType([FromBody] GetOfficerSubTypeModelInput ObjClass);
        public Task<IEnumerable<GetOfficerTypeModelOutput>> GetOfficerType([FromBody] GetOfficerTypeModelInput ObjClass);

        public Task<IEnumerable<GetOfficerLocationMappingModelOutput>> GetOfficerLocationMapping([FromBody] BindOfficerModelInput ObjClass);

        public  Task<IEnumerable<GetOfficerDetailModelOutput>> GetOfficerDetailByLocation([FromBody] GetOfficerDetailModelInput ObjClass);

    }
}
