using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZydusFrontline.API.Controllers.Base;
using ZydusFrontline.Entity.FamilyDetails;
using ZydusFrontline.Entity.Search;
using ZydusFrontline.Entity.Utilities;
using ZydusFrontline.Interface.FamilyDetails;
using ZydusFrontline.Interface.Services;


namespace ZydusFrontline.API.Controllers.FamilyDetails
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailController : BaseController
    {
        private readonly IPersonalDetailService _personalDetailService = null;

        public PersonalDetailController(IPersonalDetailService personalDetailService)
        {
            _personalDetailService = personalDetailService;
        }


        [HttpGet("GetAllPersonalDetails")]
        public async Task<List<PersonalDetailEntity>> GetAllPersonalDetails()
        {            
            var query = new SearchEntity();
            return await _personalDetailService.Find(query);
        }

        [HttpGet("GetAllPersonalDetailSP")]
        public async Task<List<PersonalDetailEntity>> GetAllPersonalDetailSP()
        {
            var query = new SearchEntity();
            return await _personalDetailService.FindSP(query);
        }

        [HttpPost("AddPersonalDetail")]
        public async Task<ApiResponse> AddPersonalDetail(PersonalDetailEntity entity)
        {
            var result= await _personalDetailService.Add(entity);
            if (result)
            {
                return new ApiResponse
                {
                    Messsage = "Successfully Added",
                    Status = Status.Success.ToString()
                };
            }

            return new ApiResponse
            {
                Messsage = "Some error ,failed to add member",
                Status = Status.Failed.ToString()
            };
        }

        [HttpPut("UpdatePersonalDetail")]
        public async Task<ApiResponse> UpdatePersonalDetail(PersonalDetailEntity entity)
        {
            var result = await _personalDetailService.Update(entity);
            if (result)
            {
                return new ApiResponse
                {
                    Messsage = "Successfully Updated",
                    Status = Status.Success.ToString()
                };
            }

            return new ApiResponse
            {
                Messsage = "Some error ,failed to update member",
                Status = Status.Failed.ToString()
            };
        }

        [HttpDelete("DeletePersonalDetail")]
        public async Task<ApiResponse> DeletePersonalDetail(PersonalDetailEntity entity)
        {
            var result = await _personalDetailService.Delete(entity);
            if (result)
            {
                return new ApiResponse
                {
                    Messsage = "Successfully Deleted",
                    Status = Status.Success.ToString()
                };
            }

            return new ApiResponse
            {
                Messsage = "Some error ,failed to delete member",
                Status = Status.Failed.ToString()
            };
        }

        [HttpGet("GetAllMember")]
        public async Task<List<MemberEntity>> GetAllMember()
        {
            return await _personalDetailService.GetAllMember();
        }
        protected virtual void Dispose()
        {
            if (_personalDetailService != null)
            {
                _personalDetailService.Dispose();
            }
        }

    }
}
