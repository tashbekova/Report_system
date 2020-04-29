using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Drawing;

namespace Report_system
{
    class Generation_intermediate_report
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelrange;
        private Excel.Sheets excelsheets;
        frm_Generation_report pb = new frm_Generation_report();
        public event Action<int> ProgressBarIncrement;  //прогресс барр

        public void Generation(string path,int month,int year)
        {
            try
            {
                excelapp = new Excel.Application();
                //добавляем книгу
                excelworkbook=excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;

                excelapp.SheetsInNewWorkbook = 3;
                //выбираем лист на котором будем работать (Лист 1)
                excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];
                excelsheets = excelworkbook.Worksheets;
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                excelworksheet.Activate();
                //Название листа
                excelworksheet.Name = "Банкоматы";
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(2);
                excelworksheet.Activate();
                //Название листа
                excelworksheet.Name = "POS-терминал";
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(3);
                excelworksheet.Activate();
                //Название листа
                excelworksheet.Name = "POS-терминалы";
                Add_data("tbl_Report_A", 1, month, year);
                Draw_line(1);
                Add_data("tbl_Report_H", 2, month, year);
                Draw_line(2);
                Add_data("tbl_Report_R", 3, month, year);
                Draw_line(3);
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

                Make_calculations(1);
                Make_calculations(2);
                Make_calculations(3);
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

        private void Draw_line(int number_of_page)
        {
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(number_of_page);
            excelworksheet.Activate();
            //выделяем первую строку
            excelrange = excelworksheet.get_Range("A1:F1", Type.Missing);

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

        private void Add_data(string Table_name,int number_of_page,int month,int year)
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
                        //(excelrange.Cells[rowInd+2, 1] ).NumberFormat = "Д ММММ, ГГГГ";
                        //(excelworksheet.Cells[rowInd, 4] as Excel.Range).NumberFormat = "### ##0,00";
                        if (collInd == 0)
                        {
                            data = DateTime.Parse(dt.Rows[rowInd].ItemArray[collInd].ToString()).ToShortDateString();
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data;
                        }
                        else if (collInd == 3)
                        {
                            data2 = Convert.ToDecimal(dt.Rows[rowInd].ItemArray[collInd]);
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data2;
                        }
                        else
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                            excelworksheet.Cells[rowInd + 2, collInd + 1] = data;
                        }

                        ProgressBarIncrement?.Invoke(rowInd); //прогресс бар двигается вместе со строками
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private DataTable GetData(string Table_name,int month,int year)
        {

            //строка соединения
            string ConnectionString = @"Data Source=DESKTOP-7N0MIBC\SQLEXPRESS;Initial Catalog=Report_System;User ID=sa;Password='123'";

            SqlConnection con = new SqlConnection(ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                string query = "SELECT " +
                    Table_name + ".Posting_date AS \"Дата\", " +
                    Table_name + ".Number_of_trans AS \"Кол-во карт\", " +
                    Table_name + ".Device AS \"Место операции\", " +
                    Table_name+ ".Account_amount AS \"Сумма\"," +
                    Table_name + ".Type_of_card AS \"Вид карты\", " +
                    Table_name + ".Currency AS \"Валюта\"" +
                    " FROM " + Table_name +
                    " WHERE MONTH(" + Table_name + ".Posting_date)=" + month + " and YEAR(" + Table_name + ".Posting_date)=" + year+
                    " ORDER BY "+Table_name+".Posting_date";
               // MessageBox.Show(query);
               SqlCommand comm = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch(SqlException ex)
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
                for (rowInd = 1; rowInd < (usedRowsNum+1); rowInd++)
                {
                    int collInd;
                    for (collInd = 1; collInd <= 1; collInd++)
                    {
                        ProgressBarIncrement?.Invoke(rowInd); //прогресс бар двигается вместе с итерациями
                        if ((excelworksheet.Cells[rowInd + 1, 1]).Text != date)
                        {
                            row_end = rowInd + 1;
                            usedRowsNum = usedRowsNum + 3;
                            InsertRow(row_end);
                            InsertRow(row_end + 1);
                            InsertRow(row_end + 2);
                            string formula = "=СУММ(D" + row_start + ":D" + (row_end-1) + ")";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
