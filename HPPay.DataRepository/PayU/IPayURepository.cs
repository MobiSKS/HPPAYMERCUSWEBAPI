using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.PayU;
using HPPay.DataModel.RechargeCCMS;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;

namespace HPPay.DataRepository.PayU
{
    public interface IPayURepository
    {
        public Task<IEnumerable<PayUPaymentGatewayModelOutPut>> GetCustomerDetailsForRecharge([FromBody] InitiatePayUPaymentGatewayModelInput ObjClass);
        public void InsertPayUApiRequestResponse([FromBody] PayUApiRequestResponse ObjClass);
        public Task<IEnumerable<GetPayUPGResponseModelOutput>> PayUGetPGResponse([FromBody] PayUResponse ObjClass);       
         
    }
} 