using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels.EmployeeInformation
{
    public class EmployeeType
    {
        public EmployeeType()
        {
            this.Employee = new HashSet<Employee>();        
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeTypeId { get; set; }




        [Required]
        [StringLength(30)]
        [Display(Name ="Employee Type")]
        public string EmployeeTypeName { get; set; }



        [StringLength(30)]
        [Display(Name = "Type Code")]
        public string EmployeeTypeCode { get; set; }



        public int? NoticePeriod { get; set; }



        public int? IsOverTimeAllowed { get; set; }





        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Is Active")]
        public int? IsActive { get; set; }


        


        [Display(Name = "Created By")]
        public int CreateBy { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }



        [Display(Name = "Updated By")]
        public int UpdateBy { get; set; }




        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }



        public virtual ICollection<Employee> Employee { get; set; }
    

    }
}
