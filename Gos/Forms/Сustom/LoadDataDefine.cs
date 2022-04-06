using Gos.Server;
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

namespace Gos.Forms.Сustom
{
    public partial class LoadDataDefine : Form
    {
        public LoadDataDefine()
        {
            InitializeComponent();
        }

        private void LoadDataDefine_Load(object sender, EventArgs e)
        {
            using (var requster = new Requester<Server.Models.Table.DataSet,
                DataSetFilter>("https://localhost:5001"))
            {
                comboBox1.DataSource = requster.Select();
                comboBox1.ValueMember = "idDataSet";
                comboBox1.DisplayMember = "setName";

                comboBox2.DataSource = requster.Select();
                comboBox2.ValueMember = "idDataSet";
                comboBox2.DisplayMember = "setName";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filter = new DatasFilter()
            { 
                Label = textBox1.Text
            };
            using (var requster = new Requester<DatasTable,
                DatasFilter>("https://localhost:5001"))
            {
                var datas = requster.Select(filter);
                var dt = new DataTable();
                dt.Columns.Add("feature", typeof(string));
                foreach(var data in datas)
                {
                    var rw = dt.NewRow();
                    rw["feature"] = data.feature;
                    dt.Rows.Add(rw);
                }
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                var datas = new DatasTable()
                {
                    feature = (string)rw.Cells["value"].Value+(string)rw.Cells["equeal"].Value,
                    label = "equeal",
                    idDataSet = (int)comboBox1.SelectedValue
                };
                using (var requester = new Requester<DatasTable, DatasFilter>("https://localhost:5001"))
                {
                    string er = requester.Insert(datas);
                    if (er!= "")
                    {
                        MessageBox.Show(
                            er,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                var datas = new DatasTable()
                {
                    feature = (string)rw.Cells["value"].Value+(string)rw.Cells["unequeal"].Value,
                    label = "unequeal",
                    idDataSet = (int)comboBox1.SelectedValue
                };
                using (var requester = new Requester<DatasTable, DatasFilter>("https://localhost:5001"))
                {
                    string er = requester.Insert(datas);
                    if (er!= "")
                    {
                        MessageBox.Show(
                            er,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            var rn = new Random();
            int i = 0;
            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                if (i == dataGridView1.Rows.Count)
                    break;
                var datas = new DatasTable()
                {
                    feature = (string)rw.Cells["value"].Value+(string)dataGridView1.Rows[rn.Next(0,dataGridView1.Rows.Count-1)].Cells["unequeal"].Value,
                    label = "unequeal",
                    idDataSet = (int)comboBox1.SelectedValue
                };
                using (var requester = new Requester<DatasTable, DatasFilter>("https://localhost:5001"))
                {
                    string er = requester.Insert(datas);
                    if (er!= "")
                    {
                        MessageBox.Show(
                            er,
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                i++;
            }
        }
    }
}
