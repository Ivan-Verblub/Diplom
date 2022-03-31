using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            if (table == null)
                return dt;
            foreach (var row in table)
            {
                var rw = dt.NewRow();
                foreach(var prop in props)
                {
                    rw[prop.Name] = prop.GetValue(row);
                }
                dt.Rows.Add(rw);
            }

            return dt;
        }
    }
}
