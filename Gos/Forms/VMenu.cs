using Gos.Forms.Generic;
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

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            button1.Width = flowLayoutPanel1.Width-30;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var zak = new Zak();
            zak.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var ro = new ResObj();
            ro.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var ro = new History();
            ro.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var ro = new Dump();
            ro.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var t = new PathTester();
            t.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var str = "Для формирования ТЗ необходимо:\n" +
                "1.Создать контекст в пункте \"Контексты\"\n" +
                "2.Добавить пути до информации для созданного контекста в " +
                "пункте \"Тестирование путей\" или \"Пути\"(Небезопасно)\n" +
                "3.Добавить опции для обработки информации для созданного контекста в пункте \"Опции\"\n" +
                "4.Создать набор данных для обучения в пунке \"Наборы данных\"\n" +
                "5.Заполнить созданный набор данных в пункте " +
                "\"Загрузка данных с сайта\"(Автоматически) или \"Данные\"(Вручную)\n" +
                "5.1.Если данные были заполнены Автоматичеки в пункте \"Данные\" " +
                "указать признаки\n" +
                "6.Обучить инструмент в пункте \"Обучить\"\n" +
                "7.Создать контекст поиска в пункте \"Контексты поиска\"\n" +
                "8.Заполнить созданный контекст в пунке \"Содержимое контекстов поиска\"\n" +
                "9.Связать контекст с обучением в пункте \"Контекстное обучение\"\n" +
                "10.Связать контекстное обучение с контекстом поиска в пункте \"Связь контекстов\"\n" +
                "11.В пункте \"Создать ТЗ\" выберите:\n" +
                "11.1.Контекстное обучение\n" +
                "11.2.Искомый обьект\n" +
                "11.3.Требуемые характеристики для искомого обьекта\n" +
                "11.4.Нажать кнопку \"Найти\"(Займет определенное время от 5 до 30 минут)\n" +
                "11.5.Выбрать подходящий обьект(если в контексте" +
                " поиска несколько наименований то начните с 11.2)" +
                "11.6.Нажать кнопку \"Сформировать\"\n" +
                "11.7.В открытом окне создайте группы с обоснованием и перенести в них характеристики\n" +
                "11.8.Укажите количество и добавьте в очередь, " +
                "если требуется добавить еще один обьект не закрывая окно, перейдите к пункту 11.1\n" +
                "11.9 Сформируйте ТЗ и подтвердите его";
            var info = new Info(str);
            info.ShowDialog();
        }

        public void VMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                var str = "Для формирования ТЗ необходимо:\n" +
                "1.Создать контекст в пункте \"Контексты\"\n" +
                "2.Добавить пути до информации для созданного контекста в " +
                "пункте \"Тестирование путей\" или \"Пути\"(Небезопасно)\n" +
                "3.Добавить опции для обработки информации для созданного контекста в пункте \"Опции\"\n" +
                "4.Создать набор данных для обучения в пунке \"Наборы данных\"\n" +
                "5.Заполнить созданный набор данных в пункте " +
                "\"Загрузка данных с сайта\"(Автоматически) или \"Данные\"(Вручную)\n" +
                "5.1.Если данные были заполнены Автоматичеки в пункте \"Данные\" " +
                "укажите признаки\n" +
                "6.Обучите инструмент в пункте \"Обучить\"\n" +
                "7.Создать контекст поиска в пункте \"Контексты поиска\"\n" +
                "8.Заполнить созданный контекст в пунке \"Содержимое контекстов поиска\"\n" +
                "9.Связать контекст с обучением в пункте \"Контекстное обучение\"\n" +
                "10.Связать контекстное обучение с контекстом поиска в пункте \"Связь контекстов\"\n" +
                "11.В пункте \"Создать ТЗ\" выберите:\n" +
                "11.1.Контекстное обучение\n" +
                "11.2.Искомый обьект\n" +
                "11.3.Требуемые характеристики для искомого обьекта\n" +
                "11.4.Нажать кнопку \"Найти\"(Займет определенное время от 5 до 30 минут)\n" +
                "11.5.Выбрать подходящий обьект(если в контексте" +
                " поиска несколько наименований то начните с 11.2)" +
                "11.6.Нажать кнопку \"Сформировать\"\n" +
                "11.7.В открытом окне создайте группы с обоснованием и перенести в них характеристики\n" +
                "11.8.Укажите количество и добавьте в очередь, " +
                "если требуется добавить еще один обьект не закрывая окно, перейдите к пункту 11.1\n" +
                "11.9 Сформируйте ТЗ и подтвердите его";
                var info = new Info(str);
                info.ShowDialog();
            }
        }
    }
}
