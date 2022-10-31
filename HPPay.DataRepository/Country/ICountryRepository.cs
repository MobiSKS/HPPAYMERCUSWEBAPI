using HPPay.DataModel.Country;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Country
{
    public interface ICountryRepository
    {
        public Task<IEnumerable<GetCountryModelOutput>> GetCountry([FromBody] GetCountryModelInput ObjClass);

        public Task<IEnumerable<DeleteCountryModelOutput>> DeleteCountry([FromBody] DeleteCountryModelInput ObjClass);
    }
}
