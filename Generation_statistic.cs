using System;
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

        public void Generation(string path, string report, int year,string column)
        {
            try
            {
                string Table_name = "";
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
                excelapp = new Excel.Application();
                //добавляем книгу
                excelworkbook = excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];
                //Название листа
                excelworksheet.Name = "Лист 1";

                //Выгрузка данных
                DataTable dt = GetData(Table_name, year,column);
                int collInd = 0;
                int rowInd = 0;
                string data = "";
                decimal data2;

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[1, i + 1] = data;
                }
                //выделяем первую строку
                excelrange = excelworksheet.get_Range("A1:C1", Type.Missing);

                //делаем полужирный текст и перенос слов
                excelrange.WrapText = true;
                excelrange.Font.Bold = true;

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        if (collInd == 2)
                        {
                            data2 = Convert.ToDecimal(dt.Rows[rowInd].ItemArray[collInd]);
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data2;
                        }
                        else
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data;
                        }
                    }
                }

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
                MessageBox.Show(ex.ToString());
            }
            finally
            {

                //Показываем ексель
                excelapp.Visible = true;

                excelapp.Interactive = true;
                excelapp.ScreenUpdating = true;
                excelapp.UserControl = true;

                // Make_calculations();
                //excelapp.DefaultFilePath = path;
                // excelworkbook.Saved = true;
                //excelworkbook.SaveAs(path);

                ////Отсоединяемся от Excel
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                MessageBox.Show("Успешно сформирован отчет");
                GC.Collect();

            }

        }

        public void Generation(string path, string report, int month,int month2, int year,string column)
        {
            try
            {
                string Table_name = "";
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
                excelapp = new Excel.Application();
                //добавляем книгу
                excelworkbook = excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];
                //Название листа
                excelworksheet.Name = "Лист 1";


                //Выгрузка данных
                DataTable dt = GetData(Table_name, month,month2, year,column);
                int collInd = 0;
                int rowInd = 0;
                string data = "";
                decimal data2;

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[1, i + 1] = data;
                }
                //выделяем первую строку
                excelrange = excelworksheet.get_Range("A1:C1", Type.Missing);

                //делаем полужирный текст и перенос слов
                excelrange.WrapText = true;
                excelrange.Font.Bold = true;

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        if (collInd == 2)
                        {
                            data2 = Convert.ToDecimal(dt.Rows[rowInd].ItemArray[collInd]);
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data2;
                        }
                        else
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data;
                        }
                    }
                }

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
                MessageBox.Show(ex.ToString());
            }
            finally
            {

                //Показываем ексель
                excelapp.Visible = true;

                excelapp.Interactive = true;
                excelapp.ScreenUpdating = true;
                excelapp.UserControl = true;

                // Make_calculations();
                //excelapp.DefaultFilePath = path;
                // excelworkbook.Saved = true;
                //excelworkbook.SaveAs(path);

                ////Отсоединяемся от Excel
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                MessageBox.Show("Успешно сформирован отчет");
                GC.Collect();

            }
        }
        private DataTable GetData(string Table_name, int year,string column)
        {
            string name = "";
            if (column == "Currency")
                name = "Валюта";
            else if (column == "Type_of_card")
                name = "Вид карты";
            else if (column == "Device")
                name = "Место операции";
            //строка соединения
            string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";

            SqlConnection con = new SqlConnection(ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                string query = "SELECT " +
                    Table_name + "."+column+ " AS \""+name+"\", " +
                    "SUM("+Table_name + ".Number_of_trans) AS \"Количество совершенных операций\", " +
                     "SUM(" + Table_name + ".Account_amount) AS \"Сумма\"" +
                    " FROM " + Table_name +
                    " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                    " GROUP BY "+Table_name+"."+column+
                    " ORDER BY Сумма DESC";
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

        private DataTable GetData(string Table_name, int month,int month2, int year,string column)
        {
            string name = "";
            if (column == "Currency")
                name = "Валюта";
            else if (column == "Type_of_card")
                name = "Вид карты";
            else if (column == "Device")
                name = "Место операции";
            //строка соединения
            string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";

            SqlConnection con = new SqlConnection(ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                string query = "SELECT " +
                     Table_name + "."+column+ " AS \"" + name + "\", " +
                     "SUM(" + Table_name + ".Number_of_trans) AS \"Количество совершенных операций\", " +
                      "SUM(" + Table_name + ".Account_amount) AS \"Сумма\"" +
                     " FROM " + Table_name +
                     " WHERE YEAR(" + Table_name + ".Posting_date)=" + year +
                     "AND MONTH("+Table_name+".Posting_date)>="+month+
                     "AND MONTH(" + Table_name + ".Posting_date)<=" + month2 + 
                     " GROUP BY " + Table_name + "." + column +
                     " ORDER BY " + Table_name + ".Account_amount";
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


        private void Make_calculations()
        {
            try
            {
                // Откройте рабочую книгу только для чтения.
                //excelworkbook = excelapp.Workbooks.Open(path);

                // Получить первый рабочий лист.
                excelworksheet = (Excel.Worksheet)excelworkbook.Sheets[1];
                int rowInd;
                int row_end = 0;//строка окончания даты
                int row_start = 2;//строка с новой датой
                string date = excelworksheet.Cells[2, 1].Text;//дата взятая с ячейки excel
                int usedRowsNum = excelworksheet.UsedRange.Rows.Count; //все используемые строки excel
                for (rowInd = 1; rowInd < (usedRowsNum + 1); rowInd++)
                {
                    int collInd;
                    for (collInd = 1; collInd <= 1; collInd++)
                    {
                       
                        if ((excelworksheet.Cells[rowInd + 1, 1]).Text != date)
                        {
                            row_end = rowInd + 1;
                            usedRowsNum = usedRowsNum + 3;
                            InsertRow(row_end);
                            InsertRow(row_end + 1);
                            InsertRow(row_end + 2);
                            string formula = "=СУММ(D" + row_start + ":D" + (row_end - 1) + ")";
                            string formula2 = "=СУММ(B" + row_start + ":B" + (row_end - 1) + ")";
                            excelworksheet.Cells[row_end, 4].FormulaLocal = formula;
                            excelworksheet.Cells[row_end, 2].FormulaLocal = formula2;
                            excelworksheet.Cells[row_end, 2].Interior.Color = Color.Red;
                            excelworksheet.Cells[row_end, 4].Interior.Color = Color.Red;
                            date = excelworksheet.Cells[row_end + 3, 1].Text;
                            row_start = row_end + 3;
                            rowInd += 2;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                GC.Collect();
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
