using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS.DatabaseModels.CompanyInformation
{
    public class Location
    {
        public Location()
        {
            this.Rosters= new HashSet<Roster>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Location ID")]
        public int LocationId { get; set; }



        [Required(ErrorMessage = "Location Name is required")]
        [Display(Name ="Location Name")]
        [StringLength(100)]
        public string LocationName { get; set; }



        [Required(ErrorMessage = "Location Address is required")]
        [Display(Name ="Location Address")]
        [StringLength(300)]
        public string LocationAddress { get; set; }



        [Required(ErrorMessage ="Department Name is required")]
        [ForeignKey("Department")]
        [Display(Name = "Department Name")]
        public int? DepartmentId { get; set; }



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



        // ------------------------- Navigations
        public virtual ICollection<Roster> Rosters { get; }
    }
}
