using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Entity.Movies;
using ZydusFrontline.Interface.Repository;

namespace ZydusFrontline.Interface.Movies
{
    public interface IMovieRepository: IRepository<MovieEntity, MovieEntity, bool>
    {
        Task<IQueryable<MovieEntityTest1>> CustomMethod(MovieEntityTest1 query);
        Task<IQueryable<MovieEntityTest2>> CustomMethod2(MovieEntityTest1 query);       
    }
}
