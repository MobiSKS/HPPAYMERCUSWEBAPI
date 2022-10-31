using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.DataModel.BasicSearchByCard.BasicSearchByModelCard;

namespace HPPay.DataRepository.BasicSearchByCard
{
    public interface IBasicSearchByCardRepository
    {
        public Task<IEnumerable<BasicSearchByCardOutput>> GetBasicSearchByModelCards([FromBody] BasicSearchByCardInput ObjClass);

    }
}
