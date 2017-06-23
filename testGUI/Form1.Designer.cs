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
            this.SuspendLayout();
            // 
            // buttonLED
            // 
            this.buttonLED.Location = new System.Drawing.Point(43, 213);
            this.buttonLED.Name = "buttonLED";
            this.buttonLED.Size = new System.Drawing.Size(75, 23);
            this.buttonLED.TabIndex = 0;
            this.buttonLED.Text = "button1";
            this.buttonLED.UseVisualStyleBackColor = true;
            this.buttonLED.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 195);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // buttonSyncTime
            // 
            this.buttonSyncTime.Location = new System.Drawing.Point(165, 213);
            this.buttonSyncTime.Name = "buttonSyncTime";
            this.buttonSyncTime.Size = new System.Drawing.Size(75, 23);
            this.buttonSyncTime.TabIndex = 2;
            this.buttonSyncTime.Text = "Sync Time";
            this.buttonSyncTime.UseVisualStyleBackColor = true;
            this.buttonSyncTime.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelSerial
            // 
            this.labelSerial.AutoSize = true;
            this.labelSerial.Location = new System.Drawing.Point(13, 519);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(37, 13);
            this.labelSerial.TabIndex = 3;
            this.labelSerial.Text = "serial: ";
            // 
            // labelFirmware
            // 
            this.labelFirmware.AutoSize = true;
            this.labelFirmware.Location = new System.Drawing.Point(450, 519);
            this.labelFirmware.Name = "labelFirmware";
            this.labelFirmware.Size = new System.Drawing.Size(52, 13);
            this.labelFirmware.TabIndex = 4;
            this.labelFirmware.Text = "firmware: ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(374, 77);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(36, 13);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "Time: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 544);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelFirmware);
            this.Controls.Add(this.labelSerial);
            this.Controls.Add(this.buttonSyncTime);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonLED);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
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
    }
}

