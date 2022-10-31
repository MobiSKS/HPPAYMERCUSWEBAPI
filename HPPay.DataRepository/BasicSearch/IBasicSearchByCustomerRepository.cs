using HPPay.DataModel.BasicSearchByCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.DataModel.BasicSearchByCard.BasicSearchByModelCard;

namespace HPPay.DataRepository.BasicSearch
{
    public interface IBasicSearchByCustomerRepository
    {
       // public Task<IEnumerable<GetCreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBank([FromBody] GetCreditPouchDetalsAtBankInput ObjClass);
        public Task<IEnumerable<BasicSearchByCustomerOutput>> GetBasicSearchByModelCustomers([FromBody] BasicSearchByCustomerInput ObjClass);

        public Task<IEnumerable<BasicSearchByCardOutput>> GetBasicSearchByModelCards([FromBody] BasicSearchByCardInput ObjClass);

        public Task<IEnumerable<ViewBasicSearchByCustomerModelOutput>> ViewBasicSearchByModelCustomers([FromBody] ViewBasicSearchByCustomerModelInput ObjClass);


    }
}
