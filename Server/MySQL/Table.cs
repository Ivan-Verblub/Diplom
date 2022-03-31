using MySql.Data.MySqlClient;
using Server.MySQL.Atributes.Table;
using Server.MySQL.Tables;
using Server.MySQL.Tables.Info;
using System.Data;
using System.Text;

namespace Server.MySQL
{
    public class Table<T,D> : ITable<T>,IFilter<D>, IDisposable where T: class where D : class
    {
        private MySqlCommand _command;
        private MySqlDataAdapter _adapter;
        DecryptTable decryptTable;
        public Table(Connector connector)
        {
            _command = new MySqlCommand();
            _command.Connection = connector.Connection;
            _adapter = new MySqlDataAdapter(_command);
            decryptTable = new DecryptTable(typeof(T),typeof(D));
        }
        public DataTable Select()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            foreach (var element in decryptTable.InfoFields)
            {
                builder.Append(element.Table);
                builder.Append('.');
                builder.Append(element.DBField);
                builder.Append(',');
                builder.Append(' ');
            }
            if(decryptTable.InfoFields.Count != 0)
                builder.Remove(builder.Length-2,2);
            builder.Append(' ');
            builder.Append("FROM ");
            for (int i = 0; i < decryptTable.UsedTable.Count-1; i++)
                builder.Append('(');
            if(decryptTable.FKeyFields.Count == 0)
            {
                builder.Append(' ');
                builder.Append(decryptTable.UsedTable[0]);
            }
            foreach (var element in decryptTable.FKeyFields)
            {
                if(element == decryptTable.FKeyFields.First())
                    builder.Append(element.Table);
                builder.Append(' ');
                builder.Append(element.ConType.ToString());
                builder.Append(" JOIN ");
                builder.Append(element.CTable);
                builder.Append(" ON ");
                builder.Append(element.Table);
                builder.Append('.');
                builder.Append(element.DBField);
                builder.Append(" = ");
                builder.Append(element.CTable);
                builder.Append('.');
                builder.Append(element.DBField);
                builder.Append(')');
            }

            _command.CommandText = builder.ToString();
            Console.WriteLine(_command.CommandText);
            DataTable dt = new DataTable();
            _adapter.Fill(dt);
            return dt;
        }
        public string Insert(T obj)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("INSERT INTO ");
            builder.Append(decryptTable.UsedTable[0]);
            builder.Append('(');
            foreach (var element in decryptTable.KeyFields)
            {
                builder.Append(element.DBField);
                builder.Append(',');
            }
            if (decryptTable.DataFields.Count == 0)
                builder.Remove(builder.Length - 1, 1);
            foreach (var element in decryptTable.DataFields)
            {
                builder.Append(element.DBField);
                builder.Append(',');
            }
            if (decryptTable.DataFields.Count != 0)
                builder.Remove(builder.Length - 1, 1);
            builder.Append(") VALUES(");
            foreach (var element in decryptTable.KeyFields)
            {
                foreach (var field in typeof(T).GetProperties())
                {
                    if (field.Name == element.Field)
                    {
                        if (!element.AI)
                        {
                            SetData(builder, field, obj, element);
                        }
                        else
                        {
                            builder.Append("NULL");
                        }
                        break;
                    }

                }
                builder.Append(',');
            }
            if (decryptTable.DataFields.Count == 0)
                builder.Remove(builder.Length - 1, 1);
            foreach (var element in decryptTable.DataFields)
            {
                foreach (var field in typeof(T).GetProperties())
                {
                    if (field.Name == element.Field)
                    {
                        SetData(builder, field, obj, element);
                        break;
                    }

                }
                builder.Append(',');
            }
            if (decryptTable.DataFields.Count != 0)
                builder.Remove(builder.Length - 1, 1);
            builder.Append(')');
            try
            {
                _command.CommandText = builder.ToString();
                Console.WriteLine(_command.CommandText);
                if (_command.ExecuteNonQuery() == 0)
                    return "Запись не была добавлена";
                return "";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
        public string Update(T obj)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append(decryptTable.UsedTable[0]);
            builder.Append(" SET ");
            foreach (var element in decryptTable.KeyFields)
            {
                foreach (var field in typeof(T).GetProperties())
                {
                    if (field.Name == element.Field)
                    {
                        if (element.AI)
                        {
                            builder.Append(element.DBField);
                            builder.Append('=');
                            SetData(builder, field, obj, element);
                        }
                        break;
                    }
                }
                builder.Append(',');
            }
            if (decryptTable.DataFields.Count == 0)
                builder.Remove(builder.Length - 1, 1);
            foreach (var element in decryptTable.DataFields)
            {
                
                foreach (var field in typeof(T).GetProperties())
                {
                    if (field.Name == element.Field)
                    {
                        builder.Append(element.DBField);
                        builder.Append('=');
                        SetData(builder, field, obj, element);
                        break;
                    }
                }
                builder.Append(',');
            }
            if (decryptTable.DataFields.Count != 0)
                builder.Remove(builder.Length - 1, 1);
            builder.Append(" WHERE ");

            foreach (var element in decryptTable.KeyFields)
            {
                foreach (var field in typeof(T).GetProperties())
                {
                    if (field.Name == element.Field)
                    {
                        if (element.AI)
                        {
                            builder.Append(element.DBField);
                            builder.Append('=');
                            SetData(builder, field, obj, element);
                        }
                        break;
                    }
                }
                builder.Append(" AND ");
            }
            if (decryptTable.KeyFields.Count != 0)
                builder.Remove(builder.Length - 5, 5);

            try
            {
                _command.CommandText = builder.ToString();
                Console.WriteLine(_command.CommandText);
                if (_command.ExecuteNonQuery() == 0)
                    return "Запись не была изменена";
                return "";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
        public string Delete(T obj)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("DELETE FROM ");
            builder.Append(decryptTable.UsedTable[0]);
            builder.Append(" WHERE ");
            foreach (var element in decryptTable.KeyFields)
            {
                foreach (var field in typeof(T).GetProperties())
                {
                    if (field.Name == element.Field)
                    {
                        if (element.AI)
                        {
                            builder.Append(element.DBField);
                            builder.Append('=');
                            SetData(builder, field, obj, element);
                        }
                        break;
                    }
                }

                builder.Append(" AND ");
            }
            if (decryptTable.KeyFields.Count != 0)
                builder.Remove(builder.Length - 5, 5);

            try
            {
                _command.CommandText = builder.ToString();
                if (_command.ExecuteNonQuery() == 0)
                    return "Запись не была удалена";
                return "";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
        public DataTable Select(D obj)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT ");
                foreach (var element in decryptTable.InfoFields)
                {
                    builder.Append(element.Table);
                    builder.Append('.');
                    builder.Append(element.DBField);
                    if (element != decryptTable.InfoFields.Last())
                        builder.Append(',');
                    builder.Append(' ');
                }
                builder.Append("FROM ");
                for (int i = 0; i < decryptTable.UsedTable.Count - 1; i++)
                    builder.Append('(');
                if (decryptTable.FKeyFields.Count == 0)
                {
                    builder.Append(' ');
                    builder.Append(decryptTable.UsedTable[0]);
                }
                foreach (var element in decryptTable.FKeyFields)
                {
                    if (element == decryptTable.FKeyFields.First())
                        builder.Append(element.Table);
                    builder.Append(' ');
                    builder.Append(element.ConType.ToString());
                    builder.Append(" JOIN ");
                    builder.Append(element.CTable);
                    builder.Append(" ON ");
                    builder.Append(element.Table);
                    builder.Append('.');
                    builder.Append(element.DBField);
                    builder.Append(" = ");
                    builder.Append(element.CTable);
                    builder.Append('.');
                    builder.Append(element.DBField);
                    builder.Append(')');
                }
                builder.Append(" WHERE ");

                foreach (var element in decryptTable.Ranges)
                {
                    var t = false;
                    builder.Append('(');
                    foreach (var range in element.Range)
                    {
                        if (!IsDefault(obj.GetType().GetProperty(range.Field).GetValue(obj)))
                        {
                            foreach (var field in typeof(D).GetProperties())
                            {
                                if (field.Name == range.Field)
                                {
                                    builder.Append(range.Table);
                                    builder.Append('.');
                                    builder.Append(range.DBField);
                                    builder.Append(range.FiltType);
                                    SetData(builder, field, obj, range);
                                    builder.Append(" OR ");
                                    break;
                                }
                            }
                            t = true;
                        }
                    }
                    if (t)
                    {
                        builder.Remove(builder.Length - 4, 4);
                        builder.Append(')');
                        builder.Append(" AND ");
                        if (decryptTable.Filters.Count == 0)
                            builder.Remove(builder.Length - 5, 5);
                    }
                    else
                        builder.Remove(builder.Length - 1, 1);
                }

                foreach (var element in decryptTable.Filters)
                {
                    if (!IsDefault(obj.GetType().GetProperty(element.Field).GetValue(obj)))
                    {
                        foreach (var field in typeof(D).GetProperties())
                        {
                            if (field.Name == element.Field)
                            {
                                builder.Append(element.Table);
                                builder.Append('.');
                                builder.Append(element.DBField);
                                builder.Append(element.FiltType);
                                SetData(builder, field, obj, element);
                                builder.Append(" AND ");
                                break;
                            }
                        }
                    }
                }
                if (decryptTable.Filters.Count != 0)
                    builder.Remove(builder.Length - 5, 5);
                _command.CommandText = builder.ToString();
                DataTable dt = new DataTable();
                _adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        bool IsDefault<Tp>(Tp o)
        {
            if (o == null)
                return true;
            if (Nullable.GetUnderlyingType(typeof(Tp)) != null)
                return false;
            var type = o.GetType();
            if (type.IsClass)
                return false;
            else           // => тип-значение, есть конструктор по умолчанию
                return Activator.CreateInstance(type).Equals(o);
        }
        private void SetData<Tp>(StringBuilder builder,
            System.Reflection.PropertyInfo field, Tp obj,
            FieldInfo element)
        {
            if (null == ((ByteArray)Attribute.GetCustomAttribute(field, typeof(ByteArray))))
            {

                builder.Append('\'');
                if (field.PropertyType == typeof(DateTime))
                    builder.Append(
                        ((DateTime)obj.GetType().GetProperty(element.Field)
                        .GetValue(obj)).ToString("yyyy-MM-dd"));
                else
                    builder.Append(
                        obj.GetType().GetProperty(element.Field)
                        .GetValue(obj));
                builder.Append('\'');
            }
            else
            {
                builder.Append('@');
                builder.Append(element.Field);
                _command.Parameters.AddWithValue(
                    element.Field,
                    Convert.FromBase64String((string)obj.GetType().
                    GetProperty(element.DBField)
                    .GetValue(obj)));
            }
        }
        public void Dispose()
        {
            _command.Dispose();
            _adapter.Dispose();
        }
    }
}
