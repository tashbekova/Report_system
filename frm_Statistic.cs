using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.IO;
using System.Data;

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
            Show_path();
        }

        private void frm_Statistic_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet1.tbl_Name_of_report". При необходимости она может быть перемещена или удалена.
            this.tbl_Name_of_reportTableAdapter.Fill(this.report_SystemDataSet1.tbl_Name_of_report);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Year". При необходимости она может быть перемещена или удалена.
            this.tbl_YearTableAdapter.Fill(this.report_SystemDataSet.tbl_Year);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Type_of_report". При необходимости она может быть перемещена или удалена.
            this.tbl_Type_of_reportTableAdapter.Fill(this.report_SystemDataSet.tbl_Type_of_report);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Month". При необходимости она может быть перемещена или удалена.
            this.tbl_MonthTableAdapter.Fill(this.report_SystemDataSet.tbl_Month);

            comboBox_month.SelectedIndex = DateTime.Now.Month - 1;
            comboBox_month2.SelectedIndex = DateTime.Now.Month - 1;
            int index = comboBox_year.FindString((System.DateTime.Now.Year).ToString());
            if (index < 0)
            {
                MessageBox.Show("Нынешнего года нет в Базе данных");
            }
            else
            {
                comboBox_year.SelectedIndex = index;
            }

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
            comboBox_month2.Visible = false;
            label_description_for_year.Visible = true;
            label_description_for_time.Visible = false;
        }

        private void rbutton_Time_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_type_report.Visible = true;
            comboBox_year.Visible = true;
            comboBox_month.Visible = true;
            comboBox_month2.Visible = true;
            label_description_for_year.Visible = true;
            label_description_for_time.Visible = true;
        }

        private async void button_Make_statistic_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                
                pb_Status.Visible = true;
                //Блокировка кнопки до окончания формирования статистики
                button_Make_statistic.Enabled = false;
                //Если выбран год и тип отчета
                if (comboBox_year.SelectedItem != null && comboBox_type_report.SelectedItem != null)
                {
                    string path;
                    string Table_name = "";
                    string report = comboBox_type_report.SelectedValue.ToString();
                    int year = (int)((DataRowView)comboBox_year.SelectedItem)[comboBox_year.DisplayMember];
                    string path_directory = label_path_directory.Text.ToString();
                    Generation_statistic statistic = new Generation_statistic();
                    string column = "";

                    if (rbutton_Currency.Checked == true)
                    { 
                        column = "Currency";
                    }
                    else if (rbutton_Type_of_card.Checked == true)
                    { 
                        column = "Type_of_card";
                        if(report=="Report Infe")
                        {
                            MessageBox.Show("Выберите другой тип статистики,не по типам карт.Этот вид не поддерживается Элкарт");
                            return;
                        }
                    }
                    else if (rbutton_Device.Checked == true)
                    { 
                        column = "Device"; 
                    }

                    if (report == "Report A")
                    {
                        Table_name = "tbl_Report_A";
                    }
                    else if (report == "Report H")
                    {
                        Table_name = "tbl_Report_H";
                    }
                    else if (report == "Report R")
                    {
                        Table_name = "tbl_Report_R";
                    }
                    else if(report=="Report Infe")
                    {
                        Table_name = "tbl_Report_Infe";
                    }
                    Check check_data = new Check();
                    int check = 0;
                    if (rbutton_Year.Checked == true)
                    {
                        check = check_data.Check_Data(Table_name,year);
                        if (check == 0)
                        {
                            MessageBox.Show("Нет данных за этот год", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (check >= 1)
                        {
                                path = path_directory + @"\" + year.ToString() + @"\" + report;
                                if (Directory.Exists(path))
                                {
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" +column.ToString()+"_"+  year.ToString() + "_" + report + ".xlsx";
                                    string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + column.ToString() + "_" + year.ToString() + "_" + report + ".xls";
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
                                            await Task.Run(() => statistic.Generation(path, report,year,column));
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Статистика еще не сформирована");
                                        await Task.Run(() => statistic.Generation(path, report, year,column));
                                    }
                                }
                                else
                                {
                                    DirectoryInfo di = Directory.CreateDirectory(path);
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + column.ToString() + "_" + year.ToString() + "_" + report + ".xlsx";
                                    MessageBox.Show("Статистика еще не сформирована");
                                    await Task.Run(() => statistic.Generation(path, report, year,column));
                                }
                        }
                        else if (check == 2)
                        {
                            MessageBox.Show("Произошла ошибка", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (rbutton_Time.Checked == true)
                    {
                        if (comboBox_month.SelectedItem != null && comboBox_month2.SelectedItem != null)
                        {
                            int month = Convert.ToInt32(comboBox_month.SelectedValue.ToString());
                            int month2 = Convert.ToInt32(comboBox_month2.SelectedValue.ToString());
                            check = check_data.Check_Data(Table_name,month,month2, year);
                            if (check == 0)
                            {
                                MessageBox.Show("Нет данных за этот период времени", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                                else if (check >= 1)
                                {
                                    path = path_directory + @"\" + year.ToString() + @"\" + report;
                                    if (Directory.Exists(path))
                                    {
                                        path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + column.ToString() + "_" + month.ToString() + "/" +
                                        year.ToString() + "-" + month2.ToString() + "/" + year.ToString() + "_" + report + ".xlsx";

                                        string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + column.ToString() + "_" + month.ToString() +
                                        "/" + year.ToString() + "-" + month2.ToString() + "/" + year.ToString() + "_" + report + ".xls";
                                        if (System.IO.File.Exists(path))
                                        {
                                            // pb_Status.PerformStep();
                                            MessageBox.Show("Отчёт уже сформирован");
                                            string message = "Отчёт уже сформирован. Хотите ли вы сформировать ещё раз?";
                                            string caption = "Error Detected in Input";
                                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                            DialogResult result;
                                            //pb_Status.PerformStep();
                                            // Displays the MessageBox.
                                            result = MessageBox.Show(message, caption, buttons);
                                            if (result == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                await Task.Run(() => statistic.Generation(path, report, month, month2, year, column));
                                            }
                                        }
                                        else
                                        {
                                            // pb_Status.PerformStep();
                                            MessageBox.Show("Статистика еще не сформирована");
                                            await Task.Run(() => statistic.Generation(path, report, month, month2, year, column));
                                        }
                                    }
                                    else
                                    {
                                        //pb_Status.PerformStep();
                                        DirectoryInfo di = Directory.CreateDirectory(path);
                                        path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" +
                                        month.ToString() + "/" + year.ToString() + "-" + month2.ToString() + "/" + year.ToString() + "_" + report + ".xlsx";
                                        // pb_Status.PerformStep();
                                        MessageBox.Show("Статистика еще не сформирована");
                                        //pb_Status.PerformStep();
                                        await Task.Run(() => statistic.Generation(path, report, month, month2, year, column));
                                    }

                            }
                            else if (check == 2)
                            {
                                pb_Status.Value = 50;
                                pb_Status.Visible = false;
                                MessageBox.Show("Произошла ошибка", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите месяц", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (comboBox_year.SelectedItem == null)
                {
                    MessageBox.Show("Выберите год", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBox_type_report.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тип отчета", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                pb_Status.Visible = false;
                button_Make_statistic.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
            }
            finally
            {
                pb_Status.Visible = false;
                button_Make_statistic.Enabled = true;
                GC.Collect();
            }

        }

        private void button_Edit_path_directory_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    Connection sql = new Connection();
                    string ConnectionString = sql.Get_Connection_String();
                    SqlConnection myConnection = new SqlConnection(ConnectionString);
                    string Table_name = "[dbo].[tbl_Path_Directory_for_save_report]";
                    string path_directory = FBD.SelectedPath;
                    myConnection.Open();
                    string query = "Update " + Table_name +
                                "Set Path ='" + path_directory + "'" +
                                " WHERE " +
                                " ID='" + 2 + "'";
                    SqlCommand command = new SqlCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    myConnection.Close();
                    Show_path();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Show_path()
        {
            try
            {
                Connection sql = new Connection();
                string ConnectionString = sql.Get_Connection_String();
                SqlConnection myConnection = new SqlConnection(ConnectionString);
                string Table_name = "[dbo].[tbl_Path_Directory_for_save_report]";
                myConnection.Open();
                string query = "Select * From " + Table_name +
                     " WHERE " +
                " ID='" + 2 + "'";
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
            }
            finally
            {
                GC.Collect();
            }
        }

        private void comboBox_type_report_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
