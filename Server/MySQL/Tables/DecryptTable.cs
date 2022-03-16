using Server.MySQL.Atributes;
using Server.MySQL.Atributes.Filter;
using Server.MySQL.Tables.Info;

namespace Server.MySQL.Tables
{
    public class DecryptTable
    { 
        public List<string> UsedTable;
        public List<KFieldInfo> KeyFields;
        public List<FieldInfo> InfoFields;
        public List<FieldInfo> DataFields;
        public List<CFieldInfo> FKeyFields;
        public List<FilterInfo> Filters;
        public List<RangeInfo> Ranges;
        private List<int> _used;
        public DecryptTable(Type tableType, Type filterType)
        {
            UsedTable = new List<string>();
            KeyFields = new List<KFieldInfo>();
            InfoFields = new List<FieldInfo>();
            DataFields = new List<FieldInfo>();
            FKeyFields = new List<CFieldInfo>();
            Filters = new List<FilterInfo>();
            Ranges = new List<RangeInfo>();
            _used = new List<int>();
            Decrypt(tableType,filterType);
        }

        private void Decrypt(Type tableType, Type filterType)
        {
            TableAtribute tableAtribute =
                (TableAtribute)Attribute.GetCustomAttribute(tableType, typeof(TableAtribute));
            if (tableAtribute == null)
                throw new NullReferenceException(
                    "Используемый класс не имеет требуемого атрибута");
            foreach (string element in tableAtribute.Tables)
            {
                UsedTable.Add(element);
            }

            foreach (var field in tableType.GetProperties())
            {
                using (var dbAtribute =
                      (DBAtribute)Attribute.GetCustomAttribute(
                          field, typeof(DBAtribute)))
                {
                    if (dbAtribute == null)
                        continue;
                    if (!dbAtribute.Hide)
                        InfoFields.Add(
                            new FieldInfo(dbAtribute.Field,
                            dbAtribute.Table, field.Name));
                    using (var dataAtribute =
                          (DataAtribute)Attribute.GetCustomAttribute(
                              field, typeof(DataAtribute)))
                    {
                        if (dataAtribute != null)
                            DataFields.Add(
                                new FieldInfo(dbAtribute.Field,
                                dbAtribute.Table, field.Name));
                    }
                    using (var keyAtribute =
                          (KeyAtribute)Attribute.GetCustomAttribute(
                              field, typeof(KeyAtribute)))
                    {
                        if (keyAtribute != null)
                            KeyFields.Add(
                                new KFieldInfo(dbAtribute.Field,
                                dbAtribute.Table, field.Name, keyAtribute.AI));
                    }

                    using (var fKeyAtribute =
                          (FKeyAtribute)Attribute.GetCustomAttribute(
                              field, typeof(FKeyAtribute)))
                    {
                        if (fKeyAtribute != null)
                            FKeyFields.Add(
                                new CFieldInfo(dbAtribute.Field,
                                dbAtribute.Table, field.Name,
                                fKeyAtribute.Conection, fKeyAtribute.Table));
                    }
                }
            }
            int i = 0;
            foreach (var field in tableType.GetProperties())
            {
                using (var orderAtribute =
                     (OrderAtribute)Attribute.GetCustomAttribute(
                         field, typeof(OrderAtribute)))
                {
                    if (orderAtribute != null)
                    {
                        FieldInfo buff = InfoFields[orderAtribute.Order];
                        FieldInfo saveBuff = InfoFields[i];
                        InfoFields.RemoveAt(orderAtribute.Order);
                        InfoFields.Insert(orderAtribute.Order, saveBuff);
                        InfoFields.RemoveAt(i);
                        InfoFields.Insert(i, buff);
                        i++;
                    }

                }
            }

            foreach (var filter in filterType.GetProperties())
            {
                using (var rangeAtribute =
                     (RangeAtribute)Attribute.GetCustomAttribute(
                         filter, typeof(RangeAtribute)))
                {
                    if (rangeAtribute != null)
                    {
                        List<FilterInfo> range = new List<FilterInfo>();
                        if (!_used.Contains(rangeAtribute.Group))
                        {
                            foreach (var filter2 in filterType.GetProperties())
                            {
                                using (var rangeAtributeSecond =
                             (RangeAtribute)Attribute.GetCustomAttribute(
                                 filter2, typeof(RangeAtribute)))
                                {
                                    if (rangeAtributeSecond != null)
                                    {
                                        if (rangeAtribute.Group
                                            == rangeAtributeSecond.Group)
                                        {
                                            using (var filterAtribute =
                                                (FilterAtribute)Attribute.GetCustomAttribute(
                                                filter2, typeof(FilterAtribute)))
                                            {
                                                if (filterAtribute != null)
                                                {

                                                    string filtType = "";
                                                    switch (filterAtribute.FiltType)
                                                    {
                                                        case FType.GREATER:
                                                            filtType = ">";
                                                            break;
                                                        case FType.LESSER:
                                                            filtType = "<";
                                                            break;
                                                        case FType.EQUAL:
                                                            filtType = "=";
                                                            break;
                                                        case FType.INEQUAL:
                                                            filtType = "<>";
                                                            break;
                                                        case FType.GREATEREQUAL:
                                                            filtType = ">=";
                                                            break;
                                                        case FType.LESSEREQUAL:
                                                            filtType = "<=";
                                                            break;
                                                        case FType.LIKE:
                                                            filtType = " LIKE ";
                                                            break;
                                                        case FType.ISNULL:
                                                            filtType = " IS NULL";
                                                            break;
                                                    }
                                                    range.Add(new FilterInfo(
                                                        filterAtribute.Field, filterAtribute.Table,
                                                        filter2.Name, filtType));
                                                }

                                            }


                                        }
                                    }
                                }
                            }
                            i = 0;
                            foreach (var filter2 in filterType.GetProperties())
                            {
                                using (var rangeAtributeSecond =
                                    (RangeAtribute)Attribute.GetCustomAttribute(
                                    filter2, typeof(RangeAtribute)))
                                {

                                    if (rangeAtributeSecond != null)
                                    {
                                        if (rangeAtribute.Group
                                            == rangeAtributeSecond.Group)
                                        {
                                            FilterInfo buff = range[rangeAtributeSecond.Position];
                                            FilterInfo saveBuff = range[i];
                                            range.RemoveAt(rangeAtributeSecond.Position);
                                            range.Insert(rangeAtributeSecond.Position, saveBuff);
                                            range.RemoveAt(i);
                                            range.Insert(i, buff);
                                            i++;
                                        }
                                    }
                                }
                            }
                            _used.Add(rangeAtribute.Group);
                            Ranges.Add(new RangeInfo(range));
                        }
                    }
                }
            }
            foreach (var filter in filterType.GetProperties())
            {
                using (var filterAtribute =
                    (FilterAtribute)Attribute.GetCustomAttribute(
                    filter, typeof(FilterAtribute)))
                {
                    if (filterAtribute != null)
                    {
                        using (var rangeAtributeSecond =
                            (RangeAtribute)Attribute.GetCustomAttribute(
                            filter, typeof(RangeAtribute)))
                        {
                            if (rangeAtributeSecond == null)
                            {
                                string filtType = "";
                                switch (filterAtribute.FiltType)
                                {
                                    case FType.GREATER:
                                        filtType = ">";
                                        break;
                                    case FType.LESSER:
                                        filtType = "<";
                                        break;
                                    case FType.EQUAL:
                                        filtType = "=";
                                        break;
                                    case FType.INEQUAL:
                                        filtType = "<>";
                                        break;
                                    case FType.GREATEREQUAL:
                                        filtType = ">=";
                                        break;
                                    case FType.LESSEREQUAL:
                                        filtType = "<=";
                                        break;
                                    case FType.LIKE:
                                        filtType = " LIKE ";
                                        break;
                                    case FType.ISNULL:
                                        filtType = " IS NULL";
                                        break;
                                }
                                Filters.Add(new FilterInfo(
                                    filterAtribute.Field, filterAtribute.Table,
                                    filter.Name, filtType));
                            }
                        }
                    }
                }
            }
        }
    }
}
