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
            // TODO: ������ ������ ���� ��������� ��������� ������ � ������� "report_SystemDataSet1.tbl_Year". ��� ������������� ��� ����� ���� ���������� ��� �������.
            this.tbl_YearTableAdapter.Fill(this.report_SystemDataSet1.tbl_Year);
            // TODO: ������ ������ ���� ��������� ��������� ������ � ������� "report_SystemDataSet.tbl_Type_of_report". ��� ������������� ��� ����� ���� ���������� ��� �������.
            this.tbl_Type_of_reportTableAdapter.Fill(this.report_SystemDataSet.tbl_Type_of_report);
            // TODO: ������ ������ ���� ��������� ��������� ������ � ������� "report_SystemDataSet.tbl_Month". ��� ������������� ��� ����� ���� ���������� ��� �������.
            this.tbl_MonthTableAdapter.Fill(this.report_SystemDataSet.tbl_Month);

            comboBox_month.SelectedIndex = DateTime.Now.Month - 1;
            int index = comboBox_year.FindString((System.DateTime.Now.Year).ToString());
            if (index < 0)
            {
                MessageBox.Show("��������� ���� ��� � ���� ������,�������� ����� ���������");
            }
            else
            {
                comboBox_year.SelectedIndex = index;
            }

            Show_path();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void button_Generation_ClickAsync(object sender, EventArgs e)
        {
            if (comboBox_month.SelectedItem != null && comboBox_year.SelectedItem != null && comboBox_type_report.SelectedItem != null)
            {
                try
                {
                    button_Generation.Enabled = false;
                    pb_Status.Visible = true;
                    int month = 0;
                    int year = 0;
                    string path = "";
                    //string path;
                    string report = comboBox_type_report.SelectedValue.ToString();
                    month = Convert.ToInt32(comboBox_month.SelectedValue.ToString()) ;
                    year= (int)((DataRowView)comboBox_year.SelectedItem)[comboBox_year.DisplayMember];
                    string path_directory = label_path_directory.Text.ToString();
                    int year_now =  Convert.ToInt32(DateTime.Now.ToString("yyyy"));

                    //string Table_name = "";
                    if (year >= 2000 && year <= year_now)
                    {
                        if (report == "������������� ����� �� ������")
                        {
                            Check check_data = new Check();
                            MessageBox.Show("month=" + month.ToString() + "   year=" + year);
                            int check = check_data.Check_Data("tbl_Report_Infe", month, year);
                            MessageBox.Show(check.ToString());
                            if(check==0)
                            {
                                MessageBox.Show("��� ������ �� ������ �� ���� ����� � ��� ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (check > 0)
                            {
                                path = path_directory + @"\" + year.ToString() + @"\" + report;
                                if (Directory.Exists(path))
                                {
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xls";
                                    string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsx";
                                    if (System.IO.File.Exists(path) || System.IO.File.Exists(path2))
                                    {
                                        MessageBox.Show("����� ��� �����������");
                                        string message = "����� ��� �����������. ������ �� �� ������������ ��� ���?";
                                        string caption = "Error Detected in Input";
                                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                        DialogResult result;
                                        // Displays the MessageBox.
                                        result = MessageBox.Show(message, caption, buttons);
                                        if (result == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            Generation_intermediate_report_Elcart create = new Generation_intermediate_report_Elcart();
                                            await Task.Run(() => create.Generation(path, month, year));
                                        }
                                    }
                                    else
                                    {
                                        Generation_intermediate_report_Elcart create = new Generation_intermediate_report_Elcart();
                                        await Task.Run(() => create.Generation(path, month, year));
                                    }
                                }
                                else
                                {
                                    DirectoryInfo di = Directory.CreateDirectory(path);
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xls";
                                    string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsx";
                                    Generation_intermediate_report_Elcart create = new Generation_intermediate_report_Elcart();
                                    await Task.Run(() => create.Generation(path, month, year));
                                }
                                pb_Status.Visible = false;
                                button_Generation.Enabled = true;
                            }
                            else if (check == -2 )
                            {
                                MessageBox.Show("��������� ������", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            Check check_data = new Check();
                            int check_A = check_data.Check_Data("tbl_Report_A", month, year);
                            int check_H = check_data.Check_Data("tbl_Report_H", month, year);
                            int check_R = check_data.Check_Data("tbl_Report_R", month, year);
                            int check_Infe = check_data.Check_Data("tbl_Report_Infe", month, year);
                            if (check_A <= 0 && check_H <= 0 && check_R <= 0 && check_Infe<=0)
                            {
                                MessageBox.Show("��� ������ �� ���� ����� � ���", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (check_A > 0 || check_H > 0 || check_R > 0 || check_Infe > 0)
                            {
                                if (check_A <= 0 && check_H > 0 && check_R > 0 && check_Infe >0)
                                {
                                    MessageBox.Show("��� ������ �� ������ A, ������ �� ���������� ����� �����", "Error", MessageBoxButtons.OK);
                                }
                                else if (check_A > 0 && check_H <= 0 && check_R > 0 && check_Infe > 0)
                                {
                                    MessageBox.Show("��� ������ �� ������ H, ������ �� POS-���������� ����� �����", "Error", MessageBoxButtons.OK);
                                }
                                else if (check_A > 0 && check_H > 0 && check_R <= 0 && check_Infe > 0)
                                {
                                    MessageBox.Show("��� ������ �� ������ R, ������ �� POS-���������� ����� �����", "Error", MessageBoxButtons.OK);
                                }
                                else if (check_A > 0 && check_H > 0 && check_R > 0 && check_Infe <= 0)
                                {
                                    MessageBox.Show("��� ������ �� ������ Infe, ������ �� ������ ����� �����", "Error", MessageBoxButtons.OK);
                                }

                                path = path_directory + @"\" + year.ToString() + @"\" + report;
                                if (Directory.Exists(path))
                                {
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xls";
                                    string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsm";
                                    if (System.IO.File.Exists(path) || System.IO.File.Exists(path2))
                                    {
                                        MessageBox.Show("����� ��� �����������");
                                        string message = "����� ��� �����������. ������ �� �� ������������ ��� ���?";
                                        string caption = "Error Detected in Input";
                                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                        DialogResult result;
                                        // Displays the MessageBox.
                                        result = MessageBox.Show(message, caption, buttons);
                                        if (result == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            if (report == "������������� ����� �� Visa Cards")
                                            {
                                                // Start the asynchronous operation.
                                                Generation_intermediate_report_Visa_Cards create = new Generation_intermediate_report_Visa_Cards();
                                                await Task.Run(() => create.Generation(path, month, year));
                                            }
                                            else if (report == "����� ��� ���.�����")
                                            {
                                                Generation_report_for_National_bank create = new Generation_report_for_National_bank();
                                                await Task.Run(() => create.Generation(path2));

                                            }

                                        }
                                    }
                                    else
                                    {

                                        if (report == "������������� ����� �� Visa Cards")
                                        {
                                            Generation_intermediate_report_Visa_Cards create = new Generation_intermediate_report_Visa_Cards();
                                            await Task.Run(() => create.Generation(path, month, year));
                                        }
                                        else if (report == "����� ��� ���.�����")
                                        {

                                            Generation_report_for_National_bank create = new Generation_report_for_National_bank();
                                            await Task.Run(() => create.Generation(path2));
                                        }
                                    }
                                }
                                else
                                {

                                    DirectoryInfo di = Directory.CreateDirectory(path);
                                    path = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xls";
                                    string path2 = path_directory + @"\" + year.ToString() + @"\" + report + @"\" + month.ToString() + "_" + year.ToString() + "_" + report + ".xlsm";
                                    if (report == "������������� ����� �� Visa Cards")
                                    {
                                        Generation_intermediate_report_Visa_Cards create = new Generation_intermediate_report_Visa_Cards();
                                        await Task.Run(() => create.Generation(path, month, year));
                                    }
                                    else if (report == "����� ��� ���.�����")
                                    {
                                        Generation_report_for_National_bank create = new Generation_report_for_National_bank();
                                        await Task.Run(() => create.Generation(path2));

                                    }
                                }
                                pb_Status.Visible = false;
                                button_Generation.Enabled = true;
                            }
                            else if (check_A == -2 && check_H == -2 && check_R == -2)
                            {
                                MessageBox.Show("��������� ������", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("�������� ���������� ���", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("�������� ��� ������","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox_month.SelectedItem == null)
            {
                MessageBox.Show("�������� �����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox_year.SelectedItem == null)
            {
                MessageBox.Show("�������� ���", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Connection sql = new Connection();
                    string ConnectionString = sql.Get_Connection_String();
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
            Connection sql = new Connection();
            string ConnectionString = sql.Get_Connection_String();
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
      
    }
   
}
