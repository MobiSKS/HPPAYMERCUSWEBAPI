using HPPay.DataModel.STFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.STFC
{
    public  interface IStfcApiRepository
    {
        public Task<IEnumerable<GetStfcCustomerIdByCardOutput>> GetStfcCustomerIdByCard(string CardNo);

        public Task<IEnumerable<STFCApiRequestModelOutput>> InsertStfcFastagApiRequest(STFCApiRequestModelInput ObjClass);
        public Task<IEnumerable<GetCustomerIdByCardForExternalAPIOutput>> GetCustomerIdByCardForExternalAPI(string CardNo, string Mobileno);
        public void InsertStfcApiRequestResponseDetail(STFCApiRequestResponseModelInput ObjClass);
        public Task<IEnumerable<STFCTransactionReversalModelOutput>> CheckFastagRefundProcessedForSTFCCustomer(STFCTransactionReversalModelInput ObjClass);
        public Task<IEnumerable<CheckSTFCInvoiceIdBatchIdExistOutput>> CheckFastagInvoiceIdBatchIdExist(CheckSTFCInvoiceIdBatchIdExistInput obj);

        public  Task<IEnumerable<UpdateCCMSBAlanceForSTFCCustomer>> RefundCCMSBAlanceForSTFCCustomer(STFCTransactionReversalModelInput ObjClass);
        public  Task<IEnumerable<STFCRefundStatusUpdateModelOutput>> UpdateRequestResponseDetailRefundStatus(STFCTransactionReversalModelInput ObjClass);
        public Task<IEnumerable<UpdateCCMSBAlanceForSTFCCustomer>> UpdateCCMSBAlanceForStfcCustomer(EntityCheckAPIRequestModelInput ObjClass, string TxnId, string CustomerId);
        public void UpdateSTFCApiRequest(UpdateSTFCRequestInput ObjClass);
        public Task<IEnumerable<GetSTFCTxnRefIDOutput>> GetSTFCTxnRefID();
        public Task<IEnumerable<CheckCardLimitValidationforAPIOutput>> CheckCardLimitValidationforAPI(CheckCardLimitValidationforAPIInput obj);


    }
}
