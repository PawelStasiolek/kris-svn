using System;
using System.Collections.Generic;
using System.Text;
using FactoryWorksOPC;

namespace RFID_Write
{
    public class OPCReader
    {
        private string key;
        private FactoryWorksOPC.FactoryWorksOPC FactoryWorksOPC1 = new FactoryWorksOPC.FactoryWorksOPC();

        public OPCReader(string modelNum)
        {
            this.key = modelNum;

            FactoryWorksOPC1.Channel = FactoryWorksOPC.FactoryWorksOPC.EnumChannel.Ethernet;
            FactoryWorksOPC1.Token = Program.OPC_Token;
            FactoryWorksOPC1.Action = FactoryWorksOPC.FactoryWorksOPC.Behavior.Interaction;
        }

        /// <summary>
        /// Get Model number
        /// </summary>
        /// <returns></returns>
        public string Excute(string parameter)
        {
            string message = string.Empty;
            message = FactoryWorksOPC1.Execute(Program.OPC_WorkShop, Program.OPC_Category, parameter, key);
            return message;
        }

    }
}
