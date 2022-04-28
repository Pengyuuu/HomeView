using Services.Implementations;
//using System.Configuration;
using Managers.Implementations;
using Managers.Contracts;
using System.Net.Http.Headers;
using System.Web.Http;
using Data;

var builder = WebApplication.CreateBuilder(args);
var homeViewClient = "homeviewClient";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: homeViewClient,
                      policy =>
                      {
                          policy.WithOrigins("https://myhomeview.me");
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(homeViewClient);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();