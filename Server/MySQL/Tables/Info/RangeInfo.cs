namespace Server.MySQL.Tables.Info
{
    public class RangeInfo
    {
        public List<FilterInfo> Range;

        public RangeInfo(List<FilterInfo> range)
        {
            Range = range;
        }
    }
}
