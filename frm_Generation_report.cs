using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.ComponentModel;

namespace Report_system
{
    public partial class frm_Generation_report : MaterialForm
    {

        public frm_Generation_report()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Amber600, Primary.Teal200, Accent.Teal200, TextShade.WHITE);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet1.tbl_Year". При необходимости она может быть перемещена или удалена.
            this.tbl_YearTableAdapter.Fill(this.report_SystemDataSet1.tbl_Year);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Type_of_report". При необходимости она может быть перемещена или удалена.
            this.tbl_Type_of_reportTableAdapter.Fill(this.report_SystemDataSet.tbl_Type_of_report);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "report_SystemDataSet.tbl_Month". При необходимости она может быть перемещена или удалена.
            this.tbl_MonthTableAdapter.Fill(this.report_SystemDataSet.tbl_Month);

            comboBox_month.SelectedIndex = DateTime.Now.Month - 1;
            int index = comboBox_year.FindString((System.DateTime.Now.Year).ToString());
            if (index < 0)
            {
                MessageBox.Show("Нынешнего года нет в Базе данных,добавьте через настройки");
            }
            else
            {
                comboBox_year.SelectedIndex = index;
            }

            Show_path();
        }
        // Set up the BackgroundWorker object by 
        // attaching event handlers. 
       

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button_Generation_ClickAsync(object sender, EventArgs e)
        {
            if (comboBox_month.SelectedItem != null && comboBox_year.SelectedItem != null && comboBox_type_report.SelectedItem != null)
            {
                button_Generation.Enabled = false;
                try
                {
                    pb_Status.Visible = true;
                    int month = 0;
                    int year = 0;
                    string path = "";
                    System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();
                    swatch.Start();
                    //string path;
                    string report = comboBox_type_report.SelectedValue.ToString();
                    month = Convert.ToInt32(comboBox_month.SelectedValue.ToString()) ;
                    year= (int)((DataRowView)comboBox_year.SelectedItem)[comboBox_year.DisplayMember];
                    string path_directory = label_path_directory.Text.ToString();
                    int year_now =  Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                    
                    //string Table_name = "";
                    if (year >= 2000 && year<=year_now)
                    {
                        if (report == "Промежуточный отчет")
                        {
                           
                        }
                        Check check_data = new Check();
                        int check_A = check_data.Check_Data("tbl_Report_A", month, year);
                        int check_H= check_data.Check_Data("tbl_Report_H", month, year);
                        int check_R= check_data.Check_Data("tbl_Report_R", month, year);
                        if(check_A<=0 && check_H<=0 && check_R<=0)
                        {
                            MessageBox.Show("Нет данных за этот месяц и год", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if(check_A > 0 || check_H > 0 || check_R > 0)
                        {
                             if (check_A <= 0 && check_H > 0 && check_R > 0)
                            {
                                MessageBox.Show("Нет данных по отчету A, данные по банкоматам будут пусты", "Error", MessageBoxButtons.OK);
                            }
                            else if (check_A > 0 && check_H <= 0 && check_R > 0)
                            {
                                MessageBox.Show("Нет данных по отчету H, данные по POS-терминалам будут пусты", "Error", MessageBoxButtons.OK);
                            }
                            else if (check_A > 0 && check_H > 0 && check_R <= 0)
                            {
                                MessageBox.Show("Нет данных по отчету R, данные по POS-терминалам будут пусты", "Error", MessageBoxButtons.OK);
                            }
                            path = path_directory + @"\" + year.ToString();
                            if (Directory.Exists(path))
                            {
                                path = path_directory + @"\" + year.ToString() + @"\" + report;
                                if (Directory.Exists(path))
                                {
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsx";
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
                                            // Start the asynchronous operation.
                                         Generation_intermediate_report create = new Generation_intermediate_report();
                                            await Task.Run(() => create.Generation(path, month, year)); 
                                         
                                        }
                                    }
                                    else
                                    {
                                        
                                        Generation_intermediate_report create = new Generation_intermediate_report();
                                        await Task.Run(() => create.Generation(path, month, year));
                                        //SetProgress(100);

                                    }
                                }
                                else
                                {
                                    DirectoryInfo di = Directory.CreateDirectory(path);
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsx";
                                    //MessageBox.Show("Отчет еще не сформирован");
                                    Generation_intermediate_report create = new Generation_intermediate_report();
                                    await Task.Run(() => create.Generation(path, month, year));
                                }
                            }
                            else
                            {
                                DirectoryInfo di = Directory.CreateDirectory(path);
                                path = path_directory + @"\" + year.ToString() + @"\" + report;
                                di = Directory.CreateDirectory(path);
                                path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsx";
                                Generation_intermediate_report create = new Generation_intermediate_report();
                                await Task.Run(() => create.Generation(path, month, year));
                            }
                            pb_Status.Visible = false;
                            // Тут ваш код, время выполнения которого нужно измерить
                            swatch.Stop();
                            MessageBox.Show("" + swatch.Elapsed);
                            button_Generation.Enabled = true;
                        }
                        else if(check_A == -2 && check_H == -2 && check_R == -2)
                        {
                            MessageBox.Show("Произошла ошибка", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите корректный год", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    pb_Status.Visible = false;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button_Generation.Enabled = true;
                }
                finally
                {
                    pb_Status.Visible = false;
                    button_Generation.Enabled = true;
                    GC.Collect();
                }
            }
            else if (comboBox_type_report.SelectedItem == null)
            {
                MessageBox.Show("Выберите вид отчета","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox_month.SelectedItem == null)
            {
                MessageBox.Show("Выберите месяц", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox_year.SelectedItem == null)
            {
                MessageBox.Show("Выберите год", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GC.Collect();
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
            GC.Collect();
        }
      
        public void MEssage()
        {
            MessageBox.Show("Hello");
        }
    }
   
}
