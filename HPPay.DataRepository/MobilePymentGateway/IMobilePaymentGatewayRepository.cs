using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.MobilePaymentGatewayModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.MobilePaymentGateway
{
    public interface IMobilePaymentGatewayRepository
    {  
         public Task<IEnumerable<MobilePaymentGatewayModelOutPut>> InitiateMobilePaymentRequest([FromForm] MobilePaymentGatewayModelInPut ObjClass);

        public Task<IEnumerable<GenerateQRCodeModelOutput>> GenerateQRCode([FromForm] GenerateQRCodeModelInput ObjClass);
        public Task<IEnumerable<ValidateQRCodeModelOutput>> ValidateQRCode([FromForm] ValidateQRCodeModelInput ObjClass);
    }
} 