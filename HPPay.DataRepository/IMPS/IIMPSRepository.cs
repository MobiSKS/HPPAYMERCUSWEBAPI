using HPPay.DataModel.IMPS;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.IMPS
{
    public interface IIMPSRepository
    {
        public Task<IEnumerable<IMPSSearchOutput>> IMPSTransactionSearch([FromForm] IMPSSearchInput ObjClass);

        public Task<IEnumerable<IMPSRechargeReversalRequestOutput>> IMPSRechargeReversalRequest([FromForm] IMPSRechargeReversalRequestInput ObjClass);
    }
}
