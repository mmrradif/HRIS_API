//using HRIS.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels.EmployeeInformation
{
    public class EmployeePosting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Employee Posting ID")]
        public int EmployeePostingId { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public int CompanyId { get; set; }

        public int GradeId { get; set; }

        public int DesignationId { get; set; }

        public int DivisionId { get; set; }

        public int DepartmentId { get; set; }

        public int LocationId { get; set; }

        public int RosterId { get; set; }


        [Required(ErrorMessage ="Bank Account No is required")]
        [Display(Name ="Bank Account No")]
        public string BankAccountNo { get; set; }


        [Display(Name ="Telephone Extension")]
        public string TelephoneExtension { get; set; }


        [Display(Name = "Official Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string OfficialEmail { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Job End Date")]
        public DateTime? JobEndDate { get; set; }


        [Display(Name = "TIN Number")]
        public string TinNumber { get; set; }

        public int? Status { get; set; }


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
