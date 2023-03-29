using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRISdatabaseModels.DatabaseModels.Leave
{
    public class LeaveDetails
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveDetailsId { get; set; }



        [Required(ErrorMessage = "Employee is required!")]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }



        [Display(Name = "Leave Type ID")]
        public int? LeaveTypeId { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "leave Dates")]
        public DateTime LeaveDates { get; set; }




        public int? Status { get; set; }



        [Display(Name = "Created By")]
        public int CreateBy { get; set; }



        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Updated By")]
        public int UpdateBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }
    }
}
