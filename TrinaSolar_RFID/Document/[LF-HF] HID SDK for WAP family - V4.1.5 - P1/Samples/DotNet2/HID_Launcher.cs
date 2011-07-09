using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using HidGlobal.MultiIso.CFReader;
using PsionTeklogix.RFID;

namespace PsionTeklogixRFIDDemoApplications
{
    public partial class HID_Launcher : Form
    {
        static void Main()
        {
            try
            {
                Application.Run(new HID_Launcher());
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// RFID Driver class is used to manage the driver previously installed via CAB file
        /// Enable and Disable are the main functions to setup the RFID reader (power, com port assignement)
        /// </summary>
        private RFIDDriver rfidDriver = new RFIDDriver();        
        /// <summary>
        /// HID Reader class is used to manage the RFID HID Readers (LFX or MultiISO)
        /// It provides the basics functions to dialog with the reader (Open/Close/SendCommand/GetData/...)
        /// Each reader has these specific commands - refer to User Manual for more information
        /// For example: With SendCommandGetData, you can dialog with the reader
        ///     s = select a tag
        ///     r00 = read data from block 00 of selected tag
        ///     w0011223344 = write 11223344 in block 00 of selected tag
        ///     
        /// When the reader is connected, you can go to the HyperTerminal to play with these commands
        /// </summary>
        private HID_Reader Reader = null;


        private Int32 baudrate = 9600;
        private Byte protocol = 0;
        private Byte autodetect = 2;

        public HID_Launcher()
        {
            InitializeComponent();

            // Check if the RFID driver is well installed
            if (rfidDriver.IsInstalled)
            {
                _lblRFIDDriverStatus.Text = "Driver installed";
                _lblRFIDDriverStatus.ForeColor = Color.Green;
            }
            else
            {
                _lblRFIDDriverStatus.Text = "Driver NOT installed";
                _lblRFIDDriverStatus.ForeColor = Color.Red;
            }
        }


        private void HID_Launcher_Closing(object sender, CancelEventArgs e)
        {
            // Be sure the reader is closed and RFID driver is disabled
            CloseReader();
            if(rfidDriver.IsEnabled)rfidDriver.Disable();
        }

        public void ClearMsg()
        {
            this.listBox1.Items.Clear();
            this.listBox1.Refresh();
        }
        public void DisplayMsg(string msg)
        {
            this.listBox1.SelectedIndex = this.listBox1.Items.Add(msg);
            this.listBox1.Refresh();
        }

        private void _btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClearMsg();

                if (_btConnect.Text == "Connect")
                {
                    // Enable RFID driver (power / com port assignement)
                    rfidDriver.Enable();
                    // Open HID reader
                    // - Get automatically the Com Port allocated and provided by RFID driver
                    OpenReader(rfidDriver.ComPort);
                    _plExamples.Enabled = true; 
                    _btConnect.Text = "Disconnect";
                }
                else
                {
                    // Close HID reader
                    CloseReader();
                    // Disable RFID driver
                    rfidDriver.Disable();
                    _plExamples.Enabled = false; 
                    _btConnect.Text = "Connect";
                }
            }
            catch (Exception ex)
            {
                foreach (string msg in ex.Message.Split('\n'))
                    DisplayMsg(msg);

                CloseReader();
                if (rfidDriver.IsEnabled) rfidDriver.Disable();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #region Show Modules
        private void ClearModules()
        {
            _lb.Items.Clear();
        }
        private void DefaultModules()
        {
            _lb.Items.Add("Hyper Terminal");
        }
        private void LFModules()
        {
            _lb.Items.Add("LF Read/Write");
            _lb.Items.Add("Hitag S continuous reading");
        }
        private void HFModules()
        {
            _lb.Items.Add("ISO 15693");
            _lb.Items.Add("ISO 14443");
            _lb.Items.Add("MiFare Standard");
            _lb.Items.Add("MiFare Ultralight");
            _lb.Items.Add("MiFare DESFIRE");
            _lb.Items.Add("SAMs");
        }
        #endregion

        private void OpenReader(int ComPortNumber)
        {
            Reader = new HID_Reader();

            // Graphically, baudrate and protocol can be modified in Settings form
            HID_Reader.presetSettings PS;
            PS.baudRate = baudrate;
            PS.protocol = protocol;

            // Enable baudrates higher than 115200
            Reader.RDR_SetHighBaudrates(1);

            // ** Open comm
            if (Reader.RDR_OpenSingle(String.Format("COM{0}:", ComPortNumber), autodetect, 0 , PS) > 0)
            {
                DisplayMsg("OpenSingle successful (" + String.Format("COM{0}:", ComPortNumber) + ")");

                string buffer = "";
                byte[] Data = new byte[515];

                Reader.RDR_AbortContinuousReadExt();

                Reader.RDR_SetCommTimeout(500);

                
                // Update settings if autodetect mode has been used
                HID_Reader.readerConfig newConfig;
                newConfig.baudRate = baudrate;
                newConfig.protocol = protocol;
                newConfig.stationID = 1;
                Reader.RDR_SetReaderConfig(ref newConfig);

                // Get informations from the reader
                protocol = Reader.RDR_GetCommProtocol();
                if (protocol == 1)
                    DisplayMsg("Binary Protocol");
                else
                    DisplayMsg("ASCII Protocol");

                baudrate = Reader.RDR_GetCommBaudRate();
                DisplayMsg("Baudrate: " + baudrate.ToString());
                DisplayMsg("Timeout: " + Reader.RDR_GetCommTimeout());
                DisplayMsg("Station ID: " + Reader.RDR_GetStationID());

                DisplayMsg("Debug Output state: " + Reader.RDR_GetDebugOutputState());
                byte b = Reader.RDR_IsCommandAvailable("version");
                DisplayMsg("Is 'version' available: " + (b != 0 ? "yes" : "no"));
                Reader.RDR_GetReaderType(ref buffer);
                DisplayMsg("Type: " + buffer);

                // Determinate if the reader is a LF or HF reader
                ClearModules();
                DefaultModules();
                if (buffer.IndexOf("LFX") != -1)
                    LFModules();
                if (buffer.IndexOf("MultiISO") != -1)
                    HFModules();

                Reader.RDR_GetDeviceID(ref buffer);
                DisplayMsg("DeviceID: " + buffer);

                Reader.RDR_GetDLLVersionStr(ref buffer);
                DisplayMsg("DLL Version: " + buffer);

                Reader.RDR_SendCommandGetData("s", "", ref buffer);
                DisplayMsg("Select: " + buffer);
            }
            else
            {
                //Error during Open reader
                throw new Exception("OpenReader failed");
            }
        }

        private void CloseReader()
        {
            if (Reader != null)
            {
                DisplayMsg("Closing...");

                Reader.RDR_CloseReader();
                Reader.RDR_CloseComm();

                Reader = null;

                ClearModules();
                DisplayMsg("CloseReader successful");
            }
        }


        private void _btLaunch_Click(object sender, EventArgs e)
        {
            if (_lb.SelectedIndex != -1)
                switch (_lb.SelectedItem.ToString())
                {
                    case "Hyper Terminal":
                        HID_HyperTerminal fhp = new HID_HyperTerminal(Reader);
                        fhp.ShowDialog();
                        break;
                    //*********** LF reader
                    case "LF Read/Write":
                        HID_ReaderLF flf = new HID_ReaderLF(Reader);
                        flf.ShowDialog();
                        break;
                    case "Hitag S continuous reading":
                        HID_ReaderHitagS fhs = new HID_ReaderHitagS(Reader);
                        fhs.ShowDialog();
                        break;
                    //*********** HF reader
                    case "ISO 15693":
                        HID_ReaderISO15693 fi15693 = new HID_ReaderISO15693(Reader);
                        fi15693.ShowDialog();
                        break;
                    case "ISO 14443":
                        HID_ReaderISO14443 fi14443 = new HID_ReaderISO14443(Reader);
                        fi14443.ShowDialog();
                        break;
                    case "MiFare Standard":
                        HID_ReaderMiFareStandard fms = new HID_ReaderMiFareStandard(Reader);
                        fms.ShowDialog();
                        break;
                    case "MiFare Ultralight":
                        HID_ReaderMiFareUltralight fmu = new HID_ReaderMiFareUltralight(Reader);
                        fmu.ShowDialog();
                        break;
                    case "MiFare DESFIRE":
                        HID_ReaderMiFareDESFIRE fmdDualISO = new HID_ReaderMiFareDESFIRE(Reader);
                        fmdDualISO.ShowDialog();
                        break;
                    case "SAMs":
                        HID_ReaderSAMs fsams = new HID_ReaderSAMs(Reader);
                        fsams.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("\"" + 
                            _lb.SelectedItem.ToString() + 
                            "\", this form is unkown.");
                        break;
                }
        }

        private void _btSettings_Click(object sender, EventArgs e)
        {
            HID_Settings f;

            // If the reader is already open the autodetect settings are disabled
            if (Reader != null)
                f = new HID_Settings(baudrate, protocol, Byte.MaxValue);
            else
                f = new HID_Settings(baudrate, protocol, autodetect);

            DialogResult result = f.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Update the connection settings
                baudrate = f.baudrate;
                protocol = f.protocol;

                if (f.autodetect != Byte.MaxValue)
                    autodetect = f.autodetect;


                // The reader is open
                if (Reader != null)
                {
                    if (baudrate > 115200)
                        Reader.RDR_SetHighBaudrates(1);
                    else
                        Reader.RDR_SetHighBaudrates(0);

                    HID_Reader.readerConfig newConfig;
                    newConfig.baudRate = baudrate;
                    newConfig.protocol = protocol;
                    newConfig.stationID = 1;
                    Reader.RDR_SetReaderConfig(ref newConfig);

                    if (Reader.RDR_GetCommProtocol() == 1)
                        DisplayMsg("Binary Protocol");
                    else
                        DisplayMsg("ASCII Protocol");

                    DisplayMsg("Baudrate: " + Reader.RDR_GetCommBaudRate());

                }
            }
        }

        private void _btDriverInformation_Click(object sender, EventArgs e)
        {
            if (rfidDriver.IsInstalled)
            {
                List<String> infos = rfidDriver.GetInfos();
                ClearMsg();
                DisplayMsg("** RFID DRIVER INFORMATIONS **");
                foreach (string s in infos)
                {
                    DisplayMsg(s);
                }
            }
            else
                DisplayMsg("Driver NOT installed");

        }


    }
}