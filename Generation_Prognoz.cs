using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Report_system
{
    class Generation_Prognoz
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelrange;
        private Excel.Sheets excelsheets;
        string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";
        public void Generation(string path)
        {
            try
            {
                excelapp = new Excel.Application();
                excelapp.SheetsInNewWorkbook = 2;
                //добавляем книгу
                excelworkbook = excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;
                excelsheets = excelworkbook.Worksheets;


                Check check_data = new Check();
                int check_A = check_data.Check_Data("tbl_Total_Device_Report_A");

                if (check_A > 0)
                {
                    excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                    excelworksheet.Activate();
                    excelworksheet.Cells[1,1] = " Банкомат";
                    excelworksheet.Cells[1, 2] = "Год";
                   

                    //Выгрузка данных
                    DataTable dt_Year = GetData_Year();
                    DataTable dt_Currency = GetData_Currency();
                    DataTable dt_Device = GetData_Device();

                    string column_Currency = "";
                    for(int i=0;i<dt_Currency.Rows.Count;i++)
                    {
                        column_Currency = "Сумма ("+dt_Currency.Rows[i].ItemArray[0].ToString()+")";
                        excelworksheet.Cells[1, i + 3] = column_Currency;
                    }
                    int yearInd = 0;
                    int deviceInd = 0;
                    int currencyInd = 0;
                    decimal sum;
                    string device = "";
                    string currency = "";
                    int year = 0;

                    //заполняем строки
                    for (deviceInd = 0; deviceInd < dt_Device.Rows.Count; deviceInd++)
                    {
                        for (yearInd = 0; yearInd < dt_Year.Rows.Count; yearInd++)
                        {
                            for (currencyInd = 0; currencyInd < dt_Currency.Rows.Count; currencyInd++)
                            {
                                device = dt_Device.Rows[deviceInd].ItemArray[0].ToString();
                                //MessageBox.Show(device);
                                currency = dt_Currency.Rows[currencyInd].ItemArray[0].ToString();
                               // MessageBox.Show(currency);
                                year = Convert.ToInt32(dt_Year.Rows[yearInd].ItemArray[0]);
                               // MessageBox.Show(year.ToString());

                                DataTable dt = GetData(device,year,currency);
                                if (dt == null)
                                {
                                    excelworksheet.Cells[yearInd + 2, currencyInd + 3] = 0;
                                }
                                else
                                {
                                    sum = Convert.ToDecimal(dt.Rows[0].ItemArray[0]);
                                    excelworksheet.Cells[yearInd + 2, currencyInd + 3] = sum;
                                }
                                excelworksheet.Cells[yearInd + 2, 2] = year;
                                excelworksheet.Cells[yearInd + 2,1] = device;
                            }
                        }
                    }
                    //Add_data("tbl_Report_A", 1, month, year);
                    //Make_calculations(1);
                    Draw_line(1);

                }
                

            }
            catch (Exception ex)
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

                //excelapp.DefaultFilePath = path;
                // excelworkbook.Saved = true;
                //excelworkbook.SaveAs(path);

                ////Отсоединяемся от Excel
                //ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelsheets);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                MessageBox.Show("Успешно сформирован отчет");
                GC.Collect();

            }
        }

        private DataTable GetData(string device,int year,string currency)
        {
            string Table_name = "tbl_Total_Device_Report_A";
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt= new DataTable();
            try
            {
                con.Open();
                string query = "SELECT " +
                    "SUM(" + Table_name + ".Account_amount)" +
                     " FROM " + Table_name +
                     " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                     " AND (Device = '" + device + "') " +
                     " AND (Currency = '" + currency + "') ";
                // MessageBox.Show(query);
                SqlCommand comm = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                if (dt != null)
                {
                    return dt;
                }
                else 
                    return null;
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
           
        }

        private DataTable GetData_Device()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt_Device = new DataTable();
            try
            {
                con.Open();

                string query_device = "SELECT DISTINCT Device AS 'Банкомат' FROM dbo.tbl_Total_Device_Report_A";
                SqlCommand comm_device = new SqlCommand(query_device, con);
                SqlDataAdapter da_device = new SqlDataAdapter(comm_device);
                DataSet ds_device = new DataSet();
                da_device.Fill(ds_device);
                dt_Device = ds_device.Tables[0];


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt_Device;
        }

        private DataTable GetData_Year()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            int year = DateTime.Now.Year;
            DataTable dt_Year = new DataTable();
            //MessageBox.Show(year.ToString());
            try
            {
                con.Open();

                string query_year = "SELECT DISTINCT YEAR(Posting_date) FROM dbo.tbl_Total_Device_Report_A"+
                    " WHERE Year(Posting_date)<"+year;
                SqlCommand comm_year = new SqlCommand(query_year, con);
                SqlDataAdapter da_year = new SqlDataAdapter(comm_year);
                DataSet ds_year = new DataSet();
                da_year.Fill(ds_year);
                dt_Year = ds_year.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt_Year;
        }

        private DataTable GetData_Currency()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            int year = DateTime.Now.Year;
            DataTable dt_Currency = new DataTable();
            try
            {
                con.Open();

                string query_currency = "SELECT DISTINCT Currency AS 'Валюта' FROM dbo.tbl_Total_Device_Report_A";
                SqlCommand comm_currency = new SqlCommand(query_currency, con);
                SqlDataAdapter da_currency = new SqlDataAdapter(comm_currency);
                DataSet ds_currency = new DataSet();
                da_currency.Fill(ds_currency);
                dt_Currency = ds_currency.Tables[0];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt_Currency;
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

        private void Draw_line(int number_of_page)
        {
            try
            {
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
                excelworksheet.Activate();
                ////Название листа
                excelworksheet.Name = "Банкоматы";
                //выделяем первую строку
                excelrange = excelworksheet.get_Range("A1:E1", Type.Missing);

                //делаем полужирный текст и перенос слов
                excelrange.WrapText = true;
                excelrange.Font.Bold = true;
                //выбираем всю область данных
                excelrange = excelworksheet.UsedRange;


                //выравниваем строки и колонки по их содержимому
                excelrange.Columns.AutoFit();
                excelrange.Rows.AutoFit();
                excelrange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                excelrange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
                excelrange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                excelrange.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous;
                excelrange.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous;
                excelrange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReleaseObject(excelrange);
            }
        }

    }
    }
