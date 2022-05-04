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
                          policy.WithOrigins("http://localhost:3000",
                                             "http://myhomeview.me").AllowAnyHeader().AllowAnyMethod();
                      });

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Insert customer services here */
/* User Transient -> new manager for every call 
 * transient v scoped (once per chain call)
 * use scoped for transactions
 */
builder.Services.AddTransient<INewsManager, NewsManager>();
builder.Services.AddTransient<IBlacklistManager, BlacklistManager>();

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

app.UseRouting();
app.UseCors(homeViewClient);
app.UseAuthorization();
app.MapControllers();


app.Run();