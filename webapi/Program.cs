using webapi.Interfaces;
using webapi.Services;
using webapi.Entites;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString")));
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddHttpClient();
builder.Services.AddHostedService<WorkerService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().WithOrigins(builder.Configuration.GetSection("ApiUrl:FrontendUrl").Value!));

app.UseRouting();

app.MapControllers();

app.Run();
