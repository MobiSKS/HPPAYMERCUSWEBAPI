using HPPay.DataModel.M2PExternal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.M2PExternal
{
    public interface IM2PExternalRepository
    {
        public Task<IEnumerable<M2PApiRequestModelOutput>> InsertM2PFastagApiRequest(M2PApiRequestModelInput ObjClass);
        public void InsertM2PApiRequestResponseDetail(M2PApiRequestResponseModelInput ObjClass);
        public Task<IEnumerable<GetM2PCustomerIdByCardOutput>> GetM2PCustomerIdByCard(string CardNo);
        public Task<IEnumerable<CheckM2PInvoiceIdBatchIdExistOutput>> CheckM2PInvoiceIdBatchIdExist(CheckM2PInvoiceIdBatchIdExistInput obj);  
        public Task<IEnumerable<UpdateCCMSBAlanceForM2PCustomer>> RefundCCMSBAlanceForM2PCustomer(M2PTransactionReversalModelInput ObjClass);
        public Task<IEnumerable<M2PCheckCardLimitValidationforAPIOutput>> M2PCheckCardLimitValidationforAPI(M2PCheckCardLimitValidationforAPIInput obj);
        public  Task<IEnumerable<M2PRefundStatusUpdateModelOutput>> M2PUpdateRequestResponseDetailRefundStatus(M2PTransactionReversalModelInput ObjClass);
        public void UpdateM2PApiRequest(UpdateM2PRequestInput ObjClass);
        public Task<IEnumerable<M2PTransactionReversalModelOutput>> CheckRefundProcessedForM2PCustomer(M2PTransactionReversalModelInput ObjClass);

    }
}
