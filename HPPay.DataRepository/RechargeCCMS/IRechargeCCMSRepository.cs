using HPPay.DataModel.RechargeCCMS;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.DBDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.RechargeCCMS
{
    public interface IRechargeCCMSRepository
    {
        public Task<IEnumerable<GetDetailsRechargeCCMSModelOutPut>> InitiateRechargeCCMS([FromBody] GetDetailsRechargeCCMSModelInput ObjClass);
        public void InsertRechargeCCMSApiRequestResponse([FromBody] CCMSApiRequestResponse ObjClass);

        public Task<IEnumerable<CCMSRechargeCCMSAccountModelOutput>> RechargeCCMSAccount([FromBody] CCMSRechargeCCMSAccountModelInput ObjClass);

        public Task<IEnumerable<WebGenerateOTPModelOutput>> CCMSGenerateOTP([FromBody] WebGenerateOTPModelInput ObjClass);

        public Task<IEnumerable<CCMSConfirmOTPModelOutPut>> CCMSConfirmOTP([FromBody] CCMSConfirmOTPModelInput ObjClass);

        public Task<IEnumerable<InitiateRechargeCCMSModelOutPut>> GetDetailsForRechargeCCMS([FromBody] InitiateRechargeCCMSModelInput ObjClass);

    }
}
