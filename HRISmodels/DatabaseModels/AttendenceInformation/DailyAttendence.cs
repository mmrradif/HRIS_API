using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels.AttendenceInformation
{
    public class DailyAttendence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }



        [Required(ErrorMessage ="Employee required!")]
        [Display(Name ="Employee")]
        public int EmployeeId { get; set; }


        [Display(Name ="Employee Type Id")]
        public int EmployeeTypeId { get; set; }



        [Required(ErrorMessage = "Company required!")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }



        [Required(ErrorMessage = "Grade required!")]
        [Display(Name = "Grade")]
        public int GradeId { get; set; }



        [Required(ErrorMessage = "Designation required!")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }



        [Required(ErrorMessage = "Division required!")]
        [Display(Name = "Division")]
        public int DivisionId { get; set; }



        [Required(ErrorMessage = "Department required!")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }



        [Required(ErrorMessage = "Location required!")]
        [Display(Name = "Location")]
        public int LocationId { get; set; }


        [Required(ErrorMessage = "Roster required!")]
        [Display(Name = "Roster")]
        public int RosterId { get; set; }



        [Required(ErrorMessage ="Date is required!")]
        [DataType(DataType.Date)]
        [Column(TypeName ="date")]
        [Display(Name ="Attendence Date")]
        public DateTime? AttendanceDate { get; set; }



        //[Column(TypeName = "time")]
        [Required(ErrorMessage = "In Time Required!")]
        [Display(Name = "In Time")]
        public DateTime InTime { get; set; } = default!;



        //[Column(TypeName = "time")]
        [Required(ErrorMessage = "Out Time Required!")]
        [Display(Name = "Out Time")]
        public DateTime OutTime { get; set; }



        [Display(Name = "Total working hours")]
        public decimal? TotalWorkingHours { get; set; }



        [Display(Name = "Out Time")]
        public decimal? OverTimeHours { get; set; }



        public int? Status { get; set; }




        //[Display(Name = "Entry")]
        //public string RosterIntime { get; set; } = default!;


        //[Display(Name = "Leave")]
        //public string RosterOutTime { get; set; } = default!;


       




        [Display(Name = "Created By")]
        public int CreateBy { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Updated By")]
        public int UpdateBy { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }
    }
}
