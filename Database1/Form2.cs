using System;
using System.Windows.Forms;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Diagnostics;
using System.Data;

namespace Database1
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.GraphTable". При необходимости она может быть перемещена или удалена.
            this.graphTableTableAdapter.Fill(this.database1DataSet.GraphTable);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.ReportTable". При необходимости она может быть перемещена или удалена.
            this.reportTableTableAdapter.Fill(this.database1DataSet.ReportTable);

            DataTable dt = graphTableTableAdapter.GetData();

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chart1.Series[0].Points.AddXY(dt.Rows[i].ItemArray[0], dt.Rows[i].ItemArray[1]);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            {
                IWorkbook workbook = new XSSFWorkbook();

                //название листа в Excel
                ISheet sheet1 = workbook.CreateSheet("Лист1");

                //создание заголовка в первой ячейке
                sheet1.CreateRow(0).CreateCell(0).SetCellValue("Количество студентов по годам на факультет");

                DataTable dt = reportTableTableAdapter.GetData();

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i);

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(dt.Rows[i - 1].ItemArray[j].ToString());
                    }
                }

                //удаление копии
                if (!File.Exists("report.xlsx"))
                {
                    File.Delete("report.xlsx");
                }

                //создание файла отчета
                FileStream sw = File.Create("report.xlsx");

                workbook.Write(sw);

                //запуск Excel
                Process.Start("report.xlsx");
            }
        }
    }
}
