using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;

namespace HRIS.DatabaseModels.CompanyInformation
{
    public class Division
    {
        public Division()
        {
            this.Departments = new HashSet<Department>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Division ID")]
        public int DivisionId { get; set; }


        [Required(ErrorMessage = "Grade Name is required")]
        [StringLength(100)]
        public string DivisionName { get; set; }


        
        [Display(Name ="Division Code")]
        [StringLength(10)]
        public string? DivisionCode { get; set; }


        [Required(ErrorMessage = "Company Name is required")]
        [ForeignKey("Company")]
        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }



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




        // ---------------- Navigations
        public virtual ICollection<Department> Departments { get;}
    }
}
