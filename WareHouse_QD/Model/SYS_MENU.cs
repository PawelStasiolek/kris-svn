namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_MENU")]
    public class SYS_MENU : ObjectRow {
        
        public SYS_MENU() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_MENU(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_MENU(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("MenuID",true,true)]
        public int MenuID {
            get {
                return (System.Int32)GetValue("MenuID");
            }
            set {
                SetValue("MenuID", value);
            }
        }
        
        [Field("MenuName")]
        public string MenuName {
            get {
                return (System.String)GetValue("MenuName");
            }
            set {
                SetValue("MenuName", value);
            }
        }
        
        [Field("ModuleID")]
        public int ModuleID {
            get {
                return (System.Int32)GetValue("ModuleID");
            }
            set {
                SetValue("ModuleID", value);
            }
        }
        
        [Field("Link")]
        public string Link {
            get {
                return (System.String)GetValue("Link");
            }
            set {
                SetValue("Link", value);
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
        
        [Field("IsDisplay")]
        public bool IsDisplay {
            get {
                return (System.Boolean)GetValue("IsDisplay");
            }
            set {
                SetValue("IsDisplay", value);
            }
        }
    }
}
