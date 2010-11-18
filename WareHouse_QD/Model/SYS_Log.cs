namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_Log")]
    public class SYS_Log : ObjectRow {
        
        public SYS_Log() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_Log(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_Log(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("LogID",true,true)]
        public int LogID {
            get {
                return (System.Int32)GetValue("LogID");
            }
            set {
                SetValue("LogID", value);
            }
        }
        
        [Field("LogType")]
        public int LogType {
            get {
                return (System.Int32)GetValue("LogType");
            }
            set {
                SetValue("LogType", value);
            }
        }
        
        [Field("Text")]
        public string Text {
            get {
                return (System.String)GetValue("Text");
            }
            set {
                SetValue("Text", value);
            }
        }
        
        [Field("UpdateBy")]
        public string UpdateBy {
            get {
                return (System.String)GetValue("UpdateBy");
            }
            set {
                SetValue("UpdateBy", value);
            }
        }
        
        [Field("LastDate")]
        public System.DateTime LastDate {
            get {
                return (System.DateTime)GetValue("LastDate");
            }
            set {
                SetValue("LastDate", value);
            }
        }
    }
}
