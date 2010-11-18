using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Net.Mail;


/// <summary>
///comm 的摘要说明
/// </summary>
public class comm : PageBase
{

    #region 进行MD5加密

    /// <summary>
    /// 进行MD5加密
    /// </summary>
    /// <param name="pwd">待加密字符串</param>
    /// <returns></returns>
    public static string EncryptMd5(string pwd)
    {
        string pwd2 = string.Empty;
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
        for (int i = 0; i < s.Length; i++)
        {
            // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

            pwd2 = pwd2 + s[i].ToString("X");

        }
        return pwd2; ;
    }

    #endregion

    #region Base64加密解密

    /// <summary>
    /// Base64加密解密
    /// </summary>
    /// <param name="url">URL</param>
    /// <param name="isEncrypt">是否加密</param>
    /// <returns></returns>
    public static string EncryptUrl(string url, bool isEncrypt)
    {
        string result, encodeUrl;
        if (isEncrypt)
        {
            try
            {
                encodeUrl = Convert.ToBase64String(System.Text.ASCIIEncoding.Default.GetBytes(url));
                result = UrlEncode(encodeUrl, true);
            }
            catch
            {
                result = url;
            }
        }
        else
        {
            try
            {
                encodeUrl = System.Text.ASCIIEncoding.Default.GetString(Convert.FromBase64String(url));
                result = UrlEncode(encodeUrl, false);
            }
            catch
            {
                result = url;
            }
        }
        return result;
    }

    #endregion

    #region Url地址编码
    /// <summary>
    /// Url地址编码
    /// </summary>
    /// <param name="url">Url</param>
    /// <param name="Encode">是否加密</param>
    /// <returns></returns>
    public static string UrlEncode(string url, bool Encode)
    {
        return Encode ? System.Web.HttpUtility.UrlEncode(url, Encoding.Default) : System.Web.HttpUtility.UrlDecode(url, Encoding.Default);
    }
    #endregion

    #region 获取客户端IP

    public static string GetClientIP()
    {
        string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (null == result || result == String.Empty)
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        if (null == result || result == String.Empty)
        {
            result = HttpContext.Current.Request.UserHostAddress;
        }
        return result;
    }

    #endregion

    #region 转换人民币大写

    public static string CmycurD(decimal num)
    {
        string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
        string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
        string str3 = "";    //从原num值中取出的值 
        string str4 = "";    //数字的字符串形式 
        string str5 = "";  //人民币大写金额形式 
        int i;    //循环变量 
        int j;    //num的值乘以100的字符串长度 
        string ch1 = "";    //数字的汉语读法 
        string ch2 = "";    //数字位的汉字读法 
        int nzero = 0;  //用来计算连续的零值是几个 
        int temp;            //从原num值中取出的值 

        num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
        str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
        j = str4.Length;      //找出最高位 
        if (j > 15) { return "溢出"; }
        str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

        //循环取出每一位需要转换的值 
        for (i = 0; i < j; i++)
        {
            str3 = str4.Substring(i, 1);          //取出需转换的某一位的值 
            temp = Convert.ToInt32(str3);      //转换为数字 
            if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
            {
                //当所取位数不为元、万、亿、万亿上的数字时 
                if (str3 == "0")
                {
                    ch1 = "";
                    ch2 = "";
                    nzero = nzero + 1;
                }
                else
                {
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                }
            }
            else
            {
                //该位是万亿，亿，万，元位等关键位 
                if (str3 != "0" && nzero != 0)
                {
                    ch1 = "零" + str1.Substring(temp * 1, 1);
                    ch2 = str2.Substring(i, 1);
                    nzero = 0;
                }
                else
                {
                    if (str3 != "0" && nzero == 0)
                    {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 == "0" && nzero >= 3)
                        {
                            ch1 = "";
                            ch2 = "";
                            nzero = nzero + 1;
                        }
                        else
                        {
                            if (j >= 11)
                            {
                                ch1 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                ch1 = "";
                                ch2 = str2.Substring(i, 1);
                                nzero = nzero + 1;
                            }
                        }
                    }
                }
            }
            if (i == (j - 11) || i == (j - 3))
            {
                //如果该位是亿位或元位，则必须写上 
                ch2 = str2.Substring(i, 1);
            }
            str5 = str5 + ch1 + ch2;

            if (i == j - 1 && str3 == "0")
            {
                //最后一位（分）为0时，加上“整” 
                str5 = str5 + '整';
            }
        }
        if (num == 0)
        {
            str5 = "零元整";
        }
        return str5;
    }

    #endregion

}
