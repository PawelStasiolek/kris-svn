namespace eBest.Entity{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("TB_BARCODE")]
    public class TB_BARCODE : ObjectRow {
        
        public TB_BARCODE() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public TB_BARCODE(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected TB_BARCODE(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
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
        
        [Field("CONTAINER_CODE")]
        public string CONTAINERCODE {
            get {
                return (System.String)GetValue("CONTAINERCODE");
            }
            set {
                SetValue("CONTAINERCODE", value);
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
        
        [Field("STATUS")]
        public int STATUS {
            get {
                return (System.Int32)GetValue("STATUS");
            }
            set {
                SetValue("STATUS", value);
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
        
        [Field("LAST_UPDATE")]
        public string LASTUPDATE {
            get {
                return (System.String)GetValue("LASTUPDATE");
            }
            set {
                SetValue("LASTUPDATE", value);
            }
        }
        
        [Field("LAST_UPDATE_DATE")]
        public System.DateTime LASTUPDATEDATE {
            get {
                return (System.DateTime)GetValue("LASTUPDATEDATE");
            }
            set {
                SetValue("LASTUPDATEDATE", value);
            }
        }
    }
}
