using Diet.Framework.Core.Bus;
using Diet.Persistence.EF;
using Diet.Application;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IQueryBus, QueryBus>();
builder.Services
      .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
