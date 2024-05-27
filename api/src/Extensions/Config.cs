using NpgsqlTypes;
using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace StoreFront.Extensions;

static class Config
{

    public static void AddProductionErrorHandling(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler(exceptionHandlerApp
                => exceptionHandlerApp.Run(async context
                    => await Results.Problem()
                                 .ExecuteAsync(context)));
        }
    }

    public static void AddSerilogForPostgres(this WebApplicationBuilder builder, string connectionString)
    {
        var tableName = "logs";

        IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
        {
            {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
            {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
            {"raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
            {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
            {"properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
            {"props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
            {"machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
        };

        builder.Services.AddSerilog(
            (services, lc) 
                => lc
                    .ReadFrom.Configuration(builder.Configuration)
                    .WriteTo.PostgreSQL(connectionString, tableName, columnWriters, needAutoCreateTable: true)
                    .WriteTo.Console()
                );
    }
}