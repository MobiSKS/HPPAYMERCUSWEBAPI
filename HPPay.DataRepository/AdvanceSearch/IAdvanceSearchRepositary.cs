using System;
using HPPay.DataModel.AdvanceSearch;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.AdvanceSearch
{
    public interface IAdvanceSearchRepositary
    {
        public Task<IEnumerable<GetAdvanceSearchCustomerSearchModelOutput>> GetAdvanceSearchCustomerSearch([FromBody] GetAdvanceSearchCustomerSearchModelInput ObjClass);
        public Task<IEnumerable<GetAdvanceSearchMerchantSearchModelOutput>> GetAdvanceSearchMerchantSearch([FromBody] GetAdvanceSearchMerchantSearchModelInput ObjClass);
        public Task<IEnumerable<GetAdvanceSearchCardSearchModelOutput>> GetAdvanceSearchCardSearch([FromBody] GetAdvanceSearchCardSearchModelInput ObjClass);
        public Task<IEnumerable<GetAdvanceSearchTerminalSearchModelOutput>> GetAdvanceSearchTerminalSearch([FromBody] GetAdvanceSearchTerminalSearchModelInput ObjClass);
    }
}
