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
            vMenu.OnClickBtn1 += ShowData;
            vMenu.Show();
        }

        private void MainF_Load(object sender, EventArgs e)
        {

        }

        private void ShowData()
        {
            DataForm dataForm = new DataForm();
            dataForm.TopLevel = false;
            dataForm.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(dataForm);
            dataForm.Show();
        }
    }
}
