using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HPPay.DataModel.CustomerFeedback;

namespace HPPay.DataRepository.CustomerFeedbackRepository
{
    public interface ICustomerFeedbackRepository
    {
        public Task<IEnumerable<CustomerFeedbackDropdownModelOutput>> CustomerFeedbackDropdown([FromBody] CustomerFeedbackDropdownModelInput ObjClass);
    }
}
