using HPPay.DataModel.HDFCCreditPouch;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.HDFCCreditPouch
{
    public interface IPCCreditPouchRepository
    {
        public Task<IEnumerable<CheckCreditPouchEligibilityModelOutPut>> CheckCreditPouchEligibilityForPC([FromBody] CheckCreditPouchEligibilityModelInput ObjClass);
        public Task<IEnumerable<InsertCreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomerForPC([FromBody] InsertCreditPouchDetailsByCustomerModelInput ObjClass);
        public Task<GetCustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMOForPC([FromBody] GetCustomerDetailsForCreditPouchByMOModelInput ObjClass);
        public Task<IEnumerable<GetPlanNameModelHDFCOutPut>> GetPlan([FromBody] GetPlanNameModelHDFCInput ObjClass);
        public Task<IEnumerable<InsertCreditPouchDetailsModelOutPut>> InsertCreditPouchDetailsForPC([FromBody] InsertCreditPouchDetailsModelInput ObjClass);
        public Task<IEnumerable<GetCreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBankForPC([FromBody] GetCreditPouchDetalsAtBankInput ObjClass);
        public Task<IEnumerable<ActionOnCreditPouchModelOutput>> ActionOnCreditPouchForPC([FromBody] ActionOnCreditPouchModelInput ObjClass);
        public Task<IEnumerable<AuthActionOnCreditPouchModelOutput>> AuthActionOnCreditPouchForPC([FromBody] AuthActionOnCreditPouchModelInput ObjClass);
        public Task<IEnumerable<GetCreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuthForPC([FromBody] GetCreditPouchDetalsForAuthInput ObjClass);
        public Task<IEnumerable<GetCreditPouchStatusOutPut>> GetCreditPouchStatusForPC([FromBody] GetCreditPouchStatusInput ObjClass);
        public Task<IEnumerable<GetCreditPouchStatusReportOutPut>> GetCreditPouchStatusReportForPC([FromBody] GetCreditPouchDetalsStatusReportInput ObjClass);
        public Task<IEnumerable<InitiateCreditPouchRechargeModelOutPut>> InitiateCPRechargeForPC([FromBody] InitiateCreditPouchRechargeModelInput ObjClass);
        public void InsertCPPGApiRequestResponse([FromBody] ApiRequestResponse ObjClass);
        
    }
}
