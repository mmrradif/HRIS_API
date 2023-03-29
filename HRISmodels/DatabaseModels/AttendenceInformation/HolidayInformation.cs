using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HRIS_Models.DatabaseModels.AttendenceInformation
{
    public class HolidayInformation
    {
        public int HolidayInformationId { get; set; }


        public string HolidayType { get; set; }


        public DateTime HolidayDate { get; set; }


        public int Year { get; set; }



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
    }
}
