using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
using Gos.Server;
using System.Diagnostics;

namespace Gos.Forms.Сustom
{
    public partial class ResObj : Form
    {
        public ResObj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("MySheet");
                ws.Cells.Style.Font.Name = "Calibri";
                ws.Cells.Style.Font.Size = 11;
                ws.Cells["C1"].Value = "РЕЕСТР №";
                ws.Cells["C1"].Style.Font.Size = 14;
                ws.Cells["C1"].Style.Font.Bold = true;
                ws.Cells["D1"].Value = textBox1.Text;
                ws.Cells["D1"].Style.Font.Size = 14;
                ws.Cells["D1"].Style.Border.Bottom.Style = 
                    OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells["D1"].Style.HorizontalAlignment = 
                    OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                ws.Cells["A2"].Value = "ЗАКУПЛЕННЫХ ОБЪЕКТОВ";
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
                ws.Cells["B6"].Value = "Учереждение";
                ws.Cells["C6"].Value = "ГОБУЗ \"МООД\"";
                ws.Cells["C6:D6"].Style.Border.Bottom.Style =
                    OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                ws.Cells["B11"].Value = "Материально ответвенное лицо";
                ws.Cells["C11:D11"].Style.Border.Bottom.Style =
                    OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                ws.Cells["A13"].Value = "№";
                ws.Cells["B13"].Value = "Наименование объекта ";
                ws.Cells["C13"].Value = "Инвентарный\nНомер";
                ws.Cells["D13"].Value = "Расположение";
                ws.Cells["E13"].Value = "Статус";
                ws.Cells["F13"].Value = "Стоимость\n(руб.)";
                ws.Cells["G13"].Value = "Категория";
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
                for (int i = 1; i<8; i++)
                {
                    ws.Cells[14, i].Value = i.ToString();
                }
                List<Objects> objects = new List<Objects>();
                using (var requester = new Requester<Objects,
                        ObjectsFilter>(Param.Serv.host))
                {
                    using (var requester2 = new Requester<ObjectsHistory,
                        ObjectsHistoryFilter>(Param.Serv.host))
                    {
                        var objs = requester.Select();
                        foreach (var obj in objs)
                        {
                            var hists = requester2.Select(new ObjectsHistoryFilter()
                            {
                                InvNumber = obj.invNumber
                            });
                            if (hists != null)
                            {
                                var hist = hists.OrderBy(x => x.date).ToArray()[0];
                                if ((hist.date>dateTimePicker1.Value)&&
                                    (hist.date<dateTimePicker2.Value))
                                {
                                    objects.Add(obj);
                                }
                            }
                        }
                    }
                }
                int row = 15;
                int index = 1;
                foreach (var obj in objects)
                {
                    ws.Cells[$"A{row}"].Value = index.ToString();
                    ws.Cells[$"B{row}"].Value = obj.name;
                    ws.Cells[$"C{row}"].Value = obj.invNumber;
                    ws.Cells[$"D{row}"].Value = obj.location;
                    ws.Cells[$"E{row}"].Value = obj.status;
                    ws.Cells[$"F{row}"].Value = obj.cost;
                    ws.Cells[$"G{row}"].Value = obj.cat;
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
                ws.Cells[$"B{row}"].Value = "Всего оборудования в обороте";
                ws.Cells[$"B{row}"].Style.Font.Bold = true;
                ws.Cells[$"C{row}"].Value = objects.Count.ToString();
                ws.Cells[$"C{row}:G{row}"].Style.Border.Bottom.Style =
                    OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                row += 2;
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
                p.SaveAs("myworkbook.xlsx");
                Process.Start("myworkbook.xlsx");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
