using Server.MySQL;
using Server.MySQL.Tables;
using Server.MySQL.Tables.Table;

class Programm
{
    public static void Main(string[] args)
    {
        StaticTables.Connector = new Connector("localhost","root","qwerty");
        if(!StaticTables.Connector.Open())
            Environment.Exit(0);
        StaticTables.ActualT = new(StaticTables.Connector);
        StaticTables.DataSetT = new(StaticTables.Connector);
        StaticTables.DataT = new(StaticTables.Connector);
        StaticTables.LearningHistoryT = new(StaticTables.Connector);
        StaticTables.ObjectsT = new(StaticTables.Connector);
        StaticTables.ObjectsHistoryT = new(StaticTables.Connector);
        StaticTables.RequestT = new(StaticTables.Connector);
        StaticTables.RequestInnerT = new(StaticTables.Connector);
        StaticTables.ScatT = new(StaticTables.Connector);
        StaticTables.SLocationT = new(StaticTables.Connector);
        StaticTables.SStatusT = new(StaticTables.Connector);
        

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
    }
}


