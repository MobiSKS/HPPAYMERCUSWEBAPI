using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataModel.ICICICreditPouch;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.ICICICreditPouch
{
    public interface ICreditPouchRepositoryICICI
    {
        public Task<IEnumerable<CheckICICICreditPouchEligibilityModelOutPut>> CheckCreditPouchEligibility([FromBody] CheckICICICreditPouchEligibilityModelInput ObjClass);
        public Task<IEnumerable<InsertICICICreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomer([FromBody] InsertICICICreditPouchDetailsByCustomerModelInput ObjClass);
        public Task<GetICICICustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMO([FromBody] GetICICICustomerDetailsForCreditPouchByMOModelInput ObjClass);
        public Task<IEnumerable<GetPlanNameModelICICIOutPut>> GetPlan([FromBody] GetPlanNameModelICICIInput ObjClass);
        public Task<IEnumerable<InsertICICICreditPouchDetailsModelOutPut>> InsertCreditPouchDetails([FromBody] InsertICICICreditPouchDetailsModelInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBank([FromBody] GetICICICreditPouchDetalsAtBankInput ObjClass);
        public Task<IEnumerable<ActionOnICICICreditPouchModelOutput>> ActionOnCreditPouch([FromBody] ActionOnICICICreditPouchModelInput ObjClass);
        public Task<IEnumerable<AuthActionOnICICICreditPouchModelOutput>> AuthActionOnCreditPouch([FromBody] AuthActionOnICICICreditPouchModelInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuth([FromBody] GetICICICreditPouchDetalsForAuthInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchStatusOutPut>> GetCreditPouchStatus([FromBody] GetICICICreditPouchStatusInput ObjClass);
        public Task<IEnumerable<GetICICICreditPouchStatusReportOutPut>> GetCreditPouchStatusReport([FromBody] GetICICICreditPouchDetalsStatusReportInput ObjClass);
        public Task<IEnumerable<InitiateICICICreditPouchRechargeModelOutPut>> InitiateCPRecharge([FromBody] InitiateICICICreditPouchRechargeModelInput ObjClass);
        public void InsertCPPGApiRequestResponse([FromBody] ICICIApiRequestResponse ObjClass);

        public Task<IEnumerable<InsertCreditPouchReferralDetailsModelOutPut>> InsertCreditPouchReferralDetails([FromBody] InsertCreditPouchReferralDetailsModelInput ObjClass);
        public Task<IEnumerable<GetCreditPouchDetalsReferral>> GetCreditPouchReferral([FromBody] GetCreditPouchDetalsReferralInput ObjClass);

    }
}
