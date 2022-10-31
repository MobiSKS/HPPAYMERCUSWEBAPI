using HPPay.DataModel.HDFCCreditPouch;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.HDFCCreditPouch
{
    public interface ICreditPouchRepository
    {
        public Task<IEnumerable<CheckCreditPouchEligibilityModelOutPut>> CheckCreditPouchEligibility([FromBody] CheckCreditPouchEligibilityModelInput ObjClass);
        public Task<IEnumerable<InsertCreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomer([FromBody] InsertCreditPouchDetailsByCustomerModelInput ObjClass);
        public Task<GetCustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMO([FromBody] GetCustomerDetailsForCreditPouchByMOModelInput ObjClass);
        public Task<IEnumerable<GetPlanNameModelHDFCOutPut>> GetPlan([FromBody] GetPlanNameModelHDFCInput ObjClass);
        public Task<IEnumerable<InsertCreditPouchDetailsModelOutPut>> InsertCreditPouchDetails([FromBody] InsertCreditPouchDetailsModelInput ObjClass);
        public Task<IEnumerable<GetCreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBank([FromBody] GetCreditPouchDetalsAtBankInput ObjClass);
        public Task<IEnumerable<ActionOnCreditPouchModelOutput>> ActionOnCreditPouch([FromBody] ActionOnCreditPouchModelInput ObjClass);
        public Task<IEnumerable<AuthActionOnCreditPouchModelOutput>> AuthActionOnCreditPouch([FromBody] AuthActionOnCreditPouchModelInput ObjClass);
        public Task<IEnumerable<GetCreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuth([FromBody] GetCreditPouchDetalsForAuthInput ObjClass);
        public Task<IEnumerable<GetCreditPouchStatusOutPut>> GetCreditPouchStatus([FromBody] GetCreditPouchStatusInput ObjClass);
        public Task<IEnumerable<GetCreditPouchStatusReportOutPut>> GetCreditPouchStatusReport([FromBody] GetCreditPouchDetalsStatusReportInput ObjClass);
        public Task<IEnumerable<InitiateCreditPouchRechargeModelOutPut>> InitiateCPRecharge([FromBody] InitiateCreditPouchRechargeModelInput ObjClass);
        public void InsertCPPGApiRequestResponse([FromBody] ApiRequestResponse ObjClass);
        public  Task<IEnumerable<HdfcTransactionStatusModelOutPut>> HdfcTransactionStatus([FromBody] HdfcTransactionStatusModelInput ObjClass);
        public Task<IEnumerable<HdfcTransactionStatusModelOutPut>> HdfcTransactionStatusReport([FromBody] HdfcTransactionStatusReportModelInput ObjClass);
        public Task<IEnumerable<InsertCreditPouchReferralDetailsModelOutPut>> InsertCreditPouchReferralDetails([FromBody] InsertCreditPouchReferralDetailsModelInput ObjClass);
        public Task<IEnumerable<GetCreditPouchDetalsReferral>> GetCreditPouchReferral([FromBody] GetCreditPouchDetalsReferralInput ObjClass);
    }
}
