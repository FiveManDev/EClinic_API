using Microsoft.EntityFrameworkCore;
using Project.Core.Authentication;
using Project.Core.Cors;
using Project.Core.Mapper;
using Project.Core.MediatR;
using Project.Core.Swagger;
using Project.Core.Versioning;
using Project.ProfileService.Data.Configurations;
using Project.ProfileService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EClinicDBConnection"))
);

//builder.Logging.AddLogger(builder.Configuration);
builder.Services.AddMyMapper();
builder.Services.AddMyVersioning();
var CorsName = "Eclinic";
builder.Services.AddMyCors(CorsName);
//builder.Services.AddMassTransitWithRabbitMQ((config, context) =>
//{
//    config.AddReceiveEndpoint<RabbitMQConsumer>(ExchangeConstants.IdentityService, context);
//});
//builder.Services.AddRedisCache(builder.Configuration);
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//builder.Services.AddScoped(typeof(NotFoundIdFilter<IUserRepository, User>));
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
