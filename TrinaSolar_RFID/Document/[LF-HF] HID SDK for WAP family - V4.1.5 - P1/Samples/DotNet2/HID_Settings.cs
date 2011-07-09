using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PsionTeklogixRFIDDemoApplications
{
    public partial class HID_Settings : Form
    {
        public Int32 baudrate
        {
            get { return _baudrate; }
        }private Int32 _baudrate;

        public Byte protocol
        {
            get { return _protocol; }
        }private Byte _protocol;

        public Byte autodetect
        {
            get { return _autodetect; }
        }private Byte _autodetect;

        public HID_Settings(Int32 baudrate, Byte protocol, Byte autodetect)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            this._baudrate = baudrate;
            _cbBaudRate.SelectedItem = baudrate.ToString();

            this._protocol = protocol;
            if (_protocol == 0)
                radioButtonASCII.Checked = true;

            // If autodetect equals Byte.MaxValue it means it's not configurable
            // because the reader is already open
            this._autodetect = autodetect;
            if (_autodetect == Byte.MaxValue)
            {
                panelAutodetect.Enabled = false;
                labelAutodetect.Text = "Settings not available if reader open";
            }
            else
            {
                if (_autodetect >= 0x80)
                {
                    checkBox0x80.Checked = true;
                    _autodetect -= 0x80;
                }

                if (_autodetect == 0)
                    radioButtonNoAuto.Checked = true;
                else if (_autodetect == 1)
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            _baudrate = Int32.Parse(_cbBaudRate.SelectedItem.ToString());
            

            if( radioButtonASCII.Checked )
                _protocol = 0;
            else
                _protocol = 1;

            if (panelAutodetect.Enabled)
            {
                if (radioButtonNoAuto.Checked)
                    _autodetect = 0;
                else if (radioButton1.Checked)
                    _autodetect = 1;
                else
                    _autodetect = 2;

                if (checkBox0x80.Checked)
                    _autodetect += 0x80;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}