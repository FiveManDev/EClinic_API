using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Core.Authentication;
using Project.Core.Cors;
using Project.Core.Filters;
using Project.Core.Mapper;
using Project.Core.MediatR;
using Project.Core.Swagger;
using Project.Core.Versioning;
using Project.ProfileService.Data.Configurations;
using Project.ProfileService.Repository.DoctorProfileRepository;
using Project.ProfileService.Repository.HealthProfileRepository;
using Project.ProfileService.Repository.ProfileRepository;
using Project.ProfileService.Repository.RelationshipRepository;
using Project.ProfileService.Repository.SupporterProfileRepository;
using Project.ProfileService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EClinicDBConnection"))
);
builder.Services.AddMyMapper();
builder.Services.AddMyVersioning();
var CorsName = "Eclinic";
builder.Services.AddMyCors(CorsName);
//builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IHealthProfileRepository, HealthProfileRepository>();
builder.Services.AddScoped<IDoctorProfileRepository, DoctorProfileRepository>();
builder.Services.AddScoped<ISupporterProfileRepository, SupporterProfileRepository>();
builder.Services.AddScoped<IRelationshipRepository, RelationshipRepository>();
builder.Services.AddScoped(typeof(NotFoundIdFilter<IProfileRepository, Project.ProfileService.Data.Profile>));
builder.Services.AddMyAuthentication(builder.Configuration.GetJWTOptions());
builder.Services.AddControllers();
builder.Services.AddMyMediatR();
builder.Services.AddMyMapper();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMySwagger();
builder.Services.AddGrpc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMySwagger();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(CorsName);
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<ProfileDataService>();
});
app.MapControllers();

app.Run();
