using Steeltoe.Extensions.Configuration.ConfigServer;
using Steeltoe.Management.Endpoint;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.AddConfigServer();

// builder.Configuration.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAllActuators(builder.Configuration);
builder.Services.ActivateActuatorEndpoints();


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

