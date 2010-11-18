namespace eBest.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EBest.Persistent;
    using System.Data;
    using System.Runtime.Serialization;
    
    
    [System.SerializableAttribute()]
    [Map("TB_User")]
    public class TB_User : ObjectRow {
        
        public TB_User() {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">DataTable 中的一行数据</param>
        /// <param name="objectTable">存储当前对象的数据表格</param>
        public TB_User(System.Data.DataRow dataRow, ObjectTable parent) : 
                base(dataRow, parent) {
        }
        
        /// <summary>
        /// 供反序列化使用的构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected TB_User(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
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
        public string Name
        {
            get {
                return (System.String)GetValue("Name");
            }
            set {
                SetValue("Name", value);
            }
        }
        
        [Field("LoginName")]
        public string LoginName {
            get {
                return (System.String)GetValue("LoginName");
            }
            set {
                SetValue("LoginName", value);
            }
        }
        
        [Field("Passsword")]
        public string Passsword {
            get {
                return (System.String)GetValue("Passsword");
            }
            set {
                SetValue("Passsword", value);
            }
        }
        
        [Field("Email")]
        public string Email {
            get {
                return (System.String)GetValue("Email");
            }
            set {
                SetValue("Email", value);
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

        [Field("FailCount")]
        public int FailCount
        {
            get
            {
                return (System.Int32)GetValue("FailCount",0);
            }
            set
            {
                SetValue("FailCount", value);
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

        [Field("LastLoginDate")]
        public System.DateTime LastLoginDate
        {
            get {
                return (System.DateTime)GetValue("LastLoginDate");
            }
            set {
                SetValue("LastLoginDate", value);
            }
        }

        [Field("LastDate")]
        public System.DateTime LastDate
        {
            get
            {
                return (System.DateTime)GetValue("LastDate");
            }
            set
            {
                SetValue("LastDate", value);
            }
        }
    }
}
