using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace Report_system
{
    public partial class frm_Statistic : MaterialForm
    {
        public frm_Statistic()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Amber600, Primary.Teal200, Accent.Teal200, TextShade.WHITE);

        }

        private void frm_Statistic_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Type_of_report". При необходимости она может быть перемещена или удалена.
            this.tbl_Type_of_reportTableAdapter.Fill(this.report_SystemDataSet.tbl_Type_of_report);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Month". При необходимости она может быть перемещена или удалена.
            this.tbl_MonthTableAdapter.Fill(this.report_SystemDataSet.tbl_Month);

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbutton_Year_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_type_report.Visible = true;
            comboBox_year.Visible = true;
            comboBox_month.Visible = false;
            combobox_month2.Visible = false;
            label_description_for_year.Visible = true;
            label_description_for_time.Visible = false;
        }

        private void rbutton_Time_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_type_report.Visible = true;
            comboBox_year.Visible = true;
            comboBox_month.Visible = true;
            combobox_month2.Visible = true;
            label_description_for_year.Visible = true;
            label_description_for_time.Visible = true;
        }

    }
}
