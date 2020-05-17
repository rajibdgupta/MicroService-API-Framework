using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Entity.Movies;
using ZydusFrontline.Interface.Services;

namespace ZydusFrontline.Interface.Movies
{
    public interface IMovieService: ISerivces<MovieEntity, MovieEntity, bool>
    {
        Task<List<MovieEntityTest1>> CustomMethod1(MovieEntityTest1 query);
        Task<List<MovieEntityTest2>> CustomMethod2(MovieEntityTest1 query);
        Task<string> CallTargetAsync();
    }
}
