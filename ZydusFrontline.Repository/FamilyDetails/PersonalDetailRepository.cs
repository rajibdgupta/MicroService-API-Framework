using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Entity.FamilyDetails;
using ZydusFrontline.Entity.Search;
using ZydusFrontline.Entity.Utilities;
using ZydusFrontline.Interface.FamilyDetails;
using ZydusFrontline.Interface.Repository;
using ZydusFrontline.Repository.ContextModel;


namespace ZydusFrontline.Repository.FamilyDetails
{
    public class PersonalDetailRepository : IPersonalDetailRepository
    {
        private readonly DBContext _context = null;
        private IConfiguration _configuration = null;
        public int LoggedInUserId;
        public PersonalDetailRepository(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            LoggedInUserId = Int32.Parse(_configuration.GetValue<string>("LoggedInUserid"));
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public async Task<bool> Add(PersonalDetailEntity entity)
        {
            var result = 0;
            var memberList = _context.Member.Where(x => x.IsActive.Value).Select(x => new {
                id = x.MemberId,
                desc = x.MemberDesc
            }).ToList();

            var maxSerialno = 0;
            var maxSerialnoquery = _context.FamilyDetail.Where(x => x.IsActive.Value && x.RepId == LoggedInUserId).Select(x => x.SerialNo);
            if (maxSerialnoquery.Any())
            {
                maxSerialno = maxSerialnoquery.Max();
            }
            var CodeValue = _context.CodeValue.Where(x => x.IsActive.Value).Select(x => x).ToList();

            var detail = new FamilyDetail()
            {
                RepId = LoggedInUserId,
                MemberId = memberList.Where(x => x.desc == entity.RelationWithEmp).Select(x => x.id).FirstOrDefault(),
                SerialNo = maxSerialno + 1,
                BirthDate = Convert.ToDateTime(entity.DateOfBirth),
                GenderId = CodeValue.Where(x => x.ValCode.ToLower() == entity.Gender.ToLower() && x.TypeCode == GlobalConstant.Gender).Select(x => x.CodeValId).FirstOrDefault(),
                FirstName = entity.MemberName.Split(" ")[0],
                LastName = entity.MemberName.Split(" ")[1],
                MaritalStatusId = CodeValue.Where(x => x.ValCode.ToLower() == entity.MaritalStatus.ToLower() && x.TypeCode == GlobalConstant.MaritalStatus).Select(x => x.CodeValId).FirstOrDefault(),
                NomineeName = string.IsNullOrEmpty(entity.NameOfNominee) ? null : entity.NameOfNominee,
                NomineeRelationId = string.IsNullOrEmpty(entity.RelationOfNomineeWithEmp) ? (int?)null : memberList.Where(x => x.desc == entity.RelationOfNomineeWithEmp).Select(x => x.id).FirstOrDefault(),
                Reason = entity.Reason,
                IsActive = true,
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                ModifiedBy = "System",
                ModifiedDate = DateTime.Now,

            };
            _context.FamilyDetail.Add(detail);
             result = _context.SaveChanges();

            if (result > 0)
                return true;
            return false;
        }

        public async Task<bool> Delete(PersonalDetailEntity entity)
        {
            var result = 0;
            var detail = _context.FamilyDetail.Where(x => x.IsActive.Value && x.FamilyDetailId == entity.UniqueKey).FirstOrDefault();
            if (detail!=null)
            {
                _context.Remove(detail);
                result = _context.SaveChanges();
            }           
            if (result > 0)
                return true;
            return false;
        }

        public async Task<IQueryable<PersonalDetailEntity>> Entities(SearchEntity query)
        {
            var result = _context.FamilyDetail.Where(x => x.IsActive.Value && x.RepId == LoggedInUserId)
             .Select(m => new PersonalDetailEntity
             {
                 UniqueKey = m.FamilyDetailId,
                 MemberName = m.FirstName + " " + m.LastName,
                 DateOfBirth = String.Format("{0:MM/dd/yyyy}", m.BirthDate),
                 Gender = m.Gender.ValCode,
                 MaritalStatus = m.MaritalStatus.ValCode,
                 NameOfNominee = m.NomineeName,
                 RelationWithEmp = m.Member.MemberDesc,
                 RelationOfNomineeWithEmp = m.NomineeRelation.MemberDesc
             }).Distinct().AsQueryable();

            return result;
        }

        public async Task<List<PersonalDetailEntity>> EntitiesSP(SearchEntity query)
        {          

            var result = _context.PersonalDetailEntityListSP
                        .FromSqlRaw($"EXEC GetAllPersonalDetails 5").ToList();

            return result;
        }
        public async Task<bool> Update(PersonalDetailEntity entity)
        {
            var result = 0;
            var memberList = _context.Member.Where(x => x.IsActive.Value).Select(x => new {
                id = x.MemberId,
                desc = x.MemberDesc
            }).ToList();

            var CodeValue = _context.CodeValue.Where(x => x.IsActive.Value).Select(x => x).ToList();

            var detail = _context.FamilyDetail.Where(x => x.IsActive.Value && x.FamilyDetailId == entity.UniqueKey).FirstOrDefault();
            if (detail !=null)
            {
                detail.MemberId = memberList.Where(x => x.desc == entity.RelationWithEmp).Select(x => x.id).FirstOrDefault();
                detail.BirthDate = Convert.ToDateTime(entity.DateOfBirth);
                detail.GenderId = CodeValue.Where(x => x.ValCode.ToLower() == entity.Gender.ToLower() && x.TypeCode == GlobalConstant.Gender).Select(x => x.CodeValId).FirstOrDefault();
                detail.FirstName = entity.MemberName.Split(" ")[0];
                detail.LastName = entity.MemberName.Split(" ")[1];
                detail.MaritalStatusId = CodeValue.Where(x => x.ValCode.ToLower() == entity.MaritalStatus.ToLower() && x.TypeCode == GlobalConstant.MaritalStatus).Select(x => x.CodeValId).FirstOrDefault();
                detail.NomineeName = string.IsNullOrEmpty(entity.NameOfNominee) ? null : entity.NameOfNominee;
                detail.NomineeRelationId = string.IsNullOrEmpty(entity.RelationOfNomineeWithEmp) ? (int?)null : memberList.Where(x => x.desc == entity.RelationOfNomineeWithEmp).Select(x => x.id).FirstOrDefault();
                detail.Reason = entity.Reason;
                detail.ModifiedBy = "System";
                detail.ModifiedDate = DateTime.Now;

                result = _context.SaveChanges();
            }

            if (result > 0)
                return true;
            return false;
        }

        public async Task<IQueryable<MemberEntity>> GetAllMember()
        {
            var result = _context.Member.Where(x => x.IsActive.Value)
             .Select(m => new MemberEntity
             {
                 MemberId = m.MemberId,
                 MemberDesc = m.MemberDesc
             }).Distinct().AsQueryable();

            return result;
        }
    }
}