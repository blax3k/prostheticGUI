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
            this.butonApply = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            this.richTextBox1.Location = new System.Drawing.Point(12, 34);
            this.richTextBox1.Name = "richTextBox1";
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
            this.labelSerial.Location = new System.Drawing.Point(12, 289);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(37, 13);
            this.labelSerial.TabIndex = 3;
            this.labelSerial.Text = "serial: ";
            // 
            // labelFirmware
            // 
            this.labelFirmware.AutoSize = true;
            this.labelFirmware.Location = new System.Drawing.Point(12, 302);
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
            this.listBoxVariables.FormattingEnabled = true;
            this.listBoxVariables.Location = new System.Drawing.Point(369, 60);
            this.listBoxVariables.Name = "listBoxVariables";
            this.listBoxVariables.ScrollAlwaysVisible = true;
            this.listBoxVariables.Size = new System.Drawing.Size(392, 355);
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
            this.buttonRefresh.Location = new System.Drawing.Point(369, 5);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // butonApply
            // 
            this.butonApply.Location = new System.Drawing.Point(686, 421);
            this.butonApply.Name = "butonApply";
            this.butonApply.Size = new System.Drawing.Size(75, 23);
            this.butonApply.TabIndex = 9;
            this.butonApply.Text = "Apply";
            this.butonApply.UseVisualStyleBackColor = true;
            this.butonApply.Click += new System.EventHandler(this.butonApply_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(369, 438);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 10;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 411);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(369, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(392, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "ITEM       NAME                     TYPE       VALUE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 476);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.butonApply);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxVariables);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelFirmware);
            this.Controls.Add(this.labelSerial);
            this.Controls.Add(this.buttonSyncTime);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonLED);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button butonApply;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBox2;
    }
}

