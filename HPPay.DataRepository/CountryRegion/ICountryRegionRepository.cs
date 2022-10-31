using HPPay.DataModel.CountryRegion;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.CountryRegion
{
    public interface ICountryRegionRepository
    {
        public Task<IEnumerable<GetCountryRegionModelOutput>> GetCountryRegion([FromBody] GetCountryRegionModelInput ObjClass);

        public Task<IEnumerable<DeleteCountryRegionModelOutput>> DeleteCountryRegion([FromBody] DeleteCountryRegionModelInput ObjClass);
    }
}
