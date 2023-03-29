using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using HRISgenericInterfaces.RecruitmentInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.RecruitmentRepositories
{
    public class CandidateRepo : GenericRepo<Candidate>, ICandidate
    {
        public CandidateRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }


        //get all

        public override Task<List<Candidate>> GetAll()
        {
            try
            {
                return base.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get by id

        public override async Task<Candidate> GetById(int id)
        {
            try
            {
                var candidate = await dbSet.FirstOrDefaultAsync(item => item.CandidateId == id);
                return candidate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get by name

        public override async Task<Candidate> GetByName(string name)
        {
            try
            {
                var candidate = await dbSet.FirstOrDefaultAsync(item => item.FullName == name || item.FullName.StartsWith(name) || item.FullName.EndsWith(name) || item.FullName.ToLower().StartsWith(name.ToLower()) || item.FullName.ToLower().EndsWith(name.ToLower()) || item.FullName.ToLower().Equals(name.ToLower()));
                return candidate;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //insert
        public override async Task Insert(Candidate entity)
        {
            await dbSet.AddAsync(entity);
        }


        //update
        public override async Task<bool> Update(Candidate entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.CandidateId == entity.CandidateId);

                if (existdata != null)
                {
                    existdata.CandidateId= entity.CandidateId;
                    existdata.AppliedDate= entity.AppliedDate;
                    existdata.DesignationId= entity.DesignationId;
                    existdata.FullName= entity.FullName;
                    existdata.FatherName= entity.FatherName;
                    existdata.MotherName= entity.MotherName;
                    existdata.SpouseName= entity.SpouseName;
                    existdata.Gender= entity.Gender;
                    existdata.Religion= entity.Religion;
                    existdata.Nationality= entity.Nationality;
                    existdata.NationalId= entity.NationalId;
                    existdata.PassportNo= entity.PassportNo;
                    existdata.DateofBirth= entity.DateofBirth;
                    existdata.PresentAddress= entity.PresentAddress;
                    existdata.District = entity.District;
                    existdata.Upazila= entity.Upazila;
                    existdata.Thana = entity.Thana;
                    existdata.PermanentAddress= entity.PermanentAddress;
                    existdata.PermanentAddressDistrict= entity.PermanentAddressDistrict;
                    existdata.PermanentAddressThana= entity.PermanentAddressThana;
                    existdata.PermanentAddressUpazila=entity.PermanentAddressUpazila;
                    existdata.HomePhone= entity.HomePhone;
                    existdata.MobileNo= entity.MobileNo;
                    existdata.PersonalEmail= entity.PersonalEmail;
                    existdata.BloodGroup= entity.BloodGroup;
                    existdata.ProfilePicture= entity.ProfilePicture;
                    existdata.MaritalStatus= entity.MaritalStatus;
                    existdata.BirthCertificateNo= entity.BirthCertificateNo;
                    existdata.Height= entity.Height;
                    existdata.Weight= entity.Weight;
                    existdata.Signature= entity.Signature;
                    existdata.Sscinstitute= entity.Sscinstitute;
                    existdata.Sscboard= entity.Sscboard;
                    existdata.SscpassingYear= entity.SscpassingYear;
                    existdata.SscregNo= entity.SscregNo;
                    existdata.SscrollNo= entity.SscrollNo;
                    existdata.Sscsection= entity.Sscsection;
                    existdata.Hscsection = entity.Hscsection;
                    existdata.Hscboard= entity.Hscboard;
                    existdata.HscpassingYear=   entity.HscpassingYear;
                    existdata.Hscinstitute=entity.Hscinstitute;
                    existdata.HscregNo= entity.HscregNo;
                    existdata.HscrollNo= entity.HscrollNo;
                    existdata.HonoursBoard = entity.HonoursBoard;
                    existdata.HonoursDepartment= entity.HonoursDepartment;
                    existdata.HonoursInstitute= entity.HonoursInstitute;
                    existdata.HonoursPassingYear= entity.HonoursPassingYear;
                    existdata.HonoursRegNo= entity.HonoursRegNo;
                    existdata.HonoursRollNo= entity.HonoursRollNo;
                    existdata.MastersBoard= entity.MastersBoard;
                    existdata.MastersInstitute= entity.MastersInstitute;
                    existdata.MastersPassingYear= entity.MastersPassingYear;
                    existdata.MastersRegNo= entity.MastersRegNo;
                    existdata.MastersRollNo= entity.MastersRollNo;
                    existdata.MastersSection= entity.MastersSection;
                    existdata.JobExperienceCompany1= entity.JobExperienceCompany1;
                    existdata.JobExperienceCompany2 = entity.JobExperienceCompany2;
                    existdata.JobExperienceCompany3= entity.JobExperienceCompany3;
                    existdata.JobExperienceDetails1= entity.JobExperienceDetails1;
                    existdata.JobExperienceDetails2 = entity.JobExperienceDetails2;
                    existdata.JobExperienceDetails3=entity.JobExperienceDetails3;
                    existdata.JobExperienceType1= entity.JobExperienceType1;
                    existdata.JobExperienceType2 = entity.JobExperienceType2;
                    existdata.JobExperienceType3 = entity.JobExperienceType3;
                    existdata.Cv = entity.Cv;
                    existdata.Status= entity.Status;
                    existdata.UpdateBy = entity.UpdateBy;
                    existdata.UpdateDate= entity.UpdateDate;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        //delete
        public override async Task<bool> Delete(int id)
        {
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.CandidateId == id);
            if (existdata != null)
            {
                dbSet.Remove(existdata);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
