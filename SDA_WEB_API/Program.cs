using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using SDA_WEB_API.BusinessLayer.Interfaces;
using SDA_WEB_API.BusinessLayer.Services;
using SDA_WEB_API.DataLayer;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services Injection
builder.Services.AddScoped(typeof(IUserAccountService), typeof(UserAccountService));
builder.Services.AddScoped(typeof(IeBuyService), typeof(eBuyService));
builder.Services.AddHttpContextAccessor();

//Database Injection
builder.Services.AddDbContext<OnlineBuyDBContext>(options =>
        options.UseSqlServer(builder.Configuration
        .GetConnectionString("ebuy")));//Connection String

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
