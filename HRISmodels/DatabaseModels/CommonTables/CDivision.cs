using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRISdatabaseModels.DatabaseModels.CommonTables
{
    public class CDivision
    {
        public CDivision()
        {
            CDistrict = new HashSet<CDistrict>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Division ID")]
        public int CDivisionId { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "Division Name is required")]
        [Display(Name = "Division Name")]
        public string DivisionName { get; set; }


        public virtual ICollection<CDistrict> CDistrict { get; set; }
    }
}
