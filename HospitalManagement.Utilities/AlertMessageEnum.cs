using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HospitalManagement.Utilities.enums;

public class AlertMessageEnum
{

    public enum AlertMsg
    {
        [Display(Name = "Record saved successfully.")] insertMsg = 1,
        [Display(Name = "Record updated successfully.")] updatetMsg = 2,
        [Display(Name = "Record deleted successfully.")] deleteMsg = 3,
        [Display(Name = "Record Already exists.")] alreadyMsg = 4,
        [Display(Name = "Number is not in the valid range.")] alreadyMsg1 = 4,
        [Display(Name = "Cheque Number is Already In Same Account Number")] alreadyMsg2 = 9000,
        [Display(Name = "Cheque Book  Already Issued")] alreadyMsg4 = 900,
        [Display(Name = "All fields are mandatory.")] mandatoryMsg = 5,
        [Display(Name = "Record not found.")] notFoundMsg = 6,
        [Display(Name = "Please,try after sometime.")] userMsg = 7,
        [Display(Name = "Record is not deleted,please try after sometime.")] notDeleteMsg = 8,
        [Display(Name = "State is already used in Division Master.")] StateAlreadyUsedDivisionMsg = 9,
        [Display(Name = "Division is already used in District Master.")] DivisionAlreadyUsedDistrictMsg = 10,
        [Display(Name = "Management Group is already used in School Management Group Detail.")] SmgAlreadyUsedSmgdMsg = 11,
        [Display(Name = "School Medium is already used in School Registration.")] SchoolMediumAlreadyUsedSchoolRegMsg = 12,
        [Display(Name = "School Management Group Detail is already used in School Registration.")] SmgdAlreadyUsedSchoolRegMsg = 13,
        [Display(Name = "Habitation is already used in School Registration.")] HabitationAlreadyUsedSchoolRegMsg = 14,
        [Display(Name = "Request approved successfully.")] RecordApproved = 15,
        [Display(Name = "Request rejected successfully.")] RecordRejected = 16,
        [Display(Name = "Request Generated successfully.")] RequestGenerated = 17,
        [Display(Name = "Invalid UDISE Code.")] InvalidUDISECode = 18,
        [Display(Name = "Invalid OTP")] InvalidOTP = 19,
        [Display(Name = "Invalid Remark")] InvalidRemark = 20,
        [Display(Name = " is already used in School Registration.")] AlreadyUsedRecord = 21,
        [Display(Name = " ToDate must be greater than or equal to the FromDate and Month must be same(ex : 01/01/2021 - 31/01/2021)")] DateValidation = 22,
        [Display(Name = " is already used in User Role Master.")] AlreadyUsedRole = 23,
        [Display(Name = " Upload PDF File Only.")] UploadPDFFileOnly = 24,
        [Display(Name = " Leave Approve Successfully.")] LeaveApprove = 25,
        [Display(Name = " Leave Rejected Successfully.")] LeaveReject = 26,
        [Display(Name = " Department Leave Approver Already Exists.")] DepartmentApproverExists = 27,
        [Display(Name = "Uploded file Size less Then 400kb")] FileSize = 28,
        [Display(Name = " Refrence No. Already Exists .")] RefrenceNoExist = 29,
        [Display(Name = "Album Photos Must be in .pdf\", \".PDF\", \".img\", \".IMG\", \".jpg\", \".JPG\", \"jpeg\", \"JPEG\", \".png\", \".PNG\"")] PhotoCheck = 30,
        [Display(Name = " Upload Document Size is more than 500 KB ?? .")] DocumentSize = 31,
        [Display(Name = "Request Sent Successfully.")] ReqtMsg = 32,
        [Display(Name = "Error")] ErrorMsg = 33,
        [Display(Name = "Invalid Data")] ValidData = 34,
        [Display(Name = "Upload PDF File and Image Only")] PdfAndImage = 35,
        [Display(Name = "Please Upload Document")] UploadDoc = 36,
        #region Transport
        [Display(Name = "Vehicle Number Or Driver Already Exists:")] VehicleOrDriverAlreadyReg = 37,
        [Display(Name = "Vehicle Number Or Attender Already Exists:")] VehicleOrAttenderAlreadyReg = 38,
        [Display(Name = "Route To Vehicle Unmap Successfully")] RouteToVechileUnmapSuce = 39,
        [Display(Name = "Route To Stop Unmap Successfully")] RouteToStopUnmapSuces = 52,
        [Display(Name = "Vehile Already In")] AlreadyIn = 85,
        [Display(Name = "Vehile Already Out")] AlreadyOut = 86,


        #endregion

        #region Grievance
        [Display(Name = "Grievance File Id not supplied!")] GVIDnotsupplied = 53,
        [Display(Name = "Grievance Details not found!")] GVIDnotfound = 40,
        [Display(Name = "Grievance Details Found Successfully")] GVIDfound = 41,
        [Display(Name = "Grievance Dispose Successfully")] GVIDdispose = 42,
        [Display(Name = "Grievance Disposed Failure Try Again After Sometime! ")] GVIDdisposefailure = 43,
        [Display(Name = "Uploaded file is empty or null.")] GVIDFileempty = 44,
        [Display(Name = "Grievance Disposed Details not properly filled!")] GVIDdisposeinvalidedetails = 45,
        [Display(Name = "Grievance Disposed Details document not supported!")] GVIDinvalidDoc = 46,
        [Display(Name = "Grievance Successfully Registered . Your Grievance No. : ")] GVIDregister = 47,
        [Display(Name = " file extension is not valid.")] GVIDInvaildFileExt = 48,
        [Display(Name = "file size is bigger than 2MB.")] GVID2MB = 49,
        [Display(Name = "Grievance Request Cancel SuccessFully! ")] GVIDReqCancel = 50,
        #endregion

        [Display(Name = "Vehicle Number :-")] VehicleNumber = 51,

        #region Transfer
        [Display(Name = "For mutual transfer panel must be the same for both the employees.")]
        MutualTransferSubjectPanelMismatch = 98,

        [Display(Name = "You cannot choose the same school/office/institute for mutual transfer.")]
        MutualTransferSameSchoolError = 89,

        [Display(Name = "For mutual transfer, the designation of both employees must be the same.")]
        MutualTransferDesignationMismatch = 54,

        [Display(Name = "You cannot apply for mutual transfer as age is greater than or equal to 62.")]
        MutualTransferAgeLimitError = 55,

        [Display(Name = "You have already applied for transfer, and your request is under process.")]
        AlreadyAppliedMessage = 56,

        [Display(Name = "You cannot choose yourself for mutual transfer, please enter a valid Unique ID.")] SelfSelectionError = 57,

        [Display(Name = "Document file size should not be more than 500 KB.")] DocFileSize = 58,

        [Display(Name = "Please upload transfer draft application.")] DraftRequired = 59,

        [Display(Name = "Transfer request approved successfully and processed for DSC.")] TransferApproval = 60,

        [Display(Name = "Effective Date cannot be less than Order Date.")] EffectiveOrderDate = 61,
        [Display(Name = "Relieving Date cannot be less than Order Date.")] RelievingOrderDate = 62,
        [Display(Name = "Relieving Date cannot be less than Effective Date.")] RelievingeffectiveOrderDate = 63,
        [Display(Name = "Request rejected successfully.")] RejectRequest = 64,
        [Display(Name = "file not available.")] FilenotAvailable = 65,
        [Display(Name = "The order has not been generated yet.The request is in process.")] OrderProcess = 66,
        [Display(Name = "Vacant post not available.")] VacancyNotAvailable = 68,
        [Display(Name = "Promotion details saved successfully,now you can generate orders.")] PromotionDetailSave = 69,
        [Display(Name = "UnKnown.")] Unknown = 70,
        [Display(Name = "Ok.")] Ok = 71,
        [Display(Name = "Order generated successfully.")] OrderGenerate = 72,
        [Display(Name = "Promotion order hold successfully.")] PromotionOrderHold = 73,
        [Display(Name = "Previous dates are not allowed. Please select a date from today or later.")] PreviousDateMsg = 74,
        [Display(Name = "Order already generated.")] AlreadyOrderMsg = 75,
        [Display(Name = "Select at least one record.")] SelectMsg = 76,
        [Display(Name = "For Promotion designation and payscale can not be same as previous.")] PromerrorMsg = 77,
        [Display(Name = "Your Transfer Request Saved Successfully,Please download and lock the draft application to complete the process.Your Transfer Request Number is:")] TransferDraftMsg = 78,
        [Display(Name = "You are not allowed to fill voluntary transfer request as your service is less than 3 years:")] LessServiceMsg = 79,
        [Display(Name = "You can not select this location as your subject panel does not match with vacant post")] PanelmismatchMsg = 80,
        [Display(Name = "Maximum twenty entries are allowed.")] MaximumEnteriesMsg = 81,
        [Display(Name = "Record is already exists in the list please choose different option.")] RecordExistMsg = 82,
        [Display(Name = "You can not eligible for transfer as your age is 62.")] NotEligibleMsg = 83,
        [Display(Name = "Old and new values must not be identical")] NotIdenticalMsg = 84,
        [Display(Name = "DSC completed successfully.")] DSCCompletedMsg = 87,
        [Display(Name = "File size should not be greater than 500 KB.")] MaxFileSizeMsg = 88,
        [Display(Name = "3 Years have not been completed since last transfer for the candidate, So the candidate is not eligible for this transfer as of now.")] Last3YearsNotComplete = 107,
        [Display(Name = "You are not eligible to apply for this transfer as you already have an active transfer request.")] NotEligibleDueToActiveTransferRqst = 108,
        [Display(Name = "You are not eligible to apply for voluntary transfer as you have an active departmental enquiry.")] NotEligibleDueToActiveDeptEnquiry = 109,
        [Display(Name = "1 year or less than 1 year have been left for the candidate to retire, So the candidate is not eligible for this transfer.")] Only1YearsLeftForRetirement = 110,
        [Display(Name = "Employee is critically ill, So they are not eligible for this transfer.")] EmpIsCriticallIll = 111,
        [Display(Name = "Invalid Cheque Range.")] InvalidChequeRangeMsg = 112,
        [Display(Name = "You are not able to edit after 15 days.")] InvalidDateMsg = 113,


        #endregion


        #region UserManageMent
        [Display(Name = "Sequence No. Already Exists.")] SequenceNo = 67,
        #endregion

        #region CivilConstruction
        [Display(Name = "This vendor is associated with an active project and cannot be marked as inactive.")] VendorUsedInProject = 90,
        [Display(Name = "PAN ")] PAN = 91,
        [Display(Name = "GSTIN ")] GSTIN = 92,
        #endregion

        #region Finance & Budget
        [Display(Name = "already exists.")] alreadyExistsMsg = 95,
        [Display(Name = "New effective date must be after than the previous effective date.!")] EffectiveDateCompareMsg = 96,
        [Display(Name = "No changes were found in the current available data!")] NoChangesfoundMsg = 97,
		[Display(Name = "Budget Already Allocate for Selected Date!")] BudgetAllocateAlready = 98,
		#endregion Finance & Budget
		#region Scheme & Student
		[Display(Name = "Invalid Samagra ID")] InvalidSmagraId = 100,
        #endregion
          [Display(Name = "Employee Is Not Eligible For Retirment")] MsgValRetirement = 101,

        #region Change Password

         [Display(Name = "Invalid Current Password!")] MsgValCurrentPassword = 102,
         [Display(Name = "Registered Email Id does not exist!")] MsgValRegisteredEmail = 103,
         [Display(Name = "OTP successfully sent to registered Email ID.")] MsgValOTPSuccessCP = 104,
         [Display(Name = "failed to send OTP to registered Email ID.")] MsgValOTPfailedCP = 105,
         [Display(Name = "Password successfully updated.")] MsgPasswordUpdatedSuccess = 106,
         

        #endregion Change Password
    }
    public enum AlertCode
    {
        [Display(Name = "success")] sucessCode = 1,
        [Display(Name = "warning")] WarningCode = 2,
        [Display(Name = "error")] errorCode = 3,
        [Display(Name = "info")] infoCode = 4,
    }

    public static string GetEnumDisplayName(Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DisplayAttribute displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

        return displayAttribute?.Name ?? value.ToString();
    }

}