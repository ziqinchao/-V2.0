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

            private string _ReceiveRemark = "";

            /// <summary>
            /// 属性ReceiveRemark
            /// </summary>
            public string ReceiveRemark
            {
                set
                {
                    _ReceiveRemark = value;
                }
                get { return _ReceiveRemark; }
            }

            private string _RowGuid = "";

            /// <summary>
            /// 属性RowGuid
            /// </summary>
            public string RowGuid
            {
                set
                {
                    _RowGuid = value;
                }
                get { return _RowGuid; }
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
        /// <param name="RowGuid"></param>
        public Detail_ReceiveInfo GetDetail(string RowGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM ReceiveInfo WHERE  RowGuid=@RowGuid " :
                "SELECT * FROM ReceiveInfo WHERE  RowGuid=:RowGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);

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
                    if (!Convert.IsDBNull(myReader["RowGuid"]))
                    {
                        myDetail.RowGuid = Convert.ToString(myReader["RowGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["ReceiveRemark"]))
                    {
                        myDetail.ReceiveRemark = Convert.ToString(myReader["ReceiveRemark"]);
                    }
                }
            }
            return myDetail;
        }







        /// <summary>
        /// 表【ReceiveInfo】的更新操作
        /// 编写日期：2017/9/19
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="RowGuid"></param>
        /// <param name="ReceiveName"></param>
        /// <param name="ReceivePhone"></param>
        /// <param name="ReceivePost"></param>
        /// <param name="ReceiveAddress"></param>
        public int Update(string RowGuid, string ReceiveName, string ReceivePhone, string ReceivePost, string ReceiveAddress)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE ReceiveInfo SET ReceiveName=@ReceiveName,ReceivePhone=@ReceivePhone,ReceivePost=@ReceivePost,ReceiveAddress=@ReceiveAddress WHERE  RowGuid=@RowGuid " :
                "UPDATE ReceiveInfo SET ReceiveName=:ReceiveName,ReceivePhone=:ReceivePhone,ReceivePost=:ReceivePost,ReceiveAddress=:ReceiveAddress WHERE  RowGuid=:RowGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ReceiveName", DbType.String, ReceiveName);
            db.AddInParameter(cmd, "ReceivePhone", DbType.String, ReceivePhone);
            db.AddInParameter(cmd, "ReceivePost", DbType.String, ReceivePost);
            db.AddInParameter(cmd, "ReceiveAddress", DbType.String, ReceiveAddress);

            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);
            return db.ExecuteNonQuery(cmd);
        }








        /// <summary>
        /// 根据相应条件，获取表【ReceiveInfo】的记录
        /// 编写日期：2017/9/15
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public DataSet Select(string UserGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserGuid,RowGuid,ReceiveName,ReceivePhone,ReceivePost,ReceiveAddress,ReceiveRemark FROM ReceiveInfo Where  UserGuid=@UserGuid " :
                "SELECT UserGuid,RowGuid,ReceiveName,ReceivePhone,ReceivePost,ReceiveAddress,ReceiveRemark FROM ReceiveInfo Where  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteDataSet(cmd);
        }


        /// <summary>
        /// 根据相应条件，获取表【ReceiveInfo】的记录
        /// 编写日期：2017/9/19
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="RowGuid"></param>
        public DataSet SelectByRowGuid(string RowGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserGuid,RowGuid,ReceiveName,ReceivePhone,ReceivePost,ReceiveAddress,ReceiveRemark FROM ReceiveInfo Where  RowGuid=@RowGuid " :
                "SELECT UserGuid,RowGuid,ReceiveName,ReceivePhone,ReceivePost,ReceiveAddress,ReceiveRemark FROM ReceiveInfo Where  RowGuid=:RowGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);
            return db.ExecuteDataSet(cmd);
        }











        /// <summary>
        /// 根据相应条件，获取表【ReceiveInfo】的记录
        /// 编写日期：2017/9/15
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public DataSet SelectReceiveRemark(string UserGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT RowGuid,ReceiveRemark FROM ReceiveInfo Where  UserGuid=@UserGuid " :
                "SELECT RowGuid,ReceiveRemark FROM ReceiveInfo Where  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteDataSet(cmd);
        }



        /// <summary>
        /// 表【ReceiveInfo】的添加方法
        /// 编写日期：2017/9/19
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="RowGuid"></param>
        /// <param name="ReceiveName"></param>
        /// <param name="ReceivePhone"></param>
        /// <param name="ReceivePost"></param>
        /// <param name="ReceiveAddress"></param>
        /// <param name="ReceiveRemark"></param>
        public int Insert(string UserGuid, string RowGuid, string ReceiveName, string ReceivePhone, string ReceivePost, string ReceiveAddress, string ReceiveRemark)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO ReceiveInfo(UserGuid,RowGuid,ReceiveName,ReceivePhone,ReceivePost,ReceiveAddress,ReceiveRemark) VALUES(@UserGuid,@RowGuid,@ReceiveName,@ReceivePhone,@ReceivePost,@ReceiveAddress,@ReceiveRemark) " :
                "INSERT INTO ReceiveInfo(UserGuid,RowGuid,ReceiveName,ReceivePhone,ReceivePost,ReceiveAddress,ReceiveRemark) VALUES(:UserGuid,:RowGuid,:ReceiveName,:ReceivePhone,:ReceivePost,:ReceiveAddress,:ReceiveRemark)";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);
            db.AddInParameter(cmd, "ReceiveName", DbType.String, ReceiveName);
            db.AddInParameter(cmd, "ReceivePhone", DbType.String, ReceivePhone);
            db.AddInParameter(cmd, "ReceivePost", DbType.String, ReceivePost);
            db.AddInParameter(cmd, "ReceiveAddress", DbType.String, ReceiveAddress);
            db.AddInParameter(cmd, "ReceiveRemark", DbType.String, ReceiveRemark);
            return db.ExecuteNonQuery(cmd);
        }


        /// <summary>
        /// 表【ReceiveInfo】的删除方法
        /// 编写日期：2017/10/30
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="RowGuid"></param>
        public int Delete(string RowGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "DELETE FROM ReceiveInfo WHERE  RowGuid=@RowGuid " :
                "DELETE FROM ReceiveInfo WHERE  RowGuid=:RowGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);
            return db.ExecuteNonQuery(cmd);
        }
















    }
}
