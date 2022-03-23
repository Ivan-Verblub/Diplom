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
        public ChangingForm()
        {    
            InitializeComponent();
            var props = typeof(T).GetProperties();
            foreach(var prop in props)
            {
                var df = new DataField<T, F>(prop);
                flowLayoutPanel1.Controls.Add(df);
            }

        }
        public ChangingForm(F filter)
        {
            InitializeComponent();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var df = new DataField<T, F>(prop);
                flowLayoutPanel1.Controls.Add(df);
            }
            using (var requester = new Requester<T,F>(""))
            {
                var table = requester.Select(filter);
                foreach(var item in table.GetType().GetElementType().GetProperties())
                {
                   
                }
            }
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
                            if(field.PropertyType == typeof(int))
                                table.GetType().GetProperty(field.Name).SetValue(table, int.Parse(((TextBox)df).Text));
                            else if(field.PropertyType == typeof(float))
                                table.GetType().GetProperty(field.Name).SetValue(table, float.Parse(((TextBox)df).Text.Replace(',','.')));
                            else
                                table.GetType().GetProperty(field.Name).SetValue(table, ((TextBox)df).Text);
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
        }
    }
}
