using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testGUI
{
    public partial class Form1 : Form
    {
        public delegate void SetTextDelegate(String myString);
        public SetTextDelegate textDelegate; //an instance of AddDataDelegate
        public delegate void AddDataDelegate_button(String myString);
        public AddDataDelegate_button myDelegate_button;
        public delegate void setSerialDelegate(String serial);
        public setSerialDelegate serialDelegate;
        public delegate void setFirmwrDelegate(String myString);
        public setFirmwrDelegate firmwrDelegate;
        public delegate void setTimeDelegate(String myString);
        public setTimeDelegate timeDelegate;
        bool ledStatus = false;
        volatile bool running = false;
        string firmware = "";
        string serial = "";
        const string STATE = "STATE=",
            INFO = "INFO=",
            GETTIME = "GETTIME=",
            SYNCTIME = "SYNCTIME";


        public Form1()
        {
            InitializeComponent();
        }

        /*
        peforms initial setup and makes sure that there is a valid device connected
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            running = true;
            this.textDelegate = new SetTextDelegate(AddDataMethod);
            this.myDelegate_button = new AddDataDelegate_button(setButtonLEDText);
            this.serialDelegate = new setSerialDelegate(setSerial);
            this.firmwrDelegate = new setFirmwrDelegate(setFirmware);
            this.timeDelegate = new setTimeDelegate(setTime);

            try
            {                       //try to establish a connection
                serialPort1.Open();
                serialPort1.WriteLine(STATE);
                //setup Serial number
                serialPort1.WriteLine(INFO);
                serialPort1.WriteLine(GETTIME);

                Thread timeThread = new Thread(new ThreadStart(this.startTimeThread));
                timeThread.Start();

            }
            catch (Exception exception) //no device detected
            {
                MessageBox.Show("No device detected" + "\n" + exception, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        } 

        private void startTimeThread()
        {
            while (running)
            {
                serialPort1.WriteLine(GETTIME);
                System.Threading.Thread.Sleep(5000);
            }
        }

        /*

        */
        private void setButtonLEDText(string myString)
        {
            buttonLED.Text = myString;
        }
        /*
        set the text in the rich text box
        */
        private void AddDataMethod(string myString)
        {
            richTextBox1.Text = richTextBox1.Text + myString + Environment.NewLine;
        }
        /*
        sets the serial number label
        */
        private void setSerial(string serial)
        {
            labelSerial.Text = "serial: " + serial;
        }
        /*
        sets the firmware label
        */
        private void setFirmware(string firmware)
        {
            labelFirmware.Text = "firmware: " + firmware;
        }
        /*
        sets the time of the time label
        */
        private void setTime(string time)
        {
            labelTime.Text = time;
        }
        /*
        handles input from the serial port
        */
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string s = serialPort1.ReadLine(); //get the data
            if (s.Contains("STATE=")) //received the LED state
            {
                s = s.Trim();
                string new_s = s;
                Console.WriteLine("read State");
                //string new_s = s.Replace("state=", "");
                if (new_s.Contains("1")) //the light is on
                {
                    ledStatus = true;
                    buttonLED.Invoke(this.myDelegate_button, new Object[] { "OFF" });
                }
                else //the light is off
                {
                    ledStatus = false;
                    buttonLED.Invoke(this.myDelegate_button, new Object[] { "ON" });
                }
            }
            else if (s.Contains("info=")) //starts as "info=firmware~serial"
            {
                s = s.Trim();
                s = s.Replace("info=", ""); //becomes "firmware~serial"
                string[] infoArray = s.Split('~'); //split into firmware and serial
                labelSerial.Invoke(this.serialDelegate, new Object[] { infoArray[1] });
                labelFirmware.Invoke(this.firmwrDelegate, new Object[] { infoArray[0] });
            }
            else if (s.Contains("time="))
            {
                //s.Replace("time=", "");
                s = s.Trim();
                s = s.Replace("time=", "Time: ");
                labelTime.Invoke(this.timeDelegate, new Object[] { s });
            }
            else
            {
                richTextBox1.Invoke(this.textDelegate, new Object[] { s });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ledStatus) //the light is on
            {
                serialPort1.WriteLine("OFF");
                buttonLED.Text = "OFF";
                ledStatus = false;
            } else //the light is off
            {
                serialPort1.WriteLine("ON");
                buttonLED.Text = "ON";
                ledStatus = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }

        /*
        Sync Time button
        */
        private void button2_Click(object sender, EventArgs e)
        {
            Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string unixDate = SYNCTIME;
            unixDate += unixTimestamp + '=';
            serialPort1.WriteLine(unixDate);
            //serialPort1.WriteLine("T1262347200");
        }

        public class Interfacex
        {

        }
    }
}
