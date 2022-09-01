using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace EstimateConverter
{
    public partial class EstimateConverterUI : Form
    {
        public EstimateConverterUI()
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
}