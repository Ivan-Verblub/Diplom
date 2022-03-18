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

        private void ShowData()
        {
            var dataForm = new DataForm<Scat>();
            dataForm.TopLevel = false;
            dataForm.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(dataForm);
            dataForm.Show();

            var fs = new FilterSelector<ScatFilter>()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            splitContainer2.Panel2.Controls.Add(fs);
            fs.Show();
        }
    }
}
