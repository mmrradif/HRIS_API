using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRISdatabaseModels.DatabaseModels.SalaryStructure
{
    public class SalaryComponent
    {      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryComponentId { get; set; }



        [Required(ErrorMessage = " Salary Component Code is required")]
        [Display(Name = "Salary Component Code ")]
        public string SalaryComponentCode { get; set; } = default!;



        [Required(ErrorMessage = " Salary Component Name is required")]
        [Display(Name = "Salary Component Name ")]
        public string SalaryComponentName { get; set; } = default!;




        [Required(ErrorMessage = " Salary Component Type is required")]
        [Display(Name = "Salary Component Type (Addition/Deduction)")]
        public int? SalaryComponentType { get; set; }




        [Display(Name = "Is Bonus")]
        public int? IsBonus { get; set; }



        [Display(Name = "Bonus Eligibility (Month)")]
        public int? BonusEligibility { get; set; }



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
