using HPPay.DataModel.Merchant;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Terminal
{
    public interface ITerminalRepository
    {
        public Task<MerchantSearchForTerminalInstallationRequestModelOutput> SearchForTerminalInstallationRequest([FromBody] MerchantSearchForTerminalInstallationRequestModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertAddonTerminalModelOutput>> InsertTerminalInstallationRequest([FromBody] MerchantInsertAddonTerminalModelInput ObjClass);

        public Task<IEnumerable<MerchantSearchForTerminalInstallationRequestCloseModelOutput>> SearchForTerminalInstallationRequestClose([FromBody] MerchantSearchForTerminalInstallationRequestCloseModelInput ObjClass);

        public Task<IEnumerable<MerchantUpdateTerminalInstallationRequestCloseModelOutput>> UpdateTerminalInstallationRequestClose([FromBody] MerchantUpdateTerminalInstallationRequestCloseModelInput ObjClass);

        public Task<IEnumerable<MerchantViewTerminalInstallationRequestStatusCloseModelOutput>> ViewTerminalInstallationRequestStatus([FromBody] MerchantViewTerminalInstallationRequestStatusCloseInput ObjClass);

        public Task<MerchantGetTerminalDeinstallationRequestModelOutput> GetTerminalDeinstallationRequest([FromBody] MerchantGetTerminalDeinstallationRequestModelInput ObjClass);

        public Task<IEnumerable<MerchantUpdateTerminalDeInstalRequestModelOutput>> UpdateTerminalDeInstalRequest([FromBody] MerchantUpdateTerminalDeInstalRequestModelInput ObjClass);

        public Task<IEnumerable<MerchantGetReasonListModelOutput>> GetReasonList([FromBody] MerchantGetReasonListModelInput ObjClass);

        public Task<IEnumerable<MerchantGetTerminalDeInstallationRequestCloseModelOutput>> GetTerminalDeInstallationRequestClose([FromBody] MerchantGetTerminalDeInstallationRequestCloseModelInput ObjClass);

        public Task<IEnumerable<MerchantTerminalDeInstalUpdateRequestCloseModelOutput>> TerminalDeInstalUpdateRequestClose([FromBody] MerchantTerminalDeInstalUpdateRequestCloseModelInput ObjClass);

        public Task<IEnumerable<MerchantGetTerminalInstallationRequestApprovalModelOutput>> GetTerminalInstallationRequestApproval([FromBody] MerchantGetTerminalInstallationRequestApprovalModelInput ObjClass);

        public Task<IEnumerable<MerchantUpdateTerminalInstallationRequestApprovalModelOutput>> InsertTerminalInstallationRequestApproval([FromBody] MerchantUpdateTerminalInstallationRequestApprovalModelInput ObjClass);

        public Task<IEnumerable<MerchantGetTerminalDeInstallationRequestApprovalModelOutput>> GetTerminalDeInstallationRequestApproval([FromBody] MerchantGetTerminalDeInstallationRequestApprovalModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertTerminalDeInstallationRequestApprovalModelOutput>> InsertTerminalDeInstallationRequestApproval([FromBody] MerchantInsertTerminalDeInstallationRequestApprovalModelInput ObjClass);

        public Task<IEnumerable<MerchantGetTerminalDeInstallationRequestAuthorizationModelOutput>> GetTerminalDeInstallationRequestAuthorization([FromBody] MerchantGetTerminalDeInstallationRequestAuthorizationModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>> InsertTerminalDeInstallationRequestAuthorization([FromBody] MerchantInsertTerminalDeInstallationRequestAuthorizationModelInput ObjClass);

        public Task<IEnumerable<MerchantViewTerminalDeInstallationRequestStatusModelOutput>> ViewTerminalDeInstallationRequestStatus([FromBody] MerchantViewTerminalDeInstallationRequestStatusModelInput ObjClass);

        public Task<IEnumerable<MerchantGetManageTerminalDetailsModelOutput>> GetManageTerminalDetails([FromBody] MerchantGetManageTerminalDetailsModelInput ObjClass);

        public Task<IEnumerable<MerchantSearchTerminalModelOutput>> SearchTerminal([FromBody] MerchantSearchTerminalModelInput ObjClass);

        public Task<IEnumerable<MerchantGetTerminalTypeModelOutput>> GetTerminalType([FromBody] MerchantGetTerminalTypeModelInput ObjClass);

        public Task<MerchantTerminalDetailModelOutput> TerminalDetail([FromBody] MerchantTerminalDetailModelInput ObjClass);

        public Task<IEnumerable<MerchantGetProblematicDeinstalledToDeinstalledModelOutput>> GetProblematicDeinstalledToDeinstalled([FromBody] MerchantGetProblematicDeinstalledToDeinstalledModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertProblematicDeinstalledToDeinstalledModelOutput>> InsertProblematicDeinstalledToDeinstalled([FromBody] MerchantInsertProblematicDeinstalledToDeinstalledModelInput ObjClass);
        public Task<GetTerminalParametersModelOutput> GetTerminalParameters([FromBody] GetTerminalParametersModelInput ObjClass);

        public Task<IEnumerable<MerchantSaveTerminalParametersModelOutput>> SaveTerminalParameters([FromBody] MerchantSaveTerminalParametersModelInput ObjClass);

    }
}
