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
    public class Roster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Roster ID")]
        public int RosterId { get; set; }


        [Required(ErrorMessage = "Roster Month is required")]
        [Display(Name = "Roster Month")]
        [StringLength(30)]
        public string RosterMonth { get; set; } = default!;


        [Required(ErrorMessage ="Location Name is required")]
        [ForeignKey("Location")]
        [Display(Name = "Location Name")]
        public int LocationId { get; set; }


        [Required(ErrorMessage ="Roster InTime is required")]
        [Display(Name = "Roster InTime")]
        public DateTime RosterInTime { get; set; } = default!;


        [Required(ErrorMessage = "Roster OutTime is required")]
        [Display(Name = "Roster OutTime")]
        public DateTime RosterOutTime { get; set; } = default!;


        [Display(Name = "Total working hours")]
        public decimal? TotalWorkingHours { get; set; }


        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Is Active")]
        public int IsActive { get; set; }


        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }


        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]

        public DateTime CreateDate { get; set; } = DateTime.Now;


        [Display(Name = "Updated By")]
        public int? UpdateBy { get; set; }


        [Display(Name = "Updated Date")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
