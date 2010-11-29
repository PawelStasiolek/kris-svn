using System;
using System.Collections.Generic;
using System.Text;

namespace PDAClient.Scanner
{
    // Delegate
    public delegate void BarcodeScanEventHandler(string barCode);

    // Interface Scanner
    public abstract class IScanner
    {
        // Bar code notify
        public BarcodeScanEventHandler BarCodeReceived;
        public event BarcodeScanEventHandler BarcodeScan;
        protected virtual void OnBarcodeScan(string barcode)
        {
            if (BarcodeScan != null)
                BarcodeScan(barcode);
        }

        public abstract void OpenScanner();
        public abstract void Stop();
        public abstract void CloseScanner();
    }
}
