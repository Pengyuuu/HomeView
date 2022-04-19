using Services.Implementations;
//using System.Configuration;
using Managers.Implementations;
using Managers.Contracts;
using System.Net.Http.Headers;
using System.Web.Http;
using Data;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();

// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.json");
var c = builder.Configuration.AddUserSecrets("c75071fc - 3162 - 491e-84bc - 0281cca24924");
//var config = c.AddConfiguration(builder.Configuration);

//builder.Configuration.AddConfiguration(builder.Configuration);
//builder.Services.AddSingleton<IConfiguration, config.>();
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
//builder.Services.AddSingleton<IConfiguration>();
//builder.Services.AddSingleton<>
builder.Services.AddSingleton<SqlDataAccess>();

var config = builder.Configuration.GetSection("ConnectionStrings");
var config2 = builder.Configuration.GetSection("ConnectionStrings:ConnectionStr");

// To get the value configA
var value = config["ConnectionStr"];

/**
builder.Services.Configure<SqlDataAccess>(con =>
{
    //get from config.json file
    con.ConnectionStr = value;
});**/
var x = 1;
// or direct get the value
//var configA = Configuration.GetSection("MyConfig:ConfigA");

// This is to bind to your object
//builder.Configuration.GetSection("ConnectionStrings").Bind(data);
//builder.Configuration.Bind(data.ConnectionStr, value);
//builder.Services.Configure<SqlDataAccess>(builder.Configuration.GetSection("ConnectionStrings"));
//builder.Services.Configure<SqlDataAccess>(conn);






//builder.Services.AddSingleton<SqlDataAccess>();









var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //builder.Configuration.AddUserSecrets("c75071fc - 3162 - 491e-84bc - 0281cca24924");
    //app.Create
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