using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using HRISdatabaseModels.DatabaseModels.SalaryFinalize;

namespace HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Salary Id")]
        public int SalaryId { get; set; }



        [Required(ErrorMessage = "Employee Name is required")]
        [Display(Name = "Employee Name")]
        public int EmployeeId { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Salary Month")]
        public DateTime SalaryMonth { get; set; }



        [Display(Name = "Total Pay")]
        public decimal TotalSalary { get; set; }


        [Display(Name = "Days")]
        public int DaysOfMonth { get; set; }



        [Display(Name = "Acumulation")]
        public int AcumulatedDays { get; set; }


       
        [Required(ErrorMessage = "Gross Pay is required")]
        [Display(Name = "Gross Pay")]
        public decimal GrossPay { get; set; }
        


        [Required(ErrorMessage = "Tax is required")]
        public decimal Tax { get; set; }


        [Required(ErrorMessage = "Loan Schedule Type is required")]
        [Display(Name = "Loan Schedule Type")]
        public int? LoanScheduleId { get; set; }


        public decimal? Arear { get; set; }


        [Required(ErrorMessage = "Net Payout is required")]
        [Display(Name = "Net Payout")]
        public decimal NetPayout { get; set; }


       
        [Display(Name = "Status")]
        public int? Status { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }



        [Display(Name = "Created By")]
        public int? CreateBy { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }




        [Display(Name = "Updated By")]
        public int? UpdateBy { get; set; }



        [Display(Name = "Approver")]
        public int? ApproverId { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Approve Date")]
        public DateTime? ApproveDate { get; set; }



        [Required(ErrorMessage = "Company Name is required")]
        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }



        
        [Required(ErrorMessage = "Grade is required")]
        [Display(Name = "Grade")]
        public int GradeId { get; set; }


        [Required(ErrorMessage = "Designation is required")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }


        [Required(ErrorMessage = "Division is required")]
        [Display(Name = "Division")]
        public int DivisionId { get; set; }


        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }


        [Required(ErrorMessage = "Location is required")]
        [Display(Name = "Location")]
        public int LocationId { get; set; }


        [Required(ErrorMessage = "Employee Type is required")]
        [Display(Name = "Employee Type")]
        public int EmployeeTypeId { get; set; }


        [Required(ErrorMessage = "Bank Account No is required")]
        [Display(Name = "Bank Account No")]
        public string BankAccountNo { get; set; }


        [Required(ErrorMessage = "Salary Remarks is required")]
        [Display(Name = "Salary Remarks")]
        public string SalaryRemarks { get; set; }


        [Display(Name = "Payment By")]
        public int? PaymentBy { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime? PaymentDate { get; set; }


        [Display(Name = "Bank Payment?")]
        public int? IsBankPayment { get; set; }


        [Display(Name = "Bank Payment By")]
        public int? BankPaymentBy { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Bank Payment Date")]
        public DateTime? BankPaymentDate { get; set; }


        [Display(Name = "Cash Payment?")]
        public int? IsCashPayment { get; set; }


        [Display(Name = "Cash Payment By")]
        public int? CashPaymentBy { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cash Payment Date")]
        public DateTime? CashPaymentDate { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Confirmation Date")]
        public DateTime? PaymentConfirmationDate { get; set; }

       
    }
}

