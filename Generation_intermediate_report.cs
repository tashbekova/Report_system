using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Report_system
{
    class Generation_intermediate_report
    {
        private Excel.Application excelapp;
        private Excel.Workbook excelworkbook;
        //private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelcells;
        
        public void Generation(string path)
        {
            create_excel_doc(path);
            

        }

        public void create_excel_doc(string path)
        {
            try
            {
                excelapp = new Excel.Application();
                excelapp.Visible = true;
                excelworkbook = excelapp.Workbooks.Add(1);
                excelworksheet = (Excel.Worksheet)excelworkbook.Sheets[1];
                excelworksheet.Name = "Банкоматы";
                excelworksheet.Cells[1, 1] = "Id";
                excelworksheet.Cells[1, 2] = "Id";
                excelworksheet.Cells[1, 3] = "Id";
                excelapp.DefaultFilePath = path;
                excelworkbook.Saved = true;
                excelworkbook.SaveAs(path);

            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
      

    }
}
