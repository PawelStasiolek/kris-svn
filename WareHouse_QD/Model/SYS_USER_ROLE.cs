namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_USER_ROLE")]
    public class SYS_USER_ROLE : ObjectRow {
        
        public SYS_USER_ROLE() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_USER_ROLE(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_USER_ROLE(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("RoleID",true,true)]
        public int RoleID {
            get {
                return (System.Int32)GetValue("RoleID");
            }
            set {
                SetValue("RoleID", value);
            }
        }
        
        [Field("GroupID")]
        public int GroupID {
            get {
                return (System.Int32)GetValue("GroupID");
            }
            set {
                SetValue("GroupID", value);
            }
        }
        
        [Field("MenuID")]
        public int MenuID {
            get {
                return (System.Int32)GetValue("MenuID");
            }
            set {
                SetValue("MenuID", value);
            }
        }
    }
}
