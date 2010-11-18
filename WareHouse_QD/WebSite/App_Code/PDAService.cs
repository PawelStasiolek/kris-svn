using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using eBest.Business;
using EBest.Data;
using eBest.Entity;

/// <summary>
///PDAService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class PDAService : System.Web.Services.WebService
{

    public PDAService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public bool PDALogin(string loginName, string pwd, out string errorMessage, out string userName)
    {
        userName = string.Empty;
        TB_User user = UserManager.Login(loginName, comm.EncryptMd5(pwd), out errorMessage);

        if (errorMessage != string.Empty)
            return false;

        if (user.GroupID.ToString() != ConfigManager.Load(ConfigType.MobileGroup).Value)
        {
            errorMessage = "错误的用户名或密码！";
            return false;
        }

        userName = user.Name;

        return true;
    }

    [WebMethod]
    public bool Inventory_Check(string product, string pallet,string user, out string errorMessage)
    {
        errorMessage = string.Empty;

        //校验是否已入库过
        string sql = string.Format("select count(*) from TB_STOCK_IN where PRODUCT_CODE='{0}' and PALLET_CODE='{1}'", product, pallet);
        object result = SqlData.ExecuteScalar(sql);
        if (result == null || result.ToString() == "0")
        {
            errorMessage = "数据库中无此组件数据,请先入库才能进行盘点!";
            return false;
        }

        //检查当天是否已盘点过
        sql = string.Format("select count(*) from TB_INVENTORY_CHECK where PRODUCT_CODE='{0}' and PALLET_CODE='{1}' and datediff(day,REC_TIME_STAMP,getdate())=0", product, pallet);
        result = SqlData.ExecuteScalar(sql);
        if (result == null || result.ToString() == "0")
        {
            TB_INVENTORY_CHECK inventoryCheck = new TB_INVENTORY_CHECK();
            inventoryCheck.PRODUCTCODE = product;
            inventoryCheck.PALLETCODE = pallet;
            inventoryCheck.RECTIMESTAMP = DateTime.Now;
            inventoryCheck.RECUSERCODE = user;
            inventoryCheck.Save();
        }

        return true;
    }

    [WebMethod]
    public bool StockIn(string orderNo, string product, string pallet, string user, out string errorMessage)
    {
        errorMessage = string.Empty;

        //校验是否已入库过
        string sql = string.Format("select count(*) from TB_STOCK_IN where PRODUCT_CODE='{0}' and PALLET_CODE='{1}'", product, pallet);
        object result = SqlData.ExecuteScalar(sql);
        if (result == null || result.ToString() == "0")
        {
            TB_STOCK_IN stockIn = new TB_STOCK_IN();
            stockIn.ORDERNO = orderNo;
            stockIn.PRODUCTCODE = product;
            stockIn.PALLETCODE = pallet;
            stockIn.RECUSERCODE = user;
            stockIn.RECTIMESTAMP = DateTime.Now;
            stockIn.Save();
            return true;
        }

        errorMessage = "产品条码: " + product + "\n托盘号: " + pallet + "\n已存在,请勿重复入库!";
        return false;
    }

    [WebMethod]
    public bool InsertBarcode(DataTable dtBarcode, string containerCode, string user, out string errorMessage)
    {
        errorMessage = string.Empty;

        //上传前检查失败
        if (!new BarCodeManager().CheckBarCode(dtBarcode, out errorMessage))
            return false;

        try
        {
            foreach (DataRow row in dtBarcode.Rows)
            {
                TB_BARCODE barcode = new TB_BARCODE();
                barcode.CONTAINERCODE = containerCode;
                barcode.PALLETCODE =row["Pallet"].ToString();
                barcode.PRODUCTCODE = row["Product"].ToString();
                barcode.STATUS = 0;
                barcode.RECTIMESTAMP = DateTime.Now;
                barcode.RECUSERCODE = user;
                barcode.Save();
            }
        }
        catch (Exception error)
        {
            errorMessage = "上传数据失败：" + error.Message;
        }

        return (errorMessage == string.Empty);

    }

    [WebMethod]
    public bool DeliverCheck(string containerCode, string barCode)
    {
        BarCodeManager barCodeManager = new BarCodeManager();

        return barCodeManager.DeliverCheck(containerCode, barCode);
    }

}

