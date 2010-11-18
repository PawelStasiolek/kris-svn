namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_LogType")]
    public class SYS_LogType : ObjectRow {
        
        public SYS_LogType() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_LogType(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_LogType(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("LogTypeID")]
        public int LogTypeID {
            get {
                return (System.Int32)GetValue("LogTypeID");
            }
            set {
                SetValue("LogTypeID", value);
            }
        }
        
        [Field("TypeName")]
        public string TypeName {
            get {
                return (System.String)GetValue("TypeName");
            }
            set {
                SetValue("TypeName", value);
            }
        }
    }
}
