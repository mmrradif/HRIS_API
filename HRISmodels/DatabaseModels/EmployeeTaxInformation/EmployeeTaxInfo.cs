using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRISdatabaseModels.DatabaseModels.EmployeeTaxInformation
{
    public class EmployeeTaxInfo
    {
        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee Tax Info ID")]
        public int EmployeeTaxInfoId { get; set; }



        [Required(ErrorMessage = "Employee Name is required")]
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }



        [Display(Name = "Tax Amount")]
        [Column(TypeName ="decimal(12,2)")]
        public decimal? TaxAmount { get; set; }

        
        [Display(Name = "Effective Date"),DataType(DataType.Date)]
        public DateTime? EffectiveDate { get; set; }

       // [StringLength(100)]
        [Display(Name = "Status")]
        public int? Status { get; set; }

        //[StringLength(100)]
        [Display(Name ="Created By")]
        public int? CreateBy { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }

        //[StringLength(100)]
        [Display(Name = "Updated By")]
        public int? UpdateBy { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime? UpdateDate { get; set; }
    }
}
