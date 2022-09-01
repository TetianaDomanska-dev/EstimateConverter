using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace EstimateConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConverterRule.GenerateRule();
            mode1label.Text = days;
            mode2label.Text = sps;
        }

        private int numberOfUS = 1;
        Dictionary<int, Tuple<string, string, Tuple<double, double, double>>> listOfUS = new Dictionary<int, Tuple<string, string, Tuple<double, double, double>>>();
        int mode = 1;
        string days = "Days";
        string sps = "SPs";
        int mode2tbwidth = 71;

        private void button1_Click(object sender, EventArgs e)
        {
            var storyName = textBox1.Text;
            var SP = comboBox1.Text;

            if (storyName != String.Empty)
            {
                var manDays = ConverterRule.GetManDayForSP(SP);

                listOfUS.Add(numberOfUS, new Tuple<string, string, Tuple<double, double, double>>(storyName, SP, manDays));
                listBox1.Items.Insert(numberOfUS-1, Convert.ToString(numberOfUS) + ") " 
                    + storyName + " - " + SP + ", Expected ManDays " + Convert.ToString(manDays.Item3) + ";");

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
                    story.Value.Item1, story.Value.Item2, Convert.ToString(story.Value.Item3.Item1),
                    Convert.ToString(story.Value.Item3.Item2), Convert.ToString(story.Value.Item3.Item3));
            }

            MessageBox.Show("WBS generated and saved");
            excelFile.closeExcel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void mode1textbox_TextChanged(object sender, EventArgs e)
        {
            if (mode1textbox.Text != String.Empty)
            {
                if (mode == 1)
                {
                    mode2textbox.Text = String.Empty;
                    var value = Convert.ToDouble(mode1textbox.Text);
                    foreach (var i in ConverterRule.convertRule)
                    {
                        if (value >= i.Value.Item1 && value <= i.Value.Item2)
                        {
                            if (i.Key == 21)
                            {
                                mode2textbox.Text = "21 or more";
                                MessageBox.Show("Need to be decomposed");
                            }
                            mode2textbox.Text = Convert.ToString(i.Key);
                            break;
                        }
                    }
                }
                else
                {
                    mode2textbox.Text = String.Empty;
                    var value = Convert.ToInt32(mode1textbox.Text);
                    if (ConverterRule.convertRule.Keys.Contains(value))
                    {
                        mode2textbox.Text = ">= " + 
                            Convert.ToString(Math.Round(ConverterRule.convertRule[value].Item1,2)) + 
                            " & <= " + 
                            Convert.ToString(Math.Round(ConverterRule.convertRule[value].Item2,2));
                    }
                }
            }
            else 
            {
                mode2textbox.Text = String.Empty;
            }
        }

        private void changeModeLabel_Click(object sender, EventArgs e)
        {
            mode = mode == 1 ? 2 : 1;
            mode1label.Text = mode == 1 ? days : sps;
            mode2label.Text = mode == 2 ? days : sps;
            mode1textbox.Text = String.Empty;
            mode2textbox.Text = String.Empty;
            mode2textbox.Width = mode == 1 ? mode2tbwidth : mode2tbwidth + 25;
        }
    }

    public static class ConverterRule
    {
        public static Dictionary<int,Tuple< double, double, double>> convertRule = new Dictionary<int, Tuple<double, double, double>>();
        public static void GenerateRule()
        {
            double optPercent = 0.8;  // 20% from most likely
            double pesPercent = 1.35; // 35% from most likely

            convertRule.Add(1, new Tuple<double, double, double>(0.3*optPercent, 0.3*pesPercent,0.3));
            convertRule.Add(2, new Tuple<double, double, double>(0.8 * optPercent, 0.8 * pesPercent, 0.8));
            convertRule.Add(3, new Tuple<double, double, double>(1.2 * optPercent, 1.2 * pesPercent, 1.2));
            convertRule.Add(5, new Tuple<double, double, double>(2 * optPercent, 2 * pesPercent, 2));
            convertRule.Add(8, new Tuple<double, double, double>(3.5 * optPercent, 3.5 * pesPercent, 3.5));
            convertRule.Add(13, new Tuple<double, double, double>(5 * optPercent, 5 * pesPercent, 5));
            //convertRule.Add(0, new Tuple<double, double, double>(0.1, 0.5, 0.4));
            convertRule.Add(21, new Tuple<double, double, double>(7, 20, 15));
        }

        public static Tuple<double,double,double> GetManDayForSP(string SP)
        {
            var res = SP.Split(" ");
            int numOfSP = Convert.ToInt32(res[0]);
            return convertRule[numOfSP];
        }
    }
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

        public void addDataToExcel(string numberOfUS, string storyName, string SP,  string optManDays, string pesManDays, string expectManDays)
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