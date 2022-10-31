using HPPay.DataModel.AmexCreditPouch;
using HPPay.DataModel.AMEXCreditPouch;
using HPPay.DataModel.HDFCCreditPouch;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.AMEXCreditPouch
{
    public interface ICreditPouchRepositoryAMEX
    {
        public Task<IEnumerable<CheckAMEXCreditPouchEligibilityModelOutPut>> CheckCreditPouchEligibility([FromBody] CheckAMEXCreditPouchEligibilityModelInput ObjClass);
        public Task<IEnumerable<InsertAMEXCreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomer([FromBody] InsertAMEXCreditPouchDetailsByCustomerModelInput ObjClass);
        public Task<GetAMEXCustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMO([FromBody] GetAMEXCustomerDetailsForCreditPouchByMOModelInput ObjClass);
        public Task<IEnumerable<GetPlanNameModelAMEXOutPut>> GetPlan([FromBody] GetPlanNameModelAMEXInput ObjClass);         
        public Task<IEnumerable<InsertAMEXCreditPouchDetailsModelOutPut>> InsertCreditPouchDetails([FromBody] InsertAMEXCreditPouchDetailsModelInput ObjClass);
        public Task<IEnumerable<GetAMEXCreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBank([FromBody] GetAMEXCreditPouchDetalsAtBankInput ObjClass);
        public Task<IEnumerable<ActionOnAMEXCreditPouchModelOutput>> ActionOnCreditPouch([FromBody] ActionOnAMEXCreditPouchModelInput ObjClass);
        public Task<IEnumerable<AuthActionOnAMEXCreditPouchModelOutput>> AuthActionOnCreditPouch([FromBody] AuthActionOnAMEXCreditPouchModelInput ObjClass);
        public Task<IEnumerable<GetAMEXCreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuth([FromBody] GetAMEXCreditPouchDetalsForAuthInput ObjClass);
        public Task<IEnumerable<GetAMEXCreditPouchStatusOutPut>> GetCreditPouchStatus([FromBody] GetAMEXCreditPouchStatusInput ObjClass);
        public Task<IEnumerable<GetAMEXCreditPouchStatusReportOutPut>> GetCreditPouchStatusReport([FromBody] GetAMEXCreditPouchDetalsStatusReportInput ObjClass);
        public Task<IEnumerable<InitiateAMEXCreditPouchRechargeModelOutPut>> InitiateCPRecharge([FromBody] InitiateAMEXCreditPouchRechargeModelInput ObjClass);
        public void InsertCPPGApiRequestResponse([FromBody] AMEXApiRequestResponse ObjClass);
        public Task<IEnumerable<InsertCreditPouchReferralDetailsModelOutPut>> InsertCreditPouchReferralDetails([FromBody] InsertCreditPouchReferralDetailsModelInput ObjClass);
        public Task<IEnumerable<GetCreditPouchDetalsReferral>> GetCreditPouchReferral([FromBody] GetCreditPouchDetalsReferralInput ObjClass);


    }
}
