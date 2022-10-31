using HPPay.DataModel.HDFCPG;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.HDFCPG
{
    public interface IHDFCPGRepository
    { 
        public GetHDFCPGResponseModelInput DecryptResponse(GetHDFCPGEncResponseModelInput obj);
        public Task<IEnumerable<GetHDFCPGResponseModelOutput>> GetHDFCPGResponse([FromBody] GetHDFCPGResponseModelInput ObjClass);
        public Task<IEnumerable<GetHDFCPaymentStatusModelOutput>> GetHDFCPaymentStatus([FromBody] GetHDFCPaymentStatusModelInput ObjClass);
    }
} 