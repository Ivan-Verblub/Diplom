using Gos.Server.Atribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms.Components
{
    public partial class Value<T> : UserControl where T: class
    {
        public Value(T row)
        {
            InitializeComponent();
            var props = typeof(T).GetProperties();
            foreach(var prop in props)
            {
                var key = prop.GetCustomAttribute<Key>();
                if (key.IsKey == true)
                {
                    var lab = new Label()
                    {
                        Text = prop.GetValue(row).ToString()
                    };
                    
                }
            }
        }
    }
}
