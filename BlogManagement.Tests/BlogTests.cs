using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlogManagement.Core.ApplicationServices.Blogs;
using BlogManagement.Core.Domain.Blogs;
using BlogManagement.Endpoints.API;
using BlogManagement.Infra.Data.Sql.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Xunit;

namespace BlogManagement.Tests
{
    public class BlogTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _fixture;
        public BlogTests(WebApplicationFactory<Startup> fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task BlogInsert()
        {
            var dbConnection = new SqliteConnection($"DataSource=testDb{Guid.NewGuid().ToString("N")};mode=memory;cache=shared");
            await dbConnection.OpenAsync();
            var client = _fixture.WithWebHostBuilder(hostBuilder =>
            {
                hostBuilder.ConfigureTestServices(services =>
                {
                    var descriptors = services.Where(d => d.ServiceType == typeof(DbContextOptions<BlogManagementDbContext>)
                        || d.ServiceType == typeof(BlogManagementDbContext)).ToList();
                    foreach (var descriptor in descriptors)
                        services.Remove(descriptor);
                    services.AddDbContext<BlogManagementDbContext>(options => options.UseSqlite(dbConnection).LogTo(Console.WriteLine));

                    var serviceProvider = services.BuildServiceProvider();
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<BlogManagementDbContext>();
                        dbContext.Database.Migrate();
                    }
                });
            }).CreateClient();
            var command = new AddBlogCommand
            {
                Name = "Test blog",
                EnName = "Test Blog En",
                Desciption = "This is a description for test blog"
            };
            var response = await client.PostAsync("/Blogs", SerializeContent(command));
            response.EnsureSuccessStatusCode();

            response = await client.GetAsync("/Blogs");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var objResult = JsonConvert.DeserializeObject<List<Blog>>(result);
            Assert.Equal(objResult.Count, 1);
            Assert.Equal(objResult[0].Name, command.Name);
            Assert.Equal(objResult[0].EnName, command.EnName);
            Assert.Equal(objResult[0].Desciption, command.Desciption);
            await dbConnection.CloseAsync();
        }

        private HttpContent SerializeContent(object model)
        {
            var json = JsonConvert.SerializeObject(model);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}