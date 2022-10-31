using HPPay.DataModel.SadakKeSathi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.SadakKeSathi
{
    public interface ISadakKeSathiRepository
    {

        public Task<IEnumerable<GetSKSVehicleDetailModelOutput>> GetSKSVehicleDetail(GetSKSVehicleDetailModelInput objClass);
        public Task<IEnumerable<GetSKSVehicleEnrolmentDetailModelOutput>> GetSKSVehicleEnrolmentDetail(GetSKSVehicleEnrolmentDetailModelInput objClass);
        public Task<IEnumerable<GetSKSChargesPerVehicleModelOutput>> GetSKSMonthlyChargesPerVehicle();
        public Task<IEnumerable<InsertSKSVehicleEnrolmentDetailModelOutput>> InsertSKSVehicleEnrolmentDetail(InsertSKSVehicleEnrolmentDetailModelInput objClass);
    }
}
