using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Report_system
{
    public partial class frm_Settings : MaterialForm
    {
        private SqlConnection myConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommandBuilder sqlBuilder = null;
        private int column = 0;
        private string Table_name = "";
        private bool newRowAdding = false;
        private bool flag_empty = false;
        public frm_Settings()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Amber600, Primary.Teal200, Accent.Teal200, TextShade.WHITE);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Connection sql = new Connection();
            string ConnectionString = sql.Get_Connection_String();
            myConnection = new SqlConnection(ConnectionString);
            myConnection.Open();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Edit_Settings_Click(object sender, EventArgs e)
        {
            column = 0;
            button_Update.Visible = true;
            dataGridView_List_Settings.Visible = true;
            if (flag_empty == true)
            {
                dataSet.Tables[Table_name].Clear();
                //dataGridView_List_Settings.Rows.Clear();
                dataGridView_List_Settings.DataSource = null;
                dataGridView_List_Settings.Refresh();
            }
            if (rbutton_User.Checked==true)
            {
                column = 3;
                Table_name = "tbl_User";
                Load_Data(Table_name, column);
            }
            else if(rbutton_Year.Checked==true)
            {
                column = 2;
                Table_name = "tbl_Year";
                Load_Data(Table_name, column);
            }
            else if(rbutton_Name_of_ATM.Checked==true)
            {
                column = 4;
                Table_name = "tbl_ATM_Region";
                Load_Data(Table_name, column);
            }
            else if(rbutton_Name_of_Cash_POS.Checked==true)
            {
                column = 3;
                Table_name = "tbl_POS_Cash_Region";
                Load_Data(Table_name, column);
            }
            else if (rbutton_Name_of_POS.Checked == true)
            {
                column = 3;
                Table_name = "tbl_POS_Region";
                Load_Data(Table_name, column);
            }
            else if (rbutton_Name_of_Region.Checked == true)
            {
                column = 2;
                Table_name = "tbl_Region";
                Load_Data(Table_name, column);
            }
            dataGridView_List_Settings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            flag_empty = true;
        }
       
        private void Load_Data(string Table_name,int column)
        {
          
            try
            {
             
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Delete] From " + Table_name, myConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
               
                sqlDataAdapter.Fill(dataSet, Table_name);

                dataGridView_List_Settings.DataSource = dataSet.Tables[Table_name];
                int i = 0;
               while(i<dataGridView_List_Settings.Rows.Count)
                { 
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView_List_Settings[column, i] = linkCell;
                    dataGridView_List_Settings[0, i].ReadOnly = true ;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reload_Data(string Table_name, int column)
        {
            try
            {
                if (flag_empty == true)
                { dataSet.Tables[Table_name].Clear(); }
                sqlDataAdapter.Fill(dataSet, Table_name);

                dataGridView_List_Settings.DataSource = dataSet.Tables[Table_name];
                int i = 0;
                while (i < dataGridView_List_Settings.Rows.Count)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView_List_Settings[column, i] = linkCell;
                    dataGridView_List_Settings[0, i].ReadOnly = true;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView_List_Settings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                    if(e.ColumnIndex==column)
                    {
                    string task = dataGridView_List_Settings.Rows[e.RowIndex].Cells[column].Value.ToString();
                    if(task=="Delete")
                    {
                        if(MessageBox.Show("Удалить эту строку?","Удаление",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                            ==DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView_List_Settings.Rows.RemoveAt(rowIndex);
                            dataSet.Tables[Table_name].Rows[rowIndex].Delete();
                            sqlDataAdapter.Update(dataSet, Table_name);
                        }

                    }
                    else if (task=="Insert")
                    {
                        int rowIndex = dataGridView_List_Settings.Rows.Count - 2;
                        DataRow row = dataSet.Tables[Table_name].NewRow();
                        if(rbutton_User.Checked==true)
                        {
                            row["Login"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Login"].Value;
                            row["Password"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Password"].Value;
                        }
                        else if (rbutton_Year.Checked == true)
                        {
                            row["Name_of_year"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Name_of_year"].Value;
                        }
                        else if (rbutton_Name_of_ATM.Checked == true)
                        {
                            row["Device"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Device"].Value;
                            row["Device_infe"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Device_infe"].Value;
                            row["Region_id"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Region_id"].Value;
                        }
                        else if (rbutton_Name_of_Cash_POS.Checked == true)
                        {
                            row["Device"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Device"].Value;
                            row["Region_id"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Region_id"].Value;
                        }
                        else if (rbutton_Name_of_POS.Checked == true)
                        {
                            row["Device"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Device"].Value;
                            row["Region_id"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Region_id"].Value;
                        }
                        else if (rbutton_Name_of_Region.Checked == true)
                        {
                            row["Region"] = dataGridView_List_Settings.Rows[rowIndex].Cells["Region"].Value;
                        }
                        dataSet.Tables[Table_name].Rows.Add(row);
                        dataSet.Tables[Table_name].Rows.RemoveAt(dataSet.Tables[Table_name].Rows.Count - 1);
                        dataGridView_List_Settings.Rows.RemoveAt(dataGridView_List_Settings.Rows.Count - 2);
                        dataGridView_List_Settings.Rows[e.RowIndex].Cells[column].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, Table_name);
                        newRowAdding = false;
                    }
                    else if (task=="Update")
                    {
                        int r = e.RowIndex;
                        if (rbutton_User.Checked == true)
                        {
                            dataSet.Tables[Table_name].Rows[r]["Login"] = dataGridView_List_Settings.Rows[r].Cells["Login"].Value;
                            dataSet.Tables[Table_name].Rows[r]["Password"] = dataGridView_List_Settings.Rows[r].Cells["Password"].Value;
                        }
                        else if (rbutton_Year.Checked == true)
                        {
                            dataSet.Tables[Table_name].Rows[r]["Name_of_year"] = dataGridView_List_Settings.Rows[r].Cells["Name_of_year"].Value;
                        }
                        else if (rbutton_Name_of_ATM.Checked == true)
                        {
                            dataSet.Tables[Table_name].Rows[r]["Device"] = dataGridView_List_Settings.Rows[r].Cells["Device"].Value;
                            dataSet.Tables[Table_name].Rows[r]["Device_infe"] = dataGridView_List_Settings.Rows[r].Cells["Device_infe"].Value;
                            dataSet.Tables[Table_name].Rows[r]["Region_id"] = dataGridView_List_Settings.Rows[r].Cells["Region_id"].Value;
                        }
                        else if (rbutton_Name_of_Cash_POS.Checked == true)
                        {
                            dataSet.Tables[Table_name].Rows[r]["Device"] = dataGridView_List_Settings.Rows[r].Cells["Device"].Value;
                            dataSet.Tables[Table_name].Rows[r]["Region_id"] = dataGridView_List_Settings.Rows[r].Cells["Region_id"].Value;
                        }
                        else if (rbutton_Name_of_POS.Checked == true)
                        {
                            dataSet.Tables[Table_name].Rows[r]["Device"] = dataGridView_List_Settings.Rows[r].Cells["Device"].Value;
                            dataSet.Tables[Table_name].Rows[r]["Region_id"] = dataGridView_List_Settings.Rows[r].Cells["Region_id"].Value;
                        }
                        else if (rbutton_Name_of_Region.Checked == true)
                        {
                            dataSet.Tables[Table_name].Rows[r]["Region"] = dataGridView_List_Settings.Rows[r].Cells["Region"].Value;
                        }
                        sqlDataAdapter.Update(dataSet, Table_name);
                        dataGridView_List_Settings.Rows[e.RowIndex].Cells[column].Value = "Delete";
                    }
                    Reload_Data(Table_name,column);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView_List_Settings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(newRowAdding==false)
                {
                    int rowIndex = dataGridView_List_Settings.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView_List_Settings.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView_List_Settings[column, rowIndex] = linkCell;
                    editingRow.Cells["Delete"].Value = "Update";   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void dataGridView_List_Settings_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView_List_Settings.Rows.Count - 2;
                    DataGridViewRow row = dataGridView_List_Settings.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView_List_Settings[column, lastRow] = linkCell;
                    row.Cells["Delete"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Update_Click_1(object sender, EventArgs e)
        {
            if (rbutton_User.Checked == true)
            {
                Reload_Data("tbl_User", 3);
            }
            else if (rbutton_Year.Checked == true)
            {
                Reload_Data("tbl_Year", 2);
            }
            else if (rbutton_Name_of_Cash_POS.Checked == true)
            {
                Reload_Data("tbl_POS_Cash_Region", 2);
            }
            else if (rbutton_Name_of_ATM.Checked == true)
            {
                Reload_Data("tbl_ATM_Region", 2);
            }
            else if (rbutton_Name_of_POS.Checked == true)
            {
                Reload_Data("tbl_POS_Region", 2);
            }
            else if (rbutton_Name_of_Region.Checked == true)
            {
                Reload_Data("tbl_Region", 2);
            }
        }
    }
}
