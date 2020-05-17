using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Entity.Movies;
using ZydusFrontline.Interface.Movies;
using ZydusFrontline.Interface.Repository;
using ZydusFrontline.Repository.ContextModel;

namespace ZydusFrontline.Repository.Movies
{  
    public class MovieRepository : IMovieRepository
    {
        private readonly DBContext _context = null;
        public MovieRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<MovieEntity>> Entities(MovieEntity query)
        {
            IQueryable<MovieEntity> result = null;
            //_context = new DBContext();
            //result = _context.Movies.Where(x => x.Genre == query.Genre)
            //    .Select(x => new MovieEntity()
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Genre = x.Genre
            //    }).AsQueryable();
            //return result;
            return null;
        }

        public Task<bool> Update(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<MovieEntityTest1>> CustomMethod(MovieEntityTest1 query)
        {
            IQueryable<MovieEntityTest1> result = null;
            //_context = new DBContext();
            //result = _context.Movies.Where(x => x.Genre == query.Genre)
            //    .Select(x => new MovieEntityTest1()
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Genre = x.Genre
            //    }).AsQueryable();
            //return result;
            return null;
        }

        public async Task<IQueryable<MovieEntityTest2>> CustomMethod2(MovieEntityTest1 query)
        {
            IQueryable<MovieEntityTest2> result = null;
            //_context = new DBContext();
            //result = _context.Movies.Where(x => x.Genre == query.Genre)
            //    .Select(x => new MovieEntityTest2()
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Genre = x.Genre
            //    }).AsQueryable();
            //return result;
            return null;
        }
    }
}
