using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeyiShow.Libraries
{
    public class DB_ReceiveInfo
    {

        string ConnectionStringName = "WeyiShow_Connection";

        /// <summary>
        /// ReceiveInfo实体类
        /// 编写日期：2017/9/14
        /// 编写人：訾钦朝
        /// </summary>
        [Serializable]
        public class Detail_ReceiveInfo 
        {
            /// <summary>
            /// 默认的类的初始化
            /// </summary>
            public Detail_ReceiveInfo() : this("") { }
            
            /// <summary>
            /// 默认的类的初始化
            /// </summary>
            public Detail_ReceiveInfo(string tenantID)   { }
            
            //一些类的属性的定义
            private string _UserGuid = "";

            /// <summary>
            /// 属性UserGuid
            /// </summary>
           
            public string UserGuid
            {
                set
                {
                    _UserGuid = value;
                }
                get { return _UserGuid; }
            }

            private string _ReceiveName = "";

            /// <summary>
            /// 属性ReceiveName
            /// </summary>
            public string ReceiveName
            {
                set
                {
                    _ReceiveName = value;
                }
                get { return _ReceiveName; }
            }

            private string _ReceivePhone = "";

            /// <summary>
            /// 属性ReceivePhone
            /// </summary>
            public string ReceivePhone
            {
                set
                {
                    _ReceivePhone = value;
                }
                get { return _ReceivePhone; }
            }

            private string _ReceivePost = "";

            /// <summary>
            /// 属性ReceivePost
            /// </summary>
            public string ReceivePost
            {
                set
                {
                    _ReceivePost = value;
                }
                get { return _ReceivePost; }
            }

            private string _ReceiveAddress = "";

            /// <summary>
            /// 属性ReceiveAddress
            /// </summary>
            public string ReceiveAddress
            {
                set
                {
                    _ReceiveAddress = value;
                }
                get { return _ReceiveAddress; }
            }


        }//class


        /// <summary>
        /// 
        /// 编写日期：2017/9/14
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public Detail_ReceiveInfo GetDetail(string UserGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM ReceiveInfo WHERE  UserGuid=@UserGuid " :
                "SELECT * FROM ReceiveInfo WHERE  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);

            Detail_ReceiveInfo myDetail = new Detail_ReceiveInfo();

            using (IDataReader myReader = db.ExecuteReader(cmd))
            {
                if (myReader.Read())
                {
                    if (!Convert.IsDBNull(myReader["UserGuid"]))
                    {
                        myDetail.UserGuid = Convert.ToString(myReader["UserGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["ReceiveName"]))
                    {
                        myDetail.ReceiveName = Convert.ToString(myReader["ReceiveName"]);
                    }
                    if (!Convert.IsDBNull(myReader["ReceivePhone"]))
                    {
                        myDetail.ReceivePhone = Convert.ToString(myReader["ReceivePhone"]);
                    }
                    if (!Convert.IsDBNull(myReader["ReceivePost"]))
                    {
                        myDetail.ReceivePost = Convert.ToString(myReader["ReceivePost"]);
                    }
                    if (!Convert.IsDBNull(myReader["ReceiveAddress"]))
                    {
                        myDetail.ReceiveAddress = Convert.ToString(myReader["ReceiveAddress"]);
                    }
                }
            }
            return myDetail;
        }





        /// <summary>
        /// 表【ReceiveInfo】的更新操作
        /// 编写日期：2017/9/14
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="ReceiveName"></param>
        /// <param name="ReceivePhone"></param>
        /// <param name="ReceivePost"></param>
        /// <param name="ReceiveAddress"></param>
        public int Update(string UserGuid, string ReceiveName, string ReceivePhone, string ReceivePost, string ReceiveAddress)
        {
            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE ReceiveInfo SET ReceiveName=@ReceiveName,ReceivePhone=@ReceivePhone,ReceivePost=@ReceivePost,ReceiveAddress=@ReceiveAddress WHERE  UserGuid=@UserGuid " :
                "UPDATE ReceiveInfo SET ReceiveName=:ReceiveName,ReceivePhone=:ReceivePhone,ReceivePost=:ReceivePost,ReceiveAddress=:ReceiveAddress WHERE  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ReceiveName", DbType.String, ReceiveName);
            db.AddInParameter(cmd, "ReceivePhone", DbType.String, ReceivePhone);
            db.AddInParameter(cmd, "ReceivePost", DbType.String, ReceivePost);
            db.AddInParameter(cmd, "ReceiveAddress", DbType.String, ReceiveAddress);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteNonQuery(cmd);
        }




    }
}
