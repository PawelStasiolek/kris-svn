using System;

using System.Collections.Generic;
using System.Text;
using Symbol.Barcode;

namespace PDAClient.Scanner
{
    public class SymbolScanner : IScanner
    {
        private Reader symbolReader = null;
        private ReaderData symbolReaderData = null;

        public SymbolScanner()
        {
            // If the scanner is already present, fail to initialize
            if (symbolReader == null)
            {

                // Create a new scanner; use the first available scanner
                symbolReader = new Reader();

                // Create the scanner data
                symbolReaderData = new ReaderData(ReaderDataTypes.Text,
                    ReaderDataLengths.MaximumLabel);

                // Create the event handler delegate
                symbolReader.ReadNotify += new EventHandler(symbolReader_ReadNotify);

                // Enable the scanner with a wait cursor
                symbolReader.Actions.Enable();

                // Set up the scanner
                symbolReader.Parameters.Feedback.Success.BeepTime = 200;
            }
        }


        public override void OpenScanner()
        {
            // If you have both a scanner and data
            if ((symbolReader != null) && (symbolReaderData != null))
                // Submit a scan
                symbolReader.Actions.Read(symbolReaderData);
        }

        public override void Stop()
        {
            if (symbolReader != null)
                symbolReader.Actions.Flush();
        }

        public override void CloseScanner()
        {
            // If you have a scanner
            if (symbolReader != null)
            {
                // Disable the scanner
                symbolReader.Actions.Disable();

                // Free it up
                symbolReader.Dispose();

                // Indicate that you no longer have a scanner
                symbolReader = null;
            }

            // If you have a scanner data object
            if (symbolReaderData != null)
            {
                // Free it up
                symbolReaderData.Dispose();

                // Indicate that you no longer have a scanner
                symbolReaderData = null;
            }
        }

        private void symbolReader_ReadNotify(object sender, EventArgs e)
        {
            ReaderData readerData = symbolReader.GetNextReaderData();

            // If successful, scan
            if (readerData.Result == Symbol.Results.SUCCESS)
            {
                // Raise the scan event to the caller (with data)
                OnBarcodeScan(readerData.Text);

                // Start the next scan
                OpenScanner();
            }
        }

    }
}
