namespace EstimateConverter
{
    partial class EstimateConverterUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.mode1textbox = new System.Windows.Forms.TextBox();
            this.changeModeLabel = new System.Windows.Forms.Label();
            this.mode2textbox = new System.Windows.Forms.TextBox();
            this.mode1label = new System.Windows.Forms.Label();
            this.mode2label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 SP",
            "2 SP",
            "3 SP",
            "5 SP",
            "8 SP",
            "13 SP"});
            this.comboBox1.Location = new System.Drawing.Point(526, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(469, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add story in list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(367, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 66);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generate WBS and save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(51, 91);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(469, 139);
            this.listBox1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(538, 277);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 24);
            this.button3.TabIndex = 6;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // mode1textbox
            // 
            this.mode1textbox.Location = new System.Drawing.Point(51, 277);
            this.mode1textbox.Name = "mode1textbox";
            this.mode1textbox.Size = new System.Drawing.Size(70, 23);
            this.mode1textbox.TabIndex = 7;
            this.mode1textbox.TextChanged += new System.EventHandler(this.mode1textbox_TextChanged);
            // 
            // changeModeLabel
            // 
            this.changeModeLabel.AutoSize = true;
            this.changeModeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeModeLabel.Location = new System.Drawing.Point(127, 282);
            this.changeModeLabel.Name = "changeModeLabel";
            this.changeModeLabel.Size = new System.Drawing.Size(48, 15);
            this.changeModeLabel.TabIndex = 8;
            this.changeModeLabel.Text = "<----->";
            this.changeModeLabel.Click += new System.EventHandler(this.changeModeLabel_Click);
            // 
            // mode2textbox
            // 
            this.mode2textbox.Enabled = false;
            this.mode2textbox.Location = new System.Drawing.Point(181, 277);
            this.mode2textbox.Name = "mode2textbox";
            this.mode2textbox.Size = new System.Drawing.Size(71, 23);
            this.mode2textbox.TabIndex = 9;
            // 
            // mode1label
            // 
            this.mode1label.AutoSize = true;
            this.mode1label.Location = new System.Drawing.Point(74, 256);
            this.mode1label.Name = "mode1label";
            this.mode1label.Size = new System.Drawing.Size(0, 15);
            this.mode1label.TabIndex = 10;
            // 
            // mode2label
            // 
            this.mode2label.AutoSize = true;
            this.mode2label.Location = new System.Drawing.Point(195, 256);
            this.mode2label.Name = "mode2label";
            this.mode2label.Size = new System.Drawing.Size(0, 15);
            this.mode2label.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 352);
            this.Controls.Add(this.mode2label);
            this.Controls.Add(this.mode1label);
            this.Controls.Add(this.mode2textbox);
            this.Controls.Add(this.changeModeLabel);
            this.Controls.Add(this.mode1textbox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "EstimateConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private ListBox listBox1;
        private Button button3;
        private TextBox mode1textbox;
        private Label changeModeLabel;
        private TextBox mode2textbox;
        private Label mode1label;
        private Label mode2label;
    }
}