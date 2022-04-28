using Gos.Forms.Changing;
using Gos.Server;
using Gos.Server.Atribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms
{
    public partial class ChangingForm<T,F>: Form where T: class where F: class
    {
        private bool isChange;
        private F filter;
        private object key;
        private EventController ec = EventController.Instance;
        public ChangingForm()
        {    
            InitializeComponent();
            var props = typeof(T).GetProperties();
            foreach(var prop in props)
            {
                if (prop.GetCustomAttributes(typeof(AI), true).Count() == 0)
                {
                    var df = new DataField<T, F>(prop);
                    df.Width = flowLayoutPanel1.Width-260;
                    flowLayoutPanel1.Controls.Add(df);
                    flowLayoutPanel1.SizeChanged += (o, e) =>
                    {
                        df.Width = flowLayoutPanel1.Width-260;
                    };
                }
            }
            isChange = false;
        }
        public ChangingForm(F filter)
        {
            InitializeComponent();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                if (prop.GetCustomAttributes(typeof(AI), true).Count() == 0)
                {
                    var df = new DataField<T, F>(prop);
                    flowLayoutPanel1.Controls.Add(df);
                }
            }
            this.filter = filter;
            isChange = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var table = typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                foreach (var field in typeof(T).GetProperties())
                {
                    if(isChange)
                    {
                        var key = field.GetCustomAttributes(typeof(Key), true);
                        if (key.Count() != 0)
                        {
                            if (((Key)key[0]).IsKey)
                            {
                                field.SetValue(table,this.key);
                            }
                        }
                    }
                    if (item.Name == field.Name)
                    {
                        var df = ((DataField<T, F>)item).Data;
                        if (df.GetType() == typeof(TextBox))
                        {
                            if(String.IsNullOrWhiteSpace(((TextBox)df).Text))
                            {
                                MessageBox.Show("");
                                df.Focus();
                                return ;
                            }
                            string val = ((TextBox)df).Text.Replace("\'", "\\\'").Replace("\"", "\\\"");
                            if (field.PropertyType == typeof(int))
                                table.GetType().GetProperty(field.Name).SetValue(table, int.Parse(val));
                            else if(field.PropertyType == typeof(float))
                                table.GetType().GetProperty(field.Name).SetValue(table, float.Parse(val.Replace(',','.')));
                            else
                                table.GetType().GetProperty(field.Name).SetValue(table, val);
                        }
                        else if (df.GetType() == typeof(DateTimePicker))
                        {
                            if(((DateTimePicker)df).Checked)
                            {
                                MessageBox.Show("");
                                df.Focus();
                                return;
                            }
                            table.GetType().GetProperty(field.Name).SetValue(table, ((DateTimePicker)df).Value);
                        }
                        else if (df.GetType() == typeof(ComboBox))
                        {
                            if(((ComboBox)df).SelectedIndex == -1)
                            {
                                MessageBox.Show("");
                                df.Focus();
                                return;
                            }
                            table.GetType().GetProperty(field.Name).SetValue(table, ((ComboBox)df).SelectedValue);
                        }
                        
                    }
                }
            }
            using (var requester = new Requester<T, F>(Param.Serv.host))
            {
                string er = "";
                if (isChange)
                {

                    er = (string)requester.GetType()
                        .GetMethod("Update", new Type[] { typeof(T) })
                        .Invoke(requester, new object[] { table });
                }
                else
                {
                    er = (string)requester.GetType()
                        .GetMethod("Insert", new Type[] { typeof(T) })
                        .Invoke(requester, new object[] { table });
                }
                if(er == "")
                {
                    ec.InvokeUpdateTable();
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        er, "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ChangingForm_Load(object sender, EventArgs e)
        {
            if (isChange)
                using (var requester = new Requester<T, F>(Param.Serv.host))
                {
                    var table = requester.Select(filter);
                    foreach (var item in table.GetType().GetElementType().GetProperties())
                    {
                        var key = item.GetCustomAttributes(typeof(Key), true);
                        if (key.Count() != 0)
                        {
                            if (((Key)key[0]).IsKey)
                            {
                                this.key = item.GetValue(table[0]);
                            }
                        }
                        foreach (var field in flowLayoutPanel1.Controls)
                        {
                            if (field.GetType() == typeof(DataField<T, F>))
                            {
                                if (((DataField<T, F>)field).Name == item.Name)
                                {
                                    if (((DataField<T, F>)field).Data.GetType() == typeof(TextBox))
                                    {
                                        ((TextBox)((DataField<T, F>)field).Data).Text =
                                            item.GetValue(table[0]).ToString();
                                    }
                                    else if (((DataField<T, F>)field).Data.GetType() == typeof(ComboBox))
                                    {
                                        ((ComboBox)((DataField<T, F>)field).Data).SelectedItem =
                                            ((ComboBox)((DataField<T, F>)field).Data).Items.Cast<DataRowView>().ToList()
                                            .FirstOrDefault(i => i.Row
                                            == ((DataTable)((ComboBox)((DataField<T, F>)field).Data).DataSource)
                                            .Select($"{item.Name} = {item.GetValue(table[0])}")[0]);
                                    }
                                    else if (((DataField<T, F>)field).Data.GetType() == typeof(DateTimePicker))
                                    {
                                        ((DateTimePicker)((DataField<T, F>)field).Data).Value =
                                            (DateTime)item.GetValue(table[0]);
                                    }
                                }
                            }
                        }
                    }
                }
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
