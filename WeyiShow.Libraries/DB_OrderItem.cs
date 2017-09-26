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
    public class DB_OrderItem
    {
        string ConnectionStringName = "WeyiShow_Connection";
        /// <summary>
        /// 表【OrderItem】的添加方法
        /// 编写日期：2017/9/25
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="ProductId"></param>
        /// <param name="Price"></param>
        /// <param name="Number"></param>
        /// <param name="SumPrice"></param>
        public void Insert(string OrderId, string ProductId, double Price, int Number, double SumPrice)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO OrderItem(OrderId,ProductId,Price,Number,SumPrice) VALUES(@OrderId,@ProductId,@Price,@Number,@SumPrice) " :
                "INSERT INTO OrderItem(OrderId,ProductId,Price,Number,SumPrice) VALUES(:OrderId,:ProductId,:Price,:Number,:SumPrice)";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "OrderId", DbType.String, OrderId);
            db.AddInParameter(cmd, "ProductId", DbType.String, ProductId);
            db.AddInParameter(cmd, "Price", DbType.Double, Price);
            db.AddInParameter(cmd, "Number", DbType.Int32, Number);
            db.AddInParameter(cmd, "SumPrice", DbType.Double, SumPrice);
            db.ExecuteNonQuery(cmd);
        }




    }
}
