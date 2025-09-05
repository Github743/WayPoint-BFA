using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Interfaces;
using WayPoint_Infrastructure.Options;
using WayPoint_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbProcOptions>(builder.Configuration.GetSection("DbProcedures"));
builder.Services.AddSingleton<ISqlRunner, SqlRunner>();
builder.Services.AddScoped<ISystemDiscountRepository, SystemDiscountRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());
builder.Services.AddHealthChecksUI(setupSettings =>
{
    setupSettings.AddHealthCheckEndpoint("WayPoint API - self", "/health");
})
.AddInMemoryStorage();

// ---- CORS ----
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("DefaultCorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI(options =>
{
    options.UIPath = "/health-ui";
});

app.Run();