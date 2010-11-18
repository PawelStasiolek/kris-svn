namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("TB_INVENTORY_CHECK")]
    public class TB_INVENTORY_CHECK : ObjectRow {
        
        public TB_INVENTORY_CHECK() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public TB_INVENTORY_CHECK(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected TB_INVENTORY_CHECK(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("ID",true,true)]
        public int ID {
            get {
                return (System.Int32)GetValue("ID");
            }
            set {
                SetValue("ID", value);
            }
        }
        
        [Field("PALLET_CODE")]
        public string PALLETCODE {
            get {
                return (System.String)GetValue("PALLETCODE");
            }
            set {
                SetValue("PALLETCODE", value);
            }
        }
        
        [Field("PRODUCT_CODE")]
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
