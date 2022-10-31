using HPPay.DataModel.State;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.State
{
    public interface IStateRepository
    {
        public Task<IEnumerable<GetStateModelOutput>> GetState([FromBody] GetStateModelInput ObjClass);

        public Task<IEnumerable<DeleteStateModelOutput>> DeleteState([FromBody] DeleteStateModelInput ObjClass);
    }
}
