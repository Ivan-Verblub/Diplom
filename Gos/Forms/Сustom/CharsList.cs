using Gos.Server.Models.Requesting;
using Gos.Server.Models.Table;
using Gos.Server;
using Server.Controllers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Gos.Server.Models.Filter;
using System.Threading;

namespace Gos.Forms.Сustom
{
    public partial class CharsList : Form
    {
        private List<Final> _finals = new List<Final>();
        private int _id;
        private string _name;
        public CharsList(int id)
        {
            InitializeComponent();
            _id = id;
        }
        public void Create(Chars[] chars,string name)
        {
            Clear();
            _name = name;
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
            var tab = new TabPage()
            {
                Text = textBox2.Text
            };
            var flow = new FlowLayoutPanel()
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                AllowDrop = true                
            };
            var lab = new Label()
            {
                Text = textBox1.Text,
                AutoSize = false,
                Width = flow.Width-10,
            };
            flow.Resize += (o, ea) =>
            {
                lab.Width = flow.Width-10;
            };
            flow.Controls.Add(lab);
            flow.DragDrop += (o,ea) =>
            {
                flow.Controls.Add((CharList)ea.Data.GetData(ea.Data.GetFormats()[0]));
                try
                {
                    ((CharList)ea.Data.GetData(typeof(CharList))).Resize();
                }
                catch
                {

                }
            };
            flow.DragEnter += (o, ea) =>
            {
                ea.Effect = DragDropEffects.Copy;
                
            };
            tab.Controls.Add(flow);
            tabControl1.TabPages.Add(tab);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            flowLayoutPanel1.Controls.Add((CharList)e.Data.GetData(e.Data.GetFormats()[0]));
            try
            {
                ((CharList)e.Data.GetData(typeof(CharList))).Resize();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(tabControl1.TabIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
            if (untiled.ShowDialog() == DialogResult.OK)
            {
                CreateDoc(_finals);
            }
        }
        private void Clear()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                tabControl1.TabPages.Clear();
            }
            catch { }
        }

        private void CreateDoc(List<Final> finals)
        {
            try
            {
                var app = new Word.Application();
                app.Visible = false;
                object missing = Missing.Value;
                var doc = app.Documents.Add(ref missing, ref missing,
                    ref missing, ref missing);
                Thread.Sleep(5000);
                doc.PageSetup.Orientation =
                    Word.WdOrientation.wdOrientLandscape;
                doc.PageSetup.LeftMargin =
                doc.PageSetup.RightMargin =
                doc.PageSetup.TopMargin =
                doc.PageSetup.BottomMargin = 2*28.357f;
                var par1 = doc.Paragraphs.Add();
                var range = par1.Range;
                range.Text = "РАЗДЕЛ 3.  ОПИСАНИЕ ОБЪЕКТА ЗАКУПКИ\n\n" +
                    "3.1. Требования к техническим, функциональным " +
                    "характеристикам и эксплуатационным характеристикам " +
                    "(потребительским свойствам) товара (работ, услуг), " +
                    "к размерам товара, используемым при выполнении " +
                    "работ (оказании услуг)\n\n";
                range.Font.Name = "Times New Roman";
                range.Font.Size = 12;
                range.Font.Bold = 1;
                range.Paragraphs.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                var par2 = doc.Paragraphs.Add();
                var nextRange = par2.Range;
                nextRange.Text += "Таблица №1\n\n";
                nextRange.Font.Name = "Times New Roman";
                nextRange.Font.Size = 11;
                nextRange.Font.Italic = 1;
                nextRange.Font.Bold = 0;
                nextRange.Paragraphs.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphRight;
                nextRange.InsertParagraphAfter();
                var par3 = doc.Paragraphs.Add();
                var table = doc.Tables.Add(par3.Range, 4, 7);
                table.Rows[1].Cells[1].Range.Text = "№\nп/п";
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
                for (int j = 1; j<3; j++)
                    for (int i = 1; i<8; i++)
                    {
                        table.Rows[j].Cells[i].Range.Font.Name = "Times New Roman";
                        table.Rows[j].Cells[i].Range.Font.Size = 8;
                        table.Rows[j].Cells[i].Range.Paragraphs.Alignment =
                            Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        table.Rows[j].Cells[i].VerticalAlignment =
                            Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    }
                table.Rows[1].HeadingFormat = -1;
                table.Rows[2].HeadingFormat = -1;
                table.ApplyStyleHeadingRows = true;

                int indexRow = 3;
                bool firstA;
                int index = 1;
                foreach (var final in finals)
                {
                    var firstF = true;
                    foreach (var about in final.Abouts)
                    {
                        firstA = true;
                        foreach (var result in about.Results)
                        {
                            if (firstF)
                            {
                                table.Rows[indexRow].Cells[1].Range.Text = index.ToString();
                                table.Rows[indexRow].Cells[1].Range.Font.Name = "Times New Roman";
                                table.Rows[indexRow].Cells[1].Range.Font.Size = 10;
                                table.Rows[indexRow].Cells[1].Range.Paragraphs.Alignment =
                                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                table.Rows[indexRow].Cells[1].VerticalAlignment =
                                    Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                table.Rows[indexRow].Cells[2].Range.Text = final.Name;
                                table.Rows[indexRow].Cells[2].Range.Font.Name = "Times New Roman";
                                table.Rows[indexRow].Cells[2].Range.Font.Size = 12;
                                table.Rows[indexRow].Cells[2].Range.Paragraphs.Alignment =
                                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                table.Rows[indexRow].Cells[2].VerticalAlignment =
                                    Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                index++;
                                firstF = false;
                            }
                            table.Rows[indexRow].Cells[4].Range.Text = result.Title;
                            table.Rows[indexRow].Cells[4].Range.Font.Name = "Times New Roman";
                            table.Rows[indexRow].Cells[4].Range.Font.Size = 12;
                            table.Rows[indexRow].Cells[4].Range.Paragraphs.Alignment =
                                Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            table.Rows[indexRow].Cells[4].VerticalAlignment =
                                Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                            table.Rows[indexRow].Cells[5].Range.Text = result.Value;
                            table.Rows[indexRow].Cells[5].Range.Font.Name = "Times New Roman";
                            table.Rows[indexRow].Cells[5].Range.Font.Size = 11;
                            table.Rows[indexRow].Cells[5].Range.Paragraphs.Alignment =
                                Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            table.Rows[indexRow].Cells[5].VerticalAlignment =
                                Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                            table.Rows[indexRow].Cells[6].Range.Text = result.Instruction;
                            table.Rows[indexRow].Cells[6].Range.Font.Name = "Times New Roman";
                            table.Rows[indexRow].Cells[6].Range.Font.Size = 10;
                            table.Rows[indexRow].Cells[6].Range.Paragraphs.Alignment =
                                Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            table.Rows[indexRow].Cells[6].VerticalAlignment =
                                Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            table.Rows[indexRow].Cells[6].Range.Font.Italic = 1;
                            if (firstA)
                            {
                                table.Rows[indexRow].Cells[7].Range.Text = about.Info;
                                table.Rows[indexRow].Cells[7].Range.Font.Name = "Times New Roman";
                                table.Rows[indexRow].Cells[7].Range.Font.Size = 12;
                                table.Rows[indexRow].Cells[7].Range.Paragraphs.Alignment =
                                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                table.Rows[indexRow].Cells[7].VerticalAlignment =
                                    Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                firstA = false;
                            }
                            table.Rows.Add(table.Rows[indexRow+1]);
                            indexRow++;
                        }
                    }
                }
                #region line
                table.Columns[1].Width = 1f*28.357f;
                table.Columns[1].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[1].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[2].Width = 3.42f*28.357f;
                table.Columns[2].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[2].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[3].Width = 0.75f*28.357f;
                table.Columns[3].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[3].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[4].Width = 5.75f*28.357f;
                table.Columns[4].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[4].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[5].Width = 5*28.357f;
                table.Columns[5].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[5].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[6].Width = 6.25f*28.357f;
                table.Columns[6].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[6].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[7].Width = 4.5f*28.357f;
                table.Columns[7].Borders.InsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
                table.Columns[7].Borders.OutsideLineStyle =
                    Word.WdLineStyle.wdLineStyleSingle;
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
                table.Rows[table.Rows.Count].Delete();
                table.Rows[table.Rows.Count].Delete();
                int indexRows = 3;
                foreach (var final in finals)
                {
                    int buff = 0;
                    foreach (var about in final.Abouts)
                    {
                        buff += about.Results.Count;
                    }
                    table.Cell(indexRows, 1).Merge(
                        table.Cell(indexRows+buff-1, 1));
                    table.Cell(indexRows, 2).Merge(
                        table.Cell(indexRows+buff-1, 2));
                    table.Cell(indexRows, 3).Merge(
                        table.Cell(indexRows+buff-1, 3));
                    indexRows += buff;
                }
                indexRows = 3;
                foreach (var final in finals)
                {
                    foreach (var about in final.Abouts)
                    {
                        table.Cell(indexRows, 7).Merge(
                            table.Cell(indexRows+about.Results.Count-1, 7));
                        indexRows += about.Results.Count;
                    }
                }
                doc.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakNextPage);
                var par4 = doc.Paragraphs.Add();
                par4.Range.PageSetup.Orientation =
                    Word.WdOrientation.wdOrientPortrait;
                par1.Range.Font.Name = "Times New Roman";
                par1.Range.Font.Size = 11;
                par1.Range.Text = @"3.2. Требования к качеству и безопасности товара, оказания услуг, выполнения работ
3.2.1. Поставщик гарантирует заказчику, что товар, поставляемый в рамках Контракта, является новым (не был в употреблении, использовании, не прошел ремонт, в т.ч. восстановление, замену составных частей, восстановление потребительских свойств), свободным от любых притязаний третьих лиц, не находится под запретом (арестом), в залоге, или под иным обременением. В противном случае он обязан возместить Заказчику все убытки, причиненные изъятием товара. 
Товар должен быть серийного производства, не ранее 2019 года выпуска. 
3.2.2. Товар может происходить из Российской Федерации или любого другого государства, за исключением товара, в отношении которого Правительством Российской Федерации установлены запреты или ограничения.
3.2.3. Товар должен быть поставлен надлежащего качества в соответствии с сертификатом соответствия системы обязательной сертификации Госстандарта России или декларацией о соответствии, документами об оценке (подтверждении) соответствия обязательным требованиям, установленным нормативными правовыми актами Таможенного союза или законодательством государства - члена Таможенного союза на каждое наименование товара, заверенные установленным образом.
3.2.4. Вся сопроводительная информация о поставляемом товаре должна иметь информацию на русском языке, перевод на русский язык. Товар должен иметь маркировочные ярлыки (или этикетки) с указанием полной информации, предусмотренной законами и иными нормативно-правовыми актами РФ, подтверждающей качество поставляемого товара  и его  соответствие требованиям законодательства РФ. Маркировка должна быть выполнена на русском языке и содержать: наименование товара, наименование фирмы изготовителя, юридический адрес изготовителя, дату выпуска и гарантийный срок хранения. Маркировка должна обеспечивать полную и однозначную идентификацию каждой единицы товара при ее приемке от Поставщика.
3.2.5. Товар должен соответствовать требованиям ГОСТ, ТУ и иных документов, применяемых для данного вида товара. 
Поставщик гарантирует соответствие качества и безопасности товара требованиям Контракта, а также его соответствие техническими регламентам, принятым в соответствии с законодательством Российской Федерации о техническом регулировании, документам, разрабатываемым и применяемым в национальной системе стандартизации, принятым в соответствии с законодательством Российской Федерации о стандартизации, которые являются обязательными в отношении данного вида товара в соответствии с законодательными и подзаконными актами, действующими на территории Российской Федерации на дату поставки товара.
3.2.6. При возникновении сомнений в качестве, эффективности и безопасности товара, Заказчик может провести его дополнительную (внешнюю) экспертизу. При получении заключения экспертизы о несоответствии товара качеству эффективности и безопасности, принятому для данного вида товара, расходы, связанные с её проведением, возмещаются Поставщиком в бесспорном порядке в полном объеме. 
3.2.7. При обнаружении некачественного товара вызов представителя Поставщика обязателен
3.2.8.  Товар должен быть поставлен в заводской упаковке, с соблюдением требований, установленных эксплуатационной документацией на оборудование транспортом, обеспечивающим сохранность товара от загрязнения, внешних воздействий и любого вида повреждений при транспортировке, погрузочно-разгрузочных работах и хранении (при необходимости иметь светонепроницаемую защиту, и упакованы в тару, которая предохраняет от различного рода повреждений, проникновения в неё избыточной влажности), обеспечивающих его дальнейшее качественное и безопасное применение.  
При несоблюдении данных условий весь товар разгрузке по адресу Заказчика не подлежит. 
 Упаковка товара возврату поставщику не подлежит, за исключением случаев, когда по завершении приемки товара упаковка не требуется заказчику и подлежит уборке и вывозу поставщиком.
3.2.9. Поставщик поставляет товар свободный от любых прав третьих лиц, в противном случае он обязан возместить Заказчику все убытки, причиненные изъятием товара.
3.2.10. Гарантия на поставляемый товар – не менее 12 месяцев. 
3.2.11. Поставщик поставляет системный блок в сборе. 
3.2.12. Поставка товара с механическими повреждениями не допускается. 
      3.2.13.  Поставщик должен осуществить замену некачественного товара на качественный, а также  несоответствующего спецификации,  в течение 3 (трех) рабочих дней с момента поступления претензии от Заказчика, переданной посредством факсимильного или электронного сообщения с последующим предоставлением почтовой или нарочной связью
";
                #endregion
                try
                {
                    doc.SaveAs(untiled.FileName+".docx", Word.WdSaveFormat.wdFormatDocumentDefault);
                    doc.Close();
                    Process.Start(untiled.FileName+".docx");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                MessageBox.Show("Заполните количество",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            var final = new Final();
            final.Name = _name;
            final.Count = int.Parse(textBox3.Text);
            final.Abouts = new List<About>();
            foreach (TabPage tab in tabControl1.TabPages)
            {
                var about = new About();
                about.Results = new List<Result>();
                foreach (Control item in tab.Controls[0].Controls)
                {
                    if (item.GetType() == typeof(Label))
                    {
                        about.Info = item.Text;
                    }
                    else if (item.GetType() == typeof(CharList))
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
                                value = '\u003e'+((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "конкретное (единственное) значение " +
                                    "показателя, которое должно быть " +
                                    "равно или  больше установленного " +
                                    $"заказчиком значения. Знак «{'\u003e'}»  " +
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
                                value = '\u003c'+((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "конкретное (единственное) значение " +
                                    "показателя, которое должно быть " +
                                    "равно или  больше установленного " +
                                    $"заказчиком значения. Знак «{'\u003c'}»  " +
                                    "не должен использоваться участником.";
                                break;
                            case 4:
                                value = '\u2264'+((CharList)item).Value;
                                instruction = "Участник закупки указывает " +
                                    "конкретное (единственное) значение " +
                                    "показателя, которое должно быть " +
                                    "равно или  больше установленного " +
                                    $"заказчиком значения. Знак «{'\u2264'}»  " +
                                    "не должен использоваться участником.";
                                break;
                            case 5:
                                value = '\u003e'+" "+((CharList)item).Start
                                    +" "+'\u003c'+" "+((CharList)item).End;
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
            _finals.Add(final);
            Clear();
            label4.Text = _finals.Count().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (File.Exists(untiled.FileName+".docx"))
            {
                byte[] bytes;
                try
                {
                    bytes = File.ReadAllBytes(untiled.FileName+".docx");
                }
                catch
                {
                    MessageBox.Show(
                    "Файл используется",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                using (var requester = new Requester<Request,
                    RequestFilter>(Param.Serv.host))
                {
                    var res = requester.Select();
                    int idReq = res == null ? 0 : res.Count();
                    var request = new Request()
                    {
                        id = idReq,
                        name = textBox4.Text,
                        file = Convert.ToBase64String(bytes),
                        idLearning = _id
                    };
                    requester.Insert(request);
                    using (var requester2 = new Requester<RequestInner,
                        RequestInnerFilter>(Param.Serv.host))
                    {
                        foreach (var final in _finals)
                        {
                            var res2 = requester2.Select();
                            int idReqInner = res2 == null ? 0 : res.Count();
                            requester2.Insert(new RequestInner()
                            {
                                id = idReqInner,
                                name = final.Name,
                                count = final.Count,
                                cost = final.Cost,
                                idRequest = idReq,
                                idCat = null
                            });
                            using (var requester3 = new Requester<CharListRequest,
                                CharListRequestFilter>(Param.Serv.host))
                            {
                                foreach (var about in final.Abouts)
                                {
                                    foreach (var result in about.Results)
                                    {
                                        requester3.Insert(new CharListRequest()
                                        {
                                            idRequest = idReqInner,
                                            name = result.Title,
                                            value = result.Value
                                        });
                                    }
                                }
                            }
                        }

                    }

                }
                Dispose();
            }
            else
            {
                MessageBox.Show(
                    "Файл пропал",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count != 0)
                for(int i = 0;i<flowLayoutPanel1.Controls.Count;i++)
                {
                    Control element = flowLayoutPanel1.Controls[i];
                    if (element.GetType() == typeof(CharList))
                    {
                        if (((CharList)element).Selected)
                        {
                            ((CharList)element).SSize();
                            tabControl1.SelectedTab.
                                Controls[0].Controls.Add(element);
                            i--;
                            ((CharList)element).Resize();
                        }
                    }
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count != 0)
                for (int i = 0; i<tabControl1.SelectedTab.Controls[0].Controls.Count; i++)
                {
                    Control element = tabControl1.
                        SelectedTab.Controls[0].Controls[i];
                    if (element.GetType() == typeof(CharList))
                    {
                        if (((CharList)element).Selected)
                        {
                            ((CharList)element).SSize();
                            flowLayoutPanel1.Controls.Add(element);
                            i--;
                            ((CharList)element).Resize();
                        }
                    }
                }
        }
    }
}
