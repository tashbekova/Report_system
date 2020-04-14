using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using System.Data.SqlClient;


namespace Report_system
{
    public partial class frm_Generation : MaterialForm
    {
        public frm_Generation()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Amber600, Primary.Teal200, Accent.Teal200, TextShade.WHITE);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Type_of_report". При необходимости она может быть перемещена или удалена.
            this.tbl_Type_of_reportTableAdapter.Fill(this.report_SystemDataSet.tbl_Type_of_report);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Month". При необходимости она может быть перемещена или удалена.
            this.tbl_MonthTableAdapter.Fill(this.report_SystemDataSet.tbl_Month);
            Show_path();

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_Generation_Click(object sender, EventArgs e)
        {
            if (comboBox_month.SelectedItem != null && comboBox_year.SelectedItem != null && comboBox_type_report.SelectedItem != null)
            {
                try
                {
                    string path;
                    string report = comboBox_type_report.SelectedValue.ToString();
                    int month = Convert.ToInt32(comboBox_month.SelectedValue.ToString()) ;
                    int year = Convert.ToInt32(comboBox_year.SelectedItem.ToString());
                    string path_directory = label_path_directory.Text.ToString();
                    int year_now =  Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                    //string Table_name = "";
                    if (year >= 2000 && year<=year_now)
                    {
                        path = path_directory + @"\" + year.ToString();
                        if (Directory.Exists(path))
                        {
                            path = path_directory + @"\" + year.ToString() + @"\" + report;
                            if (Directory.Exists(path))
                            {
                                path = path_directory + @"\" + year.ToString() + @"\" + report+@"\"+month.ToString()+"_"+year.ToString()+"_"+report+".xlsx";
                                string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xls";
                                if (System.IO.File.Exists(path))
                                { 
                                    MessageBox.Show("Отчёт уже сформирован");
                                    string message = "Отчёт уже сформирован. Хотите ли вы сформировать ещё раз?";
                                    string caption = "Error Detected in Input";
                                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                    DialogResult result;

                                    // Displays the MessageBox.
                                    result = MessageBox.Show(message, caption, buttons);
                                    if (result == System.Windows.Forms.DialogResult.Yes)
                                    {
                                       
                                    }
                            }
                                else
                                {

                                    MessageBox.Show("File is not found");
                                    Generation_intermediate_report create = new Generation_intermediate_report();
                                    create.Generation(path,report,month,year);
                                }
                            }
                        }
                        else
                        { 
                            DirectoryInfo di = Directory.CreateDirectory(path);
                            path = path_directory + @"\" + year.ToString() + @"\" + report;
                            di = Directory.CreateDirectory(path);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Выберите корректный год");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            else if (comboBox_type_report.SelectedItem == null)
            {
                MessageBox.Show("Выберите вид отчета");
            }
            else if (comboBox_month.SelectedItem == null)
            {
                MessageBox.Show("Выберите месяц");
            }
            else if (comboBox_year.SelectedItem == null)
            {
                MessageBox.Show("Выберите год");
            }
        }

        private void button_Edit_path_directory_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
                    SqlConnection myConnection = new SqlConnection(ConnectionString);
                    string Table_name = "[dbo].[tbl_Path_Directory_for_save_report]";
                    string path_directory = FBD.SelectedPath;
                    myConnection.Open();
                    string query = "Update " + Table_name +
                                "Set Path ='"+path_directory+"'"+
                                " WHERE " +
                                " ID='" + 1 + "'";
                    SqlCommand command = new SqlCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    myConnection.Close();
                    Show_path();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void Show_path()
        {
            string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            string Table_name = "[dbo].[tbl_Path_Directory_for_save_report]";
            myConnection.Open();
            string query = "Select * From " + Table_name +
                 " WHERE " +
            " ID='" + 1 + "'";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                label_path_directory.Text = Convert.ToString(reader["Path"]);
            }
            reader.Close();
            myConnection.Close();
        }

    }
   
}
