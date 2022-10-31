using System;
using HPPay.DataModel.MODashboard;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository
{
    public interface IMODashboardRepository
    {
      public  Task<IEnumerable<MODashboardPendingTerminalModelOutput>> MODashboardPendingTerminal(MODashboardPendingTerminalModelInput objClass);
      public  Task<IEnumerable<MODashboardRegionInformationModelOutput>> MODashboardRegionInformation(MODashboardRegionInformationModelInput objClass);
      public  Task<IEnumerable<MODashboardUserInformationModelOutput>> MODashboardUserInformation(MODashboardUserInformationModelInput objClass);
    }
}
