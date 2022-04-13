using Aspose.Words;
using Gos.Server.Models.Requesting;
using Server.Controllers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Gos.Forms.Сustom
{
    public partial class CharsList : Form
    {
        public CharsList()
        {
            InitializeComponent();
        }
        public void Create(Chars[] chars)
        {
            foreach (var c in chars)
            {
                var cl = new CharList();
                cl.Title = c.name;
                cl.Value = c.value;
                cl.Index = 0;
                ControlExtension.Draggable(cl, true);
                flowLayoutPanel1.Controls.Add(cl);
            }
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tab = new TabPage();
            var flow = new FlowLayoutPanel()
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                AllowDrop = true,
                Text = textBox2.Text
            };
            flow.Controls.Add(new Label()
            {
                Text = textBox1.Text
            });
            flow.DragDrop += (o,ea) =>
            {
                flow.Controls.Add((CharList)ea.Data.GetData(ea.Data.GetFormats()[0]));
            };
            flow.DragEnter += (o, ea) =>
            {
                ea.Effect = DragDropEffects.Copy;
            };
            tab.Controls.Add(flow);
            tabControl1.TabPages.Add(tab);
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            flowLayoutPanel1.Controls.Add((CharList)e.Data.GetData(e.Data.GetFormats()[0]));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(tabControl1.TabIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var final = new Final();
            final.Name = "";
            final.Abouts = new List<About>();
            foreach(TabPage tab in tabControl1.TabPages)
            {
                var about = new About();
                about.Results = new List<Result>();
                foreach(Control item in tab.Controls[0].Controls)
                {
                    if(item.GetType() == typeof(Label))
                    {
                        about.Info = item.Text;
                    }
                    else if(item.GetType() == typeof(CharList))
                    {
                        var result = new Result();
                        result.Title = ((CharList)item).Title;
                        string value = "";
                        string instruction = "";
                        switch (((CharList)item).Index)
                        {
                            case 0:
                                value = ((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "(не меняя формулировок) то значение " +
                                    "неизменного показателя, которое " +
                                    "установил заказчик.";
                                break;
                            case 1:
                                value = '\uf03e'+((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "конкретное (единственное) значение " +
                                    "показателя, которое должно быть " +
                                    "равно или  больше установленного " +
                                    $"заказчиком значения. Знак «{'\uf03e'}»  " +
                                    "не должен использоваться участником.";
                                break;
                            case 2:
                                value = '\u2265'+((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "конкретное (единственное) значение " +
                                    "показателя, которое должно быть " +
                                    "равно или  больше установленного " +
                                    $"заказчиком значения. Знак «{'\u2265'}»  " +
                                    "не должен использоваться участником.";
                                break;
                            case 3:
                                value = '\uf03c'+((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "конкретное (единственное) значение " +
                                    "показателя, которое должно быть " +
                                    "равно или  больше установленного " +
                                    $"заказчиком значения. Знак «{'\uf03c'}»  " +
                                    "не должен использоваться участником.";
                                break;
                            case 4:
                                value = '\uf0a3'+((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "конкретное (единственное) значение " +
                                    "показателя, которое должно быть " +
                                    "равно или  больше установленного " +
                                    $"заказчиком значения. Знак «{'\uf0a3'}»  " +
                                    "не должен использоваться участником.";
                                break;
                            case 5:
                                value = '\uf03e'+" "+((CharList)item).Start
                                    +" "+'\uf03c'+" "+((CharList)item).End;
                                instruction = "Участник закупки указывает" +
                                    " конкретное (единственное) значение" +
                                    " показателя из заданного диапазона";
                                break;

                        }
                        result.Value = value;
                        result.Instruction = instruction;
                        about.Results.Add(result);
                    }
                }
                final.Abouts.Add(about);
            }
            CreateDoc(final);
        }
        private void CreateDoc(Final final)
        {
            var app = new Word.Application();
            app.Visible = true;
            object missing = Missing.Value;
            var doc = app.Documents.Add(ref missing, ref missing, 
                ref missing, ref missing);
            doc.PageSetup.Orientation = 
                Word.WdOrientation.wdOrientLandscape;
            var range = doc.Range();
            var table = doc.Tables.Add(range,4,7);
            table.Range.Borders.OutsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
            table.Range.Borders.InsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
            table.Rows[1].Range.Borders.OutsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
            table.Rows[1].Range.Borders.InsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
            table.Rows[2].Range.Borders.OutsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
            table.Rows[2].Range.Borders.InsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;
            table.Rows[1].Cells[1].Range.Text = "№п/п";
            table.Rows[1].Cells[2].Range.Text = "Наименование товара" +
                "(товарный знак(его словесное " +
                "обозначение, страну происхождения)";
            table.Rows[1].Cells[3].Range.Text = "-";
            table.Rows[1].Cells[4].Range.Text = "Показатель " +
                "(характеристика)товара";
            table.Rows[1].Cells[5].Range.Text = "Значение показателя " +
                "(характеристики) товара, или " +
                "эквивалентности предлагаемого к " +
                "поставке товара, позволяющего " +
                "определить соответствие " +
                "потребностям заказчика";
            table.Rows[1].Cells[6].Range.Text = "Инструкция для " +
                "участника закупки";
            table.Rows[1].Cells[7].Range.Text = "Обоснование необходимости " +
                "использования характеристик, показателей, " +
                "требований, условных обозначений и " +
                "терминологии при описании объекта закупки" +
                " (в соответствии с п. 2 ч. 1 ст. 33 Закона)";
            for (int i = 1; i<8; i++)
            {
                table.Rows[2].Cells[i].Range.Text = i.ToString();
            }
            table.Rows[1].HeadingFormat = -1;
            table.Rows[2].HeadingFormat = -1;
            table.ApplyStyleHeadingRows = true;
            
            int indexRow = 3;
            var firstF = true;
            bool firstA;
            int index = 1;
            foreach (var item in final.Abouts)
            {
                firstA = true;
                foreach (var ab in item.Results)
                {
                    if (firstF)
                    {
                        table.Rows[indexRow].Cells[1].Range.Text = index.ToString();
                        table.Rows[indexRow].Cells[2].Range.Text = final.Name;
                        index++;
                    }
                    table.Rows[indexRow].Cells[4].Range.Text = ab.Title;
                    table.Rows[indexRow].Cells[5].Range.Text = ab.Value;
                    table.Rows[indexRow].Cells[6].Range.Text = ab.Instruction;
                    if (firstA)
                    {
                        table.Rows[indexRow].Cells[7].Range.Text = item.Info;
                    }
                    table.Rows.Add(table.Rows[indexRow+1]);
                    indexRow++;
                }
            }
            try
            {
                doc.Close();
                Process.Start("test.docx");
            }
            catch { }
        }
    }
}
