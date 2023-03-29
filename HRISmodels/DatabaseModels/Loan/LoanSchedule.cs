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
    public class LoanSchedule
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Loan Schedule ID")]
        public int LoanScheduleId { get; set; }



        [ForeignKey("LoanInformation")]
        [Display(Name = "Loan Information ID")]
        public int LoanInformationId { get; set; }



        [DataType(DataType.Date)]
        [Display(Name ="Emi Date")]
        public DateTime? EmiDate { get; set; }



        [Display(Name ="Emi Amount")]
        public decimal? EmiAmount { get; set; }



        [DataType(DataType.Date)]
        [Display(Name ="Paid Date")]
        public DateTime? PaidDate { get; set; }



        [Display(Name = "Is Paid")]
        public int? IsPaid { get; set; }


        [StringLength(100)]
        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }



        [DataType(DataType.Date)]
        [Display(Name ="Created Date")]
        public DateTime? CreateDate { get; set; }



        [StringLength(100)]
        [Display(Name = "Update By")]
        public int? UpdateBy { get; set; }



        [DataType(DataType.Date)]
        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }

        
        
    }
}
