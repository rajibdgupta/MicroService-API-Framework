using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Entity.FamilyDetails;
using ZydusFrontline.Entity.Search;
using ZydusFrontline.Interface.FamilyDetails;

namespace ZydusFrontline.Services.FamilyDetails
{
    public class PersonalDetailService : IPersonalDetailService
    {
        private IPersonalDetailRepository _personalDetailRepository = null;
     
        public PersonalDetailService(IPersonalDetailRepository personalDetailRepository)
        {
            _personalDetailRepository = personalDetailRepository;           
        }

        public Task<bool> Add(PersonalDetailEntity entity)
        {
            return _personalDetailRepository.Add(entity);
        }

        public Task<bool> Delete(PersonalDetailEntity entity)
        {
            return _personalDetailRepository.Delete(entity);
        }

        public void Dispose()
        {
            if (_personalDetailRepository != null)
            {
                _personalDetailRepository.Dispose();
            }
        }

        public async Task<List<PersonalDetailEntity>> Find(SearchEntity query)
        {
            var result = await _personalDetailRepository.Entities(query);
            return result.ToList();
        }
        public async Task<List<PersonalDetailEntity>> FindSP(SearchEntity query)
        {
            var result = await _personalDetailRepository.EntitiesSP(query);
            return result.ToList();
        }

        public async Task<List<MemberEntity>> GetAllMember()
        {
            var result = await _personalDetailRepository.GetAllMember();
            return result.ToList();
        }

   
        public Task<bool> Update(PersonalDetailEntity entity)
        {
            return _personalDetailRepository.Update(entity);
        }
    }
}
