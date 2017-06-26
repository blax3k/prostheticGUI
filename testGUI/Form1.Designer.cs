namespace testGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonLED = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSyncTime = new System.Windows.Forms.Button();
            this.labelSerial = new System.Windows.Forms.Label();
            this.labelFirmware = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.listBoxVariables = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonValueSort = new System.Windows.Forms.Button();
            this.buttonTypeSort = new System.Windows.Forms.Button();
            this.buttonNameSort = new System.Windows.Forms.Button();
            this.buttonIDSort = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLED
            // 
            this.buttonLED.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLED.Location = new System.Drawing.Point(12, 235);
            this.buttonLED.Name = "buttonLED";
            this.buttonLED.Size = new System.Drawing.Size(123, 34);
            this.buttonLED.TabIndex = 0;
            this.buttonLED.Text = "LED";
            this.buttonLED.UseVisualStyleBackColor = true;
            this.buttonLED.Click += new System.EventHandler(this.buttonLED_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 34);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(291, 195);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // buttonSyncTime
            // 
            this.buttonSyncTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSyncTime.Location = new System.Drawing.Point(180, 235);
            this.buttonSyncTime.Name = "buttonSyncTime";
            this.buttonSyncTime.Size = new System.Drawing.Size(123, 34);
            this.buttonSyncTime.TabIndex = 2;
            this.buttonSyncTime.Text = "Sync Time";
            this.buttonSyncTime.UseVisualStyleBackColor = true;
            this.buttonSyncTime.Click += new System.EventHandler(this.buttonSyncTime_Click);
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Location = new System.Drawing.Point(9, 438);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(37, 13);
            this.labelSerial.TabIndex = 3;
            this.labelSerial.Text = "serial: ";
            // 
            // labelFirmware
            // 
            this.labelFirmware.AutoSize = true;
            this.labelFirmware.Location = new System.Drawing.Point(9, 451);
            this.labelFirmware.Name = "labelFirmware";
            this.labelFirmware.Size = new System.Drawing.Size(52, 13);
            this.labelFirmware.TabIndex = 4;
            this.labelFirmware.Text = "firmware: ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(9, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(36, 13);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Time: ";
            // 
            // listBoxVariables
            // 
            this.listBoxVariables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxVariables.FormattingEnabled = true;
            this.listBoxVariables.Location = new System.Drawing.Point(32, 92);
            this.listBoxVariables.Name = "listBoxVariables";
            this.listBoxVariables.ScrollAlwaysVisible = true;
            this.listBoxVariables.Size = new System.Drawing.Size(392, 351);
            this.listBoxVariables.TabIndex = 6;
            this.listBoxVariables.SelectedIndexChanged += new System.EventHandler(this.listBoxVariables_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(369, 424);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseUp);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(369, 9);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // butonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(686, 421);
            this.buttonApply.Name = "butonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.butonApply_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(26, 477);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 10;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 287);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.listBoxVariables);
            this.panel1.Controls.Add(this.buttonIDSort);
            this.panel1.Controls.Add(this.buttonNameSort);
            this.panel1.Controls.Add(this.buttonTypeSort);
            this.panel1.Controls.Add(this.buttonValueSort);
            this.panel1.Location = new System.Drawing.Point(336, -31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 511);
            this.panel1.TabIndex = 13;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // buttonValueSort
            // 
            this.buttonValueSort.BackColor = System.Drawing.SystemColors.Control;
            this.buttonValueSort.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonValueSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValueSort.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonValueSort.Location = new System.Drawing.Point(221, 70);
            this.buttonValueSort.Name = "buttonValueSort";
            this.buttonValueSort.Size = new System.Drawing.Size(203, 23);
            this.buttonValueSort.TabIndex = 16;
            this.buttonValueSort.Text = "Value";
            this.buttonValueSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonValueSort.UseVisualStyleBackColor = false;
            this.buttonValueSort.Click += new System.EventHandler(this.buttonValueSort_Click);
            // 
            // buttonTypeSort
            // 
            this.buttonTypeSort.BackColor = System.Drawing.SystemColors.Control;
            this.buttonTypeSort.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonTypeSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTypeSort.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonTypeSort.Location = new System.Drawing.Point(170, 70);
            this.buttonTypeSort.Name = "buttonTypeSort";
            this.buttonTypeSort.Size = new System.Drawing.Size(45, 23);
            this.buttonTypeSort.TabIndex = 15;
            this.buttonTypeSort.Text = "Type";
            this.buttonTypeSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTypeSort.UseVisualStyleBackColor = false;
            this.buttonTypeSort.Click += new System.EventHandler(this.buttonTypeSort_Click);
            // 
            // buttonNameSort
            // 
            this.buttonNameSort.BackColor = System.Drawing.SystemColors.Control;
            this.buttonNameSort.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonNameSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNameSort.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonNameSort.Location = new System.Drawing.Point(80, 70);
            this.buttonNameSort.Name = "buttonNameSort";
            this.buttonNameSort.Size = new System.Drawing.Size(84, 23);
            this.buttonNameSort.TabIndex = 14;
            this.buttonNameSort.Text = "Name";
            this.buttonNameSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNameSort.UseVisualStyleBackColor = false;
            this.buttonNameSort.Click += new System.EventHandler(this.buttonNameSort_Click);
            // 
            // buttonIDSort
            // 
            this.buttonIDSort.BackColor = System.Drawing.SystemColors.Control;
            this.buttonIDSort.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonIDSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIDSort.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonIDSort.Location = new System.Drawing.Point(32, 70);
            this.buttonIDSort.Name = "buttonIDSort";
            this.buttonIDSort.Size = new System.Drawing.Size(42, 23);
            this.buttonIDSort.TabIndex = 13;
            this.buttonIDSort.Text = "ID";
            this.buttonIDSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIDSort.UseVisualStyleBackColor = false;
            this.buttonIDSort.Click += new System.EventHandler(this.buttonIDSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(773, 476);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelFirmware);
            this.Controls.Add(this.labelSerial);
            this.Controls.Add(this.buttonSyncTime);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonLED);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLED;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSyncTime;
        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.Label labelFirmware;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ListBox listBoxVariables;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonValueSort;
        private System.Windows.Forms.Button buttonTypeSort;
        private System.Windows.Forms.Button buttonNameSort;
        private System.Windows.Forms.Button buttonIDSort;
    }
}

