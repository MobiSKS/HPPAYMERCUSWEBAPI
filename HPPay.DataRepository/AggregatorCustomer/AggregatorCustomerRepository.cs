using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.AggregatorCustomer;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay.DataRepository.AggregatorCustomer
{
    public class AggregatorCustomerRepository : IAggregatorCustomerRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AggregatorCustomerRepository(DapperContext context, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// For Aggregator Customer Creation
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AggregatorCustomerInsertModelOutput>> InsertAggregatorCustomer([FromBody] AggregatorCustomerInsertModelInput ObjClass)
        {
            //var dtDBR = new DataTable("UserDTNoofCards");
            //dtDBR.Columns.Add("CardIdentifier", typeof(string));
            //dtDBR.Columns.Add("VechileNo", typeof(string));
            //dtDBR.Columns.Add("VehicleMake", typeof(string));
            //dtDBR.Columns.Add("VehicleType", typeof(string));
            //dtDBR.Columns.Add("YearOfRegistration", typeof(int));

            //var procedureName = "UspInsertCustomer";
            var procedureName = "UspAggregatorInsertRawCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", ObjClass.CustomerSubtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ResidenceStatus", ObjClass.ResidenceStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.PermanentCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentPhoneNo", ObjClass.PermanentPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentFax", ObjClass.PermanentFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyOfficialTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialIndividualInitials", ObjClass.KeyOfficialIndividualInitials, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFax", ObjClass.KeyOfficialFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOA", ObjClass.KeyOfficialDOA, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOB", ObjClass.KeyOfficialDOB, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretQuestion", ObjClass.KeyOfficialSecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretAnswer", ObjClass.KeyOfficialSecretAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTypeOfFleet", ObjClass.KeyOfficialTypeOfFleet, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialCardAppliedFor", ObjClass.KeyOfficialCardAppliedFor, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile1", ObjClass.KeyOfficialApproxMonthlySpendsonVechile1, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile2", ObjClass.KeyOfficialApproxMonthlySpendsonVechile2, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("AreaOfOperation", ObjClass.AreaOfOperation, DbType.String, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedHCV", ObjClass.FleetSizeNoOfVechileOwnedHCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedLCV", ObjClass.FleetSizeNoOfVechileOwnedLCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedMUVSUV", ObjClass.FleetSizeNoOfVechileOwnedMUVSUV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedCarJeep", ObjClass.FleetSizeNoOfVechileOwnedCarJeep, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("FeePaymentsChequeNo", ObjClass.FeePaymentsChequeNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("FeePaymentsChequeDate", ObjClass.FeePaymentsChequeDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            //parameters.Add("ReferenceId", Variables.FunGenerateStringUId(), DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RBEId", ObjClass.RBEId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            //if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            //{
            //    foreach (CardDetail ObjCardDetails in ObjClass.ObjCardDetail)
            //    {
            //        DataRow dr = dtDBR.NewRow();
            //        dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
            //        dr["VechileNo"] = ObjCardDetails.VechileNo;
            //        dr["VehicleMake"] = ObjCardDetails.VehicleMake;
            //        dr["VehicleType"] = ObjCardDetails.VehicleType;
            //        dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;

            //        dtDBR.Rows.Add(dr);
            //        dtDBR.AcceptChanges();
            //    }
            //}
            //parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerInsertModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// For Aggregator Customer Updation
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AggregatorCustomerUpdateModelOutput>> UpdateAggregatorCustomer([FromBody] AggregatorCustomerUpdateModelInput ObjClass)
        {

            var procedureName = "UspAggregatorUpdateRawCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ResidenceStatus", ObjClass.ResidenceStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.PermanentCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentPhoneNo", ObjClass.PermanentPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentFax", ObjClass.PermanentFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyOfficialTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialIndividualInitials", ObjClass.KeyOfficialIndividualInitials, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFax", ObjClass.KeyOfficialFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOA", ObjClass.KeyOfficialDOA, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOB", ObjClass.KeyOfficialDOB, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretQuestion", ObjClass.KeyOfficialSecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretAnswer", ObjClass.KeyOfficialSecretAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTypeOfFleet", ObjClass.KeyOfficialTypeOfFleet, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialCardAppliedFor", ObjClass.KeyOfficialCardAppliedFor, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile1", ObjClass.KeyOfficialApproxMonthlySpendsonVechile1, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile2", ObjClass.KeyOfficialApproxMonthlySpendsonVechile2, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("AreaOfOperation", ObjClass.AreaOfOperation, DbType.String, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedHCV", ObjClass.FleetSizeNoOfVechileOwnedHCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedLCV", ObjClass.FleetSizeNoOfVechileOwnedLCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedMUVSUV", ObjClass.FleetSizeNoOfVechileOwnedMUVSUV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedCarJeep", ObjClass.FleetSizeNoOfVechileOwnedCarJeep, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("FeePaymentNo", ObjClass.FeePaymentNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("FeePaymentDate", ObjClass.FeePaymentDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);

            //if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            //{
            //    foreach (UpdateCardDetail ObjCardDetails in ObjClass.ObjCardDetail)
            //    {
            //        DataRow dr = dtDBR.NewRow();
            //        dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
            //        dr["VechileNo"] = ObjCardDetails.VechileNo;
            //        dr["VehicleMake"] = ObjCardDetails.VehicleMake;
            //        dr["VehicleType"] = ObjCardDetails.VehicleType;
            //        dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;

            //        dtDBR.Rows.Add(dr);
            //        dtDBR.AcceptChanges();
            //    }
            //}

            //parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            //parameters.Add("ReferenceId", Variables.FunGenerateStringUId(), DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        /// <summary>
        /// Insert Customer KYC
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AggregatorCustomerKYCModelOutput>> UploadAggregatorCustomerKYC([FromForm] AggregatorCustomerKYCModelInput ObjClass)
        {
            string FileNamePathIdProofFront = string.Empty;
            var ImageFileNameIdProofFront = ObjClass.IdProofFront;
            if (ImageFileNameIdProofFront.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameIdProofFront.FileName.Substring(ImageFileNameIdProofFront.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathIdProofFront = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameIdProofFront.FileName;
                    string filePathIdProofFront = contentRootPath + FileNamePathIdProofFront;
                    var fileStream = new FileStream(filePathIdProofFront, FileMode.Create);
                    ImageFileNameIdProofFront.CopyTo(fileStream);
                }
            }


            string FileNamePathIdProofBack = string.Empty;
            var ImageFileNameIdProofBack = ObjClass.IdProofBack;
            if (ImageFileNameIdProofBack.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameIdProofBack.FileName.Substring(ImageFileNameIdProofBack.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathIdProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameIdProofBack.FileName;
                    string filePathIdProofBack = contentRootPath + FileNamePathIdProofBack;
                    var fileStream = new FileStream(filePathIdProofBack, FileMode.Create);
                    ImageFileNameIdProofBack.CopyTo(fileStream);
                }
            }

            string FileNamePathAddressProofFront = string.Empty;
            var ImageFileNameAddressProofFront = ObjClass.AddressProofFront;
            if (ImageFileNameAddressProofFront.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameAddressProofFront.FileName.Substring(ImageFileNameAddressProofFront.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathAddressProofFront = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameAddressProofFront.FileName;
                    string filePathAddressProofFront = contentRootPath + FileNamePathAddressProofFront;
                    var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
                    ImageFileNameAddressProofFront.CopyTo(fileStream);
                }
            }


            string FileNamePathAddressProofBack = string.Empty;
            var ImageFileNameAddressProofBack = ObjClass.AddressProofBack;
            if (ImageFileNameAddressProofBack.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameAddressProofBack.FileName.Substring(ImageFileNameAddressProofBack.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathAddressProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameAddressProofBack.FileName;
                    string filePathAddressProofBack = contentRootPath + FileNamePathAddressProofBack;
                    var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
                    ImageFileNameAddressProofBack.CopyTo(fileStream);
                }
            }


            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("IdProofType", ObjClass.IdProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofDocumentNo", ObjClass.IdProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofFront", FileNamePathIdProofFront, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofBack", FileNamePathIdProofBack, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofFront", FileNamePathAddressProofFront, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofBack", FileNamePathAddressProofBack, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            //parameters.Add("ReferenceNo", Variables.FunGenerateStringUId(), DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var procedureName = "UspInsertAggregatorCustomerKYC";
            return await connection.QueryAsync<AggregatorCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        /// <summary>
        /// Seacrh Manage Profile
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GetAggregatorCustomerModelOutput>> GetAggregatorCustomer([FromBody] GetAggregatorCustomerModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BindPendingAggregatorCustomerModelOutput>> BindUnverfiedAggregatorCustomer([FromBody] BindPendingAggregatorCustomerModelInput ObjClass)
        {

            var procedureName = "UspBindUnverfiedAggregatorCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingAggregatorCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<AggregatorCustomerDetailsModelOutput> GetUnverfiedAggregatorCustomerDetailbyFormNumber([FromBody] AggregatorCustomerDetailsbyFormNumberModelInput ObjClass)
        {
            var procedureName = "UspGetUnverfiedAggregatorCustomerDetailbyFormNumber";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new AggregatorCustomerDetailsModelOutput();
            storedProcedureResult.GetAggregatorCustomerDetails = (List<AggregatorGetCustomerDetailsModelOutput>)await result.ReadAsync<AggregatorGetCustomerDetailsModelOutput>();
            storedProcedureResult.AggregatorCustomerKYCDetails = (List<AggregatorCustomerKYCDetailsModelOutput>)await result.ReadAsync<AggregatorCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<AggregatorCustomerApprovalModelOutput>> ApproveRejectAggregatorCustomer([FromBody] AggregatorCustomerApprovalModelInput ObjClass)
        {


            var dtDBR = new DataTable("FormNumberDetail");
            dtDBR.Columns.Add("FormNumber", typeof(Int64));
            dtDBR.Columns.Add("Comments", typeof(string));
            if (ObjClass.CustomerDetail != null)
            {
                foreach (CustomerDetailList ObjCustomerDetail in ObjClass.CustomerDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["FormNumber"] = ObjCustomerDetail.FormNumber;
                    dr["Comments"] = ObjCustomerDetail.Comments;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }


            var procedureName = "UspUserApproveAggregatorCustomer";
            var parameters = new DynamicParameters();
            
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumberDetail", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorCustomerGetCustomerReferenceNoModelOutput>> GetAggregatorNameandFormNumberbyReferenceNo([FromBody] AggregatorCustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNameandFormNumberbyReferenceNo";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerGetCustomerReferenceNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorNormalFleetCustomerModelOutput>> InsertAggregatorNormalFleetCustomer([FromBody] AggregatorNormalFleetCustomerModelInput ObjClass)
        {
            var procedureName = "UspAggregatorNormalFleetInsertRawCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", ObjClass.CustomerSubtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ResidenceStatus", ObjClass.ResidenceStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.PermanentCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentPhoneNo", ObjClass.PermanentPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentFax", ObjClass.PermanentFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyOfficialTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialIndividualInitials", ObjClass.KeyOfficialIndividualInitials, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFax", ObjClass.KeyOfficialFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOA", ObjClass.KeyOfficialDOA, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOB", ObjClass.KeyOfficialDOB, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretQuestion", ObjClass.KeyOfficialSecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretAnswer", ObjClass.KeyOfficialSecretAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTypeOfFleet", ObjClass.KeyOfficialTypeOfFleet, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialCardAppliedFor", ObjClass.KeyOfficialCardAppliedFor, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile1", ObjClass.KeyOfficialApproxMonthlySpendsonVechile1, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile2", ObjClass.KeyOfficialApproxMonthlySpendsonVechile2, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("AreaOfOperation", ObjClass.AreaOfOperation, DbType.String, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedHCV", ObjClass.FleetSizeNoOfVechileOwnedHCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedLCV", ObjClass.FleetSizeNoOfVechileOwnedLCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedMUVSUV", ObjClass.FleetSizeNoOfVechileOwnedMUVSUV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedCarJeep", ObjClass.FleetSizeNoOfVechileOwnedCarJeep, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("FeePaymentsChequeNo", ObjClass.FeePaymentsChequeNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("FeePaymentsChequeDate", ObjClass.FeePaymentsChequeDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RBEId", ObjClass.RBEId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            //if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            //{
            //    foreach (CardDetail ObjCardDetails in ObjClass.ObjCardDetail)
            //    {
            //        DataRow dr = dtDBR.NewRow();
            //        dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
            //        dr["VechileNo"] = ObjCardDetails.VechileNo;
            //        dr["VehicleMake"] = ObjCardDetails.VehicleMake;
            //        dr["VehicleType"] = ObjCardDetails.VehicleType;
            //        dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;

            //        dtDBR.Rows.Add(dr);
            //        dtDBR.AcceptChanges();
            //    }
            //}
            //parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorNormalFleetCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorNormalFleetCustomerUpdateModelOutput>> UpdateAggregatorNormalFleetCustomer([FromBody] AggregatorNormalFleetCustomerUpdateModelInput ObjClass)
        {

            var procedureName = "UspAggregatorNormalFleetUpdateRawCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ResidenceStatus", ObjClass.ResidenceStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.PermanentCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentPhoneNo", ObjClass.PermanentPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentFax", ObjClass.PermanentFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyOfficialTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialIndividualInitials", ObjClass.KeyOfficialIndividualInitials, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFax", ObjClass.KeyOfficialFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOA", ObjClass.KeyOfficialDOA, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOB", ObjClass.KeyOfficialDOB, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretQuestion", ObjClass.KeyOfficialSecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretAnswer", ObjClass.KeyOfficialSecretAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTypeOfFleet", ObjClass.KeyOfficialTypeOfFleet, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialCardAppliedFor", ObjClass.KeyOfficialCardAppliedFor, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile1", ObjClass.KeyOfficialApproxMonthlySpendsonVechile1, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile2", ObjClass.KeyOfficialApproxMonthlySpendsonVechile2, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("AreaOfOperation", ObjClass.AreaOfOperation, DbType.String, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedHCV", ObjClass.FleetSizeNoOfVechileOwnedHCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedLCV", ObjClass.FleetSizeNoOfVechileOwnedLCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedMUVSUV", ObjClass.FleetSizeNoOfVechileOwnedMUVSUV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedCarJeep", ObjClass.FleetSizeNoOfVechileOwnedCarJeep, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("FeePaymentNo", ObjClass.FeePaymentNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("FeePaymentDate", ObjClass.FeePaymentDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            //parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);

            //if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            //{
            //    foreach (UpdateCardDetail ObjCardDetails in ObjClass.ObjCardDetail)
            //    {
            //        DataRow dr = dtDBR.NewRow();
            //        dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
            //        dr["VechileNo"] = ObjCardDetails.VechileNo;
            //        dr["VehicleMake"] = ObjCardDetails.VehicleMake;
            //        dr["VehicleType"] = ObjCardDetails.VehicleType;
            //        dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;

            //        dtDBR.Rows.Add(dr);
            //        dtDBR.AcceptChanges();
            //    }
            //}

            //parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorNormalFleetCustomerUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorNormalFleetCustomerKYCModelOutput>> UploadAggregatorNormalFleetCustomerKYC([FromForm] AggregatorNormalFleetCustomerKYCModelInput ObjClass)
        {
            string FileNamePathAddressProofFront = string.Empty;
            var ImageFileNameAddressProofFront = ObjClass.AddressProofFront;
            if (ImageFileNameAddressProofFront.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameAddressProofFront.FileName.Substring(ImageFileNameAddressProofFront.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathAddressProofFront = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofFront.FileName;
                    string filePathAddressProofFront = contentRootPath + FileNamePathAddressProofFront;
                    var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
                    ImageFileNameAddressProofFront.CopyTo(fileStream);
                }
            }


            string FileNamePathPanCard = string.Empty;
            var ImageFileNamePanCard = ObjClass.PanCard;
            if (ImageFileNamePanCard.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNamePanCard.FileName.Substring(ImageFileNamePanCard.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathPanCard = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.PanCardType + "_" + ImageFileNamePanCard.FileName;
                    string filePathPanCard = contentRootPath + FileNamePathPanCard;
                    var fileStream = new FileStream(filePathPanCard, FileMode.Create);
                    ImageFileNamePanCard.CopyTo(fileStream);
                }
            }

            string FileNamePathIdProofFront = string.Empty;
            var ImageFileNameIdProofFront = ObjClass.IdProofFront;
            if (ImageFileNameIdProofFront.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameIdProofFront.FileName.Substring(ImageFileNameIdProofFront.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathIdProofFront = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameIdProofFront.FileName;
                    string filePathIdProofFront = contentRootPath + FileNamePathIdProofFront;
                    var fileStream = new FileStream(filePathIdProofFront, FileMode.Create);
                    ImageFileNameIdProofFront.CopyTo(fileStream);
                }
            }

            string FileNamePathVehicleDetails = string.Empty;
            var ImageFileNameVehicleDetails = ObjClass.VehicleDetails;
            if (ImageFileNameVehicleDetails.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameVehicleDetails.FileName.Substring(ImageFileNameVehicleDetails.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathVehicleDetails = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.VehicleDetailsType + "_" + ImageFileNameVehicleDetails.FileName;
                    string filePathVehicleDetails = contentRootPath + FileNamePathVehicleDetails;
                    var fileStream = new FileStream(filePathVehicleDetails, FileMode.Create);
                    ImageFileNameVehicleDetails.CopyTo(fileStream);
                }
            }

            string FileNamePathCustomerForm = string.Empty;
            var ImageFileNameCustomerForm = ObjClass.CustomerForm;
            if (ImageFileNameCustomerForm.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNameCustomerForm.FileName.Substring(ImageFileNameCustomerForm.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathCustomerForm = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.CustomerFormType + "_" + ImageFileNameCustomerForm.FileName;
                    string filePathCustomerForm = contentRootPath + FileNamePathCustomerForm;
                    var fileStream = new FileStream(filePathCustomerForm, FileMode.Create);
                    ImageFileNameCustomerForm.CopyTo(fileStream);
                }
            }

            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofFront", FileNamePathAddressProofFront, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofType", ObjClass.IdProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofFront", FileNamePathIdProofFront, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardType", ObjClass.PanCardType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PanCard", FileNamePathPanCard, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleDetailsType", ObjClass.VehicleDetailsType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("VehicleDetails", FileNamePathVehicleDetails, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerFormType", ObjClass.CustomerFormType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerForm", FileNamePathCustomerForm, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var procedureName = "UspInsertAggregatorNormalFleetCustomerKYC";
            return await connection.QueryAsync<AggregatorNormalFleetCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorNormalFleetCustomerGetCustomerReferenceNoModelOutput>> GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNo([FromBody] AggregatorNormalFleetCustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNormalFleetNameandFormNumberbyReferenceNo";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorNormalFleetCustomerGetCustomerReferenceNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelOutput>> GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNoforCustomer([FromBody] AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNormalFleetNameandFormNumberbyReferenceNoforCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<AggregatorNormalFleetCustomerDetailsModelOutput> GetUnverfiedAggregatorNormalFleetCustomerDetailbyFormNumber([FromBody] AggregatorNormalFleetCustomerDetailsbyFormNumberModelInput ObjClass)
        {
            var procedureName = "UspGetUnverfiedAggregatorNormalFleetCustomerDetailbyFormNumber";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new AggregatorNormalFleetCustomerDetailsModelOutput();
            storedProcedureResult.GetAggregatorCustomerDetails = (List<AggregatorNormalFleetGetCustomerDetailsModelOutput>)await result.ReadAsync<AggregatorNormalFleetGetCustomerDetailsModelOutput>();
            storedProcedureResult.AggregatorCustomerKYCDetails = (List<AggregatorNormalFleetCustomerKYCDetailsModelOutput>)await result.ReadAsync<AggregatorNormalFleetCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }
        /// <summary>
        /// Fleet Customer Add Card
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AggregatorNormalFleetCustomerAddCardModelOutput>> AggregatorNormalFleetCustomerAddCard([FromForm] AggregatorNormalFleetCustomerAddCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("AggUserDTNoofCards");
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleMake", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("YearOfRegistration", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("RcCopy", typeof(string));

            var procedureName = "UspAggregatorNormalFleetCustomerAddCard";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.RcCopy != null)
            {
                DataTable dtR = new DataTable();
                
                for (int i = 0; i < ObjClass.RcCopy.Count && i < ObjClass.VechileNo.Count &&  i < ObjClass.VehicleMake.Count 
                    && i < ObjClass.VehicleType.Count && i < ObjClass.YearOfRegistration.Count; i++)
                {
                    //var FileName = ObjClass.RcCopy[i].FileName;
                    string FileNamePathRcCopy = string.Empty;
                    var ImageFileNameRcCopy = ObjClass.RcCopy[i].FileName;
                    if (ImageFileNameRcCopy.Length > 0)
                    {
                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                        var ext = ImageFileNameRcCopy.Substring(ImageFileNameRcCopy.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (AllowedFileExtensions.Contains(extension))
                        {
                            string contentRootPath = _hostingEnvironment.ContentRootPath;
                            FileNamePathRcCopy = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                                + "_" + 9 + "_" + ImageFileNameRcCopy;
                            string filePathRcCopy = contentRootPath + FileNamePathRcCopy;
                            var fileStream = new FileStream(filePathRcCopy, FileMode.Create);
                            ObjClass.RcCopy[i].CopyTo(fileStream);
                        }
                    }
                    DataRow dr = dtDBR.NewRow();
                    dr["VechileNo"] = ObjClass.VechileNo[i];
                    dr["VehicleMake"] = ObjClass.VehicleMake[i];
                    dr["VehicleType"] = ObjClass.VehicleType[i];
                    dr["YearOfRegistration"] = ObjClass.YearOfRegistration[i];
                    dr["MobileNo"] = ObjClass.MobileNo ==null?null: ObjClass.MobileNo[i];
                    dr["RcCopy"] = FileNamePathRcCopy;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
             
                parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("CardPreference", ObjClass.CardPreference, DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            }

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorNormalFleetCustomerAddCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        //public async Task<IEnumerable<AggregatorNormalFleetCustomerRCCopyModelOutput>> UploadAggregatorNormalFleetCustomerRCCopy([FromForm] AggregatorNormalFleetCustomerRCCopyModelInput ObjClass)
        //{

        //    string FileNamePathRcCopy = string.Empty;
        //    //var ImageFileNameRcCopy = ObjClass.RcCopy;
        //    //if (ImageFileNameRcCopy.Length > 0)
        //    //{
        //    //    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
        //    //    var ext = ImageFileNameRcCopy.FileName.Substring(ImageFileNameRcCopy.FileName.LastIndexOf('.'));
        //    //    var extension = ext.ToLower();
        //    //    if (AllowedFileExtensions.Contains(extension))
        //    //    {

        //    //        string contentRootPath = _hostingEnvironment.ContentRootPath;
        //    //        FileNamePathRcCopy = "/CustomerKYCImage/" + ObjClass.CustomerReferenceNo + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //    //            + "_" + 9 + "_" + ImageFileNameRcCopy.FileName;
        //    //        string filePathRcCopy = contentRootPath + FileNamePathRcCopy;
        //    //        var fileStream = new FileStream(filePathRcCopy, FileMode.Create);
        //    //        ImageFileNameRcCopy.CopyTo(fileStream);
        //    //    }
        //    //}

        //    var parameters = new DynamicParameters();
        //    parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
        //    // parameters.Add("VechileNo", ObjClass.VechileNo, DbType.String, ParameterDirection.Input);
        //    //parameters.Add("RCCopy", ObjClass.RcCopy, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
        //    parameters.Add("ReferenceNo", Variables.FunGenerateStringUId(), DbType.String, ParameterDirection.Input);
        //    parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();

        //    var procedureName = "UspInsertAggregatorNormalFleetCustomerRCCopy";
        //    return await connection.QueryAsync<AggregatorNormalFleetCustomerRCCopyModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}

        public async Task<IEnumerable<GetAggregatorNormalFleetCustomerStatusModelOutput>> GetAggregatorNormalFleetCustomerStatus([FromBody] GetAggregatorNormalFleetCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNormalFleetCustomerStatus";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNormalFleetCustomerStatusModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<GetAggregatorNormalFleetCustomerStatusModelOutput>> GetAggregatorNormalFleetCustomerStatusApprove([FromBody] GetAggregatorNormalFleetCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNormalFleetCustomerStatusApprove";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNormalFleetCustomerStatusModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<GetAggregatorNormalFleetCustomerModelOutput>> GetAggregatorNormalFleetCustomer([FromBody] GetAggregatorNormalFleetCustomerModelInput ObjClass)
        {

            var procedureName = "UspGetAggregatorNormalFleetCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNormalFleetCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VerifyRejectAggregatorNormalFleetCustomerModelOutput>> VerifyRejectAggregatorNormalFleetCustomer([FromBody] VerifyRejectAggregatorNormalFleetCustomerModelInput ObjClass)
        {
            var procedureName = "UspVerifyRejectAggregatorNormalFleetCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("VerifyRemark", ObjClass.VerifyRemark, DbType.String, ParameterDirection.Input);
            parameters.Add("VerifyBy", ObjClass.VerifyBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VerifyRejectAggregatorNormalFleetCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveRejectAggregatorNormalFleetCustomerModelOutput>> ApproveRejectAggregatorNormalFleetCustomer([FromBody] ApproveRejectAggregatorNormalFleetCustomerModelInput ObjClass)
        {
            var procedureName = "UspApproveRejectAggregatorNormalFleetCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedRemark", ObjClass.ApprovedRemark, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvedby", ObjClass.Approvedby, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectAggregatorNormalFleetCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAggregatorNormalFleetNamebyReferenceNoModelOutput>> GetAggregatorNormalFleetNamebyReferenceNo([FromBody] GetAggregatorNormalFleetNamebyReferenceNoModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNormalFleetNamebyReferenceNo";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNormalFleetNamebyReferenceNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAggregatorFleetCustomerNameByCustomerIdModelOutput>> GetAggregatorFleetCustomerNameByCustomerId([FromBody] GetAggregatorFleetCustomerNameByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorFleetCustomerNameByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorFleetCustomerNameByCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorNormalFleetCustomerAddOnCardModelOutput>> AggregatorNormalFleetCustomerAddOnCard([FromForm] AggregatorNormalFleetCustomerAddOnCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("AggUserDTNoofCards");
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleMake", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("YearOfRegistration", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("RcCopy", typeof(string));

            var procedureName = "UspAggregatorNormalFleetCustomerAddOnCard";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.RcCopy != null)
            {
                DataTable dtR = new DataTable();

                for (int i = 0; i < ObjClass.RcCopy.Count && i < ObjClass.VechileNo.Count && i < ObjClass.VehicleMake.Count
                    && i < ObjClass.VehicleType.Count && i < ObjClass.YearOfRegistration.Count && i < ObjClass.MobileNo.Count; i++)
                {
                    //var FileName = ObjClass.RcCopy[i].FileName;
                    string FileNamePathRcCopy = string.Empty;
                    var ImageFileNameRcCopy = ObjClass.RcCopy[i].FileName;
                    if (ImageFileNameRcCopy.Length > 0)
                    {
                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                        var ext = ImageFileNameRcCopy.Substring(ImageFileNameRcCopy.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (AllowedFileExtensions.Contains(extension))
                        {
                            string contentRootPath = _hostingEnvironment.ContentRootPath;
                            FileNamePathRcCopy = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                                + "_" + 9 + "_" + ImageFileNameRcCopy;
                            string filePathRcCopy = contentRootPath + FileNamePathRcCopy;
                            var fileStream = new FileStream(filePathRcCopy, FileMode.Create);
                            ObjClass.RcCopy[i].CopyTo(fileStream);
                        }
                    }
                    DataRow dr = dtDBR.NewRow();
                    dr["VechileNo"] = ObjClass.VechileNo[i];
                    dr["VehicleMake"] = ObjClass.VehicleMake[i];
                    dr["VehicleType"] = ObjClass.VehicleType[i];
                    dr["YearOfRegistration"] = ObjClass.YearOfRegistration[i];
                    dr["MobileNo"] = ObjClass.MobileNo[i];
                    dr["RcCopy"] = FileNamePathRcCopy;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

                parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("CardPreference", ObjClass.CardPreference, DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorNormalFleetCustomerAddOnCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAggregatorNormalFleetCustomerDownloadKycModelOutput>> GetAggregatorNormalFleetCustomerDownloadKyc([FromBody] GetAggregatorNormalFleetCustomerDownloadKycModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNormalFleetCustomerDownloadKyc";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNormalFleetCustomerDownloadKycModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAggregatorNormalFleetCustomerVerifyCardModelOutput>> GetAggregatorNormalFleetCustomerVerifyCard([FromBody] GetAggregatorNormalFleetCustomerVerifyCardModelInput ObjClass)
        {

            var procedureName = "UspGetAggregatorNormalFleetCustomerVerifyCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNormalFleetCustomerVerifyCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAggregatorNormalFleetCustomerApproveCardModelOutput>> GetAggregatorNormalFleetCustomerApproveCard([FromBody] GetAggregatorNormalFleetCustomerApproveCardModelInput ObjClass)
        {

            var procedureName = "UspGetAggregatorNormalFleetCustomerApproveCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNormalFleetCustomerApproveCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VerifyRejectAggregatorNormalFleetCustomerCardModelOutput>> VerifyRejectAggregatorNormalFleetCustomerCard([FromBody] VerifyRejectAggregatorNormalFleetCustomerCardModelInput ObjClass)
        {
            var procedureName = "UspVerifyRejectAggregatorNormalFleetCustomerCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CardStatus", ObjClass.CardStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("VerifyRemark", ObjClass.VerifyRemark, DbType.String, ParameterDirection.Input);
            parameters.Add("VerifyBy", ObjClass.VerifyBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VerifyRejectAggregatorNormalFleetCustomerCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveRejectAggregatorNormalFleetCustomerCardModelOutput>> ApproveRejectAggregatorNormalFleetCustomerCard([FromBody] ApproveRejectAggregatorNormalFleetCustomerCardModelInput ObjClass)
        {
            var procedureName = "UspApproveRejectAggregatorNormalFleetCustomerCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CardStatus", ObjClass.CardStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedRemark", ObjClass.ApprovedRemark, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvedby", ObjClass.Approvedby, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectAggregatorNormalFleetCustomerCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        // Below Code Not Completed

        public async Task<IEnumerable<AggregatorCustomerFeewaiverApprovalModelOutput>> ApproveRejectAggregatorFeewaiver([FromBody] AggregatorCustomerFeewaiverApprovalModelInput ObjClass)
        {
            var procedureName = "UspApproveRejectAggregatorFeewaiver";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerFeewaiverApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetApproveAggregatorFeeWaiverDetailModelOutput> GetApproveAggregatorFeeWaiverDetail([FromBody] GetApproveAggregatorFeeWaiverDetailModelInput ObjClass)
        {
            var procedureName = "UspGetApproveAggregatorFeeWaiverDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetApproveAggregatorFeeWaiverDetailModelOutput();
            storedProcedureResult.GetApproveAggregatorFeeWaiverBasicDetail = (List<GetApproveAggregatorFeeWaiverBasicDetailModelOutput>)await result.ReadAsync<GetApproveAggregatorFeeWaiverBasicDetailModelOutput>();
            storedProcedureResult.GetApproveAggregatorFeeWaiverCardDetail = (List<GetApproveAggregatorFeeWaiverCardDetailModelOutput>)await result.ReadAsync<GetApproveAggregatorFeeWaiverCardDetailModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<AggregatorCustomerGetCustomerReferenceNoModelOutput>> GetAggregatorNameandFormNumberbyReferenceNoforAddCard([FromBody] AggregatorCustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            var procedureName = "UspGetNameandFormNumberbyReferenceNoforAddCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerReferenceNo", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerGetCustomerReferenceNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<AggregatorCustomerDetailsModelOutput> GetAggregatorCustomerDetails([FromBody] AggregatorCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerTypeId", ObjClass.CustomerTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtypeId", ObjClass.CustomerSubtypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeID", ObjClass.ZonalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfFleetId", ObjClass.TypeOfFleetId, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", ObjClass.ReferenceId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusId", ObjClass.CustomerStatusId, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonFromDate", ObjClass.ApprovedonFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonToDate", ObjClass.ApprovedonToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusFeewaiverID", ObjClass.CustomerStatusFeewaiverID, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedBy", ObjClass.FeewaiverApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnFromDate", ObjClass.FeewaiverApprovedOnFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnToDate", ObjClass.FeewaiverApprovedOnToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new AggregatorCustomerDetailsModelOutput();
            storedProcedureResult.GetAggregatorCustomerDetails = (List<AggregatorGetCustomerDetailsModelOutput>)await result.ReadAsync<AggregatorGetCustomerDetailsModelOutput>();
            storedProcedureResult.AggregatorCustomerKYCDetails = (List<AggregatorCustomerKYCDetailsModelOutput>)await result.ReadAsync<AggregatorCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<AggregatorCustomerDetailsModelOutput> GetAggregatorCustomerByCustomerId([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorCustomerDetailByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new AggregatorCustomerDetailsModelOutput();
            storedProcedureResult.GetAggregatorCustomerDetails = (List<AggregatorGetCustomerDetailsModelOutput>)await result.ReadAsync<AggregatorGetCustomerDetailsModelOutput>();
            storedProcedureResult.AggregatorCustomerKYCDetails = (List<AggregatorCustomerKYCDetailsModelOutput>)await result.ReadAsync<AggregatorCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
            //return await connection.QueryAsync<CustomerDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<AggregatorCustomerDetailsModelOutput> GetRawAggregatorCustomerDetails([FromBody] AggregatorCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorRawCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerTypeId", ObjClass.CustomerTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtypeId", ObjClass.CustomerSubtypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeID", ObjClass.ZonalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfFleetId", ObjClass.TypeOfFleetId, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", ObjClass.ReferenceId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusId", ObjClass.CustomerStatusId, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonFromDate", ObjClass.ApprovedonFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonToDate", ObjClass.ApprovedonToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusFeewaiverID", ObjClass.CustomerStatusFeewaiverID, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedBy", ObjClass.FeewaiverApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnFromDate", ObjClass.FeewaiverApprovedOnFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnToDate", ObjClass.FeewaiverApprovedOnToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new AggregatorCustomerDetailsModelOutput();
            storedProcedureResult.GetAggregatorCustomerDetails = (List<AggregatorGetCustomerDetailsModelOutput>)await result.ReadAsync<AggregatorGetCustomerDetailsModelOutput>();
            storedProcedureResult.AggregatorCustomerKYCDetails = (List<AggregatorCustomerKYCDetailsModelOutput>)await result.ReadAsync<AggregatorCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<BindPendingAggregatorCustomerModelOutput>> BindPendingAggregatorCustomer([FromBody] BindPendingAggregatorCustomerModelInput ObjClass)
        {
            var procedureName = "UspBindPendingAggregatorCustomer";
            var parameters = new DynamicParameters();
            //parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            //parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            //parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingAggregatorCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorCustomerGetCustomerNameModelOutput>> GetAggregatorCustomerNameByCustomerId([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorCustomerNameByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerGetCustomerNameModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorCustomerGetCustomerDetailsForSearchModelOutput>> GetAggregatorCustomerDetailsForSearch([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorCustomerDetailsForSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerGetCustomerDetailsForSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<SearchAggregatorCustomerandCardFormModelOutput> SearchAggregatorCustomerandCardForm([FromBody] SearchAggregatorCustomerandCardFormModelInput ObjClass)
        {
            var procedureName = "UspSearchAggregatorCustomerandCardForm";
            var parameters = new DynamicParameters();
            parameters.Add("EntityId", ObjClass.EntityId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("StateID", ObjClass.StateID, DbType.String, ParameterDirection.Input);
            parameters.Add("CityName", ObjClass.CityName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new SearchAggregatorCustomerandCardFormModelOutput();
            storedProcedureResult.GetAggregatorCustomerSearchOutput = (List<AggregatorCustomerSearchModelOutput>)await result.ReadAsync<AggregatorCustomerSearchModelOutput>();
            storedProcedureResult.GetAggregatorCardSearchOutput = (List<AggregatorCardSearchModelOutput>)await result.ReadAsync<AggregatorCardSearchModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetAggregatorNameandFormNumberbyCustomerIdModelOutput>> GetAggregatorNameandFormNumberbyCustomerId([FromBody] GetAggregatorNameandFormNumberbyCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorNameandFormNumberbyCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorNameandFormNumberbyCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AggregatorCustomerAddOnUserModelOutput>> AggregatorCustomerAddOnUser([FromBody] AggregatorCustomerAddOnUserModelInput ObjClass)
        {
            var procedureName = "UspAggregatorCustomerAddOnUser";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AggregatorCustomerAddOnUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetAggregatorStatusModelOutput>> GetAggregatorStatusList([FromBody] GetAggregatorStatusModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorStatus";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAggregatorStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAggregatorCustomerForZOHOApprovalModelOutput>> GetAggregatorCustomerForZOHOApproval([FromBody] GetAggregatorCustomerForZOHOApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetAggregatorCustomerForZOHOApproval";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            return await connection.QueryAsync<GetAggregatorCustomerForZOHOApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetAggregateUserDetailForApprovalModelOutput>> GetAggregateUserDetailForApproval([FromBody] GetAggregateUserDetailForApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetAggregateUserDetailForApproval";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("AggregatorID", ObjClass.AggregatorID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            return await connection.QueryAsync<GetAggregateUserDetailForApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveRejectAggregateUserApprovalModelOutput>> ApproveRejectAggregateUserApproval([FromBody] ApproveRejectAggregateUserApprovalModelInput ObjClass)
        {
            var dtDBR = new DataTable("AggregatorUserForApproval");
            dtDBR.Columns.Add("UserName", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            if (ObjClass.UserDetail != null)
            {
                foreach (AggregatorUserForApproval ObjCustomerDetail in ObjClass.UserDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["UserName"] = ObjCustomerDetail.UserName;
                    dr["Comments"] = ObjCustomerDetail.Comments;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }


            var procedureName = "UspApproveRejectAggregateUserApproval";
            var parameters = new DynamicParameters();

            parameters.Add("ApprovalStatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("AggregatorUserForApproval", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectAggregateUserApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }

}
