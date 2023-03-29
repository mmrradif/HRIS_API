using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HRIS.DatabaseModels.CompanyInformation;
using Microsoft.VisualBasic;

namespace HRISdatabaseModels.DatabaseModels.CompanyInformation
{
    public class Company
    {
        public Company()
        {
            this.Grades= new List<Grade>();
            this.Divisions = new HashSet<Division>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }


        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }


        [StringLength(10)]
        [Display(Name = "Company Alias")]
        public string? CompanyAlias { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; }


        [Required(ErrorMessage = "Phone is required")]
        [StringLength(11)]
        public string Phone { get; set; }


        public string? Fax { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }


        public string? Website { get; set; }


        [Display(Name = "Company Registration Number")]
        public string? CompanyRegisterNo { get; set; }


        [Required(ErrorMessage ="Status is required")]
        [Display(Name = "Is Active")]
        public int IsActive { get; set; }


        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }


        [Display(Name = "Created Date")]
        //[Column(TypeName = "date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        [Display(Name = "Updated By")]
        public int? UpdateBy { get; set; }


        [Display(Name = "Updated Date")]      
        public DateTime UpdateDate { get; set; } = DateTime.Now;



        // ---------------------------- Navigations
        public virtual ICollection<Grade> Grades { get; }
        public virtual ICollection<Division> Divisions { get; }
    }
}
