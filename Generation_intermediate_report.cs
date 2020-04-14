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

namespace Report_system
{
    class Generation_intermediate_report
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        //private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelcells;
       

        public void Generation(string path,string report,int month,int year)
        {
            string Table_name = "";
            if (report=="Report A")
            {
                Table_name ="tbl_Report_A";
            }
            create_excel_doc(path,Table_name,month,year);
            

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

                //называем колонки
                for(int i=0;i<dt.Columns.Count;i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    excelworksheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    excelcells = excelworksheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    excelcells.WrapText = true;
                    excelcells.Font.Bold = true;
                }

                //заполняем строки
                for(rowInd=0;rowInd<dt.Rows.Count;rowInd++)
                {
                    for(collInd=0;collInd<dt.Columns.Count;collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        excelworksheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }

                //выбираем всю область данных
                excelcells = excelworksheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                excelcells.Columns.AutoFit();
                excelcells.Rows.AutoFit();


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

                //excelapp.DefaultFilePath = path;
                //excelworkbook.Saved = true;
                //excelworkbook.SaveAs(path);

                //Отсоединяемся от Excel
                releaseObject(excelcells);
                releaseObject(excelworksheet);
                releaseObject(excelapp);
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
                    Table_name+".Transaction_amount,"+
                    //"REPLACE(convert(varchar(50),"+ Table_name+".Transaction_amount), '.', ','),"+
                    Table_name + ".Transaction_name, " +
                    Table_name + ".Currency " +
                    " FROM " + Table_name +
                    " WHERE MONTH(" + Table_name + ".Posting_date)=" + month + " and YEAR(" + Table_name + ".Posting_date)=" + year;
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
        void releaseObject(object obj)
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
