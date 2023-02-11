using Microsoft.EntityFrameworkCore;
using Project.Core.Authentication;
using Project.Core.Caching;
using Project.Core.Cors;
using Project.Core.Filters;
using Project.Core.Logger;
using Project.Core.Mapper;
using Project.Core.MediatR;
using Project.Core.Swagger;
using Project.Core.Versioning;
using Project.IdentityService.Data;
using Project.IdentityService.Data.Configurations;
using Project.IdentityService.Repository.RoleRepository;
using Project.IdentityService.Repository.UserRepository;
using Project.IdentityService.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EClinicDBConnection"))
);

builder.Logging.AddLogger(builder.Configuration);
builder.Services.AddMyMapper();
builder.Services.AddMyVersioning();
var CorsName = "Eclinic";
builder.Services.AddMyCors(CorsName);
//builder.Services.AddMassTransitWithRabbitMQ((config, context) =>
//{
//    config.AddReceiveEndpoint<RabbitMQConsumer>(ExchangeConstants.IdentityService, context);
//});
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped(typeof(NotFoundIdFilter<IUserRepository, User>));

builder.Configuration.SetTokenOptions();
builder.Services.AddMyAuthentication(builder.Configuration.GetJWTOptions());
builder.Services.AddControllers();
builder.Services.AddMyMediatR();
builder.Services.AddMyMapper();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMySwagger();
builder.Services.AddGrpc();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMySwagger();

}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(CorsName);
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<AccountDataService>();
});
app.Run();
