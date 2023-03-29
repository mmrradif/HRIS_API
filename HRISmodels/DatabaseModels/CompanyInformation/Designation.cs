using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;

namespace HRIS.DatabaseModels.CompanyInformation
{
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Designation ID")]
        public int DesignationId { get; set; }


        [Required(ErrorMessage = "Designation Name is required")]
        [StringLength(100)]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }


        [StringLength(10)]
        [Display(Name = "Designation Code")]
        public string? DesignationCode { get; set; }


        [Required(ErrorMessage ="Grade Name is required")]
        [ForeignKey("Grade")]
        [Display(Name = "Grade Name")]
        public int GradeId { get; set; }


        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Is Active")]
        public int IsActive { get; set; }


        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }


        [Display(Name = "Created Date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        [Display(Name = "Updated By")]
        public int? UpdateBy { get; set; }


        [Display(Name = "Updated Date")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

    }
}
