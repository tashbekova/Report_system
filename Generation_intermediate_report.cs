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
        //private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelrange;
        frm_Generation pb = new frm_Generation();
        public event Action<int> ProgressBarIncrement;  //прогресс барр

        public void Generation(string path,string report,int month,int year)
        {
            string Table_name = "";
            if (report=="Report A")
            {
                Table_name ="tbl_Report_A";
            }
            create_excel_doc(path,Table_name,month,year);
            GC.Collect();
        }

        public void create_excel_doc(string path,string Table_name,int month,int year)
        {
           
            try
            {
                excelapp = new Excel.Application();
                //добавляем книгу
                excelworkbook=excelapp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                excelworksheet = (Excel.Worksheet)excelapp.Sheets[1];
                //Название листа
                excelworksheet.Name = "Банкоматы";
                

                //Выгрузка данных
                DataTable dt = GetData(Table_name, month, year);
                int collInd = 0;
                int rowInd = 0;
                string data = "";

                //excelworksheet.get_Range("D2:D"+ dt.Rows.Count).NumberFormat = "0,00";
                ////excelworksheet.get_Range("A2:A"+ dt.Rows.Count).NumberFormat = "m/d/yyyy";
                //excelworksheet.get_Range("A2").NumberFormat= "mm/dd/yyyy";
                //называем колонки
                for (int i=0;i<dt.Columns.Count;i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    excelrange = excelworksheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    excelrange.WrapText = true;
                    excelrange.Font.Bold = true;
                    ProgressBarIncrement?.Invoke(i); //прогресс бар двигается вместе со строками
                }
                
                //заполняем строки
                for (rowInd=0;rowInd<dt.Rows.Count;rowInd++)
                {
                    for(collInd=0;collInd<dt.Columns.Count;collInd++)
                    {
                        //(excelrange.Cells[rowInd+2, 1] ).NumberFormat = "Д ММММ, ГГГГ";
                        //(excelworksheet.Cells[rowInd, 4] as Excel.Range).NumberFormat = "### ##0,00";
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        excelworksheet.Cells[rowInd + 2, collInd + 1] = data;
                        ProgressBarIncrement?.Invoke(rowInd); //прогресс бар двигается вместе со строками
                    }
                }

                //выбираем всю область данных
                excelrange = excelworksheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                excelrange.Columns.AutoFit();
                excelrange.Rows.AutoFit();


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

                Make_calculations();
                //excelapp.DefaultFilePath = path;
                // excelworkbook.Saved = true;
                //excelworkbook.SaveAs(path);

                ////Отсоединяемся от Excel
                ReleaseObject(excelrange);
                ReleaseObject(excelworksheet);
                ReleaseObject(excelapp);

                MessageBox.Show("Успешно сформирован отчет");


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
                    Table_name + ".Posting_date, " +
                    Table_name + ".Number_of_trans, " +
                    Table_name + ".Device, " +
                    Table_name+".Account_amount,"+
                    //"REPLACE(convert(varchar(50),"+ Table_name+".Transaction_amount), '.', ','),"+
                    Table_name + ".Transaction_name, " +
                    Table_name + ".Currency " +
                    " FROM " + Table_name +
                    " WHERE MONTH(" + Table_name + ".Posting_date)=" + month + " and YEAR(" + Table_name + ".Posting_date)=" + year+
                    " ORDER BY "+Table_name+".ID";
               // MessageBox.Show(query);
               SqlCommand comm = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch(Exception ex)
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
                for (rowInd = 1; rowInd < usedRowsNum; rowInd++)
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
