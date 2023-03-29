using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels.AttendenceInformation
{
    public class LeaveApply
    {
        [Key]
        [Display(Name ="ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeLeaveId { get; set; }



        [Required(ErrorMessage ="Employee is required!")]
        [Display(Name ="Employee ID")]
        public int EmployeeId { get; set; }



        [Display(Name ="Leave Type ID")]
        public int LeaveTypeId { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name ="Apply Date")]
        public DateTime? LeaveAppliedDate { get; set; }




        [Required(ErrorMessage = "From Date is required")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }





        [Required(ErrorMessage = "To Date is required")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }





        [Display(Name ="Applied Leave Days")]
        public int? LeaveDaysAppliedFor { get; set; }




        [Display(Name = "Leave Reason")]
        public string? LeaveReason { get; set; }



        [Display(Name ="Approved By")]
        public int? LeaveApprovedBy { get; set; }



        [Display(Name = "Approved Date")]
        public DateTime? LeaveApprovedDate { get; set; }



       
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Leave Approved From Date")]
        public DateTime? LeaveApprovedFromDate { get; set; }



        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Leave Approved To Date")]
        public DateTime? LeaveApprovedToDate { get; set; }



        [Display(Name = "Approved Leave Days")]
        public int? ApprovedLeaveDays { get; set; }



        public int? Status { get; set; }



        [Display(Name ="Updated By")]
        public int? UpdateBy { get; set; }


        [Display(Name = "Update date")]
        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

    }
}
