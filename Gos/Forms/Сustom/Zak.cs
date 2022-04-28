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
    public partial class Zak : Form
    {
        public Zak()
        {
            InitializeComponent();
            using (var requester = new Requester<Request,
                RequestFilter>(Param.Serv.host))
            {
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
                comboBox1.DataSource = DataTableParser.
                    Parse(requester.Select());
            }

            using (var requester = new Requester<SStatus,
                SStatusFilter>(Param.Serv.host))
            {
                comboBox2.DataSource = DataTableParser.
                    Parse(requester.Select());
                comboBox2.ValueMember = "idStatus";
                comboBox2.DisplayMember = "status";
            }

            using (var requester = new Requester<SLocation,
                SLocationFilter>(Param.Serv.host))
            {
                comboBox3.DataSource = DataTableParser.
                    Parse(requester.Select());
                comboBox3.ValueMember = "idLocation";
                comboBox3.DisplayMember = "location";
            }

            using (var requester = new Requester<Scat,
                ScatFilter>(Param.Serv.host))
            {
                comboBox4.DataSource = DataTableParser.
                    Parse(requester.Select());
                comboBox4.ValueMember = "idCat";
                comboBox4.DisplayMember = "name";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inv = "";
            using (var requester = new Requester<Objects,
                ObjectsFilter>(Param.Serv.host))
            {
                var obj = requester.Select();
                inv = obj == null ? "0000000001" : obj.Max(x => x.invNumber);
            }

            for (int j = 0; j<int.Parse(textBox3.Text); j++)
            {
                int col = int.Parse(inv)+1;
                inv = "";
                for (int i = 0; i<(10-col.ToString().Length); i++)
                {
                    inv += "0";
                }
                inv += col.ToString();

                using (var requester = new Requester<Objects,
                    ObjectsFilter>(Param.Serv.host))
                {
                    requester.Insert(new Objects()
                    {
                        invNumber = inv,
                        name = textBox1.Text,
                        cost = int.Parse(textBox2.Text),
                        idStatus = (int)comboBox2.SelectedValue,
                        idLocation = (int)comboBox3.SelectedValue,
                        idCat = (int)comboBox4.SelectedValue,
                        idRequest = (int)comboBox1.SelectedValue
                    });
                }
                using (var requester = new Requester<ObjectsHistory,
                        ObjectsHistoryFilter>(Param.Serv.host))
                {
                    requester.Insert(new ObjectsHistory()
                    {
                        invNumber = inv,
                        idStatus = (int)comboBox2.SelectedValue,
                        idLocation = (int)comboBox3.SelectedValue,
                        date = dateTimePicker1.Value
                    });
                }
                using (var requester = new Requester<CharListObjects,
                   CharListObjectsFilter>(Param.Serv.host))
                {
                    using (var requester2 = new Requester<CharListRequest,
                        CharListRequestFilter>(Param.Serv.host))
                    {
                        var list = requester2.Select(new CharListRequestFilter()
                        {
                            IdRequest = (int)comboBox5.SelectedValue
                        });
                        foreach (var item in list)
                        {
                            requester.Insert(new CharListObjects()
                            {
                                name = item.name,
                                value = item.value,
                                idObject = inv
                            });
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var requester = new Requester<RequestInner,
                    RequestInnerFilter>(Param.Serv.host))
                {
                    comboBox5.ValueMember = "id";
                    comboBox5.DisplayMember = "name";
                    comboBox5.DataSource = DataTableParser.
                        Parse(requester.Select(new RequestInnerFilter()
                        {
                            IdRequest = (int)comboBox1.SelectedValue
                        }));
                }
            }
            catch
            {

            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var requester = new Requester<RequestInner,
                RequestInnerFilter>(Param.Serv.host))
            {
                textBox3.Text = requester.Select(new RequestInnerFilter()
                {
                    Id = (int)comboBox5.SelectedValue
                })[0].count.ToString();
                flowLayoutPanel1.Controls.Clear();
                for(int i = 0;i<int.Parse(textBox3.Text);i++)
                {
                    flowLayoutPanel1.Controls.Add(new TextBox()
                    {
                        Width = flowLayoutPanel1.Width-10
                    });
                }
            }
        }

        private void Zak_Load(object sender, EventArgs e)
        {

        }
    }
}
