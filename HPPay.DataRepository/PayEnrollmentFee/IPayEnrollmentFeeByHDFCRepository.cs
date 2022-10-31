
using HPPay.DataModel.PayEnrollmentFee;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.PayEnrollmentFee
{
    public interface IPayEnrollmentFeeByHDFCRepository
    {
        
        public Task<IEnumerable<InitiateEnrollmentFeeByHDFCModelOutPut>> InsertFeeDetailst([FromBody] InitiateEnrollmentFeeByHDFCModelInput ObjClass);
        public void InsertEnrolFeeHDFGApiRequest([FromBody] ApiRequestResponse ObjClass);
         
        public Task<IEnumerable<GetDetailsByFormNoModelOutput>> GetDetailsByFormNo([FromBody] GetDetailsByFormNoModelInput ObjClass);

        public Task<IEnumerable<GetEnrollmentFeeAmountOutPut>> GetEnrollmentFeeAmount([FromBody] GetEnrollmentFeeAmountInput ObjClass);
    }
}
