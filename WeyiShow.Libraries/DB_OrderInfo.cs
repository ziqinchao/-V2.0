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
    public class DB_OrderInfo
    {
        string ConnectionStringName = "WeyiShow_Connection";
        /// <summary>
        /// 表【OrderInfo】的添加方法
        /// 编写日期：2017/9/25
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="OrderDate"></param>
        /// <param name="UserGuid"></param>
        /// <param name="TotalPrice"></param>
        /// <param name="State"></param>
        public int Insert(string OrderId, DateTime OrderDate, string UserGuid, string TotalPrice, string State,string ReceiveGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO OrderInfo(OrderId,OrderDate,UserGuid,TotalPrice,State,ReceiveGuid) VALUES(@OrderId,@OrderDate,@UserGuid,@TotalPrice,@State,@ReceiveGuid) " :
                "INSERT INTO OrderInfo(OrderId,OrderDate,UserGuid,TotalPrice,State,ReceiveGuid) VALUES(:OrderId,:OrderDate,:UserGuid,:TotalPrice,:State,:ReceiveGuid)";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "OrderId", DbType.String, OrderId);
            db.AddInParameter(cmd, "OrderDate", DbType.DateTime, OrderDate);
            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            db.AddInParameter(cmd, "TotalPrice", DbType.String, TotalPrice);
            db.AddInParameter(cmd, "State", DbType.String, State);
            db.AddInParameter(cmd, "ReceiveGuid", DbType.String, ReceiveGuid);
            return db.ExecuteNonQuery(cmd);
        }


        /// <summary>
        /// 表【OrderInfo】的更新操作
        /// 编写日期：2017/9/28
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="State"></param>
        public int UpdateState(string OrderId, string State)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE OrderInfo SET State=@State WHERE  OrderId=@OrderId " :
                "UPDATE OrderInfo SET State=:State WHERE  OrderId=:OrderId ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "State", DbType.String, State);

            db.AddInParameter(cmd, "OrderId", DbType.String, OrderId);
            return db.ExecuteNonQuery(cmd);
        }





    }
}
