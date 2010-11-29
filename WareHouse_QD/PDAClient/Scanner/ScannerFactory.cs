using System;

using System.Collections.Generic;
using System.Text;

namespace PDAClient.Scanner
{
    public static class ScannerFactory
    {
        public static IScanner GetScanner()
        {
            IScanner scanner = null;

            if (Program.ActiveScanner == ScannerType.Symbol_MC3000)
                scanner = new SymbolScanner();
            else
                new ArgumentException("Invalid scanner type!");

            return scanner;
        }
    }
}
