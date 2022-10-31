using HPPay.DataModel.SMSGetSend;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.SMSGetSend
{
    public interface ISMSGetSendRepository
    {
        //public Task<IEnumerable<SMSGetOutputModel>> GetSMSTemplate([FromBody] SMSGetInputModel ObjClass);

        //public Task<IEnumerable<SMSSendOutputModel>> SendSMSTemplate([FromBody] SMSSendInputModel ObjClass);
        
        //public Task<IEnumerable<InsertSMSTextEntryOutputModel>> InsertSMSTextEntry([FromBody] InsertSMSTextEntryInputModel ObjClass);

        public Task<IEnumerable<GetSMSValueOutputModel>> GetSMSValue([FromBody] GetSMSValueInputModel ObjClass);
        public Task<IEnumerable<GetDetailsSMSValueOutputModel>> GetDetailsSMSValue([FromBody] GetDetailsSMSValueInputModel ObjClass);
        public Task<IEnumerable<GetandInsertSendOutputModel>> InsertSMSTextEntry([FromBody] GetandInsertSendInputModel ObjClass);
        public Task<IEnumerable<InsertEmailTextEntryOutputModel>> InsertEmailTextEntry([FromBody] InsertEmailTextEntryInputModel ObjClass);

        //public Task<IEnumerable<GetSMSValueOutputModel>> InsertSMSandEmail([FromBody] GetSMSValueInputModel ObjClass);
    }
}
