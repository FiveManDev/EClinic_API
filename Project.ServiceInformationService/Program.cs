using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Core.Authentication;
using Project.Core.Mapper;
using Project.Core.MediatR;
using Project.Core.Swagger;
using Project.Core.Versioning;
using Project.ServiceInformationService.Data.Configurations;
using Project.ServiceInformationService.Repository.ServiceRepository;
using Project.ServiceInformationService.Repository.SpecializationRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("EClinicDBConnection"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
);
// add token jwt
builder.Services.AddMyAuthentication(builder.Configuration.GetJWTOptions());

builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
// Add auto mapper
builder.Services.AddMyMapper();

builder.Services.AddControllers();
builder.Services.AddMyMediatR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMySwagger();
builder.Services.AddMyVersioning();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMySwagger();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
