
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WeyiShow.Libraries
{
    public class DB_UserInfomation
    {

        string ConnectionStringName = "WeyiShow_Connection";
        

        /// <summary>
        /// 表【UserInfomation】的添加方法
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <param name="UserEmail"></param>
        /// <param name="UserPhone"></param>
        /// <param name="UserAddress"></param>
        /// <param name="UserRole"></param>
        /// <param name="ResgitData"></param>
        public bool Insert(string UserGuid, string UserName, string UserPwd, string UserEmail, string UserPhone, string UserAddress, string UserRole, DateTime ResgitData)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO UserInfomation(UserGuid,UserName,UserPwd,UserEmail,UserPhone,UserAddress,UserRole,ResgitData) VALUES(@UserGuid,@UserName,@UserPwd,@UserEmail,@UserPhone,@UserAddress,@UserRole,@ResgitData)  SELECT @thisId=SCOPE_IDENTITY()" :
                "begin  select sq_UserInfomation.Nextval  into :thisId from dual;INSERT INTO UserInfomation(UserGuid,UserGuid,UserName,UserPwd,UserEmail,UserPhone,UserAddress,UserRole,ResgitData) VALUES(:thisId,:UserGuid,:UserName,:UserPwd,:UserEmail,:UserPhone,:UserAddress,:UserRole,:ResgitData);end; ";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            try
            {
                UserPwd = GetMD5(UserPwd);
                db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
                db.AddInParameter(cmd, "UserName", DbType.String, UserName);
                db.AddInParameter(cmd, "UserPwd", DbType.String, UserPwd);
                db.AddInParameter(cmd, "UserEmail", DbType.String, UserEmail);
                db.AddInParameter(cmd, "UserPhone", DbType.String, UserPhone);
                db.AddInParameter(cmd, "UserAddress", DbType.String, UserAddress);
                db.AddInParameter(cmd, "UserRole", DbType.String, UserRole);
                db.AddInParameter(cmd, "ResgitData", DbType.DateTime, ResgitData);
                db.AddOutParameter(cmd, "thisID", DbType.Int32, 0);
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }  
        }

        /// <summary>
        /// 根据相应条件，获取表【UserInfomation】的记录
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserPwd"></param>
        /// <param name="UserPhone"></param>
        public bool Select( string UserPhone, string UserPwd)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM UserInfomation Where  UserPwd=@UserPwd AND UserPhone=@UserPhone " :
                "SELECT * FROM UserInfomation Where  UserPwd=:UserPwd AND UserPhone=:UserPhone ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            UserPwd = GetMD5(UserPwd);
            db.AddInParameter(cmd, "UserPwd", DbType.String, UserPwd);
            db.AddInParameter(cmd, "UserPhone", DbType.String, UserPhone);
            //return db.ExecuteDataView(cmd);
           IDataReader dr= db.ExecuteReader(cmd);
            if (dr.Read())
            {
                return true;
            }
            else
                return false;
        }



        /// <summary>
        /// 根据相应条件，获取表【UserInfomation】的详细信息
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserPwd"></param>
        /// <param name="UserPhone"></param>
        public DataView SelectInfo(string UserPhone, string UserPwd)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM UserInfomation Where  UserPwd=@UserPwd AND UserPhone=@UserPhone " :
                "SELECT * FROM UserInfomation Where  UserPwd=:UserPwd AND UserPhone=:UserPhone ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            UserPwd = GetMD5(UserPwd);
            db.AddInParameter(cmd, "UserPwd", DbType.String, UserPwd);
            db.AddInParameter(cmd, "UserPhone", DbType.String, UserPhone);
            //return db.ExecuteDataView(cmd);
            return db.ExecuteDataView(cmd);
        }


        /// <summary>
        /// 根据相应条件，获取表【UserInfomation】的记录
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserPhone"></param>
        public string SelectUserRole(string UserPhone)
        {
            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserRole FROM UserInfomation Where  UserPhone=@UserPhone " :
                "SELECT UserRole FROM UserInfomation Where  UserPhone=:UserPhone ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserPhone", DbType.String, UserPhone);

            return db.ExecuteScalar(cmd).ToString();
        }


        /// <summary>
        /// 根据相应条件，获取表【UserInfomation】的记录
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserPhone"></param>
        public string SelectUserGuid(string UserPhone)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserGuid FROM UserInfomation Where  UserPhone=@UserPhone " :
                "SELECT UserGuid FROM UserInfomation Where  UserPhone=:UserPhone ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserPhone", DbType.String, UserPhone);

            return db.ExecuteScalar(cmd).ToString();
        }


        /// <summary>
        /// 通过UserGuid查询姓名
        /// 编写日期：2017/9/24
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public string SelectUserName(string UserGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserName FROM UserInfomation Where  UserGuid=@UserGuid " :
                "SELECT UserName FROM UserInfomation Where  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteScalar(cmd).ToString();
        }

        /// <summary>
        /// 根据userguid获取用户个人资料
        /// 编写日期：2017/10/27
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public DataView SelectUserInfo(string UserGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserGuid,UserNickName,UserName,UserSex,UserEmail,UserPhone,UserAddress,BirthDay,ResgitData FROM UserInfomation Where  UserGuid=@UserGuid " :
                "SELECT UserGuid,UserNickName,UserName,UserSex,UserEmail,UserPhone,UserAddress,BirthDay,ResgitData FROM UserInfomation Where  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteDataView(cmd);
        }


        /// <summary>
        /// 用户中心的表【UserInfomation】的更新操作
        /// 编写日期：2017/10/27
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="UserNickName"></param>
        /// <param name="UserName"></param>
        /// <param name="UserSex"></param>
        /// <param name="UserEmail"></param>
        /// <param name="UserPhone"></param>
        public int UpdateUserInfo(string UserGuid, string UserNickName, string UserName, int UserSex, string UserEmail, string UserPhone,DateTime BirthDay)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE UserInfomation SET UserGuid=@UserGuid,UserNickName=@UserNickName,UserName=@UserName,UserSex=@UserSex,UserEmail=@UserEmail,UserPhone=@UserPhone,BirthDay=@BirthDay WHERE  UserGuid=@UserGuid " :
                "UPDATE UserInfomation SET UserGuid=:UserGuid,UserNickName=:UserNickName,UserName=:UserName,UserSex=:UserSex,UserEmail=:UserEmail,UserPhone=:UserPhone,BirthDay=:BirthDay WHERE  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "UserNickName", DbType.String, UserNickName);
            db.AddInParameter(cmd, "UserName", DbType.String, UserName);
            db.AddInParameter(cmd, "UserSex", DbType.Int32, UserSex);
            db.AddInParameter(cmd, "UserEmail", DbType.String, UserEmail);
            db.AddInParameter(cmd, "UserPhone", DbType.String, UserPhone);
            db.AddInParameter(cmd, "BirthDay", DbType.String, BirthDay);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteNonQuery(cmd);
        }





















        private string GetMD5(string strPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();                       //加密服务提供类
            byte[] bPwd = Encoding.Default.GetBytes(strPwd);                //将输入的密码转换成字节数组
            byte[] bMD5 = md5.ComputeHash(bPwd);                            //计算指定字节数组的哈希值
            md5.Clear();                                                    //释放加密服务提供类的所有资源
            StringBuilder sbMD5Pwd = new StringBuilder();
            for (int i = 0; i < bMD5.Length; i++)                                  //将加密后的字节转换成字符串
            {
                sbMD5Pwd.Append(bMD5[i].ToString());
            }
            return sbMD5Pwd.ToString();
        }



    }
}
