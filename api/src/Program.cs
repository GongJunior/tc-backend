using Microsoft.EntityFrameworkCore;
using StoreFront.DataAccess;
using StoreFront.Extensions;
using Serilog;
//using Microsoft.AspNetCore.OpenApi;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    var cnnString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
        throw new NullReferenceException("Connection string not found");

    builder.AddSerilogForPostgres(cnnString);
    builder.Services.AddDbContext<StoreContext>(opt => opt.UseNpgsql(cnnString));

    //openapi
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.AddProductionErrorHandling();
    app.UseSwagger();
    app.UseSwaggerUI();

    app.AddTransactionEndpoints();
    app.AddUserEndpoints();
    app.MapGet("/", () => "Hello World!");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
