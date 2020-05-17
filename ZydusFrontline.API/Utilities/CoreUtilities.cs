using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZydusFrontline.Entity.Movies;
using ZydusFrontline.Interface.FamilyDetails;
using ZydusFrontline.Interface.Movies;
using ZydusFrontline.Interface.Repository;
using ZydusFrontline.Interface.Services;
using ZydusFrontline.Repository.ContextModel;
using ZydusFrontline.Repository.FamilyDetails;
using ZydusFrontline.Repository.Movies;
using ZydusFrontline.Services.FamilyDetails;
using ZydusFrontline.Services.Movies;

namespace ZydusFrontline.API.Utilities
{
    public static class CoreUtilities
    {
        /// <summary>
        /// Set the dependency injection 
        /// </summary>
        /// <param name="services"></param>
        internal static void AddDependency(this IServiceCollection services)
        {
            GetDependencies(services);
        }

        /// <summary>
        /// Set the CORS
        /// As of now, all the URLs are allowed. In ater stage the specific URLs will be whitelisted
        /// </summary>
        /// <param name="services"></param>
        internal static void AddMDTCors(this IServiceCollection services)
        {
            services.AddCors(config =>
            {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;
                config.AddPolicy("policy", policy);
            });
        }
       

        /// <summary>
        /// Handeling authorization token
        /// </summary>
        /// <param name="services"></param>
        /// <param name="key"></param>
        //internal static void AddMDTAuthrization(this IServiceCollection services, IConfigurationSection key)
        //{
        //    services.AddAuthorization(auth =>
        //    {
        //        auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        //            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
        //            .RequireAuthenticatedUser().Build());
        //    });

        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //    .AddJwtBearer(options =>
        //    {
        //        var keyByteArray = Encoding.ASCII.GetBytes(key.GetSection("Key").Value);
        //        var signinKey = new SymmetricSecurityKey(keyByteArray);
        //        options.TokenValidationParameters = new TokenValidationParameters()
        //        {
        //            IssuerSigningKey = signinKey,
        //            ValidAudience = key.GetSection("Audience").Value,
        //            ValidIssuer = key.GetSection("Issuer").Value,
        //            ValidateIssuerSigningKey = true,
        //            ValidateLifetime = true,
        //            ClockSkew = TimeSpan.FromMinutes(0)
        //        };
        //    });
        //}

        /// <summary>
        /// Add appsettings configurations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        //internal static void AddMDTConfigurations(this IServiceCollection services, IConfiguration Configuration)
        //{
        //    services.Configure<JWTSettings>(Configuration.GetSection("JWT"));
        //}

        private static void GetDependencies(IServiceCollection services)
        {
            services.AddScoped<DBContext>();
            #region Service
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IPersonalDetailService, PersonalDetailService>();
            #endregion

            #region Repository
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IPersonalDetailRepository, PersonalDetailRepository>();
            //services.AddScoped<MovieRepository>();
            #endregion
        }
    }
}
