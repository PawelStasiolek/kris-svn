using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace RFID_Write
{
    public class DataManager
    {
        private string logPath = Program.AppFilePath + "\\Log\\Log.txt";
        private string excelPath = Program.AppFilePath + "\\list.csv";

        public string GetDataFromOnline(string modelNum, out string returnMsg, out bool overWrite)
        {
            returnMsg = string.Empty;
            overWrite = false;
            string str=string.Empty;

            try
            {
                Webservice.Service1 service = new RFID_Write.Webservice.Service1();
                service.Url = Program.WebserviceUrl;
                service.Timeout = 20000;
                Webservice.module_info moduleInfo = service.GetModuleInfo(modelNum);

                if (string.IsNullOrEmpty(moduleInfo.Module_Type))
                    returnMsg = "未找到条码对应的标签信息!";
                else
                {
                    //读取每个参数，并以|号连接成一个字符串
                    str += moduleInfo.Module_Manuf + "|";
                    str += moduleInfo.Cell_Manuf + "|";
                    str += moduleInfo.Module_Type + "|";
                    str += DateTime.Parse(moduleInfo.Test_Date).ToString("yyyy.MM.dd") + "|";
                    str += moduleInfo.Country_of_Origin + "|";
                    str += Convert.ToDouble(moduleInfo.Pmpp).ToString("0.0") + "," + Convert.ToDouble(moduleInfo.Impp).ToString("0.00") + "|";
                    str += Convert.ToDouble(moduleInfo.Umpp).ToString("0.0") + "," + Convert.ToDouble(moduleInfo.FF).ToString("0.00") + "|";
                    str += moduleInfo.Serial_No + "|";
                    str += moduleInfo.Certificate_time + "|";
                    str += moduleInfo.Certificate;

                    overWrite = moduleInfo.flag == "1";
                }
            }
            catch (Exception error)
            {
                if (error is WebException)
                    returnMsg = WebExceptionMessage.GetWebExceptionMessage((WebException)error);
                else
                    returnMsg = "接口调用失败," + error.Message;
            }

            return str;
        }

        public string GetDataFromLocal(string modelNum,out string returnMsg,out bool overWrite)
        {
            int index = 0;
            bool found = false;
            string text = string.Empty;
            returnMsg = "";
            overWrite = false;

            try
            {
                if (!File.Exists(excelPath))
                    throw new Exception("找不到离线文件list.csv");

                overWrite = ModelWrited(modelNum);

                StreamReader sr = new StreamReader(excelPath);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    index++;

                    //有空行跳过
                    if (string.IsNullOrEmpty(line))
                        continue;

                    //检查字段数是否正确
                    string[] items = line.Split(',');
                    if (items.Length <17)
                    {
                        returnMsg = "行:" + index.ToString()+"字段数错误!";
                        return null;
                    }

                    //未找到对应信息
                    if (items[1] != modelNum)
                        continue;

                    //Module Manuf.
                    text += items[12] + "|";

                    //Cells Manuf.
                    text += items[13] + "|";

                    //Model No.
                    text += items[2] + "|";

                    //Module Manuf. date
                    text += DateTime.Parse(items[11]).ToString("yyyy.MM.dd") + "|";

                    //Country of origin
                    text += items[14] + "|";

                    //Wattage,Im,Vm and FF for the module
                    text += Convert.ToDouble(items[7].Trim()).ToString("0.0") + "," + Convert.ToDouble(items[6].Trim()).ToString("0.00") + "|";

                    text += Convert.ToDouble(items[5].Trim()).ToString("0.0") + "," + Convert.ToDouble(items[8].Trim()).ToString("0.00") + "|";

                    //Serial No
                    text += items[1].Trim() + "|";

                    //IEC Certificate Date
                    text += items[16].Trim() + "|";

                    //IEC certificate 
                    text += items[15].Trim();

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

        public bool WriteFlagToService(string modelNum,out string returnMsg)
        {
            returnMsg = string.Empty;
            try
            {
                Webservice.Service1 service = new RFID_Write.Webservice.Service1();
                service.Url = Program.WebserviceUrl;
                service.Timeout = 20000;
                service.ResetWritedFlag(modelNum, "0");
                return true;
            }
            catch (Exception error)
            {
                if (error is WebException)
                    returnMsg = WebExceptionMessage.GetWebExceptionMessage((WebException)error);
                else
                    returnMsg = "接口调用失败," + error.Message;

                return false;
            }

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

                string[] items = line.Split('~');
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
