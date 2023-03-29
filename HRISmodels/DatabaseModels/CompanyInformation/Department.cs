using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRIS.DatabaseModels.CompanyInformation
{
    public class Department
    {
        public Department()
        {
            this.Locations = new HashSet<Location>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100)]
        public string DepartmentName { get; set; }


        [Display(Name = "Department Code")]
        [StringLength(10)]
        public string? DepartmentCode { get; set; }



        [Required(ErrorMessage ="Division Name is required")]
        [ForeignKey("Division")]
        [Display(Name = "Division Name")]
        public int DivisionId { get; set; }



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




        // ----------------- Navigations
        public ICollection<Location> Locations { get; }
    }
}
