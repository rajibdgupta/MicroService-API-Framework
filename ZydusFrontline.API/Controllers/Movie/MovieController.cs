using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZydusFrontline.API.Controllers.Base;
using ZydusFrontline.Entity.Movies;
using ZydusFrontline.Interface.Movies;
using ZydusFrontline.Interface.Services;
using ZydusFrontline.Services.Movies;

namespace ZydusFrontline.API.Controllers.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService = null;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetMoviesByGenre")]
        public async Task<ActionResult<IEnumerable<MovieEntity>>> GetMoviesByGenre(MovieEntity entity)

        {
            //var a = 0;
            //var b = 2;
            //var c = b / a;
            return await _movieService.Find(entity);
        }

        [HttpGet("AzureBusServiceCall")]
        public async Task<ActionResult<IEnumerable<MovieEntityTest1>>> CallCustomMethod1(MovieEntityTest1 entity)

        {
            return await _movieService.CustomMethod1(entity);
        }

        [HttpGet("ExceptionHandling")]
        public async Task<ActionResult<IEnumerable<MovieEntityTest2>>> CallCustomMethod2(MovieEntityTest1 entity)

        {
            return await _movieService.CustomMethod2(entity);
        }

        [HttpGet("HitTrget")]
        public async Task<IActionResult> Get()
        {           
            var data = await _movieService.CallTargetAsync();           
            return Ok(data);
        }

        [HttpGet("GetAllPersonalDetails")]
        public async Task<List<PersonalDetailModel>> GetAllPersonalDetails()
        {
            var list = new List<PersonalDetailModel>();
            list.Add(new PersonalDetailModel { 
            UniqueKey =1,
            MemberName="Mohammad Zahid",
            DateOfBirth="12/20/1990",
            Gender="Male",
            RelationWithEmp = "Self",
            MarriageStatus="Married",
            NameOfNominee="Anjum",
            RelationOfNomineeWithEmp="Father"            
            });

            list.Add(new PersonalDetailModel
            {
                UniqueKey = 2,
                MemberName = "Zahida Khatoon",
                DateOfBirth = "12/20/1990",
                Gender = "Female",
                RelationWithEmp = "Self",
                MarriageStatus = "Married",
                NameOfNominee = "Shahid",
                RelationOfNomineeWithEmp = "Brother"
            });
            list.Add(new PersonalDetailModel
            {
                UniqueKey = 2,
                MemberName = "Zahida Khatoon",
                DateOfBirth = "12/20/1990",
                Gender = "Female",
                RelationWithEmp = "Self",
                MarriageStatus = "Married",
                NameOfNominee = "Shahid",
                RelationOfNomineeWithEmp = "Brother"
            });
            list.Add(new PersonalDetailModel
            {
                UniqueKey = 2,
                MemberName = "Zahida Khatoon",
                DateOfBirth = "12/20/1990",
                Gender = "Female",
                RelationWithEmp = "Self",
                MarriageStatus = "Married",
                NameOfNominee = "Shahid",
                RelationOfNomineeWithEmp = "Brother"
            });
            list.Add(new PersonalDetailModel
            {
                UniqueKey = 2,
                MemberName = "Zahida Khatoon",
                DateOfBirth = "12/20/1990",
                Gender = "Female",
                RelationWithEmp = "Self",
                MarriageStatus = "Married",
                NameOfNominee = "Shahid",
                RelationOfNomineeWithEmp = "Brother"
            });

            return list;
        }

        protected virtual void Dispose()
        {
            if (_movieService != null)
            {
                _movieService.Dispose();
            }
        }

        public class PersonalDetailModel
        {
            public int UniqueKey { get; set; }
            public string MemberName { get; set; }
            public string DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string RelationWithEmp { get; set; }
            public string MarriageStatus { get; set; }
            public string NameOfNominee { get; set; }
            public string RelationOfNomineeWithEmp { get; set; }
        }

    }
}
