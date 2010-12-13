using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using eBest.Business;

public partial class system_Inventory : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        gvBarcodeList.DataSource = new BarCodeManager().SearchInventory(DateTime.Parse(txtDate.Value));
        gvBarcodeList.DataBind();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        this.ExportGridView(gvBarcodeList, "InventoryChecking_" + txtDate.Value);
    }
}
