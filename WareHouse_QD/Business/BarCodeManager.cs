using System;
using System.Collections.Generic;
using System.Text;
using EBest.Persistent;
using EBest.Data;
using System.Data;
using eBest.Entity;

namespace eBest.Business
{
    public class BarCodeManager
    {
        public bool CheckBarCode(DataTable dtBarcode,out string errorMessage)
        {
            errorMessage = string.Empty;
            string pallets = string.Empty;

            try
            {
                foreach (DataRow row in dtBarcode.Rows)
                    pallets += "'" + row["Pallet"].ToString() + "',";

                pallets = pallets.TrimEnd(',');

                string sql = "SELECT PALLET_CODE FROM TB_BARCODE WHERE PALLET_CODE IN (" + pallets + ")";
                DataTable dtResults = SqlData.OpenSql(sql).Tables[0];

                if (dtResults.Rows.Count > 0)
                {
                    foreach (DataRow row2 in dtResults.Rows)
                        errorMessage += "托盘号：" + row2[0].ToString() + "已存在\n";
                }

            }
            catch (Exception error)
            {
                errorMessage = error.Message;
            }

            return (errorMessage == string.Empty);
        }

        public DataTable SearchStockIn(string order,string product)
        {
            string sql = string.Format(@"SELECT	PRODUCT_CODE
		                                        ,(SELECT COUNT(PALLET_CODE) FROM TB_STOCK_IN AS T
		                                         WHERE ORDER_NO='789' AND TB.PRODUCT_CODE=T.PRODUCT_CODE
		                                         GROUP BY PRODUCT_CODE) AS SUM_PALLET
		                                        ,PALLET_CODE,REC_USER_CODE,REC_TIME_STAMP
                                        FROM TB_STOCK_IN AS TB
                                        WHERE ORDER_NO='{0}' ", order);

            if (product != string.Empty)
                sql += " AND PRODUCT_CODE='" + product + "' ";

            sql += @"GROUP BY PRODUCT_CODE,PALLET_CODE,REC_USER_CODE,REC_TIME_STAMP
                    ORDER BY PRODUCT_CODE";

            return SqlData.OpenSql(sql).Tables[0];
        }

        public DataTable SearchInventory(DateTime day)
        {
            string sql = string.Format(@"SELECT	PRODUCT_CODE
		                                        ,(SELECT COUNT(PALLET_CODE) FROM TB_INVENTORY_CHECK AS T
		                                         WHERE DATEDIFF(DAY,REC_TIME_STAMP,'{0}')=0 AND TB.PRODUCT_CODE=T.PRODUCT_CODE
		                                         GROUP BY PRODUCT_CODE) AS SUM_PALLET
		                                        ,PALLET_CODE,REC_USER_CODE,REC_TIME_STAMP
                                        FROM TB_INVENTORY_CHECK AS TB
                                        WHERE DATEDIFF(DAY,REC_TIME_STAMP,'{0}')=0
                                        GROUP BY PRODUCT_CODE,PALLET_CODE,REC_USER_CODE,REC_TIME_STAMP
                                        ORDER BY PRODUCT_CODE", day.ToString());

            return SqlData.OpenSql(sql).Tables[0];
        }

        public DataTable SearchBarcode(string container)
        {
            string sql = "select * from TB_BARCODE where CONTAINER_CODE='" + container + "'";
            return SqlData.OpenSql(sql).Tables[0];
        }

        public bool DeliverCheck(string container, string barCode)
        {
            string sql = string.Format("select count(*) from TB_BARCODE where CONTAINER_CODE='{0}' and PALLET_CODE='{1}'", container, barCode);

            object result=SqlData.ExecuteScalar(sql);

            return (result != null && result.ToString() != "0");
        }
        
    }
}
