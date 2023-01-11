using Project.Core.RabbitMQ;
using Project.IdentityService.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddMassTransitWithRabbitMQ("Forum");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransitWithRabbitMQ((config, context) =>
{
    config.AddReceiveEndpoint<RabbitMQConsumer>("ForumUser", context);
    config.AddReceiveEndpoint<RabbitMQProfileConsumer>("ForumProfile", context);
});
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
