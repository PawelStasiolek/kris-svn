namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_Config")]
    public class SYS_Config : ObjectRow {
        
        public SYS_Config() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_Config(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_Config(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
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
        
        [Field("Name")]
        public string Name {
            get {
                return (System.String)GetValue("Name");
            }
            set {
                SetValue("Name", value);
            }
        }
        
        [Field("Value")]
        public string Value {
            get {
                return (System.String)GetValue("Value");
            }
            set {
                SetValue("Value", value);
            }
        }
    }
}
