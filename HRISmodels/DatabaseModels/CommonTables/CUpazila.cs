using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRISdatabaseModels.DatabaseModels.CommonTables
{
    public class CUpazila
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Upazila ID")]
        public int CUpazilaId { get; set; }



        [StringLength(50)]
        [Required(ErrorMessage = "Upazila Name is required")]
        [Display(Name = "Upazila Name")]
        public string UpazilaName { get; set; } = default!;



        [Required(ErrorMessage = "District Name is required")]
        [ForeignKey("CDistrict")]
        [Display(Name = "District Name")]
        public int CDistrictId { get; set; }
             
    }
}
