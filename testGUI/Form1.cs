using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
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
        public delegate void addListBoxDelegate(List<Variable> myList);
        public addListBoxDelegate listBoxDelegate;
        bool ledStatus = false;
        volatile bool running = false;
        private int lastSelected = 0;
        const string STATE = "<STATE>",
            INFO = "<INFO>",
            GETTIME = "<GETTIME>",
            SYNCTIME = "<SYNCTIME",
            GETVARS = "<GETVARS>",
            GETVAR = "<GETVAR",
            SETVAR = "<SETVAR",
            RES = "<RES>";
        
        Variables varHolder;

        

        public Form1()
        {
            InitializeComponent();
        }

        /*
        peforms initial setup and makes sure that there is a valid device connected
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            varHolder = new Variables();
            running = true;
            this.textDelegate = new SetTextDelegate(DisplayMessage);
            this.myDelegate_button = new AddDataDelegate_button(setButtonLEDText);
            this.serialDelegate = new setSerialDelegate(setSerial);
            this.firmwrDelegate = new setFirmwrDelegate(setFirmware);
            this.timeDelegate = new setTimeDelegate(setTime);
            this.listBoxDelegate = new addListBoxDelegate(setListBox);

            try
            {                       
                serialPort1.Open();//try to establish a connection
                serialPort1.WriteLine(STATE); //get the state of the LED
                serialPort1.WriteLine(INFO);    //get the serial number and firmware
                serialPort1.WriteLine(GETTIME); //get the time from the board
                serialPort1.WriteLine(GETVARS); //get the variables from the running program
                //start new thread to handle periodically getting the time
                Thread timeThread = new Thread(new ThreadStart(this.startTimeThread));
                timeThread.IsBackground = true; 
                timeThread.Start();

            }
            catch (Exception exception) //no device detected
            {
                MessageBox.Show("No device detected" + "\n" + exception, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /*
        handles input from the serial port
        */
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string s = serialPort1.ReadLine(); //get the data
                s = s.TrimStart();
                if (s.Contains("STATE=")) //received the LED state
                {
                    string new_s = s;
                    //string new_s = s.Replace("state=", "");
                    if (new_s.Contains("1")) //the light is on
                    {
                        ledStatus = true;
                        buttonLED.Invoke(this.myDelegate_button, new Object[] { "OFF" }); //invoke setButtonLED()
                    }
                    else //the light is off
                    {
                        ledStatus = false;
                        buttonLED.Invoke(this.myDelegate_button, new Object[] { "ON" }); //invoke setButtonLED()
                    }
                }
                else if (s.Contains("info=")) //get firmware and serial data. data formatted as "info=firmware~serial"
                { 
                    s = s.Replace("info=", ""); //becomes "firmware~serial"
                    string[] infoArray = s.Split('~'); //split into firmware and serial
                    labelSerial.Invoke(this.serialDelegate, new Object[] { infoArray[1] });
                    labelFirmware.Invoke(this.firmwrDelegate, new Object[] { infoArray[0] });
                }
                else if (s.Contains("time=")) //receive the time from the device
                {
                    s = s.Replace("time=", "board time: ");
                    labelTime.Invoke(this.timeDelegate, new Object[] { s });
                }
                else if (s.Contains("VAR=")) //receive a single variable data
                {
                    //Console.WriteLine(s);
                    s = s.Replace("VAR=", ""); 
                    string[] var = s.Split('~');
                    varHolder.addVariable(var);
                    listBoxVariables.Invoke(this.listBoxDelegate, new Object[] { varHolder.varList });
                }
                else
                {
                    richTextBox1.Invoke(this.textDelegate, new Object[] { s });
                }
            }catch(Exception exception)
            {

                MessageBox.Show("The Device couldn't be reached" + "\n" + exception, "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }



        //------------------Set text for Form1 items-------------------\\
        #region setText
        /*
        starts seperate thread that checks the time every few seconds
        */
        private void startTimeThread()
        {
            while (running)
            {
                try
                {
                    serialPort1.WriteLine(GETTIME);
                    System.Threading.Thread.Sleep(5000);

                }
                catch (Exception e)
                {
                    MessageBox.Show("The device couldn't be reached" + "\n" + e, "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        /*
        set the text on the LED button
        */
        private void setButtonLEDText(string myString)
        {
            buttonLED.Text = myString;
        }
        /*
        set the text in the rich text box
        */
        private void DisplayMessage(string myString)
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
        fills the listbox with the contents of the variable list (varList)
        */
        private void setListBox(List<Variable> itemList)
        {
            listBoxVariables.Items.Clear();
            foreach (Variable var in itemList) //for each item in varList
            {
                string varID = var.id.ToString();   //get the id of item
                string listItem = varID.PadRight(6 - varID.Length) + "\t" +
                   var.name.PadRight(20 - var.name.Length) + "\t" +
                   var.type.PadRight(10 - var.type.Length) + "\t" +
                   var.value;                       //format string
                listBoxVariables.Items.Add(listItem); //add to the listbox
            }

            if (this.listBoxVariables.SelectedIndex == -1) //if no item is selected
            {
                lastSelected = varHolder.getIndex(lastSelected); //get the last selected item
                this.listBoxVariables.SetSelected(lastSelected, true); //select that item
            }
        }
        #endregion


        //------------------handles user interaction with Form1-----------------\\
        #region FormInteraction


        //------------------- textbox interaction--------------------\\
        #region textBox

        /*
        User wishes to modify the variable
        */
        private void butonApply_Click(object sender, EventArgs e)
        {
            string newValue = textBox1.Text;
            int index = listBoxVariables.SelectedIndex;
            string type = varHolder.varList.ElementAt(index).type;
            if (varHolder.validVarChange(type, newValue))
            {
                if (type.Equals("bool") && (newValue.Equals("true") || newValue.Equals("false")))
                    newValue = varHolder.boolAr(newValue);
                string message = SETVAR + index + '~' + newValue + '>';
                Console.WriteLine("index: " + index + "  type: " + type + "  newValue: " + newValue);
                serialPort1.Write(message);
                labelError.Text = "";
                serialPort1.Write(INFO);
                alreadyFocused = false;
            }
            else
            {
                textBox1.Text = varHolder.varList[index].value;
                alreadyFocused = false;                
                labelError.Text = "Invalid input type. please enter a(n) " + type;
            }
        }
        bool alreadyFocused;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                butonApply_Click(this, new EventArgs());   
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            alreadyFocused = false;
        }

 
        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(!alreadyFocused && this.textBox1.SelectionLength == 0)
            {
                alreadyFocused = true;
                this.textBox1.SelectAll();
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (MouseButtons == MouseButtons.None)
            {
                this.textBox1.SelectAll();
                alreadyFocused = true;
            }
        }

        #endregion

        //------------------- variable list interaction ------------------\\
        #region variableList

        /*
        Sends a request to the board to resend & refresh the list of variables
        */
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(GETVARS);
        }

        private void buttonIDSort_Click(object sender, EventArgs e)
        {
            varHolder.sortList("id");
            buttonIDSort.BackColor = SystemColors.ControlDark;
            buttonNameSort.BackColor = SystemColors.Control;
            buttonTypeSort.BackColor = SystemColors.Control;
            buttonValueSort.BackColor = SystemColors.Control;
            listBoxVariables.Invoke(this.listBoxDelegate, new Object[] { varHolder.varList });
        }

        private void buttonNameSort_Click(object sender, EventArgs e)
        {
            varHolder.sortList("name");
            buttonIDSort.BackColor = SystemColors.Control;
            buttonNameSort.BackColor = SystemColors.ControlDark;
            buttonTypeSort.BackColor = SystemColors.Control;
            buttonValueSort.BackColor = SystemColors.Control;
            listBoxVariables.Invoke(this.listBoxDelegate, new Object[] { varHolder.varList });
        }

        private void buttonTypeSort_Click(object sender, EventArgs e)
        {
            varHolder.sortList("type");
            buttonIDSort.BackColor = SystemColors.Control;
            buttonNameSort.BackColor = SystemColors.Control;
            buttonTypeSort.BackColor = SystemColors.ControlDark;
            buttonValueSort.BackColor = SystemColors.Control;
            listBoxVariables.Invoke(this.listBoxDelegate, new Object[] { varHolder.varList });
        }

        private void buttonValueSort_Click(object sender, EventArgs e)
        {
            varHolder.sortList("value");
            buttonIDSort.BackColor = SystemColors.Control;
            buttonNameSort.BackColor = SystemColors.Control;
            buttonTypeSort.BackColor = SystemColors.Control;
            buttonValueSort.BackColor = SystemColors.ControlDark;
            listBoxVariables.Invoke(this.listBoxDelegate, new Object[] { varHolder.varList });
        }
        /*
        listbox selected item changed
        */
        private void listBoxVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the index by parsing the first three characters into an int
            int index = int.Parse(listBoxVariables.SelectedItem.ToString().Substring(0, 3));
            if (index != -1)
                lastSelected = index;
            //serialPort1.Write(GETVAR + index + "=");
            try
            {
                textBox1.Text = varHolder.varList[index].value;
                textBox1.Focus();
            }
            catch (Exception exception)
            { //do nothing 
            }
        }
        #endregion

        //--------------------various form interaction ---------------------\\
        #region form

        private void Form1_Click(object sender, EventArgs e)
        {
            textBox1.DeselectAll();
            buttonApply.Focus();
            alreadyFocused = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Form1_Click(this, new EventArgs());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            Application.Exit();
        }

        #endregion

        /*
        Sync Time button
        */
        private void buttonSyncTime_Click(object sender, EventArgs e)
        {
            Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string unixDate = SYNCTIME;
            unixDate += unixTimestamp + '>';
            serialPort1.WriteLine(unixDate);
            //serialPort1.WriteLine("T1262347200");
        }    

        /*
        Reset button is pressed
        */
        private void buttonReset_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(RES);
            richTextBox1.Clear();
        }
        /*
        LED button is pressed (OFF/ON)
        */
        private void buttonLED_Click(object sender, EventArgs e)
        {
            if (ledStatus) //the light is on
            {
                serialPort1.WriteLine("<OFF>");
                buttonLED.Text = "OFF";
                ledStatus = false;
            } else //the light is off
            {
                serialPort1.WriteLine("<ON>");
                buttonLED.Text = "ON";
                ledStatus = true;
            }
        }

        #endregion
    }
}
