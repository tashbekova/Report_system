﻿using System;
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
    class Generation_intermediate_report_Elcart
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelrange;
        private Excel.Sheets excelsheets;

        public void Generation(string path, int month, int year)
        {
            try
            {
                excelapp = new Excel.Application();
                excelapp.SheetsInNewWorkbook = 1;
                //добавляем книгу
                excelworkbook = excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;
                excelsheets = excelworkbook.Worksheets;

                Check check_data = new Check();
                int check = check_data.Check_Data("tbl_Report_Infe", month, year);

                if (check > 0)
                {
                    Add_data("tbl_Report_Infe", 1, month, year);
                    Make_calculations(1);
                    Draw_line(1);

                }
                MessageBox.Show("Успешно сформирован отчет");
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
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelsheets);
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
               
                GC.Collect();

            }
        }

        private void Draw_line(int number_of_page)
        {
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
            excelworksheet.Activate();
            ////Название листа
            excelworksheet.Name = "Элкарт";
            //выделяем первую строку
            excelrange = excelworksheet.get_Range("A1:H1", Type.Missing);
            excelworksheet.get_Range("G2", "G" + excelworksheet.UsedRange.Rows.Count).NumberFormat = "0";
            excelworksheet.get_Range("D2", "E" + excelworksheet.UsedRange.Rows.Count).NumberFormat = "##0,00";
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

        //Добавление данных в Excel
        private void Add_data(string Table_name, int number_of_page, int month, int year)
        {
            try
            {
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
                excelworksheet.Activate();

                //Выгрузка данных
                DataTable dt = GetData(Table_name, month, year);
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
             
                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        if (collInd == 0)
                        {
                            data = DateTime.Parse(dt.Rows[rowInd].ItemArray[collInd].ToString()).ToShortDateString();
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data;
                        }
                        else if (collInd == 3 || collInd==4)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Метод для чтения данных из базы данных
        private DataTable GetData(string Table_name, int month, int year)
        {

            //строка соединения
            Connection sql = new Connection();
            string ConnectionString = sql.Get_Connection_String();

            SqlConnection con = new SqlConnection(ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                string query = "SELECT " +
                    Table_name + ".Posting_date AS \"Дата\", " +
                    Table_name + ".Device AS \"Место операции\", " +
                    Table_name + ".Type AS \"Тип\", " +
                    Table_name + ".Summa AS \"Сумма\"," +
                    Table_name + ".Interch_fee AS \"Interch_fee\", " +
                    Table_name + ".Currency AS \"Валюта\"," +
                    Table_name + ".Target_number AS \"Target_number\", " +
                    Table_name + ".Target_filial AS \"Target_filial\"" +
                    " FROM " + Table_name +
                    " WHERE MONTH(" + Table_name + ".Posting_date)=" + month + " and YEAR(" + Table_name + ".Posting_date)=" + year +
                    " ORDER BY " + Table_name + ".Posting_date";
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

        //Метод для выполнения расчетов
        private void Make_calculations(int number_of_page)
        {
            try
            {
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
                excelworksheet.Activate();

                int rowInd;
                int row_end = 0;//строка окончания даты
                int row_start = 2;//строка с новой датой
                string date = excelworksheet.Cells[2, 1].Text;//дата взятая с ячейки excel
                int usedRowsNum = excelworksheet.UsedRange.Rows.Count; //все используемые строки excel
                //Суммируем общую сумму и количество до того как будем разделять по дням
                excelworksheet.Cells[usedRowsNum + 1, 4].FormulaLocal = "=СУММ(D2:D" + usedRowsNum + ")";
                excelworksheet.Cells[usedRowsNum + 1, 5].FormulaLocal = "=СУММ(E2:E" + usedRowsNum + ")";
                decimal total_sum = Convert.ToDecimal(excelworksheet.Cells[usedRowsNum + 1, 4].Text);
                decimal total_interch = Convert.ToDecimal(excelworksheet.Cells[usedRowsNum + 1, 5].Text);
                //Обнуляем поля
                excelworksheet.Cells[usedRowsNum + 1, 4] = null;
                excelworksheet.Cells[usedRowsNum + 1, 5] = null;
                //Проходимся по всем данным и разделяем по дням и делаем расчеты для каждого дня
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
                            string formula = "=СУММ(E" + row_start + ":E" + (row_end - 1) + ")";
                            string formula2 = "=СУММ(D" + row_start + ":D" + (row_end - 1) + ")";
                            excelworksheet.Cells[row_end, 5].FormulaLocal = formula;
                            excelworksheet.Cells[row_end, 4].FormulaLocal = formula2;
                            excelworksheet.Cells[row_end, 4].Interior.Color = Color.Red;
                            excelworksheet.Cells[row_end, 5].Interior.Color = Color.Red;
                            date = excelworksheet.Cells[row_end + 3, 1].Text;
                            row_start = row_end + 3;
                            rowInd += 2;
                        }
                    }
                    //Вставляем в конец общую сумму и количество
                    excelworksheet.Cells[usedRowsNum + 1, 1] = "Общая ";
                    excelworksheet.Cells[usedRowsNum + 1, 4] = total_sum;
                    excelworksheet.Cells[usedRowsNum + 1, 5] = total_interch;
                    excelworksheet.Cells[usedRowsNum + 1, 4].Interior.Color = Color.Red;
                    excelworksheet.Cells[usedRowsNum + 1, 5].Interior.Color = Color.Red;
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

        //Метод для добавления новых строк
        public void InsertRow(int rowNum)
        {
            Excel.Range cellRange = (Excel.Range)excelworksheet.Cells[rowNum, 1];
            Excel.Range rowRange = cellRange.EntireRow;
            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
        }
    }
}
