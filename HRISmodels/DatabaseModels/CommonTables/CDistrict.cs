using HRIS.DatabaseModels.CompanyInformation;
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
    public class CDistrict
    {
        public CDistrict()
        {
            CUpazila = new HashSet<CUpazila>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "District ID")]
        public int DistrictId { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage ="District Name is required")]
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }


        [Required(ErrorMessage = "Division Name is required")]
        [ForeignKey("CDivision")]
        [Display(Name ="Division Name")]
        public int CDivisionId { get; set; }

       



        public virtual ICollection<CUpazila> CUpazila { get; set; }
    }
}
