using Project.Core.Authentication;
using Project.Core.Caching;
using Project.Core.Cors;
using Project.Core.Mapper;
using Project.Core.MediatR;
using Project.Core.RabbitMQ;
using Project.Core.Swagger;
using Project.Core.Versioning;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMassTransitWithRabbitMQ((config, context) =>
//{
//    config.AddReceiveEndpoint<DeleteProfileResultConsumer>(ExchangeConstants.ProfileService + "Delete", context);
//    config.AddReceiveEndpoint<UpdateProfileResultConsumer>(ExchangeConstants.ProfileService, context);
//});
builder.Services.AddMyVersioning();
var CorsName = "Eclinic";
builder.Services.AddMyCors(CorsName);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddMyAuthentication(builder.Configuration.GetJWTOptions());
builder.Services.AddControllers();
builder.Services.AddMyMediatR();
builder.Services.AddMyMapper();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMySwagger();
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

app.Run();