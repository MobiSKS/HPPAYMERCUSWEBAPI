using HPPay.DataModel.ICICICreditPouch;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.PCICICICreditPouch
{
    public interface IPCCreditPouchRepositoryICICI
    {
        public Task<IEnumerable<CheckICICICreditPouchEligibilityModelOutPut>> CheckCreditPouchEligibilityForPC([FromBody] CheckICICICreditPouchEligibilityModelInput ObjClass);
        public Task<IEnumerable<InsertICICICreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomerForPC([FromBody] InsertICICICreditPouchDetailsByCustomerModelInput ObjClass);
        public Task<GetICICICustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMOForPC([FromBody] GetICICICustomerDetailsForCreditPouchByMOModelInput ObjClass);
        public Task<IEnumerable<GetPlanNameModelICICIOutPut>> GetPlan([FromBody] GetPlanNameModelICICIInput ObjClass);
        public Task<IEnumerable<InsertICICICreditPouchDetailsModelOutPut>> InsertCreditPouchDetailsForPC([FromBody] InsertICICICreditPouchDetailsModelInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBankForPC([FromBody] GetICICICreditPouchDetalsAtBankInput ObjClass);
        public Task<IEnumerable<ActionOnICICICreditPouchModelOutput>> ActionOnCreditPouchForPC([FromBody] ActionOnICICICreditPouchModelInput ObjClass);
        public Task<IEnumerable<AuthActionOnICICICreditPouchModelOutput>> AuthActionOnCreditPouchForPC([FromBody] AuthActionOnICICICreditPouchModelInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuthForPC([FromBody] GetICICICreditPouchDetalsForAuthInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchStatusOutPut>> GetCreditPouchStatusForPC([FromBody] GetICICICreditPouchStatusInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchStatusReportOutPut>> GetCreditPouchStatusReportForPC([FromBody] GetICICICreditPouchDetalsStatusReportInput ObjClass);
        public Task<IEnumerable<InitiateICICICreditPouchRechargeModelOutPut>> InitiateCPRechargeForPC([FromBody] InitiateICICICreditPouchRechargeModelInput ObjClass);
        public void InsertCPPGApiRequestResponseForPC([FromBody] ICICIApiRequestResponse ObjClass);
        
    }
}
