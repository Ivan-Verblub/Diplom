using Gos.Forms.Сustom;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms
{
    public partial class VMenu : Form
    {        
        public delegate void Deleg(Type filter, Type table);
        public event Deleg Click; 
        public VMenu()
        {
            InitializeComponent();
        }

        private void VMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Click(typeof(Scat),typeof(ScatFilter));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Click(typeof(SLocation), typeof(SLocationFilter));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Click(typeof(SStatus), typeof(SStatusFilter));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Click(typeof(Context), typeof(ContextFilter));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Click(typeof(Paths), typeof(PathsFilter));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Click(typeof(Options), typeof(OptionsFilter));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Click(typeof(SearchContext), typeof(SearchContextFilter));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Click(typeof(SearchNames), typeof(SearchNamesFilter));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Click(typeof(DataSet), typeof(DataSetFilter));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Click(typeof(DatasTable), typeof(DatasFilter));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Click(typeof(LearningHistory), typeof(LearningHistoryFilter));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Click(typeof(Contextable), typeof(ContextableFilter));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Click(typeof(Contexts), typeof(ContextsFilter));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Click(typeof(Actual), typeof(ActualFilter));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Click(typeof(Request), typeof(RequestFilter));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Click(typeof(RequestInner), typeof(RequestInnerFilter));
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Click(typeof(CharListRequest), typeof(CharListRequestFilter));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Click(typeof(Objects), typeof(ObjectsFilter));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Click(typeof(CharListObjects), typeof(CharListObjectsFilter));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Click(typeof(ObjectsHistory), typeof(ObjectsHistoryFilter));
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var lDF = new LoadDataF();
            lDF.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var learn = new Learn();
            learn.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var ct = new CreateTech();
            ct.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var lDF = new LoadDataDefine();
            lDF.ShowDialog();
        }
    }
}
