using Services.Implementations;
using System.Configuration;
using Managers.Implementations;
using Managers.Contracts;
using System.Net.Http.Headers;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddSingleton<IArchivingManager, ArchivingManager>();
builder.Services.AddSingleton<IEmailManager, EmailManager>();
builder.Services.AddSingleton<ILoggingManager, LoggingManager>();
builder.Services.AddSingleton<IRatingAndReviewManager, RatingAndReviewManager>();
builder.Services.AddSingleton<IUserManager, UserManager>();



builder.Configuration.AddJsonFile("appsettings.json");

builder.Configuration.AddConfiguration()

builder.Services.AddOptions();

builder.Services.Configure<EmailManager>(_fromEmail =>
{
    builder.Configuration.GetSection("EmailService").GetSection("_fromEmail").Bind(_fromEmail);
} );
builder.Services.Configure<EmailService>(_fromEmail =>
{
    builder.Configuration.GetSection("EmailService").GetSection("_fromEmail").Bind(_fromEmail);
});
builder.Services.Configure<EmailService>(_server =>
{
    builder.Configuration.GetSection("EmailService").GetSection("_server").Bind(_server);
}); builder.Services.Configure<EmailService>(_port =>
{
    builder.Configuration.GetSection("EmailService").GetSection("_port").Bind(_port);
}); builder.Services.Configure<EmailService>(_key =>
{
    builder.Configuration.GetSection("EmailService").GetSection("_key").Bind(_key);
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/**

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeView_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

**/