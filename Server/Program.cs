using Server.Controllers.Models;
using Server.MySQL;
using System.Text.Json;
class Programm
{
    private const string DefualtPath = "C:\\Program Files\\MySQL\\MySQL Server 8.0\\bin\\";
    public static void Main(string[] args)
    {
        Param.Dump.Path = DefualtPath;
        Param.Dump.MSPath = DefualtPath;
        if (!Directory.Exists("Settings"))
        {
            Directory.CreateDirectory("Settings");
        }
        if (File.Exists(Environment.CurrentDirectory+"\\Settings\\host.json"))
        {
            try
            {
                Param.Settings = JsonSerializer.Deserialize<Settings>(
                    File.ReadAllText(Environment.CurrentDirectory+"\\Settings\\host.json"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        if (File.Exists(Environment.CurrentDirectory+"\\Settings\\dump.json"))
        {
            try
            {
                Param.Dump = JsonSerializer.Deserialize<Dump>(
                    File.ReadAllText(Environment.CurrentDirectory+"\\Settings\\dump.json"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
        for (int i = 0; i<args.Length; i++)
        {
            switch (args[i])
            {
                case "-h":
                    i++;
                    Param.Settings.host = args[i];
                    break;
                case "-u":
                    i++;
                    Param.Settings.user = args[i];
                    break;
                case "-p":
                    i++;
                    Param.Settings.password = args[i];
                    break;
                case "-d":
                    i++;
                    Param.Dump.Path = args[i];
                    break;
                case "-s":
                    i++;
                    Param.Dump.MSPath = args[i];
                    break;
            }
        }
        var st = StaticTables.Instance;
        st.Connector = new Connector(Param.Settings.host, 
            Param.Settings.user, Param.Settings.password);
        if (!st.Connector.Open())
        {
            Console.WriteLine("Ошибка при подключении к БД, " +
                "попробуйте использовать другие параметры");
            Environment.Exit(0);
        }
        var json = JsonSerializer.Serialize<Settings>(Param.Settings);
        File.WriteAllText(Environment.CurrentDirectory+"\\Settings\\host.json", json);

        var jsonD = JsonSerializer.Serialize<Dump>(Param.Dump);
        File.WriteAllText(Environment.CurrentDirectory+"\\Settings\\dump.json", jsonD);
        st.ActualT = new(st.Connector);
        st.CharsOT = new(st.Connector);
        st.CharsRT = new(st.Connector);
        st.ContextT = new(st.Connector);
        st.ContextableT = new(st.Connector);
        st.ContextsT = new(st.Connector);
        st.DataSetT = new(st.Connector);
        st.DataT = new(st.Connector);
        st.LearningHistoryT = new(st.Connector);
        st.ObjectsT = new(st.Connector);
        st.ObjectsHistoryT = new(st.Connector);
        st.OptionsT = new(st.Connector);
        st.PathsT = new(st.Connector);
        st.RequestT = new(st.Connector);
        st.RequestInnerT = new(st.Connector);
        st.ScatT = new(st.Connector);
        st.SearchContextT = new(st.Connector);
        st.SearchNamesT = new(st.Connector);
        st.SLocationT = new(st.Connector);
        st.SStatusT = new(st.Connector);

        var builder = WebApplication.CreateBuilder(new string[] { });

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


