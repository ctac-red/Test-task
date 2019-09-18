using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Факультет". При необходимости она может быть перемещена или удалена.
            this.facultyTableAdapter.Fill(this.database1DataSet.Факультет);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Специальность". При необходимости она может быть перемещена или удалена.
            this.specTableAdapter.Fill(this.database1DataSet.Специальность);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Студенты". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.database1DataSet.Студенты);
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            //Сохранение изменений во всех таблицах
            studentsTableAdapter.Update(database1DataSet);
            specTableAdapter.Update(database1DataSet);
            facultyTableAdapter.Update(database1DataSet);
        }

        private void DataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void DataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void DataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            ReportForm af = new ReportForm();
            af.Owner = this;
            af.Show();
        }
    }
}
