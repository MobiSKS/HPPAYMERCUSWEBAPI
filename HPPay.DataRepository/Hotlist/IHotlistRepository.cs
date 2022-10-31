using HPPay.DataModel.Hotlist;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.DataModel.Hotlist.HotlistUpdatePermanentlyHotlistCardsModel;

namespace HPPay.DataRepository.Hotlist
{
    public interface IHotlistRepository
    {
        public Task<IEnumerable<GetActionListOutput>> GetActionList([FromBody] GetActionListInput ObjClass);

        public Task<IEnumerable<GetEntityTypeListOutput>> GetEntityTypeList([FromBody] GetEntityTypeListInput ObjClass);


        public Task<IEnumerable<GetReasonListForEntitiesOutput>> GetReasonListForEntities([FromBody] GetReasonListForEntitiesInput ObjClass);

        public Task<IEnumerable<GetHotlistedOrReactivatedDetailsOutput>> GetHotlistedOrReactivatedDetails([FromBody] GetHotlistedOrReactivatedDetailsInput ObjClass);

        public Task<IEnumerable<HotlistUpdateModelOutput>> UpdateHotlistOrReactivate([FromBody] HotlistUpdateModelInput ObjClass);

        public Task<IEnumerable<GetHotlistApprovalModelOutput>> GetHotlistApproval([FromBody] GetHotlistApprovalModelInput ObjClass);

        public Task<IEnumerable<UpdateHotlistApprovalModelOutput>> UpdateHotlistApproval([FromBody] UpdateHotlistApprovalModelInput ObjClass);

        public Task<IEnumerable<HotlistGetHotlistCardsDetailsModelOutput>> GetHotlistCardsDetails([FromBody] HotlistGetHotlistCardsDetailsModelInput ObjClass);
        public Task<IEnumerable<HotlistGetHotlistReasonModelOutput>> GetHotlistReason([FromBody] HotlistGetHotlistReasonModelInput ObjClass);

        public Task<IEnumerable<HotlistUpdatePermanentlyHotlistCardsModelOutput>> UpdatePermanentlyHotlistCards([FromBody] HotlistUpdatePermanentlyHotlistCardsModelInput ObjClass);

        public Task<IEnumerable<CheckEntityAlreadyHotlistedModelOutput>> CheckEntityAlreadyHotlisted([FromBody] CheckEntityAlreadyHotlistedModelInput ObjClass);

        public Task<IEnumerable<HotlistGetHotlistReissueCardsModelOutput>> GetHotlistReissueCards([FromBody] HotlistGetHotlistReissueCardsModelInput ObjClass);
    }


}
