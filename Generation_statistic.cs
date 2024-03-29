﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;


namespace Report_system
{
    class Generation_statistic
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelrange;
        private Excel.Sheets excelsheets;
        private string device = "";
        private string Table_name = "";
        private string name = "";
        Connection sql = new Connection();
        string ConnectionString = "";
        public void Generation(string path, string report, int year,string column)
        {
            try
            {
                Find_Table_name(report, column);
                excelapp = new Excel.Application();
                excelapp.SheetsInNewWorkbook = 2;
                //добавляем книгу
                excelworkbook = excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;
                //выбираем лист на котором будем работать (Лист 1)
                excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];
                excelsheets = excelworkbook.Worksheets;
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();

                //Название листа
                excelworksheet.Name = "Лист 1";
               // excelsheets = excelapp.Worksheets;


                //Выгрузка данных
                DataTable dt = GetData(Table_name, year,column,false);
                int collInd = 0;
                int rowInd = 0;
                string data = "";
                decimal data2;

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[2, i + 1] = data;
                }

                excelrange = excelworksheet.get_Range("A1:C1", Type.Missing);
                excelrange.Merge(Type.Missing);
                excelworksheet.Cells[1,1] = "Статистика по совершенным операциям в " + device + " по " + name + " за " + year + " год.";
                

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        if (collInd == 1)
                        {
                            data2 = Convert.ToDecimal(dt.Rows[rowInd].ItemArray[collInd]);
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data2;
                        }
                        else if(column== "Device" && collInd==0)
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString()+"b";
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data;
                        }
                        else
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString() ;
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data;
                        }

                    }
                }
               // excelworksheet.get_Range("A2", "A" + excelworksheet.UsedRange.Rows.Count.ToString()).NumberFormat = "Текстовый";
                Make_calculations(dt.Rows.Count,1);
                Draw_line(1);
                excelworksheet.Cells[1, 1].Rows.RowHeight = 70;


                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(2);
                excelworksheet.Activate();

                DataTable dt2 = GetData(Table_name, year, column, true);

                //называем колонки
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    data = dt2.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[2, i + 1] = data;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt2.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt2.Columns.Count; collInd++)
                    {
                        if (collInd == 1)
                        {
                            data2 = Convert.ToDecimal(dt2.Rows[rowInd].ItemArray[collInd]);
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data2;
                        }
                        else 
                        {
                            data = dt2.Rows[rowInd].ItemArray[collInd].ToString();
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data;
                        }
                    }
                }
                Make_calculations(dt2.Rows.Count,2);
                Draw_line(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp); 
                ReleaseObject(excelsheets);
            }
            finally
            {

                //Показываем ексель
                excelapp.Visible = true;

                excelapp.Interactive = true;
                excelapp.ScreenUpdating = true;
                excelapp.UserControl = true;
                Draw_Chart(column);

                // Make_calculations();
                //excelapp.DefaultFilePath = path;
                excelworkbook.Saved = true;
                excelworkbook.SaveAs(path);

                ////Отсоединяемся от Excel
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                ReleaseObject(excelsheets);
                MessageBox.Show("Успешно сформирован отчет");
                GC.Collect();

            }

        }

        public void Generation(string path, string report, int month,int month2, int year,string column)
        {
            try
            {
                Find_Table_name(report, column);

                excelapp = new Excel.Application();
                //добавляем книгу
                excelworkbook = excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;

                excelapp.SheetsInNewWorkbook = 2;
                //выбираем лист на котором будем работать (Лист 1)
                excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];
                excelsheets = excelworkbook.Worksheets;
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();

                //Название листа
                excelworksheet.Name = "Лист 1";

                excelrange = excelworksheet.get_Range("A1:C1", Type.Missing);
                excelrange.Merge(Type.Missing);
                excelworksheet.Cells[1, 1] = "Статистика по совершенным операциям"+ " в " + device + " по " + name + " за период времени с " +
                    month + "." + year + " по " + month2 + "." + year; ;

                //Выгрузка данных
                DataTable dt = GetData(Table_name, month,month2, year,column,false);
                int collInd = 0;
                int rowInd = 0;
                string data = "";
                decimal data2;

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[2, i + 1] = data;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        if (collInd == 1)
                        {
                            data2 = Convert.ToDecimal(dt.Rows[rowInd].ItemArray[collInd]);
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data2;
                        }
                        else if(column=="Device" && collInd==0)
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString()+"b";
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data;
                        }
                        else
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data;
                        }
                    }
                }
                Make_calculations(dt.Rows.Count,1);
                Draw_line(1);
                excelworksheet.Cells[1, 1].Rows.RowHeight = 100;

                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(2);
                excelworksheet.Activate();

                DataTable dt2 = GetData(Table_name, month, month2, year, column, true);

                //называем колонки
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    data = dt2.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[2, i + 1] = data;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt2.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt2.Columns.Count; collInd++)
                    {
                        if (collInd == 1)
                        {
                            data2 = Convert.ToDecimal(dt2.Rows[rowInd].ItemArray[collInd]);
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data2;
                        }
                        else
                        {
                            data = dt2.Rows[rowInd].ItemArray[collInd].ToString();
                            excelworksheet.Cells[rowInd + 3, collInd + 1] = data;
                        }
                    }
                }
                Make_calculations(dt2.Rows.Count, 2);
                Draw_line(2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp); 
                ReleaseObject(excelsheets);
            }
            finally
            {

                //Показываем ексель
                excelapp.Visible = true;

                excelapp.Interactive = true;
                excelapp.ScreenUpdating = true;
                excelapp.UserControl = true;

                Draw_Chart(column);
                //excelapp.DefaultFilePath = path;
                excelworkbook.Saved = true;
                excelworkbook.SaveAs(path);

                ////Отсоединяемся от Excel
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                ReleaseObject(excelsheets);
                MessageBox.Show("Успешно сформирован отчет");
                GC.Collect();

            }
        }

       
        private DataTable GetData(string Table_name, int year,string column,bool flag_full_data)
        {
            string title = "";
            if (column == "Currency")
                title = "Валюта";
            else if (column == "Type_of_card")
                title = "Вид карты";
            else if (column == "Device")
                title = "Место операции";
            //строка соединения
            ConnectionString = sql.Get_Connection_String();
            SqlConnection con = new SqlConnection(ConnectionString);

            DataTable dt = new DataTable();
            string query = "";
            try
            {
                con.Open();
                if (flag_full_data == false)
                {
                    if(Table_name=="tbl_Report_Infe")
                    {
                        query = "SELECT " +
                     Table_name + "." + column + " AS \"" + title + "\", " +
                    "SUM(" + Table_name + ".Summa) AS \"Сумма\"" +
                     " FROM " + Table_name +
                     " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                     " GROUP BY " + Table_name + "." + column +
                     " ORDER BY Сумма DESC";
                    }
                    else
                      query = "SELECT " +
                      Table_name + "." + column + " AS \"" + title + "\", " +
                     "SUM(" + Table_name + ".Account_amount) AS \"Сумма\"," +
                      "SUM(" + Table_name + ".Number_of_trans) AS \"Количество совершенных операций\" " +
                      " FROM " + Table_name +
                      " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                      " GROUP BY " + Table_name + "." + column +
                      " ORDER BY Сумма DESC";
                }
                else if(flag_full_data==true)
                {
                    if (Table_name == "tbl_Report_Infe")
                    {
                        query = "SELECT " +
                        Table_name + "." + column + " AS \"" + title + "\", " +
                        Table_name + ".Summa AS \"Сумма\"" +
                        " FROM " + Table_name +
                        " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                        " ORDER BY " + column;
                    }
                    else
                        query = "SELECT " +
                       Table_name + "." + column + " AS \"" + title + "\", " +
                       Table_name + ".Account_amount AS \"Сумма\"," +
                       Table_name + ".Number_of_trans AS \"Количество совершенных операций\" " +
                       " FROM " + Table_name +
                       " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                       " ORDER BY " + column;
                }
                SqlCommand comm = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
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
            return dt;
        }

        private DataTable GetData(string Table_name, int month,int month2, int year,string column,bool flag_full_data)
        {
            string title = "";
            if (column == "Currency")
                title = "Валюта";
            else if (column == "Type_of_card")
                title = "Вид карты";
            else if (column == "Device")
                title = "Место операции";
            //строка соединения
            ConnectionString = sql.Get_Connection_String();
            SqlConnection con = new SqlConnection(ConnectionString);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                string query;
                if (flag_full_data == false)
                {
                    if (Table_name == "tbl_Report_Infe")
                    {
                        query = "SELECT " +
                       Table_name + "." + column + " AS \"" + title + "\", " +
                       "SUM(" + Table_name + ".Summa) AS \"Сумма\"" +
                       " FROM " + Table_name +
                       " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                       "AND MONTH(" + Table_name + ".Posting_date)>=" + month +
                       "AND MONTH(" + Table_name + ".Posting_date)<=" + month2 +
                       " GROUP BY " + Table_name + "." + column +
                      " ORDER BY Сумма DESC";
                    }
                    else
                        query = "SELECT " +
                           Table_name + "." + column + " AS \"" + title + "\", " +
                           "SUM(" + Table_name + ".Account_amount) AS \"Сумма\"," +
                           "SUM(" + Table_name + ".Number_of_trans) AS \"Количество совершенных операций\" " +
                           " FROM " + Table_name +
                           " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                           "AND MONTH(" + Table_name + ".Posting_date)>=" + month +
                           "AND MONTH(" + Table_name + ".Posting_date)<=" + month2 +
                           " GROUP BY " + Table_name + "." + column +
                          " ORDER BY Сумма DESC";
                }
                else
                {
                    if (Table_name == "tbl_Report_Infe")
                    {
                        query = "SELECT " +
                        Table_name + "." + column + " AS \"" + title + "\", " +
                        Table_name + ".Summa AS \"Сумма\"" +
                        " FROM " + Table_name +
                        " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                        "AND MONTH(" + Table_name + ".Posting_date)>=" + month +
                        "AND MONTH(" + Table_name + ".Posting_date)<=" + month2 +
                       " ORDER BY " + column;
                    }
                    else
                        query = "SELECT " +
                           Table_name + "." + column + " AS \"" + title + "\", " +
                           Table_name + ".Account_amount AS \"Сумма\"," +
                           Table_name + ".Number_of_trans AS \"Количество совершенных операций\" " +
                           " FROM " + Table_name +
                           " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                           "AND MONTH(" + Table_name + ".Posting_date)>=" + month +
                           "AND MONTH(" + Table_name + ".Posting_date)<=" + month2 +
                          " ORDER BY " + column;
                }
                SqlCommand comm = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
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
            return dt;
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


        private void Make_calculations(int rows_count,int number_of_page)
        {
            try
            {
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
                excelworksheet.Activate();
                string formula = "=СУММ(B3:B"+(rows_count+2)+ ")";
                excelworksheet.Cells[(rows_count + 3), 2].FormulaLocal = formula;
                excelworksheet.Cells[(rows_count + 3), 2].Interior.Color = Color.Red;
                if (Table_name != "tbl_Report_Infe")
                {
                    string formula2 = "=СУММ(C3:C" + (rows_count + 2) + ")";
                    excelworksheet.Cells[(rows_count + 3), 3].FormulaLocal = formula2;
                    excelworksheet.Cells[(rows_count + 3), 3].Interior.Color = Color.Red;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }


        }

        private void InsertRow(int rowNum)
        {
            try
            {
                Excel.Range cellRange = (Excel.Range)excelworksheet.Cells[rowNum, 1];
                Excel.Range rowRange = cellRange.EntireRow;
                rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Draw_Chart(string column)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                excelsheets = excelworkbook.Worksheets;
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();

                Excel.Range chartRange;
                chartRange = excelworksheet.get_Range("A3", "B" + Convert.ToString(excelworksheet.UsedRange.Rows.Count - 1));
                // Определяем диаграммы как объекты Excel.ChartObjects
                Excel.ChartObjects chartsobjrcts =
                  (Excel.ChartObjects)excelworksheet.ChartObjects(Type.Missing);
                //Добавляем одну диаграмму  в Excel.ChartObjects - диаграмма пока 
                //не выбрана, но место для нее выделено в методе Add
                Excel.ChartObject chartsobjrct = chartsobjrcts.Add(400, 20, 500, 350);
                chartsobjrct.Chart.ChartWizard(chartRange, Excel.XlChartType.xlColumnClustered
                , 2, Excel.XlRowCol.xlColumns, Type.Missing,
                  0, true, "Статистика по " + name, column, "Сумма", Type.Missing);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //xlWorkBook.Close(true, misValue, misValue);


            //excelworksheet.get_Range("A3", "B10")

        }
        private void Draw_line(int number_of_page)
        {
            try
            {
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
                excelworksheet.Activate();
                //выделяем первую строку
                excelrange = excelworksheet.get_Range("A1:C2", Type.Missing);
                //делаем полужирный текст и перенос слов
                excelrange.WrapText = true;
                excelrange.Font.Bold = true;

                excelrange = excelworksheet.get_Range("A1:C1", Type.Missing);
                //размер шрифта
                excelrange.Font.Size = 16;
                //название шрифта
                excelrange.Font.Name = "Times New Roman";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Find_Table_name(string report,string column)
        {
            if (report == "Report A")
            {
                device = "банкомате";
                if (column == "Type_of_card" || column == "Currency")
                    Table_name = "tbl_Report_A";
                else if (column == "Device")
                    Table_name = "tbl_Total_Device_Report_A";
            }
            else if (report == "Report H")
            {
                device = "POS-терминале";
                if (column == "Type_of_card" || column == "Currency")
                    Table_name = "tbl_Report_H";
                else if (column == "Device")
                    Table_name = "tbl_Total_Device_Report_H";
            }
            else if (report == "Report R")
            {
                device = "POS-терминале";
                 if (column == "Type_of_card" || column == "Currency")
                    Table_name = "tbl_Report_R";
                else if (column == "Device")
                    Table_name = "tbl_Total_Device_Report_R";
            }
            else if (report == "Report Infe")
            {
                device = "по Элкарт";
                Table_name = "tbl_Report_Infe";
            }
            if (column == "Currency")
                name = "валюте";
            else if (column == "Type_of_card")
                name = "видам карт";
            else if (column == "Device")
                name = "месту операции";
        }
    }
}
