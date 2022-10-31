using HPPay.DataModel.ZonalOffice;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.ZonalOffice
{
    public interface IZonalOfficeRepository
    {
        public Task<IEnumerable<GetZonalOfficeModelOutput>> GetZonalOffice([FromBody] GetZonalOfficeModelInput ObjClass);

        public Task<IEnumerable<DeleteZonalOfficeModelOutput>> DeleteZonalOffice([FromBody] DeleteZonalOfficeModelInput ObjClass);
    }
}
