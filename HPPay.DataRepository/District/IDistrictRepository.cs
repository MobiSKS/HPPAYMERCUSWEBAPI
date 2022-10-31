using HPPay.DataModel.District;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.District
{
    public interface IDistrictRepository
    {
        public Task<IEnumerable<GetDistrictModelOutput>> GetDistrict([FromBody] GetDistrictModelInput ObjClass);

        public Task<IEnumerable<DeleteDistrictModelOutput>> DeleteDistrict([FromBody] DeleteDistrictModelInput ObjClass);

        public Task<IEnumerable<GetDistrictModelOutput>> GetDistrictByMultipleStateID([FromBody] GetDistrictByMultipleStateIDModelInput ObjClass);
    }
}
