using HPPay.DataModel.AGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.AGS
{
    public interface IAGSRepository
    {

        public Task<IEnumerable<AGSAPIValidateCredentialsModelOutput>> AGSAPIsValidateCredentials([FromBody] AGSAPIValidateCredentialsModelInput ObjClass);


        public Task<IEnumerable<InitializationModelOutput>> Initialization([FromBody] InitializationModelInput ObjClass);
        //public Task<GetCustomerDetailsModelOutput> GetCustomerByMobileNo([FromBody] GetCustomerDetailsModelInput ObjClass);

        public Task<GetCustomerDetailsModelOutput> GetCustomerByMobileNo([FromBody] GetCustomerDetailsModelInput ObjClass);

        public Task<IEnumerable<GetPEKModelOutput>> GetPEK([FromBody] GetPEKModelInput ObjClass);

        public Task<IEnumerable<ValidateVehicleNumberModelOutput>> ValidateVehicleNumber([FromBody] ValidateVehicleNumberModelInput ObjClass);

        public Task<IEnumerable<AuthorizationModelOutput>> Authorization([FromBody] AuthorizationModelInput ObjClass);

        public Task<IEnumerable<AcknowledgeModelOutput>> Acknowledge([FromBody] AcknowledgeModelInput ObjClass);

        public Task<IEnumerable<BatchSettlementModelOutput>> BatchSettlement([FromBody] BatchSettlementModelInput ObjClass);

        public Task<IEnumerable<TransactionReversalModelOutput>> TransactionReversal([FromBody] TransactionReversalModelInput ObjClass);

        public Task<IEnumerable<PayCodeTransactionReversalModelOutput>> PayCodeTransactionReversal([FromBody] PayCodeTransactionReversalModelInput ObjClass);

        public Task<IEnumerable<AuthorizePayCodeTxnModelOutput>> AuthorizePayCodeTxn([FromBody] AuthorizePayCodeTxnModelInput ObjClass);

        public Task<IEnumerable<BatchUploadModelOutput>> BatchUpload([FromBody] BatchUploadModelInput ObjClass);



    }
}
