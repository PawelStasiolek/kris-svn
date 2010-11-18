using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PDAClient
{
    public partial class FormWebServiceCall : Form
    {
        // Platform invoke
        [DllImport("coredll.dll")]
        private extern static int QueryPerformanceCounter(out long perfCounter);

        [DllImport("coredll.dll")]
        private extern static int QueryPerformanceFrequency(out long frequency);

        // Main thread
        Thread mainThread = Thread.CurrentThread;

        private string methodName = string.Empty;
        private object[] parameters = null;
        private bool serviceInvokeOK = false;
        private object[] results = null;
        private Exception exception = null;

        // System timing
        private long frequencyPerMillisencond;
        private long beginCount;

        public FormWebServiceCall()
        {
            InitializeComponent();
        }

        // Web service method description
        public string MethodName
        {
            set
            {
                this.methodName = value;
            }
        }

        // Web service parameters description
        public object[] Parameters
        {
            set
            {
                this.parameters = value;
            }
        }

        // Web service invoke result
        public bool ServiceInvokeOK
        {
            get
            {
                return this.serviceInvokeOK;
            }
        }

        // Web service results (used when webServiceInvokeOK == true)
        public object[] Results
        {
            get
            {
                return this.results;
            }
        }

        // Error description (used when webServiceInvokeOK == false)
        public Exception Exception
        {
            get
            {
                return this.exception;
            }
        }

        private void FormWebServiceCall_Load(object sender, EventArgs e)
        {
            // Relocation
            this.Location = new Point((324 - this.Width) / 2, 80);

            // Get frequency per milliseconds
            long frequency;
            QueryPerformanceFrequency(out frequency);
            this.frequencyPerMillisencond = frequency / 1000;

            // Begin timing
            QueryPerformanceCounter(out this.beginCount);

            // Start timer
            timer.Enabled = true;

            // Start web service thread
            Thread webServiceThread = new Thread(new ThreadStart(WebServiceProc));
            webServiceThread.Start();

        }

        private void WebServiceProc()
        {
            try
            {
                string errorString;
                bool ok;

                switch (this.methodName)
                {
                    case "Login":
                        string userName;
                        ok = Program.MyPDAService.PDALogin((string)this.parameters[0], (string)this.parameters[1], out errorString, out userName);
                        this.results = new object[] { ok, userName, errorString };
                        break;
                    case "InsertBarcode":
                        ok = Program.MyPDAService.InsertBarcode((DataTable)this.parameters[0], (string)this.parameters[1], (string)this.parameters[2], out errorString);
                        this.results = new object[] { ok, errorString };
                        break;
                    case "StockIn":
                        ok = Program.MyPDAService.StockIn((string)this.parameters[0], (string)this.parameters[1], (string)this.parameters[2], Program.UserName, out errorString);
                        this.results = new object[] { ok, errorString };
                        break;
                    case "InventoryCheck":
                        ok = Program.MyPDAService.Inventory_Check((string)this.parameters[0], (string)this.parameters[1], Program.UserName, out errorString);
                        this.results = new object[] { ok, errorString };
                        break;
                    case "DeliverCheck":
                        ok = Program.MyPDAService.DeliverCheck((string)this.parameters[0], (string)this.parameters[1]);
                        this.results = new object[] { ok };
                        break;
                    default:
                        throw new Exception("未知的 Web Service 方法调用！");
                }

                // Flag invoke success
                serviceInvokeOK = true;
            }
            catch(Exception ex)
            {
                this.exception = ex;
            }

            // Call UI thread method (notify UI thread)
            this.Invoke(new EventHandler(OnWebServiceFinished));

        }

        private void FormWebServiceCall_Paint(object sender, PaintEventArgs e)
        {
            // Draw border
            e.Graphics.DrawRectangle(new Pen(Color.Black), this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientSize.Width - 1, this.ClientSize.Height - 1);

        }

        private void OnWebServiceFinished(object sender, EventArgs e)
        {
            // Stop timer
            timer.Enabled = false;

            // Manual call timer handler to last show time information
            timer_Tick(null, null);

            // Close form
            this.DialogResult = DialogResult.OK;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Upload data pack elapsed time
            long endCount;
            QueryPerformanceCounter(out endCount);

            // Get elapsed time
            int nTotalMilliseconds = (int)((endCount - beginCount) / frequencyPerMillisencond);

            // Update UI
            lblDuration.Text = string.Format("{0:0.0} 秒", (float)nTotalMilliseconds / 1000);
            lblDuration.Update();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.MyPDAService.Abort();
        }
    }
}