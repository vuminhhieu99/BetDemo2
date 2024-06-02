var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

// Cấu hình thêm filejson
builder.Configuration
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration
           .AddJsonFile("Config/connections.json", optional: false, reloadOnChange: true);
builder.Configuration
           .AddJsonFile("Config/querySql.json", optional: false, reloadOnChange: true);
var a = Directory.GetCurrentDirectory();

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
