using Gos.Forms.Filter;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
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
    public partial class MainF : Form
    {
        public MainF()
        {
            InitializeComponent();
            var load = new Load();
            load.ShowDialog();
            VMenu vMenu = new VMenu();
            vMenu.Dock = DockStyle.Fill;
            vMenu.TopLevel = false;
            splitContainer1.Panel1.Controls.Add(vMenu);
            vMenu.Click += ShowData;
            vMenu.Show();
        }

        private void MainF_Load(object sender, EventArgs e)
        {

        }

        private void ShowData(Type table,Type filter)
        {
            if(splitContainer4.Panel2.Controls.Count != 0)
                ((Form)splitContainer4.Panel2.Controls[0]).Close();
            if (splitContainer3.Panel1.Controls.Count != 0)
                ((Form)splitContainer3.Panel1.Controls[0]).Close();
            if (splitContainer3.Panel2.Controls.Count != 0)
                ((Form)splitContainer3.Panel2.Controls[0]).Close();
            if (splitContainer4.Panel1.Controls.Count != 0)
                ((Form)splitContainer4.Panel1.Controls[0]).Close();
            var dataForm = (Form)typeof(DataForm<,>).MakeGenericType(table, filter)
                .GetConstructor(Type.EmptyTypes).Invoke(null);
            dataForm.TopLevel = false;
            dataForm.Dock = DockStyle.Fill;
            splitContainer4.Panel2.Controls.Add(dataForm);
            dataForm.Show();
            
            var fs = (Form)typeof(FilterSelector<,>).MakeGenericType(table, filter)
                .GetConstructor(Type.EmptyTypes).Invoke(null);
            fs.TopLevel = false;
                fs.Dock = DockStyle.Fill;
            splitContainer3.Panel1.Controls.Add(fs);
            fs.Show();
            
            var fis = (Form)typeof(FieldSelector<>).MakeGenericType(table)
                .GetConstructor(Type.EmptyTypes).Invoke(null);
            fis.TopLevel = false;
            fis.Dock = DockStyle.Fill;
            splitContainer3.Panel2.Controls.Add(fis);
            fis.Show();

            var bs = (Form)typeof(Buttons<,>).MakeGenericType(table, filter)
                .GetConstructor(new Type[] { typeof(DataForm<,>).MakeGenericType(table, filter) })
                .Invoke(new object[] { dataForm });
            bs.TopLevel = false;
            bs.Dock = DockStyle.Fill;
            splitContainer4.Panel1.Controls.Add(bs);
            bs.Show();
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void MainF_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (splitContainer4.Panel1.Controls.Count == 0)
            {
                (splitContainer1.Panel1.Controls[0] as VMenu).VMenu_PreviewKeyDown(null, new PreviewKeyDownEventArgs(keyData));
            }
            else
            {
                splitContainer4.Panel1.Controls[0].GetType().GetMethod("Buttons_PreviewKeyDown").
                    Invoke(splitContainer4.Panel1.Controls[0], new object[] { null, new PreviewKeyDownEventArgs(keyData) });
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
