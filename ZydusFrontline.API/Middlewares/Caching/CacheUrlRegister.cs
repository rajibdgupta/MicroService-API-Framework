using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZydusFrontline.API.Middlewares.Caching
{
    public static class CacheUrlRegister
    {
        private static List<CacheUrl> CacheUrlList = new List<CacheUrl>();
        public static IList<CacheUrl> GetCacheUrlList()
        {
            CacheUrlList.Add(new CacheUrl { URL = "/WeatherForecast", SlidingExpirationTimeSpanInseconds = 120, AbsoluteExpirationTimeSpanInseconds = 180 });
            CacheUrlList.Add(new CacheUrl { URL = "/api/movie/GetMoviesByGenre", SlidingExpirationTimeSpanInseconds = 120, AbsoluteExpirationTimeSpanInseconds = 150 });
            CacheUrlList.Add(new CacheUrl { URL = "/api/PersonalDetail/GetAllMember", SlidingExpirationTimeSpanInseconds = 120, AbsoluteExpirationTimeSpanInseconds = 300 });
            return CacheUrlList;
        }
    }

    public class CacheUrl
    {
        public string URL { get; set; }
        public int AbsoluteExpirationTimeSpanInseconds { get; set; }
        public int SlidingExpirationTimeSpanInseconds { get; set; }

    }
}
