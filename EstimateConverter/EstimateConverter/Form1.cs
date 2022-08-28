using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace EstimateConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int numberOfUS = 1;
        Dictionary<int, Tuple<string, string, double>> listOfUS = new Dictionary<int, Tuple<string, string, double>>();

        private void button1_Click(object sender, EventArgs e)
        {
            if(numberOfUS == 1)
                ConverterRule.GenerateRule();

            var storyName = textBox1.Text;
            var SP = comboBox1.Text;

            if (storyName != String.Empty)
            {
                var manDays = ConverterRule.GetManDayForSP(SP);

                listOfUS.Add(numberOfUS, new Tuple<string, string, double>(storyName, SP, manDays));
                listBox1.Items.Insert(numberOfUS-1, Convert.ToString(numberOfUS) + ") " 
                    + storyName + " - " + SP + ", ManDays " + Convert.ToString(manDays) + ";");

                numberOfUS++;
                label1.Text = Convert.ToString(numberOfUS); 
                textBox1.Text = String.Empty;
                comboBox1.Text = String.Empty;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcelFile excelFile = new ExcelFile();

            excelFile.openExcel();

            foreach (var story in listOfUS)
            {
                excelFile.addDataToExcel(Convert.ToString(story.Key), 
                    story.Value.Item1, story.Value.Item2, Convert.ToString(story.Value.Item3));
            }

            MessageBox.Show("WBS generated and saved");
            excelFile.closeExcel();
        }
    }

    public static class ConverterRule
    {
        public static Dictionary<int, double> convertRule = new Dictionary<int, double>();

        public static void GenerateRule()
        {
            convertRule.Add(1, 0.7);
            convertRule.Add(2, 1);
            convertRule.Add(3, 1.5);
            convertRule.Add(5, 2);
            convertRule.Add(8, 3.5);
            convertRule.Add(13, 5); // +- 20% opt & 25% pes
        }

        public static double GetManDayForSP(string SP)
        {
            var res = SP.Split(" ");
            int numOfSP = Convert.ToInt32(res[0]);
            return convertRule[numOfSP];
        }
    }
    public class ExcelFile
    {

        private string excelFilePath = @"C:\Users\tdoma\Source\Repos\EstimateConverter\EstimateConverter\WBS.xlsx";

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

        public void addDataToExcel(string numberOfUS, string storyName, string SP,  string manDays)
        {

            myExcelWorkSheet.Cells[rowNumber, "A"] = numberOfUS;
            myExcelWorkSheet.Cells[rowNumber, "B"] = storyName;
            myExcelWorkSheet.Cells[rowNumber, "P"] = SP;
            myExcelWorkSheet.Cells[rowNumber, "H"] = manDays;
            rowNumber++;  // if you put this method inside a loop, you should increase rownumber by one 

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