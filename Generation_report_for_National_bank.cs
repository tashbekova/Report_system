using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Generation(string report_path)
        {
            try
            { 
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string full_path_template = appPath + "/Reports/National_bank.xls";

                excelapp = new Excel.Application();
                excelworkbook = excelapp.Workbooks.Open(full_path_template); //открываем наш файл    
                                                                             //делаем временно неактивным документ
                excelapp.Interactive = false;
                excelapp.EnableEvents = false;
                excelsheets = excelworkbook.Worksheets;

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
                ReleaseObject(excelworkbook);
                ReleaseObject(excelapp);
                GC.Collect();
            }


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
