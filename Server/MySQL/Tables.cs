using Server.MySQL.Tables;
using Server.MySQL.Tables.Filter;
using Server.MySQL.Tables.Table;

namespace Server.MySQL
{
    public class StaticTables
    {
        public static StaticTables Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StaticTables();
                return _instance;
            }
        }
        private static StaticTables? _instance;
        private StaticTables()
        {

        }
        public Connector Connector { get; set; }
        public Table<Actual, ActualFilter> ActualT { get; set; }
        public Table<CharListObjects, CharListObjectsFilter> CharsOT { get; set; }
        public Table<CharListRequest, CharListRequestFilter> CharsRT { get; set; }
        public Table<Context, ContextFilter> ContextT { get; set; }
        public Table<Contextable, ContextableFilter> ContextableT { get; set; }
        public Table<Contexts, ContextsFilter> ContextsT { get; set; }
        public Table<DataSet, DataSetFilter> DataSetT { get; set; }
        public Table<DatasTable, DatasFilter> DataT { get; set; }
        public Table<LearningHistory, LearningHistoryFilter> LearningHistoryT { get; set; }
        public Table<Objects, ObjectsFilter> ObjectsT { get; set; }
        public Table<ObjectsHistory, ObjectsHistoryFilter> ObjectsHistoryT { get; set; }
        public Table<Options, OptionsFilter> OptionsT { get; set; }
        public Table<Paths, PathsFilter> PathsT { get; set; }
        public Table<Request, RequestFilter> RequestT { get; set; }
        public Table<RequestInner, RequestInnerFilter> RequestInnerT { get; set; }
        public Table<Scat, ScatFilter> ScatT { get; set; }

        public Table<SLocation, SLocationFilter> SLocationT { get; set; }
        public Table<SStatus, SStatusFilter> SStatusT { get; set; }

    }
}
