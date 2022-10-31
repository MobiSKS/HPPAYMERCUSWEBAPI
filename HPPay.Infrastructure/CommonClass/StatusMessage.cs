﻿using System.ComponentModel.DataAnnotations;

namespace HPPay.Infrastructure.CommonClass
{
    public class StatusMessage
    {
        public enum StatusInformation
        {
            [Display(Name = "Record Found")] Success = 1000,
            [Display(Name = "No Record Found")] Fail = 1001,
            [Display(Name = "API Key and Secret Key is null.Please Pass API Key and Secret Key")] API_Key_Secret_Key_Is_Null = 1002,
            [Display(Name = "API Key is Null.Please Pass API Key")] API_Key_Is_Null = 1003,
            [Display(Name = "Secret Key is Null.Please pass Secret Key")] Secret_Key_Is_Null = 1004,
            [Display(Name = "Please Try Again")] Internel_Error = 1005,
            [Display(Name = "API Key or Secret Key is Invalid")] API_Key_Is_Secret_Key_Invalid = 1006,
            [Display(Name = "API Key is Invalid")] API_Key_Is_Invalid = 1007,
            [Display(Name = "Secret Key is Invalid")] Secret_Key_Is_Invalid = 1008,
            [Display(Name = "Exception Code")] Exception_Code = 1009,
            [Display(Name = "Enter 10 Digit Mobile Number")] Enter_10_Digit_Mobile_Number = 1010,
            [Display(Name = "Non Numeric Value")] Non_Numeric_Value = 1011,
            [Display(Name = "Mobile Number Start With 6,7,8,9")] Mobile_Number_Start_With_6_7_8_9 = 1012,
            [Display(Name = "Mobile Number Card Already Exists")] Mobile_Number_Card_Already_Exists = 1013,
            [Display(Name = "Customer Id Already Exists")] Customer_Id_Already_Exists = 1014,
            [Display(Name = "Customer Type is Not Match With Our Master")] Customer_Type_Is_Not_Match_With_Our_Master = 1015,
            [Display(Name = "User Agent or User IP or User Id is Null")] User_Agentor_User_IP_User_Id_is_null = 1016,
            [Display(Name = "Request JSON Body Is Null")] Request_JSON_Body_Is_Null = 1017,
            [Display(Name = "Role Created Successfully")] Success_Message_Manage_Role_Creation = 1018,
            [Display(Name = "Role Added or Edited Successfully")] Success_Message_Add_Edit_Manage_Role_Creation = 1019,
            [Display(Name = "HPPay User Location Role Created Successfully")] Success_Message_HPPay_User_Loc_Role_Creation = 1020,
            [Display(Name = "Admin User Approved Successfully")] Success_Message_Approve_Admin_User = 1021,
            [Display(Name = "Mail Sent Succesfully")] Success_Message_Forgot_Password = 1022,
            [Display(Name = "Logout Successfully")] Success_Message_Change_Password = 1023,
            [Display(Name = "Card Added Successfully")] Success_ADD_CARD = 1024,
            [Display(Name = "Manadatory Feild Required")] Manadatory_Feild_Required = 1025,
            [Display(Name = "Database Response")] Database_Response = 1026,
            [Display(Name = "User was deactivated")] User_deactivate = 1027,
            [Display(Name = "Customer was deactivate")] Customer_deactivate = 1028,
            [Display(Name = "Merchant was deactivate")] Merchant_deactivate = 1029,
            [Display(Name = "Transaction Success")] Transaction_Success = 1030,
            [Display(Name = "Transaction Failed")] Transaction_Failed = 1031,
            [Display(Name = "Vehicle No. already exists. Please enter different Vehicle No.")] Vechile_No = 1032,
            [Display(Name = "Email Id is already exits")] Email_Id_is_already_present = 1033,
            [Display(Name = "Username or Emp Id is already exits")] Username_or_Emp_Id_is_already_exits = 1034,
            [Display(Name = "Officer not exits")] Officer_not_exits = 1035,
            [Display(Name = "Location already mapped")] Location_already_mapped = 1036,
            [Display(Name = "Location not exits")] Location_not_exits = 1037,
            [Display(Name = "Username available")] Username_available = 1038,
            [Display(Name = "Username exits")] Username_exits = 1039,
            [Display(Name = "Customer not found")] Customer_not_found = 1040,
            [Display(Name = "Card Not Found")] Card_Not_Found = 1041,
            [Display(Name = "Invalid Approval Status")] Invalid_Approval_Status = 1042,
            [Display(Name = "Invalid Status Found")] Invalid_Status_Found = 1043,
            [Display(Name = "You can create only one or two terminal at the time of merchant creation")] Terminal_Creation = 1044,
            [Display(Name = "ErpCode is already registered")] ErpCode_already_registered = 1045,
            [Display(Name = "Merchant is already registered")] Merchant_already_registered = 1046,
            [Display(Name = "Failed due to one time transcation limit")] Failed_due_to_one_time_Transcation_limit = 1047,
            [Display(Name = "Failed due to day transcation limit")] Failed_due_to_day_transcation_limit = 1048,
            [Display(Name = "Failed due to monthly transcation limit")] Failed_due_to_monthly_transcation_limit = 1049,
            [Display(Name = "Failed due to transcation error")] Failed_due_to_transcation_error = 1050,
            [Display(Name = "Failed due to insufficient balance in card")] Failed_due_to_insufficient_balance_in_card = 1051,
            [Display(Name = "Failed due to one time CCCMS limit")] Failed_due_to_one_time_CCCMS_limit = 1052,
            [Display(Name = "Failed due to daily CCCMS limit")] Failed_due_to_daily_CCCMS_limit = 1053,
            [Display(Name = "RBE ID or RBE Name does not exist")] RBE_ID_or_RBE_Name_does_not_exist = 1054,
            [Display(Name = "Failed due to monthly CCCMS limit")] Failed_due_to_monthly_CCCMS_limit = 1055,
            [Display(Name = "Failed due to yearly CCCMS limit")] Failed_due_to_yearly_CCCMS_limit = 1056,
            [Display(Name = "Invalid sale type")] Invalid_sale_type = 1057,
            [Display(Name = "Customer is not active")] Customer_is_not_active = 1058,
            [Display(Name = "Service is not active at this card")] Service_is_not_active_at_this_card = 1059,
            [Display(Name = "Service is not active at this merchant")] Service_is_not_active_at_this_merchant = 1060,
            [Display(Name = "Card is not active")] Card_is_not_active = 1061,
            [Display(Name = "Terminal is not active")] Terminal_is_not_active = 1062,
            [Display(Name = "Merchant is not active")] Merchant_is_not_active = 1063,
            [Display(Name = "Details no found")] Details_no_found = 1064,
            [Display(Name = "Officer is not active")] Officer_is_not_active = 1065,
            [Display(Name = "Customer Reference no not found")] Customer_Reference_no_not_found = 1066,
            [Display(Name = "Form Number already exists")] Form_Number_is_already_exits = 1067,
            [Display(Name = "Pancard is already exits")] Pancard_is_already_present = 1068,
            [Display(Name = "Mobile No. already exists. Please enter different Mobile No.")] Mobile_No_is_already_present_Please_pass_different_Mobileno = 1069,
            [Display(Name = "Card No is already present.Please pass different Card no")] Card_No_is_already_present_Please_pass_different_Cardno = 1070,
            [Display(Name = "No any card is available for mapping")] No_any_card_is_available_for_mapping = 1071,
            [Display(Name = "Please try again")] Please_try_again = 1072,
            [Display(Name = "Not found")] Not_found = 1073,
            [Display(Name = "Trans Type Mismatched")] Trans_Type_Mismatched = 1074,
            [Display(Name = "Batch Already Settled")] Batch_Already_Settled = 1075,
            [Display(Name = "Transaction Mismatched")] Transaction_Mismatched = 1076,

            [Display(Name = "Zonal Office not found")] Zonal_Office_not_found = 1077,
            [Display(Name = "Regional Office not found")] Regional_Office_not_found = 1078,
            [Display(Name = "Country Region not found")] Country_Region_not_found = 1079,
            [Display(Name = "State not found")] State_not_found = 1080,
            [Display(Name = "District not found")] District_not_found = 1081,
            [Display(Name = "City not found")] City_not_found = 1082,
            [Display(Name = "Country not found")] Country_not_found = 1083,
            [Display(Name = "Country Zone not found")] Country_Zone_not_found = 1084,
            [Display(Name = "Invalid Username and Password")] Invalid_Username_Password = 1085,

            [Display(Name = "Merchant is Approved")] Merchant_is_Approved = 1086,
            [Display(Name = "Merchant is Temporary Hotlisted")] Merchant_is_Temporary_Hotlisted = 1087,
            [Display(Name = "Merchant is Active")] Merchant_is_Active = 1088,
            [Display(Name = "Merchant is Permanent Hotlisted")] Merchant_is_Permanent_Hotlisted = 1089,
            [Display(Name = "Merchant is Pending")] Merchant_is_Pending = 1090,
            [Display(Name = "Merchant is UnApproved")] Merchant_is_UnApproved = 1091,
            [Display(Name = "Merchant is Reactivate")] Merchant_is_Reactivate = 1092,
            [Display(Name = "Merchant is Rejected")] Merchant_is_Rejected = 1093,
            [Display(Name = "Merchant is Temporary Hotlisted Approval Pending")] Merchant_is_Temporary_Hotlisted_Approval_Pending = 1094,
            [Display(Name = "Merchant is Permanent Hotlisted Approval Pending")] Merchant_is_Permanent_Hotlisted_Approval_Pending = 1095,
            [Display(Name = "Merchant is Reactivate Approval Pending")] Merchant_is_Reactivate_Approval_Pending = 1096,


            [Display(Name = "Customer is Approved")] Customer_is_Approved = 1097,
            [Display(Name = "Customer is Temporary Hotlisted")] Customer_is_Temporary_Hotlisted = 1098,
            [Display(Name = "Customer is Active")] Customer_is_Active = 1099,
            [Display(Name = "Customer is Permanent Hotlisted")] Customer_is_Permanent_Hotlisted = 1100,
            [Display(Name = "Customer is Pending")] Customer_is_Pending = 1101,
            [Display(Name = "Customer is Unverified")] Customer_is_Unverified = 1102,
            [Display(Name = "Customer is Verified")] Customer_is_Verified = 1103,
            [Display(Name = "Customer is Verification Rejected")] Customer_is_Verification_Rejected = 1104,
            [Display(Name = "Customer is Rejected")] Customer_is_Rejected = 1105,
            [Display(Name = "Customer is Reactivate")] Customer_is_Reactivate = 1106,
            [Display(Name = "Customer is Temporary Hotlisted Approval Pending")] Customer_is_Temporary_Hotlisted_Approval_Pending = 1107,
            [Display(Name = "Customer is Permanent Hotlisted Approval Pending")] Customer_is_Permanent_Hotlisted_Approval_Pending = 1108,
            [Display(Name = "Customer is Reactivate Approval Pending")] Customer_is_Reactivate_Approval_Pending = 1109,

            [Display(Name = "Card is UnApproved")] Card_is_UnApproved = 1110,
            [Display(Name = "Card is Approved")] Card_is_Approved = 1111,
            [Display(Name = "Card is InProcessing")] Card_is_InProcessing = 1112,
            [Display(Name = "Card is ErrorWhileProcessing")] Card_is_ErrorWhileProcessing = 1113,
            [Display(Name = "Card is Active")] Card_is_Active = 1114,
            [Display(Name = "Card is InActive")] Card_is_InActive = 1115,
            [Display(Name = "Card is Temporary Hotlisted")] Card_is_Temporary_Hotlisted = 1116,
            [Display(Name = "Card is Expired")] Card_is_Expired = 1117,
            [Display(Name = "Card is Permanent Hotlisted")] Card_is_Permanent_Hotlisted = 1118,
            [Display(Name = "Card is Pending")] Card_is_Pending = 1119,
            [Display(Name = "Card is Unverified")] Card_is_Unverified = 1120,
            [Display(Name = "Card is Verified")] Card_is_Verified = 1121,
            [Display(Name = "Card is Verification Rejected")] Card_is_Verification_Rejected = 1122,
            [Display(Name = "Card is Reactivate")] Card_is_Reactivate = 1123,
            [Display(Name = "Card is Temporary Hotlisted Approval Pending")] Card_is_Temporary_Hotlisted_Approval_Pending = 1124,
            [Display(Name = "Card is Permanent Hotlisted Approval Pending")] Card_is_Permanent_Hotlisted_Approval_Pending = 1125,
            [Display(Name = "Card is Reactivate Approval Pending")] Card_is_Reactivate_Approval_Pending = 1126,
            [Display(Name = "Card is Rejected")] Card_is_Rejected = 1127,
            [Display(Name = "No Record Found")] No_record_found = 1128,
            [Display(Name = "Customer is Hotlisted")] Customer_is_Hotlisted = 1129,
            None = int.MaxValue
        }



    }
    public enum IdfcApiStatus
    {
        [Display(Name = "None")] None = 0,
        [Display(Name = "Success")] Success = 700,
        [Display(Name = "Insufficient Distributor Balance")] Insufficient_Distributor_Balance = 701,
        [Display(Name = "Insufficient Corporate Customer Balance")] Insufficient_Corporate_Customer_Balance = 702,
        [Display(Name = "Maximum Balance Breached")] Maximum_Balance_Breached = 703,
        [Display(Name = "Maximum Cumulative Recharge Breached")] Maximum_Cumulative_Recharge_Breached = 704,
        [Display(Name = "Invalid Agency Id")] Invalid_Agency_Id = 705,
        [Display(Name = "Invalid Tag ID")] Invalid_Tag_ID = 706,
        [Display(Name = "Invalid Amount")] Invalid_Amount = 707,
        [Display(Name = "Invalid Transaction ID")] Invalid_Transaction_ID = 708,
        [Display(Name = "Invalid Signature")] Invalid_Signature = 709,
        [Display(Name = "Others")] Others = 710,
        [Display(Name = "Invalid date range")] Invalid_date_range = 712,
        [Display(Name = "Invalid Vehicle No")] Invalid_Vehicle_No = 722,
        [Display(Name = "Invalid Txn Ref No")] Invalid_Txn_Ref_No = 723,
        [Display(Name = "Invalid date format. Please use ddMMyyyyHHmmss")] Invalid_date_format = 724,
        [Display(Name = "Vehicle not in Low balance, Active and Hotlist state")] Vehicle_not_in_Low_balance_Active_and_Hotlist_state = 725,
        [Display(Name = "Invalid Request")] Invalid_Request = 797,
        [Display(Name = "Invalid authentication header in request")] Invalid_authentication_header_in_request = 798,
        [Display(Name = "Duplicate txn ref no")] Duplicate_txn_ref_no = 726,
        [Display(Name = "Closed Tag Account")] Closed_Tag_Account = 727,
        [Display(Name = "Partial Success")] Partial_Success = 728,
        [Display(Name = "To be contd. As needed")] To_be_contd_As_needed = 729,
        [Display(Name = "Invalid Mobile No")] Invalid_Mobile_No = 730,
        [Display(Name = "Mobile no. is not mapped valid customer Id")] Mobile_no_is_not_mapped_valid_customer_Id = 731,
        [Display(Name = "Single mobile no. mapped with multiple customer Ids")] Single_mobile_no_mapped_with_multiple_customer_Ids = 732,
        [Display(Name = "Insufficient Balance")] Insufficient_Balance = 733,


        [Display(Name = "Amount should Not be Zero ")] Amount_Zero = 6001,
        [Display(Name = "Unhandeled Exception ")] Unhandeled_Exception = 6002,
        [Display(Name = "Amount lessthen ccms balance")] Amount_lessthen_ccms = 6003,
        [Display(Name = "Merchant Not Active")] Merchant_Not_Active = 6004,
        [Display(Name = "Terminal Not Active")] Terminal_Not_Active = 6005,
        [Display(Name = "InvoiceId BatchId Exist")] InvoiceId_BatchId_Exist = 6006,
        [Display(Name = "TxnID Not Genrated ")] TxnID_Not_Genrated = 6007,
        [Display(Name = "Customer Not Active")] Customer_Not_Active = 6003,

    }

    public enum BankName
    {
        IDFC = 1,
        ICICI = 2
    }

    public enum ValidationStatus
    {
        Amount_lessthen_ccms = 2,
        Merchant_Not_Active = 3,
        Terminal_Not_Active = 4,
        Customer_Not_Active = 5

    }
}