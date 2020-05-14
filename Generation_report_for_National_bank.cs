using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Report_system
{
    class Generation_report_for_National_bank
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        private Excel.Worksheet excelworksheet;
       // private Excel.Range excelrange;
        private Excel.Sheets excelsheets;

        Connection sql = new Connection();
        private string ConnectionString = "";
        public void Generation(string report_path,int month,int year)
        {
            try
            { 
                string appPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                string full_path_template = appPath + "/Reports/National_bank.xlsm";

                excelapp = new Excel.Application();
                excelworkbook = excelapp.Workbooks.Open(full_path_template); //открываем наш файл    
                                                                             //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;
                excelsheets = excelworkbook.Worksheets;
                Check check_data = new Check();
                int check_A = check_data.Check_Data("tbl_Report_A", month, year);
                int check_H = check_data.Check_Data("tbl_Report_H", month, year);
                int check_R = check_data.Check_Data("tbl_Report_R", month, year);
                int check_Infe= check_data.Check_Data("tbl_Report_Infe", month, year);

                if (check_Infe >= 0)
                { Make_calculations_Cash_Elcart_page1(month, year);
                    Make_calculations_Elcart_page1(month, year);
                    Make_calculations_Visa_Cash_page1(month, year);
                    Make_calculations_Visa_page1(month, year);

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Показываем ексель

                excelapp.Visible = true;

                excelapp.Interactive = true;
                excelapp.ScreenUpdating = true;
                excelapp.UserControl = true;
                excelworkbook.SaveAs(report_path);
                excelworkbook.Saved = true;
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                GC.Collect();
            }


        }

        private void Make_calculations_Cash_Elcart_page1(int month,int year)
        {
            try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();
                string Table_name = "";
                string Table_name_infe = "tbl_Report_Infe";
                decimal Summa_Infe_Cash_Halyk_Kyrgyz_card = 0;
                decimal Summa_Infe_Cash_Halyk_Kazakh_card = 0;
                decimal Summa_Infe_Cash_Other_card = 0;
                decimal Count_Infe_Cash_Halyk_Kyrgyz_card = 0;
                decimal Count_Infe_Cash_Halyk_Kazakh_card = 0;
                decimal Count_Infe_Cash_Other_card = 0;
                decimal Summa_Excel_Cash_Halyk_Kyrgyz_card = 0;
                decimal Summa_Excel_Cash_Halyk_Kazakh_card = 0;
                decimal Summa_Excel_Cash_Other_card = 0;
                decimal Count_Excel_Cash_Halyk_Kyrgyz_card = 0;
                decimal Count_Excel_Cash_Halyk_Kazakh_card = 0;
                decimal Count_Excel_Cash_Other_card = 0;

                for (int table_id = 0; table_id < 2; table_id++)
                {
                    if (table_id == 0)
                        Table_name = "tbl_ATM_Region";
                    else
                        Table_name = "tbl_POS_Cash_Region";
                    for (int region_id = 1; region_id <= 8; region_id++)
                    {
                        System.Data.DataTable dt_Device_Infe = GetData_Device(Table_name, region_id,true);
                        if(dt_Device_Infe==null)
                        {
                            continue;
                        }
                        else if (dt_Device_Infe != null)
                        {
                            for (int device_id = 0; device_id < dt_Device_Infe.Rows.Count; device_id++)
                            {
                                //////////////////////////////////////
                                string query_Count_Halyk_Card= "SELECT " +
                                    "Count(" + Table_name_infe + ".Summa)" +
                                    " FROM " + Table_name_infe +
                                    " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') "+
                                    " AND " + Table_name_infe + ".Target_number like '941730%'"+
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                SqlCommand command1 = new SqlCommand(query_Count_Halyk_Card, con);
                                Count_Infe_Cash_Halyk_Kyrgyz_card = Convert.ToInt32(command1.ExecuteScalar());

                                if ( Count_Infe_Cash_Halyk_Kyrgyz_card != 0)
                                {
                                    Count_Excel_Cash_Halyk_Kyrgyz_card = Convert.ToInt32(excelworksheet.Cells[region_id + 130, 16].Value);
                                    Count_Excel_Cash_Halyk_Kyrgyz_card = Count_Excel_Cash_Halyk_Kyrgyz_card + Count_Infe_Cash_Halyk_Kyrgyz_card;
                                    excelworksheet.Cells[region_id + 130, 16] = Count_Excel_Cash_Halyk_Kyrgyz_card;


                                    string query_Sum_Halyk_Card = "SELECT " +
                                    "SUM(" + Table_name_infe + ".Summa)" +
                                  " FROM " + Table_name_infe +
                                  " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                  " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_infe + ".Target_number like '941730%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                    SqlCommand command5 = new SqlCommand(query_Sum_Halyk_Card, con);
                                    Summa_Infe_Cash_Halyk_Kyrgyz_card = Convert.ToDecimal(command5.ExecuteScalar());
                                    if (Summa_Infe_Cash_Halyk_Kyrgyz_card != 0)
                                    {
                                        Summa_Excel_Cash_Halyk_Kyrgyz_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 130, 17].Value);
                                        Summa_Excel_Cash_Halyk_Kyrgyz_card = Summa_Excel_Cash_Halyk_Kyrgyz_card + (Summa_Infe_Cash_Halyk_Kyrgyz_card/1000);
                                        excelworksheet.Cells[region_id + 130, 17] = Summa_Excel_Cash_Halyk_Kyrgyz_card;
                                    }
                                }
                                // ---------------------------------------
                                string query_Count_Other_Card= "SELECT " +
                                    "Count(" + Table_name_infe + ".Summa)" +
                                    " FROM " + Table_name_infe +
                                    " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') "+
                                    " AND "+Table_name_infe+ ".Target_number like '9417%'"+
                                    " AND " + Table_name_infe + ".Target_number not like '941730%'"+
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                SqlCommand command2 = new SqlCommand(query_Count_Other_Card, con);
                                Count_Infe_Cash_Other_card = Convert.ToInt32(command2.ExecuteScalar());

                                if (Count_Infe_Cash_Other_card != 0)
                                {
                                    Count_Excel_Cash_Other_card = Convert.ToInt32(excelworksheet.Cells[region_id + 139, 16].Value);
                                    Count_Excel_Cash_Other_card = Count_Excel_Cash_Other_card + Count_Infe_Cash_Other_card;
                                    excelworksheet.Cells[region_id + 139, 16] = Count_Excel_Cash_Other_card;

                                    string query_Sum_Other_Card = "SELECT " +
                                       "SUM(" + Table_name_infe + ".Summa)" +
                                     " FROM " + Table_name_infe +
                                     " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                     " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                      " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                        " AND " + Table_name_infe + ".Target_number like '9417%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '941730%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                    SqlCommand command6 = new SqlCommand(query_Sum_Other_Card, con);
                                    Summa_Infe_Cash_Other_card = Convert.ToDecimal(command6.ExecuteScalar());
                                    if (Summa_Infe_Cash_Other_card != 0)
                                    {
                                        Summa_Excel_Cash_Other_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 139, 17].Value);
                                        Summa_Excel_Cash_Other_card = Summa_Excel_Cash_Other_card + (Summa_Infe_Cash_Other_card/1000);
                                        excelworksheet.Cells[region_id + 139, 17] = Summa_Excel_Cash_Other_card;
                                    }
                                }
                                // ---------------------------------------
                                string query_Count_Kazakh_Card = "SELECT " +
                                 "Count(" + Table_name_infe + ".Summa)" +
                                 " FROM " + Table_name_infe +
                                 " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                 " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                 " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                 " AND " + Table_name_infe + ".Target_number not like '9417%'";

                                SqlCommand command4 = new SqlCommand(query_Count_Kazakh_Card, con);
                                Count_Infe_Cash_Halyk_Kazakh_card = Convert.ToInt32(command4.ExecuteScalar());

                                if (Count_Infe_Cash_Halyk_Kazakh_card != 0)
                                {
                                    Count_Excel_Cash_Halyk_Kazakh_card = Convert.ToInt32(excelworksheet.Cells[region_id + 148, 16].Value);
                                    Count_Excel_Cash_Halyk_Kazakh_card = Count_Excel_Cash_Halyk_Kazakh_card + Count_Infe_Cash_Halyk_Kazakh_card;
                                    excelworksheet.Cells[region_id + 148, 16] = Count_Excel_Cash_Halyk_Kazakh_card;

                                    string query_Sum_Kazakh_Card = "SELECT " +
                                       "SUM(" + Table_name_infe + ".Summa)" +
                                     " FROM " + Table_name_infe +
                                     " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                      " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                 " AND " + Table_name_infe + ".Target_number not like '9417%'";

                                    SqlCommand command8 = new SqlCommand(query_Sum_Kazakh_Card, con);
                                    Summa_Infe_Cash_Halyk_Kazakh_card = Convert.ToDecimal(command8.ExecuteScalar());
                                    if (Summa_Infe_Cash_Halyk_Kazakh_card != 0)
                                    {
                                        Summa_Excel_Cash_Halyk_Kazakh_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 148, 17].Value);
                                        Summa_Excel_Cash_Halyk_Kazakh_card = Summa_Excel_Cash_Halyk_Kazakh_card + (Summa_Infe_Cash_Halyk_Kazakh_card/1000);
                                        excelworksheet.Cells[region_id + 148, 17] = Summa_Excel_Cash_Halyk_Kazakh_card;
                                    }
                                }
                                // ---------------------------------------
                              
                            }
                        }
                       
                    }
                }


                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
            }


        }

        private void Make_calculations_Elcart_page1(int month, int year)
        {
            try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();
                string Table_name = "";
                string Table_name_infe = "tbl_Report_Infe";
                decimal Summa_Infe_Halyk_Kyrgyz_card = 0;
                decimal Summa_Infe_Halyk_Kazakh_card = 0;
                decimal Summa_Infe_Other_card = 0;
                decimal Count_Infe_Halyk_Kyrgyz_card = 0;
                decimal Count_Infe_Halyk_Kazakh_card = 0;
                decimal Count_Infe_Other_card = 0;
                decimal Summa_Excel_Halyk_Kyrgyz_card = 0;
                decimal Summa_Excel_Halyk_Kazakh_card = 0;
                decimal Summa_Excel_Other_card = 0;
                decimal Count_Excel_Halyk_Kyrgyz_card = 0;
                decimal Count_Excel_Halyk_Kazakh_card = 0;
                decimal Count_Excel_Other_card = 0;


                    for (int region_id = 1; region_id <= 8; region_id++)
                    {
                        System.Data.DataTable dt_Device_Infe = GetData_Device("tbl_POS_Region", region_id,false);
                        if (dt_Device_Infe == null)
                        {
                            continue;
                        }
                        else if (dt_Device_Infe != null)
                        {
                            for (int device_id = 0; device_id < dt_Device_Infe.Rows.Count; device_id++)
                            {
                                //////////////////////////////////////
                                string query_Count_Halyk_Card = "SELECT " +
                                    "Count(" + Table_name_infe + ".Summa)" +
                                    " FROM " + Table_name_infe +
                                    " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_infe + ".Target_number like '941730%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                SqlCommand command1 = new SqlCommand(query_Count_Halyk_Card, con);
                                Count_Infe_Halyk_Kyrgyz_card = Convert.ToInt32(command1.ExecuteScalar());

                                if (Count_Infe_Halyk_Kyrgyz_card != 0)
                                {
                                    Count_Excel_Halyk_Kyrgyz_card = Convert.ToInt32(excelworksheet.Cells[region_id + 130, 18].Value);
                                    Count_Excel_Halyk_Kyrgyz_card = Count_Excel_Halyk_Kyrgyz_card + Count_Infe_Halyk_Kyrgyz_card;
                                    excelworksheet.Cells[region_id + 130, 18] = Count_Excel_Halyk_Kyrgyz_card;


                                    string query_Sum_Halyk_Card = "SELECT " +
                                    "SUM(" + Table_name_infe + ".Summa)" +
                                  " FROM " + Table_name_infe +
                                  " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                  " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_infe + ".Target_number like '941730%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                    SqlCommand command5 = new SqlCommand(query_Sum_Halyk_Card, con);
                                    Summa_Infe_Halyk_Kyrgyz_card = Convert.ToDecimal(command5.ExecuteScalar());
                                    if (Summa_Infe_Halyk_Kyrgyz_card != 0)
                                    {
                                        Summa_Excel_Halyk_Kyrgyz_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 130, 19].Value);
                                        Summa_Excel_Halyk_Kyrgyz_card = Summa_Excel_Halyk_Kyrgyz_card + (Summa_Infe_Halyk_Kyrgyz_card / 1000);
                                        excelworksheet.Cells[region_id + 130, 19] = Summa_Excel_Halyk_Kyrgyz_card;
                                    }
                                }
                                // ---------------------------------------
                                string query_Count_Other_Card = "SELECT " +
                                    "Count(" + Table_name_infe + ".Summa)" +
                                    " FROM " + Table_name_infe +
                                    " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_infe + ".Target_number like '9417%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '941730%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                SqlCommand command2 = new SqlCommand(query_Count_Other_Card, con);
                                Count_Infe_Other_card = Convert.ToInt32(command2.ExecuteScalar());

                                if (Count_Infe_Other_card != 0)
                                {
                                    Count_Excel_Other_card = Convert.ToInt32(excelworksheet.Cells[region_id + 139, 18].Value);
                                    Count_Excel_Other_card = Count_Excel_Other_card + Count_Infe_Other_card;
                                    excelworksheet.Cells[region_id + 139, 18] = Count_Excel_Other_card;

                                    string query_Sum_Other_Card = "SELECT " +
                                       "SUM(" + Table_name_infe + ".Summa)" +
                                     " FROM " + Table_name_infe +
                                     " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                     " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                      " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                        " AND " + Table_name_infe + ".Target_number like '9417%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '941730%'" +
                                    " AND " + Table_name_infe + ".Target_number not like '94173070%'";

                                    SqlCommand command6 = new SqlCommand(query_Sum_Other_Card, con);
                                    Summa_Infe_Other_card = Convert.ToDecimal(command6.ExecuteScalar());
                                    if (Summa_Infe_Other_card != 0)
                                    {
                                        Summa_Excel_Other_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 139, 19].Value);
                                        Summa_Excel_Other_card = Summa_Excel_Other_card + (Summa_Infe_Other_card / 1000);
                                        excelworksheet.Cells[region_id + 139, 19] = Summa_Excel_Other_card;
                                    }
                                }
                             
                                // ---------------------------------------
                                string query_Count_Kazakh_Card = "SELECT " +
                                 "Count(" + Table_name_infe + ".Summa)" +
                                 " FROM " + Table_name_infe +
                                 " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                 " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                 " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                 " AND " + Table_name_infe + ".Target_number not like '9417%'";

                                SqlCommand command4 = new SqlCommand(query_Count_Kazakh_Card, con);
                                Count_Infe_Halyk_Kazakh_card = Convert.ToInt32(command4.ExecuteScalar());

                                if (Count_Infe_Halyk_Kazakh_card != 0)
                                {
                                    Count_Excel_Halyk_Kazakh_card = Convert.ToInt32(excelworksheet.Cells[region_id + 148, 18].Value);
                                    Count_Excel_Halyk_Kazakh_card = Count_Excel_Halyk_Kazakh_card + Count_Infe_Halyk_Kazakh_card;
                                    excelworksheet.Cells[region_id + 148, 19] = Count_Excel_Halyk_Kazakh_card;

                                    string query_Sum_Kazakh_Card = "SELECT " +
                                       "SUM(" + Table_name_infe + ".Summa)" +
                                     " FROM " + Table_name_infe +
                                     " WHERE YEAR(" + Table_name_infe + ".Posting_date)=" + year +
                                      " AND MONTH(" + Table_name_infe + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Infe.Rows[device_id].ItemArray[0] + "') " +
                                 " AND " + Table_name_infe + ".Target_number not like '9417%'";

                                    SqlCommand command8 = new SqlCommand(query_Sum_Kazakh_Card, con);
                                    Summa_Infe_Halyk_Kazakh_card = Convert.ToDecimal(command8.ExecuteScalar());
                                    if (Summa_Infe_Halyk_Kazakh_card != 0)
                                    {
                                        Summa_Excel_Halyk_Kazakh_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 148, 19].Value);
                                        Summa_Excel_Halyk_Kazakh_card = Summa_Excel_Halyk_Kazakh_card + (Summa_Infe_Halyk_Kazakh_card / 1000);
                                        excelworksheet.Cells[region_id + 148, 19] = Summa_Excel_Halyk_Kazakh_card;
                                    }
                                }
                                // ---------------------------------------

                            }
                        }

                    }


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }


        }

        private void Make_calculations_Visa_Cash_page1(int month,int year)
        {
            try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();
                string Table_name = "";
                string Table_name_read = "";
                decimal Summa_Halyk_Kyrgyz_card = 0;
                decimal Summa_Halyk_Kazakh_card = 0;
                decimal Summa_Other_card = 0;
                decimal Count_Halyk_Kyrgyz_card = 0;
                decimal Count_Halyk_Kazakh_card = 0;
                decimal Count_Other_card = 0;
                decimal Summa_Excel_Halyk_Kyrgyz_card = 0;
                decimal Summa_Excel_Halyk_Kazakh_card = 0;
                decimal Summa_Excel_Other_card = 0;
                decimal Count_Excel_Halyk_Kyrgyz_card = 0;
                decimal Count_Excel_Halyk_Kazakh_card = 0;
                decimal Count_Excel_Other_card = 0;
                for (int table_id = 1; table_id <= 2; table_id++)
                {
                    if (table_id == 1)
                    {
                        Table_name = "tbl_ATM_Region";
                        Table_name_read = "tbl_Report_A";
                    }
                    else
                    { 
                        Table_name = "tbl_POS_Cash_Region";
                        Table_name_read = "tbl_Report_H";
                    }
                    for (int region_id = 1; region_id <= 8; region_id++)
                    {
                        System.Data.DataTable dt_Device_Visa = GetData_Device(Table_name, region_id,false);
                        if (dt_Device_Visa == null)
                        {
                            continue;
                        }
                        else
                        {
                            for (int device_id = 0; device_id < dt_Device_Visa.Rows.Count; device_id++)
                            {
                                //////////////////////////////////////
                                string query_Count_Halyk_Card = "SELECT " +
                                    "Count(" + Table_name_read + ".Account_amount)" +
                                    " FROM " + Table_name_read +
                                    " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                SqlCommand command1 = new SqlCommand(query_Count_Halyk_Card, con);
                                Count_Halyk_Kyrgyz_card = Convert.ToInt32(command1.ExecuteScalar());

                                if (Count_Halyk_Kyrgyz_card != 0)
                                {
                                    Count_Excel_Halyk_Kyrgyz_card = Convert.ToInt32(excelworksheet.Cells[region_id + 167, 16].Value);
                                    Count_Excel_Halyk_Kyrgyz_card = Count_Excel_Halyk_Kyrgyz_card + Count_Halyk_Kyrgyz_card;
                                    excelworksheet.Cells[region_id + 167, 16] = Count_Excel_Halyk_Kyrgyz_card;


                                    string query_Sum_Halyk_Card = "SELECT " +
                                    "SUM(" + Table_name_read + ".Account_amount)" +
                                  " FROM " + Table_name_read +
                                  " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                  " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                  " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                    SqlCommand command5 = new SqlCommand(query_Sum_Halyk_Card, con);
                                    Summa_Halyk_Kyrgyz_card = Convert.ToDecimal(command5.ExecuteScalar());
                                    if (Summa_Halyk_Kyrgyz_card != 0)
                                    {
                                        Summa_Excel_Halyk_Kyrgyz_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 167, 17].Value);
                                        Summa_Excel_Halyk_Kyrgyz_card = Summa_Excel_Halyk_Kyrgyz_card + (Summa_Halyk_Kyrgyz_card / 1000);
                                        excelworksheet.Cells[region_id + 167, 17] = Summa_Excel_Halyk_Kyrgyz_card;
                                    }
                                }
                                // ---------------------------------------
                                string query_Count_Other_Card = "SELECT " +
                                    "Count(" + Table_name_read + ".Account_amount)" +
                                    " FROM " + Table_name_read +
                                    " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_read + ".Type_of_card like '%LOCAL%'";

                                SqlCommand command2 = new SqlCommand(query_Count_Other_Card, con);
                                Count_Other_card = Convert.ToInt32(command2.ExecuteScalar());

                                if (Count_Other_card != 0)
                                {
                                    Count_Excel_Other_card = Convert.ToInt32(excelworksheet.Cells[region_id + 176, 16].Value);
                                    Count_Excel_Other_card = Count_Excel_Other_card + Count_Other_card;
                                    excelworksheet.Cells[region_id + 176, 16] = Count_Excel_Other_card;

                                    string query_Sum_Other_Card = "SELECT " +
                                       "SUM(" + Table_name_read + ".Account_amount)" +
                                     " FROM " + Table_name_read +
                                     " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                     " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                      " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_read + ".Type_of_card like '%LOCAL%'";

                                    SqlCommand command6 = new SqlCommand(query_Sum_Other_Card, con);
                                    Summa_Other_card = Convert.ToDecimal(command6.ExecuteScalar());
                                    if (Summa_Other_card != 0)
                                    {
                                        Summa_Excel_Other_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 176, 17].Value);
                                        Summa_Excel_Other_card = Summa_Excel_Other_card + (Summa_Other_card / 1000);
                                        excelworksheet.Cells[region_id + 176, 17] = Summa_Excel_Other_card;
                                    }
                                }
                                // ---------------------------------------
                                string query_Count_Kazakh_Card = "SELECT " +
                                 "Count(" + Table_name_read + ".Account_amount)" +
                                 " FROM " + Table_name_read +
                                 " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                 " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                 " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                  " AND " + Table_name_read + ".Type_of_card not like '%LOCAL%'"+
                                " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                SqlCommand command4 = new SqlCommand(query_Count_Kazakh_Card, con);
                                Count_Halyk_Kazakh_card = Convert.ToInt32(command4.ExecuteScalar());

                                if (Count_Halyk_Kazakh_card != 0)
                                {
                                    Count_Excel_Halyk_Kazakh_card = Convert.ToInt32(excelworksheet.Cells[region_id + 185, 16].Value);
                                    Count_Excel_Halyk_Kazakh_card = Count_Excel_Halyk_Kazakh_card + Count_Halyk_Kazakh_card;
                                    excelworksheet.Cells[region_id + 185, 16] = Count_Excel_Halyk_Kazakh_card;

                                    string query_Sum_Kazakh_Card = "SELECT " +
                                       "SUM(" + Table_name_read + ".Account_amount)" +
                                     " FROM " + Table_name_read +
                                     " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                      " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                   " AND " + Table_name_read + ".Type_of_card not like '%LOCAL%'" +
                                " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                    SqlCommand command8 = new SqlCommand(query_Sum_Kazakh_Card, con);
                                    Summa_Halyk_Kazakh_card = Convert.ToDecimal(command8.ExecuteScalar());
                                    if (Summa_Halyk_Kazakh_card != 0)
                                    {
                                        Summa_Excel_Halyk_Kazakh_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 185, 17].Value);
                                        Summa_Excel_Halyk_Kazakh_card = Summa_Excel_Halyk_Kazakh_card + (Summa_Halyk_Kazakh_card / 1000);
                                        excelworksheet.Cells[region_id + 185, 17] = Summa_Excel_Halyk_Kazakh_card;
                                    }
                                }
                            }
                         }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

        }

        private void Make_calculations_Visa_page1(int month, int year)
        {
            try
            {
                ConnectionString = sql.Get_Connection_String();
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();
                string Table_name_read = "tbl_Report_R";
                decimal Summa_Halyk_Kyrgyz_card = 0;
                decimal Summa_Halyk_Kazakh_card = 0;
                decimal Summa_Other_card = 0;
                decimal Count_Halyk_Kyrgyz_card = 0;
                decimal Count_Halyk_Kazakh_card = 0;
                decimal Count_Other_card = 0;
                decimal Summa_Excel_Halyk_Kyrgyz_card = 0;
                decimal Summa_Excel_Halyk_Kazakh_card = 0;
                decimal Summa_Excel_Other_card = 0;
                decimal Count_Excel_Halyk_Kyrgyz_card = 0;
                decimal Count_Excel_Halyk_Kazakh_card = 0;
                decimal Count_Excel_Other_card = 0;
                    for (int region_id = 1; region_id <= 8; region_id++)
                    {
                        System.Data.DataTable dt_Device_Visa = GetData_Device("tbl_POS_Region", region_id, false);
                        if (dt_Device_Visa == null)
                        {
                            continue;
                        }
                        else
                        {
                            for (int device_id = 0; device_id < dt_Device_Visa.Rows.Count; device_id++)
                            {
                                //////////////////////////////////////
                                string query_Count_Halyk_Card = "SELECT " +
                                    "Count(" + Table_name_read + ".Account_amount)" +
                                    " FROM " + Table_name_read +
                                    " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                SqlCommand command1 = new SqlCommand(query_Count_Halyk_Card, con);
                                Count_Halyk_Kyrgyz_card = Convert.ToInt32(command1.ExecuteScalar());

                                if (Count_Halyk_Kyrgyz_card != 0)
                                {
                                    Count_Excel_Halyk_Kyrgyz_card = Convert.ToInt32(excelworksheet.Cells[region_id + 167, 18].Value);
                                    Count_Excel_Halyk_Kyrgyz_card = Count_Excel_Halyk_Kyrgyz_card + Count_Halyk_Kyrgyz_card;
                                    excelworksheet.Cells[region_id + 167, 18] = Count_Excel_Halyk_Kyrgyz_card;


                                    string query_Sum_Halyk_Card = "SELECT " +
                                    "SUM(" + Table_name_read + ".Account_amount)" +
                                  " FROM " + Table_name_read +
                                  " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                  " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                  " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                    SqlCommand command5 = new SqlCommand(query_Sum_Halyk_Card, con);
                                    Summa_Halyk_Kyrgyz_card = Convert.ToDecimal(command5.ExecuteScalar());
                                    if (Summa_Halyk_Kyrgyz_card != 0)
                                    {
                                        Summa_Excel_Halyk_Kyrgyz_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 167, 19].Value);
                                        Summa_Excel_Halyk_Kyrgyz_card = Summa_Excel_Halyk_Kyrgyz_card + (Summa_Halyk_Kyrgyz_card / 1000);
                                        excelworksheet.Cells[region_id + 167, 19] = Summa_Excel_Halyk_Kyrgyz_card;
                                    }
                                }
                                // ---------------------------------------
                                string query_Count_Other_Card = "SELECT " +
                                    "Count(" + Table_name_read + ".Account_amount)" +
                                    " FROM " + Table_name_read +
                                    " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                    " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                    " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_read + ".Type_of_card like '%LOCAL%'";

                                SqlCommand command2 = new SqlCommand(query_Count_Other_Card, con);
                                Count_Other_card = Convert.ToInt32(command2.ExecuteScalar());

                                if (Count_Other_card != 0)
                                {
                                    Count_Excel_Other_card = Convert.ToInt32(excelworksheet.Cells[region_id + 176, 18].Value);
                                    Count_Excel_Other_card = Count_Excel_Other_card + Count_Other_card;
                                    excelworksheet.Cells[region_id + 176, 18] = Count_Excel_Other_card;

                                    string query_Sum_Other_Card = "SELECT " +
                                       "SUM(" + Table_name_read + ".Account_amount)" +
                                     " FROM " + Table_name_read +
                                     " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                     " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                      " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                    " AND " + Table_name_read + ".Type_of_card like '%LOCAL%'";

                                    SqlCommand command6 = new SqlCommand(query_Sum_Other_Card, con);
                                    Summa_Other_card = Convert.ToDecimal(command6.ExecuteScalar());
                                    if (Summa_Other_card != 0)
                                    {
                                        Summa_Excel_Other_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 176, 19].Value);
                                        Summa_Excel_Other_card = Summa_Excel_Other_card + (Summa_Other_card / 1000);
                                        excelworksheet.Cells[region_id + 176, 19] = Summa_Excel_Other_card;
                                    }
                                }
                                // ---------------------------------------
                                string query_Count_Kazakh_Card = "SELECT " +
                                 "Count(" + Table_name_read + ".Account_amount)" +
                                 " FROM " + Table_name_read +
                                 " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                 " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                 " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                  " AND " + Table_name_read + ".Type_of_card not like '%LOCAL%'" +
                                " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                SqlCommand command4 = new SqlCommand(query_Count_Kazakh_Card, con);
                                Count_Halyk_Kazakh_card = Convert.ToInt32(command4.ExecuteScalar());

                                if (Count_Halyk_Kazakh_card != 0)
                                {
                                    Count_Excel_Halyk_Kazakh_card = Convert.ToInt32(excelworksheet.Cells[region_id + 185, 18].Value);
                                    Count_Excel_Halyk_Kazakh_card = Count_Excel_Halyk_Kazakh_card + Count_Halyk_Kazakh_card;
                                    excelworksheet.Cells[region_id + 185, 18] = Count_Excel_Halyk_Kazakh_card;

                                    string query_Sum_Kazakh_Card = "SELECT " +
                                       "SUM(" + Table_name_read + ".Account_amount)" +
                                     " FROM " + Table_name_read +
                                     " WHERE YEAR(" + Table_name_read + ".Posting_date)=" + year +
                                      " AND MONTH(" + Table_name_read + ".Posting_date)=" + month +
                                   " AND (Device = '" + dt_Device_Visa.Rows[device_id].ItemArray[0] + "') " +
                                   " AND " + Table_name_read + ".Type_of_card not like '%LOCAL%'" +
                                " AND " + Table_name_read + ".Type_of_card like '%KYRGYZ%'";

                                    SqlCommand command8 = new SqlCommand(query_Sum_Kazakh_Card, con);
                                    Summa_Halyk_Kazakh_card = Convert.ToDecimal(command8.ExecuteScalar());
                                    if (Summa_Halyk_Kazakh_card != 0)
                                    {
                                        Summa_Excel_Halyk_Kazakh_card = Convert.ToDecimal(excelworksheet.Cells[region_id + 185, 19].Value);
                                        Summa_Excel_Halyk_Kazakh_card = Summa_Excel_Halyk_Kazakh_card + (Summa_Halyk_Kazakh_card / 1000);
                                        excelworksheet.Cells[region_id + 185, 19] = Summa_Excel_Halyk_Kazakh_card;
                                    }
                                }
                            }
                        }
                    }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

        }

        private System.Data.DataTable GetData_Device(string Table_name,int Region_Id,bool flag_infe)
        {
            ConnectionString = sql.Get_Connection_String();
            SqlConnection con = new SqlConnection(ConnectionString);
            System.Data.DataTable dt_Device = new System.Data.DataTable();
            string column = "";
            if (Table_name == "tbl_ATM_Region" && flag_infe==true)
                column = "Device_infe";
            else if(Table_name == "tbl_ATM_Region" && flag_infe == false)
                column = "Device";
            else
                column = "Device";
            try
            {
                con.Open();

                string query_device = "Select distinct "+ column+" from "+Table_name+" where Region_id="+Region_Id;
                SqlCommand comm_device = new SqlCommand(query_device, con);
                SqlDataAdapter da_device = new SqlDataAdapter(comm_device);
                DataSet ds_device = new DataSet();
                da_device.Fill(ds_device);
                dt_Device = ds_device.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                con.Close();
                return dt_Device;

        }
        //Освобождаем ресуры (закрываем Excel)
        void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
