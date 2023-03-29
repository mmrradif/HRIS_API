using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRISdatabaseModels.DatabaseModels.Recruitement
{
    public class Candidate
    {
        //public Candidate()
        //{
        //    this.Employee = new Employee();
        //}
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Candidate ID")]
        public int CandidateId { get; set; }


        [Required(ErrorMessage = "Applied Date is required")]
        [Display(Name = "Applied Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppliedDate { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Department Name is required")]
        [Display(Name = "Designation Name")]
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }


        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Father Name is required")]
        [Display(Name = "Father Name")]
        [StringLength(50)]
        public string FatherName { get; set; }


        [Required(ErrorMessage = "Mother Name is required")]
        [Display(Name = "Mother Name")]
        [StringLength(50)]
        public string MotherName { get; set; }


        [Required(ErrorMessage = "Spouse Name is required")]
        [Display(Name = "Spouse Name")]
        [StringLength(50)]
        public string SpouseName { get; set; }


        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Religion is required")]
        public string Religion { get; set; }


        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }


        [Required(ErrorMessage = "National ID is required")]
        [Display(Name = "National ID")]
        [StringLength(20)]
        public string NationalId { get; set; }



        [Display(Name = "Passport Number")]
        [StringLength(20)]
        public string? PassportNo { get; set; }


        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateofBirth { get; set; }


        [Required(ErrorMessage = "Present Address is required")]
        [Display(Name = "Present Address")]
        [StringLength(100)]
        public string PresentAddress { get; set; }


        [Required(ErrorMessage = "District is required")]
        public string District { get; set; }


        [Required(ErrorMessage = "Thana is required")]
        public string Thana { get; set; }


        //[Required(ErrorMessage = "Upazila is required")]
        public string? Upazila { get; set; }


        [Required(ErrorMessage = "Permanent Address is required")]
        [Display(Name = "Permanent Address")]
        [StringLength(100)]
        public string PermanentAddress { get; set; }


        [Required(ErrorMessage = "Permanent Address District is required")]
        [Display(Name = "Permanent Address District")]
        public string PermanentAddressDistrict { get; set; }


        [Required(ErrorMessage = "Permanent Address Thana is required")]
        [Display(Name = "Permanent Address Thana")]
        public string PermanentAddressThana { get; set; }


        [Required(ErrorMessage = "Permanent Address Upazila is required")]
        [Display(Name = "Permanent Address Upazila")]
        public string PermanentAddressUpazila { get; set; }


        [Required(ErrorMessage = "Home Phone Number is required")]
        [Display(Name = "Home Phone No")]
        public string HomePhone { get; set; }


        [Required(ErrorMessage = "Mobile Number is required")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }


        //[Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? PersonalEmail { get; set; }


        [Required(ErrorMessage = "Select Your Blood Group")]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }


        //[Required(ErrorMessage = "Profile Picture is required")]
        [StringLength(500)]
        //[Column(TypeName = "VARBINARY(MAX)")]
        [Display(Name = "Profile Picture")]
        public string? ProfilePicture { get; set; }


        [Required(ErrorMessage = "Select Your Marital Status")]
        [Display(Name = "Marital Status")]
        public string? MaritalStatus { get; set; }


        [Display(Name = "Birth Certificate No")]
        public string? BirthCertificateNo { get; set; }

        public string? Height { get; set; }

        public string? Weight { get; set; }


        //[Required(ErrorMessage = "Signature is required")]
        [StringLength(200)]
        //[Column(TypeName = "VARBINARY(MAX)")]
        public string? Signature { get; set; }


        [Required(ErrorMessage = "SSC Institute Name is required")]
        [Display(Name = "SSC Institute")]
        [StringLength(100)]
        public string Sscinstitute { get; set; }


        [Required(ErrorMessage = "Select your SSC Bord")]
        [Display(Name = "SSC Board")]
        public string Sscboard { get; set; }


        [Required(ErrorMessage = "Select your SSC Passing Year")]
        [Display(Name = "SSC Passing Year")]
        public string SscpassingYear { get; set; }


        [Required(ErrorMessage = "Select your SSC Section")]
        [Display(Name = "SSC Section")]
        public string Sscsection { get; set; }


        [Required(ErrorMessage = "SSC Roll No is required")]
        [Display(Name = "SSC Section")]
        [StringLength(10)]
        public string SscrollNo { get; set; }


        [Required(ErrorMessage = "SSC Reg No is required")]
        [Display(Name = "SSC Reg No")]
        [StringLength(10)]
        public string SscregNo { get; set; }


        [Required(ErrorMessage = "HSC Institute Name is required")]
        [Display(Name = "HSC Institute")]
        [StringLength(100)]
        public string Hscinstitute { get; set; }


        [Required(ErrorMessage = "Select your HSC Bord")]
        [Display(Name = "HSC Board")]
        public string Hscboard { get; set; }


        [Required(ErrorMessage = "Select your HSC Passing Year")]
        [Display(Name = "HSC Passing Year")]
        public string HscpassingYear { get; set; }


        [Required(ErrorMessage = "Select your HSC Section")]
        [Display(Name = "HSC Section")]
        public string Hscsection { get; set; }


        [Required(ErrorMessage = "HSC Roll No is required")]
        [Display(Name = "HSC Section")]
        [StringLength(10)]
        public string HscrollNo { get; set; }


        [Required(ErrorMessage = "HSC Reg No is required")]
        [Display(Name = "HSC Reg No")]
        [StringLength(10)]
        public string HscregNo { get; set; }


        [Required(ErrorMessage = "Honours Institute Name is required")]
        [Display(Name = "Honours Institute")]
        [StringLength(100)]
        public string HonoursInstitute { get; set; }


        [Required(ErrorMessage = "Select your Honours Bord")]
        [Display(Name = "Honours Board")]
        public string HonoursBoard { get; set; } 


        [Required(ErrorMessage = "Select your Honours Passing Year")]
        [Display(Name = "Honours Passing Year")]
        public string HonoursPassingYear { get; set; }


        [Required(ErrorMessage = "Select your Honours Department Name")]
        [Display(Name = "Department")]
        public string HonoursDepartment { get; set; }


        [Display(Name = "Honours Roll No")]
        [StringLength(15)]
        public string? HonoursRollNo { get; set; }


        [Display(Name = "Honours Reg No")]
        [StringLength(15)]
        public string? HonoursRegNo { get; set; }


        [Required(ErrorMessage = "Masters Institute Name is required")]
        [Display(Name = "Masters Institute")]
        [StringLength(100)]
        public string MastersInstitute { get; set; }


        [Required(ErrorMessage = "Select your Masters Bord")]
        [Display(Name = "Masters Board")]
        public string MastersBoard { get; set; }


        [Required(ErrorMessage = "Select your Masters Passing Year")]
        [Display(Name = "Masters Passing Year")]
        public string MastersPassingYear { get; set; }


        [Required(ErrorMessage = "Masters Section is required")]
        [Display(Name = "Masters Section")]
        [StringLength(50)]
        public string MastersSection { get; set; }


        [Display(Name = "Masters Roll No")]
        [StringLength(15)]
        public string MastersRollNo { get; set; }


        [Display(Name = "Masters Reg No")]
        [StringLength(15)]
        public string MastersRegNo { get; set; }


        [Display(Name = "Job Experience Type: 1")]
        [StringLength(200)]
        public string JobExperienceType1 { get; set; }


        [Display(Name = "Job Experience Company: 1")]
        [StringLength(200)]
        public string JobExperienceCompany1 { get; set; }


        [Display(Name = "Job Experience Details: 1")]
        [StringLength(200)]
        public string JobExperienceDetails1 { get; set; }


        [Display(Name = "Job Experience Type: 2")]
        [StringLength(200)]
        public string JobExperienceType2 { get; set; }


        [Display(Name = "Job Experience Company: 2")]
        [StringLength(200)]
        public string JobExperienceCompany2 { get; set; }


        [Display(Name = "Job Experience Details: 2")]
        [StringLength(200)]
        public string JobExperienceDetails2 { get; set; }


        [Display(Name = "Job Experience Type: 3")]
        [StringLength(200)]
        public string JobExperienceType3 { get; set; }


        [Display(Name = "Job Experience Company: 3")]
        [StringLength(200)]
        public string JobExperienceCompany3 { get; set; }


        [Display(Name = "Job Experience Details: 3")]
        [StringLength(200)]
        public string JobExperienceDetails3 { get; set; }


        public string Cv { get; set; }


        public int? Status { get; set; }


        [Display(Name = "Updated By")]
        public int? UpdateBy { get; set; }


        [Display(Name = "Updated Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateDate { get; set; } = DateTime.Now;

        //public virtual Employee Employee { get; set; }
    }
}
