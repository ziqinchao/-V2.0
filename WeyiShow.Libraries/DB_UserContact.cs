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
    public class DB_UserContact
    {
        string ConnectionStringName = "WeyiShow_Connection";


        /// <summary>
        /// 表【UserContact】的添加方法
        /// 编写日期：2017/11/28
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="UserCard"></param>
        /// <param name="UserRealName"></param>
        /// <param name="UserCardPZ"></param>
        /// <param name="UserCardPF"></param>
        /// <param name="UserCardDF"></param>
        /// <param name="UserCardDT"></param>
        public int Insert(string UserGuid, string UserCard, string UserRealName, string UserCardPZ, string UserCardPF, string UserCardDF, string UserCardDT)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO UserContact(UserGuid,UserCard,UserRealName,UserCardPZ,UserCardPF,UserCardDF,UserCardDT) VALUES(@UserGuid,@UserCard,@UserRealName,@UserCardPZ,@UserCardPF,@UserCardDF,@UserCardDT) " :
                "INSERT INTO UserContact(UserGuid,UserCard,UserRealName,UserCardPZ,UserCardPF,UserCardDF,UserCardDT) VALUES(:UserGuid,:UserCard,:UserRealName,:UserCardPZ,:UserCardPF,:UserCardDF,:UserCardDT)";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            db.AddInParameter(cmd, "UserCard", DbType.String, UserCard);
            db.AddInParameter(cmd, "UserRealName", DbType.String, UserRealName);
            db.AddInParameter(cmd, "UserCardPZ", DbType.String, UserCardPZ);
            db.AddInParameter(cmd, "UserCardPF", DbType.String, UserCardPF);
            db.AddInParameter(cmd, "UserCardDF", DbType.String, UserCardDF);
            db.AddInParameter(cmd, "UserCardDT", DbType.String, UserCardDT);
            return db.ExecuteNonQuery(cmd);
        }



        /// <summary>
        /// 根据相应条件，获取表【UserContact】的记录
        /// 编写日期：2017/11/28
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public DataView Select(string UserGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserGuid,UserCard,UserRealName,UserCardPZ,UserCardPF,UserCardDF,UserCardDT FROM UserContact Where  UserGuid=@UserGuid " :
                "SELECT UserGuid,UserCard,UserRealName,UserCardPZ,UserCardPF,UserCardDF,UserCardDT FROM UserContact Where  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteDataView(cmd);
        }








    }
}
