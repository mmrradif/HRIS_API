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
    public class LoanInformation
    {
        public LoanInformation()
        {
            this.LoanSchedules = new List<LoanSchedule>();
        }

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Loan Information ID")]
        public int LoanInformationId { get; set; }



        [Required(ErrorMessage = "Employee Name is required")]
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }


        [Display(Name ="Loan Amount")]
        [Column(TypeName ="decimal(12,2)")]
        public decimal LoanAmount { get; set; }



        [StringLength(100)]
        [Display(Name = "Recomendation")]
        public string Recomendation { get; set; }


        [Display(Name = "Rejected By")]
        public int? RejectedBy { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Reject Date")]
        public DateTime? RejectDate { get; set; }



        [StringLength(100)]
        [Display(Name = "Reason")]
        public string Reason { get; set; }



        [Display(Name = "Approved By")]
        public int? ApproveBy { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Approve Date")]
        public DateTime? ApproveDate { get; set; }




        [DataType(DataType.Date)]
        [Display(Name = "Loan Start Date")]
        public DateTime? LoanStartDate { get; set; }




        [Display(Name = "Installment Amount")]
        [Column(TypeName ="decimal(12,2)")]
        public decimal? InstalmentAmount { get; set; }


        [Display(Name = "Total Paid")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal? TotalPaid { get; set; }



        [Display(Name ="Due Amount")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal? DueAmount { get; set; }




        [Display(Name = "Down Payment Amount")]
        [Column(TypeName = "decimal(12,2)")]
        public int? DownpaymentAmount { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }



        [StringLength(100)]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        


        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime? CreateDate { get; set; }


       

         
        [Display(Name = "Update By")]
        public int? UpdateBy { get; set; }

        //nev
        public virtual ICollection<LoanSchedule> LoanSchedules { get; }
    }
}
