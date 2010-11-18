namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_Group")]
    public class SYS_Group : ObjectRow {
        
        public SYS_Group() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_Group(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_Group(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("GroupID",true,true)]
        public int GroupID {
            get {
                return (System.Int32)GetValue("GroupID");
            }
            set {
                SetValue("GroupID", value);
            }
        }
        
        [Field("GroupName")]
        public string GroupName {
            get {
                return (System.String)GetValue("GroupName");
            }
            set {
                SetValue("GroupName", value);
            }
        }

        [Field("Valid")]
        public String Valid
        {
            get {
                return (System.String)GetValue("Valid");
            }
            set {
                SetValue("Valid", value);
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
