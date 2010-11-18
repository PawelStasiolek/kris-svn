namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("SYS_MailList")]
    public class SYS_MailList : ObjectRow {
        
        public SYS_MailList() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public SYS_MailList(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SYS_MailList(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
        }
        
        [Key("ID",true,true)]
        public decimal ID {
            get {
                return (System.Decimal)GetValue("ID");
            }
            set {
                SetValue("ID", value);
            }
        }
        
        [Field("Address")]
        public string Address {
            get {
                return (System.String)GetValue("Address");
            }
            set {
                SetValue("Address", value);
            }
        }
        
        [Field("CC")]
        public string CC {
            get {
                return (System.String)GetValue("CC");
            }
            set {
                SetValue("CC", value);
            }
        }
        
        [Field("Subject")]
        public string Subject {
            get {
                return (System.String)GetValue("Subject");
            }
            set {
                SetValue("Subject", value);
            }
        }
        
        [Field("Body")]
        public string Body {
            get {
                return (System.String)GetValue("Body");
            }
            set {
                SetValue("Body", value);
            }
        }
        
        [Field("Comment")]
        public string Comment {
            get {
                return (System.String)GetValue("Comment");
            }
            set {
                SetValue("Comment", value);
            }
        }
        
        [Field("Send")]
        public String Send
        {
            get {
                return (System.String)GetValue("Send");
            }
            set {
                SetValue("Send", value);
            }
        }
    }
}
