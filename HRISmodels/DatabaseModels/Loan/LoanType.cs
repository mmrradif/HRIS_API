using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRISdatabaseModels.DatabaseModels.Loan
{
    public class LoanType
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Loan Type ID")]
        public int LoanTypeId { get; set; }




        [StringLength(100)]
        [Display(Name ="Loan Type Name")]
        public string LoanTypeName { get; set; }




        [Display(Name = "Maximum Loan Amount")]
        public decimal? MaximumLoanAmount { get; set; }



        [StringLength(100)]
        [Display(Name = "Terms and Condition")]
        public string TermsAndCondition { get; set; }



        [Display(Name = "Job Length")]
        public int? JobLength { get; set; }



        [Display(Name = "Status")]
        public int? Status { get; set; }


        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime? CreateDate { get; set; }


        [Display(Name = "Update By")]
        public int? UpdateBy { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }
    }
}
