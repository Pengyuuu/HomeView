using Managers.Implementations;
using Managers.Contracts;

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
builder.Services.AddTransient<IRatingAndReviewManager, RatingAndReviewManager>();
builder.Services.AddTransient<ILoggingManager, LoggingManager>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IRegistrationManager, RegistrationManager>();
builder.Services.AddTransient<IAccountRecoveryManager, AccountRecoveryManager>();
builder.Services.AddTransient<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddTransient<IEmailManager, EmailManager>();
builder.Services.AddTransient<IUADManager, UADManager>();
builder.Services.AddTransient<IPlaylistManager, PlaylistManager>();
builder.Services.AddTransient<IWatchLaterManager,WatchLaterManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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