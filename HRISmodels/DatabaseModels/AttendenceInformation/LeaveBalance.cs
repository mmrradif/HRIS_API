using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels.AttendenceInformation
{
    public class LeaveBalance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveBalanceId { get; set; }



        [Required(ErrorMessage ="Employee is required!")]
        [Display(Name ="Employee ID")]
        public int EmployeeId { get; set; }



        public int? Year { get; set; }



        [Required(ErrorMessage = "Leave type ")]
        public int? LeaveTypeId { get; set; }



        [Display(Name ="Leave Balance open")]
        public decimal? YearlyLeaveTypeBalance { get; set; }



        [Display(Name ="Leave Enjoyed")]
        public decimal? LeaveEnjoyed { get; set; }



        [Display(Name ="Available Leave Balance")]
        public decimal? YearlyClosingBalance { get; set; }



        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }



        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Updated By")]
        public int? UpdateBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }

    }
}
