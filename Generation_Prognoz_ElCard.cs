using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Report_system
{
    class Generation_Prognoz_ElCard
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        private Excel.Worksheet excelworksheet;
        private Excel.Worksheet excelworksheet_page2;
        private Excel.Worksheet excelworksheet_page1;
        private Excel.Range excelrange;
        private Excel.Sheets excelsheets;
        Connection sql = new Connection();
        private string ConnectionString = "";
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

                excelworksheet_page1 = excelworkbook.Sheets.get_Item(1);
                excelworksheet_page2 = excelworkbook.Sheets.get_Item(2);


                Check check_data = new Check();
                int check_infe = check_data.Check_Data("tbl_Report_Infe");

                if (check_infe > 0)
                {
                    excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                    excelworksheet.Activate();

                   

                    //Выгрузка данных
                    DataTable dt_Year = GetData_Year();
                    DataTable dt_Currency = GetData_Currency();
                    DataTable dt_Device = GetData_Device();

                    Add_Column_Name(1, dt_Currency);
                    Add_Column_Name(2, dt_Currency);


                    int yearInd = 0;
                    int deviceInd = 0;
                    int currencyInd = 0;
                    decimal sum;
                    string device = "";
                    string currency = "";
                    int year = 0;
                    int rowInd = 1;
                    int deviceIndex_Changed = 0;
                    int rowInd_start = 1;
                    int rowInd_end = 0;
                    string column = "";
                    int month_now = DateTime.Now.Month;
                    int year_prognoz = DateTime.Now.Year;
                    int rowInd_page2 = 2;
                    if(month_now>=11)
                    {
                        year_prognoz++;
                    }
                    //заполняем строки
                    for (deviceInd = 0; deviceInd < dt_Device.Rows.Count; deviceInd++)
                    {
                        for (yearInd = 0; yearInd < dt_Year.Rows.Count; yearInd++)
                        {
                            for (currencyInd = 0; currencyInd < dt_Currency.Rows.Count; currencyInd++)
                            {
                                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                                excelworksheet.Activate();
                                if (deviceIndex_Changed != deviceInd || ((deviceInd==(dt_Device.Rows.Count-1)) && (currencyInd==(dt_Currency.Rows.Count-1)) && (yearInd==dt_Year.Rows.Count-1) ))
                                    {
                                        rowInd_end = rowInd;
                                        rowInd++;
                                        InsertRow(rowInd);
                                        InsertRow(rowInd + 1);
                                        deviceIndex_Changed = deviceInd;
                                        excelworksheet.Cells[rowInd, 2] = year_prognoz;
                                        excelworksheet.Cells[rowInd, 1] = "Прогноз";
                                    
                                    for(int i=0;i<dt_Currency.Rows.Count;i++)
                                    {
                                        if (i == 0) column = "C";
                                        else if (i == 1) column = "D";
                                        else if (i == 2) column = "E";
                                        else if (i == 2) column = "F";
                                       
                                        string formula = "=ПРЕДСКАЗ.ЛИНЕЙН(B"+rowInd.ToString()+";"+ column + rowInd_start.ToString() + ":" + column + (rowInd_end.ToString()) +";B"+rowInd_start.ToString()+":B"+rowInd_end.ToString()+ ")";
                                        excelworksheet.Cells[rowInd, i+3].FormulaLocal = formula;
                                    }
                                    excelworksheet_page2.Cells[rowInd_page2, 1] = device;
                                    excelworksheet_page1.Range["B" + rowInd.ToString() + ":F" + rowInd.ToString()].Copy(); //копируем диапазон ячеек
                                    //вставляем скопированные данные в новую книгу 
                                    excelworksheet_page2.Range["B" + rowInd_page2.ToString() + ":F" + rowInd_page2.ToString()].PasteSpecial(Excel.XlPasteType.xlPasteValues); //вставить только значения
                                    rowInd_page2++;

                                    excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                                    excelworksheet.Activate();
                                    //выделяем первую строку
                                    excelrange = excelworksheet.get_Range("A"+rowInd+":" + column + rowInd, Type.Missing);
                                    excelrange.Interior.Color = Color.Yellow;
                                    rowInd++; ;
                                    rowInd_start = rowInd;
                                    rowInd_end = 0;
                                    if((deviceInd == (dt_Device.Rows.Count - 1)) && (currencyInd == (dt_Currency.Rows.Count - 1)) && (yearInd == dt_Year.Rows.Count - 1))
                                    {
                                        break;
                                    }
                                    }

                                        device = dt_Device.Rows[deviceInd].ItemArray[0].ToString();
                                        currency = dt_Currency.Rows[currencyInd].ItemArray[0].ToString();
                                        year = Convert.ToInt32(dt_Year.Rows[yearInd].ItemArray[0]);
                                        sum = GetData(device, year, currency);

                                        if (currencyInd == 0)
                                        {
                                            rowInd++;
                                        }
                                        excelworksheet.Cells[rowInd, currencyInd + 3] = sum;
                                        excelworksheet.Cells[rowInd, 2] = year;
                                        excelworksheet.Cells[rowInd, 1] = device;

                                }
                            }
                       
                    }
                    Draw_line(1);
                    Draw_line(2);

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
                excelworkbook.Saved = true;
                excelworkbook.SaveAs(path);

                ////Отсоединяемся от Excel
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelsheets);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                MessageBox.Show("Успешно сформирован прогноз");
                GC.Collect();

            }
        }

        private void Add_Column_Name(int number_of_page,DataTable dt_Currency)
        {
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
            excelworksheet.Activate();
            excelworksheet.Cells[1, 1] = " Место операции";
            excelworksheet.Cells[1, 2] = "Год";
            string column_Currency = "";
            for (int i = 0; i < dt_Currency.Rows.Count; i++)
            {
                column_Currency = "Сумма (" + dt_Currency.Rows[i].ItemArray[0].ToString() + ")";
                excelworksheet.Cells[1, i + 3] = column_Currency;
            }
        }
        private Decimal GetData(string device,int year,string currency)
        {
            string Table_name = "tbl_Report_Infe";
            ConnectionString = sql.Get_Connection_String();
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt= new DataTable();
            decimal sum = 0;
            try
            {
                con.Open();
                string query2 = "SELECT " +
                   "Count(" + Table_name + ".Summa)" +
                    " FROM " + Table_name +
                    " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                    " AND (Device = '" + device + "') " +
                    " AND (Currency = '" + currency + "') ";
                SqlCommand command = new SqlCommand(query2, con);
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count > 0)
                {
                    string query = "SELECT " +
                      "SUM(" + Table_name + ".Summa)" +
                       " FROM " + Table_name +
                       " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                       " AND (Device = '" + device + "') " +
                       " AND (Currency = '" + currency + "') ";
                    SqlCommand command2 = new SqlCommand(query, con);
                    sum = Convert.ToDecimal(command2.ExecuteScalar());
                }
                else
                {
                    sum = 0;
                }
                con.Close();
                
            }
            catch (SqlException ex)
            {
               
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return sum;
        }

        private DataTable GetData_Device()
        {
            ConnectionString = sql.Get_Connection_String();
            SqlConnection con = new SqlConnection(ConnectionString);
            DataTable dt_Device = new DataTable();
            try
            {
                con.Open();

                string query_device = "SELECT DISTINCT Device AS 'Банкомат' FROM dbo.tbl_Report_Infe";
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
            ConnectionString = sql.Get_Connection_String();
            SqlConnection con = new SqlConnection(ConnectionString);
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if(month>=11)
            {
                year++;
            }
            DataTable dt_Year = new DataTable();
            //MessageBox.Show(year.ToString());
            try
            {
                con.Open();

                string query_year = "SELECT DISTINCT YEAR(Posting_date) FROM dbo.tbl_Report_Infe" +
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
            ConnectionString = sql.Get_Connection_String();
            SqlConnection con = new SqlConnection(ConnectionString);
            int year = DateTime.Now.Year;
            DataTable dt_Currency = new DataTable();
            try
            {
                con.Open();

                string query_currency = "SELECT DISTINCT Currency AS 'Валюта' FROM dbo.tbl_Report_Infe";
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
                //Название листа
               // excelworksheet.Name = "Банкоматы";
                DataTable dt_Currency = GetData_Currency();
                string column = "";
                for (int i = 0; i < dt_Currency.Rows.Count; i++)
                {
                    if (i == 0) column = "C";
                    else if (i == 1) column = "D";
                    else if (i == 2) column = "E";
                    else if (i == 2) column = "F";
                }
                //выделяем первую строку
                excelrange = excelworksheet.get_Range("A1:"+column+"1", Type.Missing);


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

        public void InsertRow(int rowNum)
        {
            Excel.Range cellRange = (Excel.Range)excelworksheet.Cells[rowNum, 1];
            Excel.Range rowRange = cellRange.EntireRow;
            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
        }

    }
    }
