using BFAWebApp.Domain.Interfaces;
using BFAWebApp.Infrastructure.Data;
using BFAWebApp.Infrastructure.Options;
using BFAWebApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbProcOptions>(builder.Configuration.GetSection("DbProcedures"));
builder.Services.AddSingleton<ISqlRunner, SqlRunner>();
builder.Services.AddScoped<ISystemDiscountRepository, SystemDiscountRepository>();
builder.Services.AddScoped<SystemDiscountRepository>();


// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
