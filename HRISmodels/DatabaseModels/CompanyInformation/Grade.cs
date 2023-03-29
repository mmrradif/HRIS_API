using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HRIS.DatabaseModels.CompanyInformation;

namespace HRISdatabaseModels.DatabaseModels.CompanyInformation
{
    public class Grade
    {
        public Grade()
        {
            this.Designations = new HashSet<Designation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Grade ID")]
        public int GradeId { get; set; }


        [Required(ErrorMessage = "Grade Name is required")]
        [StringLength(100)]
        [Display(Name = "Grade Name")]
        public string GradeName { get; set; } = default!;


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





        // ----------------------- Navigations
        public virtual ICollection<Designation> Designations { get; }
    }
}
