namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_MODULE")]
    public class SYS_MODULE : ObjectRow {
        
        public SYS_MODULE() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_MODULE(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_MODULE(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("ModuleID",true,true)]
        public int ModuleID {
            get {
                return (System.Int32)GetValue("ModuleID");
            }
            set {
                SetValue("ModuleID", value);
            }
        }
        
        [Field("ModuleName")]
        public string ModuleName {
            get {
                return (System.String)GetValue("ModuleName");
            }
            set {
                SetValue("ModuleName", value);
            }
        }
        
        [Field("PageIndex")]
        public int PageIndex {
            get {
                return (System.Int32)GetValue("PageIndex");
            }
            set {
                SetValue("PageIndex", value);
            }
        }
        
        [Field("ICON")]
        public string ICON {
            get {
                return (System.String)GetValue("ICON");
            }
            set {
                SetValue("ICON", value);
            }
        }
    }
}
