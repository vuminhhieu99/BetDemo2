using Bet.Common;
using BetDemo;
using BetDemo.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:1998").AllowAnyHeader().AllowAnyMethod();                          
                      });
});
// Cấu hình thêm filejson
builder.Configuration
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration
           .AddJsonFile("Config/connections.json", optional: false, reloadOnChange: true);
builder.Configuration
           .AddJsonFile("Config/querySql.json", optional: false, reloadOnChange: true);
builder.Configuration
           .AddJsonFile("Config/LogConfig.json", optional: false, reloadOnChange: true);
var a = Directory.GetCurrentDirectory();
// Cấu hình log cho chương trình
Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.File($"{Directory.GetCurrentDirectory()}/{builder.Configuration.GetSection("LogConfig:Serilog:Part:Info").Value}", rollingInterval: RollingInterval.Day))
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.File($"{Directory.GetCurrentDirectory()}/{builder.Configuration.GetSection("LogConfig:Serilog:Part:Debug").Value}", rollingInterval: RollingInterval.Day))
                    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.File($"{Directory.GetCurrentDirectory()}/{builder.Configuration.GetSection("LogConfig:Serilog:Part:Error").Value}", rollingInterval: RollingInterval.Day))
                    .CreateLogger();

Log.Information("Create Project");
Log.Error("false Project");
Log.Debug("Debug Project");

// add authenticate
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


// cấu hình Dependency Injection 
builder.Services.CustomDependencyInjection();

// Cấu hình HttpContextAccessor
builder.Services.AddHttpContextAccessor();
SessionData.Instance.contructorHttpContextAccessor((HttpContextAccessor)builder.Services.BuildServiceProvider().GetService(typeof(IHttpContextAccessor)));

var version = builder.Configuration.GetValue<string>("NamePage");

//CHuyển hết kết nối Configuration về đây và không cần dependence inject trong layer service
BetUtil.Contructor(builder.Configuration, builder.Environment.ContentRootPath);
// Cấu hình logger ở đây vè không cần dependence inject trong layer service
LogCustom.ConstructorLoger(Log.Logger);

// Cấu hình authentication cho swagger
builder.Services.CustomSecureSwaggerUI();

// Cấu hình localization
builder.Services.CustomLocalization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Đăng ký lỗi ngoại lệ của chương trình
app.UseCustomExceptionHandler();

// Đăng ký log cho chương trình
app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

// đăng kí authen của chương trình
app.UseAuthentication();
app.UseAuthorization();

// Custom middleware của chương trình
app.UseCustomMiddleware();

// Custom localization
app.CustomUseRequestLocalization();

app.MapControllers();

app.Run();
