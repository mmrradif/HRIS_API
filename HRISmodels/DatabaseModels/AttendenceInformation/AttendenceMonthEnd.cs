using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels.AttendenceInformation
{
    public class AttendenceMonthEnd
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceMonthEndId { get; set; }



        [Required(ErrorMessage ="Employee is required!")]
        public int EmployeeId { get; set; }




        [Display(Name = "Employee Type Id")]
        public int EmployeeTypeId { get; set; }




        [Required(ErrorMessage = "Company is required!")]
        public int CompanyId { get; set; }



        [Required(ErrorMessage = "Grade is required!")]
        public int GradeId { get; set; }




        [Required(ErrorMessage = "Designation is required!")]
        public int DesignationId { get; set; }




        [Required(ErrorMessage = "Division is required!")]
        public int DivisionId { get; set; }




        [Required(ErrorMessage = "Department is required!")]
        public int DepartmentId { get; set; }




        [Required(ErrorMessage = "Location is required!")]
        public int LocationId { get; set; }




        [Required(ErrorMessage = "Roster is required!")]
        public int RosterId { get; set; }



        [Display(Name = "Attendance Month")]
        public string AttendanceMonth { get; set; }



        [Display(Name = "Days")]
        public int? DaysOfMonth { get; set; }



        [Display(Name = "Absent")]
        public int? AbsentDays { get; set; }



        [Display(Name = "Leave")]
        public int? LeaveDays { get; set; }



        [Display(Name = "Holiday")]
        public int? Holiday { get; set; }



        [Display(Name = "Deduction")]
        public int? LateDeduction { get; set; }



        [Display(Name = "Total Deduction")]
        public int? FinalDeductionDays { get; set; }


        [Display(Name = "Acumulation")]
        public int? AcumulatedDays { get; set; }


        public int? Status { get; set; }


        [Display(Name = "Created by")]
        public int? CreateBy { get; set; }


        [Display(Name = "Create date")]
        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Approved By")]
        public int? ApprovedBy { get; set; }


        [Display(Name = "Approval Date")]
        [Column(TypeName = "date")]
        public DateTime? ApprovedDate { get; set; }

    }
}
