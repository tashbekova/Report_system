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
    public partial class frm_Prognoz : MaterialForm
    {
        public frm_Prognoz()
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
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void button_Make_prognoz_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                    button_Make_prognoz.Enabled = false;
                    pb_Status.Visible = true;
                    string path;
                    string Table_name = "";
                    string path_directory = label_path_directory.Text.ToString();
                   
                    int year = System.DateTime.Now.Year;
                    Check check_data = new Check();
                    int check = 0;
                    if (rbutton_Visa.Checked == true)
                    {
                     Table_name = "[dbo].[tbl_Total_Device_Report_A]";
                    check = check_data.Check_Data(Table_name);
                        if (check == 0)
                        {
                            MessageBox.Show("��� ������ �� ����������", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (check >= 1)
                        {
                            path = path_directory + @"\" + year.ToString();
                            if (Directory.Exists(path))
                            {
                            path = path_directory + @"\" + year.ToString()+@"\Visa_" + DateTime.Now.ToShortDateString() + ".xlsx";
                            if (System.IO.File.Exists(path))
                                    {
                                        string message = "������� ��� ����������� �� �������. ������ �� �� ������������ ��� ���?";
                                        string caption = "Error Detected in Input";
                                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                        DialogResult result;
                                        // Displays the MessageBox.
                                        result = MessageBox.Show(message, caption, buttons);
                                        if (result == System.Windows.Forms.DialogResult.Yes)
                                        {
                                    Generation_Prognoz_Visa prognoz = new Generation_Prognoz_Visa();
                                    await Task.Run(() => prognoz.Generation(path));
                                    }
                                    }
                                    else
                                    {
                                Generation_Prognoz_Visa prognoz = new Generation_Prognoz_Visa();
                                await Task.Run(() => prognoz.Generation(path));
                                    }
                            }
                                else
                                {
                                    DirectoryInfo di = Directory.CreateDirectory(path);
                                     path = path_directory + @"\" + year.ToString() + @"\Visa_" + DateTime.Now.ToShortDateString() + ".xlsx";
                            Generation_Prognoz_Visa prognoz = new Generation_Prognoz_Visa();
                            await Task.Run(() => prognoz.Generation(path));
                        } 
                        }
                        else if (check == 2)
                        {
                            MessageBox.Show("��������� ������", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (rbutton_ElCard.Checked == true)
                    {
                    Table_name = "[dbo].[tbl_Report_Infe]";
                    check = check_data.Check_Data(Table_name);
                            if (check == 0)
                            {
                                MessageBox.Show("��� ������ �� ���� ������ �������", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                                else if (check >= 1)
                                {
                                    path = path_directory + @"\" + year.ToString() ;
                                if (Directory.Exists(path))
                                {
                                 path = path_directory + @"\" + year.ToString() + @"\ElCard_" +  DateTime.Now.ToShortDateString() + ".xlsx";
                                        if (System.IO.File.Exists(path))
                                        {
                                            string message = "������� ��� ����������� �� �������. ������ �� �� ������������ ��� ���?";
                                            string caption = "Error Detected in Input";
                                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                            DialogResult result;
                                            // Displays the MessageBox.
                                            result = MessageBox.Show(message, caption, buttons);
                                            if (result == System.Windows.Forms.DialogResult.Yes)
                                            {
                                    Generation_Prognoz_ElCard prognoz = new Generation_Prognoz_ElCard();
                                    await Task.Run(() => prognoz.Generation(path));
                                }
                                        }
                                        else
                                        {
                                Generation_Prognoz_ElCard prognoz = new Generation_Prognoz_ElCard();
                                await Task.Run(() => prognoz.Generation(path));
                            }
                                    }
                                    else
                                    {
                                        DirectoryInfo di = Directory.CreateDirectory(path);
                                         path = path_directory + @"\" + year.ToString() + @"\ElCard_" + DateTime.Now.ToShortDateString() + ".xlsx";

                            Generation_Prognoz_ElCard prognoz = new Generation_Prognoz_ElCard();
                            await Task.Run(() => prognoz.Generation(path));
                        }
                                }
                            else if (check == 2)
                            {
                                MessageBox.Show("��������� ������", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                button_Make_prognoz.Enabled = true;
            }
            catch(Exception ex)
            {
                pb_Status.Visible = false;
                button_Make_prognoz.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
            }
            finally
            {
                button_Make_prognoz.Enabled = true;
                pb_Status.Visible = false;
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
                                " ID='" + 3 + "'";
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
                " ID='" + 3 + "'";
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
