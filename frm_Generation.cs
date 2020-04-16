using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;

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

        private async void button_Generation_ClickAsync(object sender, EventArgs e)
        {
            if (comboBox_month.SelectedItem != null && comboBox_year.SelectedItem != null && comboBox_type_report.SelectedItem != null)
            {
                // Display the ProgressBar control.
                pb_Status.Visible = true;
                // Set Minimum to 1 to represent the first file being copied.
                pb_Status.Minimum = 1;
                // Set Maximum to the total number of files to copy.
                pb_Status.Maximum = 50;
                try
                {
                    string path;
                    string Table_name = "";
                    string report = comboBox_type_report.SelectedValue.ToString();
                    int month = Convert.ToInt32(comboBox_month.SelectedValue.ToString()) ;
                    int year = Convert.ToInt32(comboBox_year.SelectedItem.ToString());
                    string path_directory = label_path_directory.Text.ToString();
                    int year_now =  Convert.ToInt32(DateTime.Now.ToString("yyyy"));

                    // Set the initial value of the ProgressBar.
                    pb_Status.Value = 1;
                    // Set the Step property to a value of 1 to represent each file being copied.
                    pb_Status.Step = 1;
                    
                    //string Table_name = "";
                    if (year >= 2000 && year<=year_now)
                    {
                        if (report == "Report A")
                        {
                            Table_name = "tbl_Report_A";
                        }
                       // pb_Status.PerformStep();
                        Check check_data = new Check();
                        int check = check_data.Check_Data(Table_name, month, year);
                        if (check == 0)
                        {
                            //pb_Status.PerformStep();
                            MessageBox.Show("Нет данных за этот месяц и год");
                            pb_Status.Value = 50 ;
                            pb_Status.Visible = false;
                        }
                        else if (check >= 1)
                        {
                            //pb_Status.PerformStep();
                            path = path_directory + @"\" + year.ToString();
                            if (Directory.Exists(path))
                            {
                                //pb_Status.PerformStep();
                                path = path_directory + @"\" + year.ToString() + @"\" + report;
                                if (Directory.Exists(path))
                                {
                                    //pb_Status.PerformStep();
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsx";
                                    string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xls";
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
                                            //pb_Status.PerformStep();
                                        }
                                    }
                                    else
                                    {
                                       // pb_Status.PerformStep();
                                        MessageBox.Show("File is not found");
                                        //pb_Status.PerformStep();
                                        Generation_intermediate_report create = new Generation_intermediate_report();
                                        await Task.Run(() => create.Generation(path, report, month, year));
                                        create.ProgressBarIncrement += update_progressBar;
                                    }
                                }
                            }
                            else
                            {
                                //pb_Status.PerformStep();
                                DirectoryInfo di = Directory.CreateDirectory(path);
                                path = path_directory + @"\" + year.ToString() + @"\" + report;
                                //pb_Status.PerformStep();
                                di = Directory.CreateDirectory(path);
                            }

                        }
                        else if (check == 2)
                        {
                            pb_Status.Value = 50;
                            pb_Status.Visible = false;
                            MessageBox.Show("Произошла ошибка");
                        }
                    }
                    else
                    {
                        pb_Status.Value = 50;
                        pb_Status.Visible = false;
                        MessageBox.Show("Выберите корректный год");
                    }
                }
                catch (Exception ex)
                {
                    pb_Status.Value = 50;
                    pb_Status.Visible = false;
                    MessageBox.Show("" + ex);
                }
                finally
                {
                    pb_Status.Value = 50;
                    pb_Status.Visible = false;
                    GC.Collect();
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
            GC.Collect();
        }
        private void update_progressBar(int iteration)
        {
            Action action = GetAction(iteration);
            Invoke(action);
        }

        private Action GetAction(int iteration)
        {
            return () =>
            {
                pb_Status.Maximum = iteration;
                pb_Status.Value += 1;
            };
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
