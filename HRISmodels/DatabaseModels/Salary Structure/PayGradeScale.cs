using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels.SalaryStructure
{
    public class PayGradeScale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayGradeScaleId { get; set; }


        [Required(ErrorMessage = "Pay Scale Grade is required")]
        [Display(Name = "Pay Scale Grade")]
        [StringLength(20)]
        public string PayScaleGrade { get; set; }


        [Required(ErrorMessage = "Grade   is required")]
        [Display(Name = "Grade")]
        public int GradeId { get; set; }


        [Required(ErrorMessage = " Salary Component  is required")]
        [Display(Name = "Salary Component")]
        public int SalaryComponentId { get; set; }


        [Required(ErrorMessage = " Salary Component Amount  is required")]
        [Display(Name = "Salary Component Amount")]
        [Column(TypeName ="decimal(7,2)")]
        public decimal? SalaryComponentAmount { get; set; }


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
