using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace RFID_Write
{
    public class DataManager
    {
        private string logPath = Program.AppFilePath + "\\Log\\Log.txt";
        private string excelPath = Program.AppFilePath + "\\list.csv";

        public string GetDataFromOpc(string modelNum, out string returnMsg)
        {
            returnMsg = string.Empty;
            string str=string.Empty;

            //访问OPC类，读取OPC数据
            OPCReader opc = new OPCReader(modelNum);

            //读取每个参数，并以|号连接成一个字符串

            str += "|";
            str += "|";
            str += "|";
            str += "|";
            str += "";

            return str;
        }

        public string GetDataFromCSV(string modelNum,out string returnMsg)
        {
            int index = 0;
            bool found = false;
            string text = string.Empty;
            returnMsg = "";

            try
            {
                if (!File.Exists(excelPath))
                    throw new Exception("找不到离线文件list.csv");

                StreamReader sr = new StreamReader(excelPath);
                string line;

                //组件号在第7行里
                line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine();
                string modelName = line.Split(',')[0];

                while ((line = sr.ReadLine()) != null)
                {
                    index++;

                    //有空行跳过
                    if (string.IsNullOrEmpty(line))
                        continue;

                    //检查字段数是否正确
                    string[] items = line.Split(',');
                    if (index>8 && items.Length <12)
                    {
                        returnMsg = "行:" + index.ToString()+"字段错误!";
                        return null;
                    }

                    //未找到对应信息
                    if (items[1] != modelNum)
                        continue;

                    //找到对应的标签信息
                    text += modelName + "|";

                    if (items.Length==12 || items[12].Trim()==string.Empty)
                        text += DateTime.Now.ToString("yyyy.M") + "|";
                    else
                        text += items[12].Trim() + "|";

                    text += items[4].Trim() + "Wp," + items[6].Trim() + "A," + items[5].Trim() + "V," + items[7].Trim() + "|";
                    text += "S/N" + items[1] + "|";
                    text += items[8];

                    found = true;
                    break;

                }

                sr.Close();

                if (!found)
                    returnMsg = "未找到条码对应的标签信息!";
            }
            catch (Exception errorIO)
            {
                returnMsg = errorIO.Message;
            }

            return text;
        }

        /// <summary>
        /// 在Log文件里写入已扫描的组件号和标签ID
        /// </summary>
        /// <param name="message"></param>
        public void WriteLog(string message)
        {
            if (!Directory.Exists(Program.AppFilePath+"\\Log"))
                Directory.CreateDirectory(Program.AppFilePath+"\\Log");

            StreamWriter sw=new StreamWriter(logPath,true);
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 判断此组件是否已写入过标签
        /// </summary>
        /// <param name="modelNum"></param>
        /// <returns></returns>
        public bool ModelWrited(string modelNum)
        {
            if (!Directory.Exists(Program.AppFilePath + "\\Log"))
                Directory.CreateDirectory(Program.AppFilePath + "\\Log");

            if (!File.Exists(logPath))
                return false;

            StreamReader sr = new StreamReader(logPath);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                //有空行跳过
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] items = line.Split(',');
                if (items[1] == modelNum)
                {
                    sr.Close();
                    return true;
                }

            }

            sr.Close();

            return false;
        }


    }

}
