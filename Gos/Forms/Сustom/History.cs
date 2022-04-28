using Gos.Server;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms.Сustom
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            using (var requester = new Requester<Objects,
                        ObjectsFilter>(Param.Serv.host))
            {
                comboBox1.DataSource = 
                    DataTableParser.Parse(requester.Select());
                comboBox1.ValueMember = "invNumber";
                comboBox1.DisplayMember = "name";
            }
        }

        private void History_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var p = new ExcelPackage())
                {
                    var ws = p.Workbook.Worksheets.Add("MySheet");
                    ws.Cells.Style.Font.Name = "Calibri";
                    ws.Cells.Style.Font.Size = 11;
                    ws.Cells["C1"].Value = "СВОДКА №";
                    ws.Cells["C1"].Style.Font.Size = 14;
                    ws.Cells["C1"].Style.Font.Bold = true;
                    ws.Cells["D1"].Value = textBox1.Text;
                    ws.Cells["D1"].Style.Font.Size = 14;
                    ws.Cells["D1"].Style.Border.Bottom.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    ws.Cells["D1"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    ws.Cells["A2"].Value = "ИСТОРИИ ЗАКУПЛЕННОГО ОБЪЕКТА";
                    ws.Cells["A2"].Style.Font.Size = 14;
                    ws.Cells["A2"].Style.Font.Bold = true;
                    ws.Cells["A2"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells["A2:D2"].Merge = true;
                    ws.Cells["F2"].Value = "Дата:";
                    ws.Cells["G2"].Value = DateTime.Now.ToString("dd.MM.yyyy");
                    ws.Cells["G2"].Style.Border.Bottom.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    ws.Cells["G2"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells["B4"].Value =
                        $"От {dateTimePicker1.Value:dd.MM.yyyy} " +
                        $"До {dateTimePicker2.Value:dd.MM.yyyy}";
                    ws.Cells["B4:D4"].Merge = true;
                    ws.Cells["B4:D4"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells["B4:D4"].Style.Font.Bold = true;
                    ws.Cells["B5"].Value = "Учереждение";
                    ws.Cells["C5"].Value = "ГОБУЗ \"МООД\"";
                    ws.Cells["C5:D5"].Style.Border.Bottom.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                    ws.Cells["B6"].Value = "Сформировано для:";
                    using (var requester = new Requester<Objects,
                            ObjectsFilter>(Param.Serv.host))
                    {
                        var obj = requester.Select(new ObjectsFilter()
                        {
                            InvNumber = comboBox1.SelectedValue.ToString()
                        })[0];
                        ws.Cells["B7"].Value = "Наименование обьекта";
                        ws.Cells["B7"].Style.Font.Bold = true;
                        ws.Cells["B7"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        ws.Cells["C7:G7"].Style.Border.Bottom.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells["C7"].Value = obj.name;

                        ws.Cells["B8"].Value = "Инвентарный номер";
                        ws.Cells["B8"].Style.Font.Bold = true;
                        ws.Cells["B8"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        ws.Cells["C8:G8"].Style.Border.Bottom.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells["C8"].Value = obj.invNumber;

                        ws.Cells["B9"].Value = "Текущее расположение";
                        ws.Cells["B9"].Style.Font.Bold = true;
                        ws.Cells["B9"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        ws.Cells["C9:G9"].Style.Border.Bottom.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells["C9"].Value = obj.location;

                        ws.Cells["B10"].Value = "Текущий статус";
                        ws.Cells["B10"].Style.Font.Bold = true;
                        ws.Cells["B10"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        ws.Cells["C10:G10"].Style.Border.Bottom.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells["C10"].Value = obj.status;

                        ws.Cells["B11"].Value = "Стоимость(руб)";
                        ws.Cells["B11"].Style.Font.Bold = true;
                        ws.Cells["B11"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        ws.Cells["C11:G11"].Style.Border.Bottom.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells["C11"].Value = obj.cost;

                        ws.Cells["B12"].Value = "Категория";
                        ws.Cells["B12"].Style.Font.Bold = true;
                        ws.Cells["B12"].Style.HorizontalAlignment =
                            OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        ws.Cells["C12:G12"].Style.Border.Bottom.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells["C12"].Value = obj.cat;
                    }
                    ws.Cells["A13"].Value = "№";
                    ws.Cells["A14"].Value = "1";
                    ws.Cells["B13"].Value = "Комментраий о изменении";
                    ws.Cells["B14"].Value = "2";
                    ws.Cells["C13"].Value = "Статус";
                    ws.Cells["C14"].Value = "3";
                    ws.Cells["C13:D13"].Merge = true;
                    ws.Cells["C14:D14"].Merge = true;
                    ws.Cells["E13"].Value = "Расположение";
                    ws.Cells["E14"].Value = "4";
                    ws.Cells["E13:F13"].Merge = true;
                    ws.Cells["E14:F14"].Merge = true;
                    ws.Cells["G13"].Value = "Дата изменения";
                    ws.Cells["G14"].Value = "5";
                    ws.Cells["A13:G14"].Style.Font.Bold = true;
                    ws.Cells["A13:G14"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells["A13:G14"].Style.VerticalAlignment =
                        OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells["A13:G14"].Style.Border.Bottom.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    ws.Cells["A13:G14"].Style.Border.Left.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    ws.Cells["A13:G14"].Style.Border.Top.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    ws.Cells["A13:G14"].Style.Border.Right.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    List<ObjectsHistory> objects = new List<ObjectsHistory>();
                    using (var requester = new Requester<ObjectsHistory,
                        ObjectsHistoryFilter>(Param.Serv.host))
                    {
                        var hists = requester.Select(new ObjectsHistoryFilter()
                        {
                            InvNumber = comboBox1.SelectedValue.ToString()
                        });
                        if (hists != null)
                        {
                            var histsOrder = hists.OrderBy(x => x.date).ToArray();
                            foreach (var hist in histsOrder)
                            {
                                if ((hist.date>dateTimePicker1.Value)&&
                                    (hist.date<dateTimePicker2.Value))
                                {
                                    objects.Add(hist);
                                }
                            }
                        }
                    }
                    int row = 15;
                    int index = 1;
                    foreach (var obj in objects)
                    {
                        ws.Cells[$"A{row}"].Value = index.ToString();
                        ws.Cells[$"B{row}"].Value = obj.comment;
                        ws.Cells[$"C{row}"].Value = obj.status;
                        ws.Cells[$"C{row}:D{row}"].Merge = true;
                        ws.Cells[$"E{row}"].Value = obj.location;
                        ws.Cells[$"E{row}:F{row}"].Merge = true;
                        ws.Cells[$"G{row}"].Value = obj.date;
                        ws.Row(row).Style.WrapText = true;
                        ws.Cells[$"A{row}:G{row}"].Style.Border.Bottom.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells[$"A{row}:G{row}"].Style.Border.Left.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells[$"A{row}:G{row}"].Style.Border.Top.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        ws.Cells[$"A{row}:G{row}"].Style.Border.Right.Style =
                            OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        row++;
                        index++;
                    }
                    row += 4;
                    ws.Cells[$"B{row}"].Value = "Сдал";
                    ws.Cells[$"B{row}:C{row}"].Style.Border.Bottom.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    row++;
                    ws.Row(row).Height = 12;
                    ws.Cells[$"B{row}"].Value = "(должность)";
                    ws.Cells[$"B{row}"].Style.Font.Size = 8;
                    ws.Cells[$"B{row}"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[$"C{row}"].Value = "(подпись)";
                    ws.Cells[$"C{row}"].Style.Font.Size = 8;
                    ws.Cells[$"C{row}"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    row++;
                    ws.Cells[$"B{row}"].Value = DateTime.Now.ToString("dd.MM.yyyy");
                    row += 2;
                    ws.Cells[$"B{row}"].Value = "Принял";
                    ws.Cells[$"B{row}:C{row}"].Style.Border.Bottom.Style =
                        OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    row++;
                    ws.Row(row).Height = 12;
                    ws.Cells[$"B{row}"].Value = "(должность)";
                    ws.Cells[$"B{row}"].Style.Font.Size = 8;
                    ws.Cells[$"B{row}"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[$"C{row}"].Value = "(подпись)";
                    ws.Cells[$"C{row}"].Style.Font.Size = 8;
                    ws.Cells[$"C{row}"].Style.HorizontalAlignment =
                        OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Row(13).Style.WrapText = true;
                    ws.Column(1).Width = 2.14 + 0.8;
                    ws.Column(2).Width = 29.43+ 0.71;
                    ws.Column(3).Width = 14.14+ 0.71;
                    ws.Column(4).Width = 13.17+ 1.5;
                    ws.Column(5).Width = 9.86+ 0.71;
                    ws.Column(6).Width = 9.86+ 0.71;
                    ws.Column(7).Width = 14+ 0.71;
                    p.SaveAs(saveFileDialog1.FileNames+".xlsx");
                    Process.Start(saveFileDialog1.FileNames+".xlsx");
                }
            }
        }
    }
}
