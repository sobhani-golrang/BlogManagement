using BlogManagement.Core.ApplicationServices.Blogs;
using BlogManagement.Core.ApplicationServices.Comments;
using BlogManagement.Core.ApplicationServices.Posts;
using BlogManagement.Core.Domain.Blogs;
using BlogManagement.Core.Domain.Comments;
using BlogManagement.Core.Domain.Posts;
using BlogManagement.Endpoints.API.Filters;
using BlogManagement.Endpoints.API.Middlewares;
using BlogManagement.Infra.Data.Sql.Blogs;
using BlogManagement.Infra.Data.Sql.Comments;
using BlogManagement.Infra.Data.Sql.Common;
using BlogManagement.Infra.Data.Sql.Posts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BlogManagement.Endpoints.API
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
            services.AddControllers(c=> {
                c.Filters.Add(typeof(ExceptionFilter));
                c.Filters.Add(typeof(ResultFilter));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlogManagement.Endpoints.API", Version = "v1" });
            });

            services.AddLogging(c=> c.AddSeq(Configuration.GetConnectionString("SeqLogCnn")));
            services.AddDbContext<BlogManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlogManagementCnn")));
            services.AddScoped<BlogRepository, EfBlogRepository>();
            services.AddScoped<PostRepository, EfPostRepository>();
            services.AddScoped<CommentRepository, EfCommentRepository>();
            services.AddScoped<BlogApplicaitonService>();
            services.AddScoped<PostApplicationService>();
            services.AddScoped<CommentApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogManagement.Endpoints.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseMiddleware<RequestLoggerMiddleware>();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
