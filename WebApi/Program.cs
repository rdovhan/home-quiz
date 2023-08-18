using NLog.Extensions.Logging;
using NLog.Web;
using WebApi.Data.Repositories;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure logging
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
});

builder.Services.AddScoped<IThirdPartyHandlerService, ThirdPartyHandlerService>();
builder.Services.AddScoped<ICallbackServiceHandler, CallbackServiceHandler>();
builder.Services.AddScoped<ICallbackStatusRepository, CallbackStatusRepository>();


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
