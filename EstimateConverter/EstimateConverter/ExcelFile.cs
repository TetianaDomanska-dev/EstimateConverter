using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateConverter
{
    public class ExcelFile
    {

        private string excelFilePath = @"C:\EstimateConverter\EstimateConverter\EstimateConverter\WBS.xlsx";

        private int rowNumber = 2; // define first row number to enter data in excel

        Microsoft.Office.Interop.Excel.Application myExcelApplication;
        Microsoft.Office.Interop.Excel.Workbook myExcelWorkbook;
        Microsoft.Office.Interop.Excel.Worksheet myExcelWorkSheet;

        public string ExcelFilePath
        {
            get { return excelFilePath; }
            set { excelFilePath = value; }
        }

        public int Rownumber
        {
            get { return rowNumber; }
            set { rowNumber = value; }
        }

        public void openExcel()
        {
            myExcelApplication = null;

            myExcelApplication = new Microsoft.Office.Interop.Excel.Application(); // create Excell App
            myExcelApplication.DisplayAlerts = false; // turn off alerts


            myExcelWorkbook = (Microsoft.Office.Interop.Excel.Workbook)(myExcelApplication.Workbooks._Open(excelFilePath,
                System.Reflection.Missing.Value,
               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
               System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
               System.Reflection.Missing.Value, System.Reflection.Missing.Value));
            // open the existing excel file

            myExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)myExcelWorkbook.Worksheets[3]; // define in which worksheet, do you want to add data
        }

        public void addDataToExcel(string numberOfUS, string storyName, string SP, string optManDays, string pesManDays, string expectManDays)
        {

            myExcelWorkSheet.Cells[rowNumber, "A"] = numberOfUS;
            myExcelWorkSheet.Cells[rowNumber, "B"] = storyName;
            myExcelWorkSheet.Cells[rowNumber, "P"] = SP;
            myExcelWorkSheet.Cells[rowNumber, "F"] = optManDays;
            myExcelWorkSheet.Cells[rowNumber, "G"] = pesManDays;
            myExcelWorkSheet.Cells[rowNumber, "H"] = expectManDays;
            rowNumber++;

        }

        public void closeExcel()
        {
            try
            {
                myExcelWorkbook.SaveAs(excelFilePath, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                               System.Reflection.Missing.Value, System.Reflection.Missing.Value); // Save data in excel


                myExcelWorkbook.Close(true, excelFilePath, System.Reflection.Missing.Value); // close the worksheet


            }
            finally
            {
                if (myExcelApplication != null)
                {
                    myExcelApplication.Quit(); // close the excel application
                }
            }

        }
    }
}
