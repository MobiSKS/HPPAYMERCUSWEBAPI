using HPPay.DataModel.IciciAPI;
using HPPay.DataModel.IdfcAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.IciciAPI
{
   public  interface IIciciApiRepository
    {

       // public Task<IEnumerable<IciciApiRequestResponseOutput>> InsertIciciApiRequestResponse([FromBody] IciciApiRequestResponseInput ObjClass);
        public Task<IEnumerable<UpdateCCMSBAlanceForICICICustomer>> UpdateCCMSBAlanceForIciciCustomer([FromBody] FastagConfirmOtpReQuest ObjClass, string NetAmount, string DiscountAmount);
        public Task<IEnumerable<UpdateCCMSBAlanceForICICICustomer>> RefundCCMSBAlanceForIciciCustomer([FromBody] FastagRefundPaymentReQuest ObjClass);
        public void InsertIciciApiRequestResponseDetail([FromBody] IciciApiRequestResponseDetailInput ObjClass);
        public Task<IEnumerable<InsertFastagIciciApiRequestOutput>> InsertIciciFastagApiRequest(InsertFastagIciciApiRequestInput ObjClass);
        public void UpdateIciciFastagApiRequest(UpdateFastagIciciApiRequestInput ObjClass);
        public Task<IEnumerable<IciciRefundResponse>> CheckFastagRefundProcessedForIciciCustomer([FromBody] FastagRefundPaymentReQuest ObjClass);
        public Task<IEnumerable<IciciRefundStatusUpdateModelOutput>> UpdateRequestResponseDetailRefundStatus([FromBody] FastagRefundPaymentReQuest ObjClass);
        public Task<IEnumerable<IciciCheckFastagInvoiceIdBatchIdExistOutput>> CheckFastagInvoiceIdBatchIdExist(IciciCheckFastagInvoiceIdBatchIdExistInput obj);
    }
}
