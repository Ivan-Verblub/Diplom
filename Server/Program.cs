using Server.MySQL;

class Programm
{
    public static void Main(string[] args)
    {
        var st = StaticTables.Instance;
        st.Connector = new Connector("localhost","root","qwerty");
        if(!st.Connector.Open())
            Environment.Exit(0);
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


