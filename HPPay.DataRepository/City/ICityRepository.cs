using HPPay.DataModel.City;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.City
{
    public interface ICityRepository
    {
        public Task<IEnumerable<GetCityModelOutput>> GetCity([FromBody] GetCityModelInput ObjClass);

        public Task<IEnumerable<DeleteCityModelOutput>> DeleteCity([FromBody] DeleteCityModelInput ObjClass);
    }
}
