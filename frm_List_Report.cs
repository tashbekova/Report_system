using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Data;

namespace Report_system
{
    public partial class frm_List_Report : MaterialForm
    {
        public frm_List_Report()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Amber600, Primary.Teal200, Accent.Teal200, TextShade.WHITE);
            dataGridView_List_Reports.Columns[0].Width = 150;
            dataGridView_List_Reports.Columns[1].Width = 160;
            dataGridView_List_Reports.Columns[2].Width = 305;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Name_of_report". При необходимости она может быть перемещена или удалена.
            this.tbl_Name_of_reportTableAdapter.Fill(this.report_SystemDataSet.tbl_Name_of_report);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Year". При необходимости она может быть перемещена или удалена.
            this.tbl_YearTableAdapter.Fill(this.report_SystemDataSet.tbl_Year);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_Show_List_Report_Click(object sender, EventArgs e)
        {
            if(comboBox_month.SelectedItem!=null && comboBox_year.SelectedItem!=null && comboBox_type_report.SelectedItem!=null)
            {
                dataGridView_List_Reports.Rows.Clear();
                string Table_name= "";
                string report = comboBox_type_report.SelectedValue.ToString();
                int month = Convert.ToInt32(comboBox_month.SelectedValue.ToString());
                int year = (int)((DataRowView)comboBox_year.SelectedItem)[comboBox_year.DisplayMember];
                if (year>=2000)
                {
                    if (report== "Report A")
                    {
                        Table_name= "tbl_Result_Report_A";
                    }
                    else if (report == "Report H")
                    {
                        Table_name = "tbl_Result_Report_H";
                    }
                    else if (report == "Report R")
                    {
                        Table_name = "tbl_Result_Report_R";
                    }

                    Check check_data = new Check();
                    int check=check_data.Check_Data(Table_name,month, year);
                    if(check==0)
                    {
                        MessageBox.Show("Нет добавленных отчетов на этот месяц", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(check>=1)
                    {
                        dataGridView_List_Reports.Visible = true;
                        Load_Data(Table_name,month,year);
                    }
                    else if(check==2)
                    {
                        MessageBox.Show("Произошла ошибка", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введите правильный год", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if(comboBox_type_report.SelectedItem==null)
            {
                MessageBox.Show("Выберите вид отчета", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox_month.SelectedItem==null)
            {
                MessageBox.Show("Выберите месяц", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox_year.SelectedItem==null)
            {
                MessageBox.Show("Выберите год", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_Data(string Table_name,int month,int year)
        {
            try
            {
                string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
                SqlConnection myConnection = new SqlConnection(ConnectionString);
                myConnection.Open();
                string query = "Select * From " + Table_name +
                     " WHERE " +
                " Month(Date_of_read)='" + month + "' and YEAR(Date_of_read)='" + year + "'"+
                " Order by Name_of_report";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = reader[1].ToString();
                    data[data.Count - 1][1] = reader[2].ToString();
                    data[data.Count - 1][2] = reader[3].ToString();

                }
                reader.Close();
                myConnection.Close();
                foreach (string[] s in data)
                    dataGridView_List_Reports.Rows.Add(s);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_List_Reports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
