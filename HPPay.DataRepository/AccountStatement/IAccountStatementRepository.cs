using HPPay.DataModel.AccountStatment;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.AccountStatment
{
    public interface IAccountStatmentRepository
    {
        public Task<GetAccountStatmentRequestDetailsOutPut> GetAccountStatmentRequestDetails([FromBody] GetAccountStatmentRequestDetailsInput ObjClass);
        public Task<IEnumerable<GetAccountStatmentTypeOutPut>> GetAccountStatmentType([FromBody] GetAccountStatmentTypeInput ObjClass);         
        public Task<IEnumerable<InsertAccountStatmentRequestModelOutPut>> InsertAccountStatmentRequest([FromBody] InsertAccountStatmentRequestModelInput ObjClass);
       
        public Task<IEnumerable<UpdateAccountStatmentRequestModelOutput>> UpdateAccountStatmentRequest([FromBody] UpdateAccountStatmentRequestModelInput ObjClass);
        public Task<IEnumerable<DownloadAccountStatmentOutput>> DownloadAccountStatment([FromBody] DownloadAccountStatmentInput ObjClass);
        
    }
}
