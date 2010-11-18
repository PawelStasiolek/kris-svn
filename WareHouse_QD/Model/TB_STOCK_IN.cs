namespace eBest.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("TB_STOCK_IN")]
    public class TB_STOCK_IN : ObjectRow {
        
        public TB_STOCK_IN() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public TB_STOCK_IN(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected TB_STOCK_IN(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Field("ORDER_NO")]
        public string ORDERNO {
            get {
                return (System.String)GetValue("ORDERNO");
            }
            set {
                SetValue("ORDERNO", value);
            }
        }
        
        [Key("PALLET_CODE")]
        public string PALLETCODE {
            get {
                return (System.String)GetValue("PALLETCODE");
            }
            set {
                SetValue("PALLETCODE", value);
            }
        }
        
        [Key("PRODUCT_CODE")]
        public string PRODUCTCODE {
            get {
                return (System.String)GetValue("PRODUCTCODE");
            }
            set {
                SetValue("PRODUCTCODE", value);
            }
        }
        
        [Field("REC_USER_CODE")]
        public string RECUSERCODE {
            get {
                return (System.String)GetValue("RECUSERCODE");
            }
            set {
                SetValue("RECUSERCODE", value);
            }
        }
        
        [Field("REC_TIME_STAMP")]
        public System.DateTime RECTIMESTAMP {
            get {
                return (System.DateTime)GetValue("RECTIMESTAMP");
            }
            set {
                SetValue("RECTIMESTAMP", value);
            }
        }
    }
}
