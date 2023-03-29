using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HRIS_Models.DatabaseModels.SalaryFinalize
{
    public class SalaryDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryDetailsId { get; set; }


        [ForeignKey("Salary")]
        [Required(ErrorMessage = "Salary ID is required")]
        [Display(Name = "Salary ID")]
        public int SalaryId { get; set; }
    

        [Required(ErrorMessage = " Salary Component  is required")]
        [Display(Name = "Salary Component")]
        public int SalaryComponentId { get; set; }



        [Display(Name = "Salary Component value ")]
        public decimal? SalaryComponentValue { get; set; }


        [Required(ErrorMessage = "Salary Component Type is required")]
        [Display(Name = "Salary Component Type(Addition/Deduction)")]
        public int? SalaryComponentType { get; set; }


        [Display(Name = "Status")]
        public int? Status { get; set; }


        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }


        [Display(Name = "Created Date")]
        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Update By")]
        public int? UpdateBy { get; set; }


        [Display(Name = "Update Date")]
        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
