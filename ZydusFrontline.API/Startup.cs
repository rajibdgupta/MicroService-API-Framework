using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZydusFrontline.API.MessageQueue.Publisher;
using ZydusFrontline.API.MessageQueue.Subscriber;
using ZydusFrontline.API.Middlewares.Caching;
using ZydusFrontline.API.Middlewares.ExceptionHandling;
using ZydusFrontline.API.Middlewares.Logging;
using ZydusFrontline.API.Utilities;
using ZydusFrontline.Entity.Logging;
using ZydusFrontline.Entity.Movies;
using ZydusFrontline.Interface.MessageQueue;
using ZydusFrontline.Interface.Repository;
using ZydusFrontline.Interface.Services;
using ZydusFrontline.Repository.Movies;
using ZydusFrontline.Services.Movies;

namespace ZydusFrontline.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<CustomerConsumerService>();
            services.AddHostedService<OrderConsumerService>();
            services.AddControllers();

            services.AddSingleton<IQueueClient>(x => new QueueClient(Configuration.GetValue<string>("ServiceBus:ConnectionString"),
                Configuration.GetValue<string>("ServiceBus:QueueName")));

            services.AddSingleton<ITopicClient>(x => new TopicClient(Configuration.GetValue<string>("ServiceBus:ConnectionString"),
               Configuration.GetValue<string>("ServiceBus:TopicName")));

            services.AddSingleton<IMessagePublisher, MessagePublisher>();
            services.AddTransient<RequestHandler>();
            services.AddHttpClient<TargetClient>((client) => client.BaseAddress = new System.Uri("http://localhost:34349"))
               .AddHttpMessageHandler<RequestHandler>();

            services.AddHttpContextAccessor();
            services.AddTransient<ICorrelationIdAccessor, CorrelationIdAccessor>();

            

            // add the dependency
            services.AddDependency();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });

            // enable cors
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //});
            services.AddMDTCors();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseAuthorization();
            app.UseMiddleware<LogHeaderMiddleware>();
            app.UseMiddleware<CachingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
