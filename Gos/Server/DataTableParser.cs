using Gos.Server.Atribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server
{
    internal class DataTableParser
    {
        public static DataTable Parse<T>(T[] table) where T : class
        {
            DataTable dt = new DataTable();
            var props = typeof(T).GetProperties();
            foreach(var prop in props)
            {
                DataColumn col;
                if (prop.GetCustomAttributes<EnumList>().Count() != 0)
                    col = dt.Columns.Add(prop.Name, typeof(string));
                else if (Nullable.GetUnderlyingType(prop.PropertyType) == null)
                    col = dt.Columns.Add(prop.Name, prop.PropertyType);
                else
                    col = dt.Columns.Add(prop.Name,
                        Nullable.GetUnderlyingType(prop.PropertyType));
                col.AllowDBNull = true;
            }
            if (table == null)
                return dt;
            foreach (var row in table)
            {
                var rw = dt.NewRow();
                foreach(var prop in props)
                {
                    var value = prop.GetValue(row);
                    var en = prop.GetCustomAttribute<EnumList>();
                    if (en != null)
                    {
                        foreach (var ar in en.EnumType.GetEnumValues())
                        {
                            var loc = ar.GetType().GetMember(ar.ToString())[0]
                                .GetCustomAttribute<Localize>();
                            if (((int)value) == (int)ar)
                            {
                                if (loc == null)
                                    rw[prop.Name] = ar.ToString();
                                else
                                    rw[prop.Name] = loc.Name;
                            }
                        }
                    }
                    else if (value == null)
                        rw[prop.Name] = DBNull.Value;
                    else
                        rw[prop.Name] = value;
                }
                dt.Rows.Add(rw);
            }

            return dt;
        }
    }
}
