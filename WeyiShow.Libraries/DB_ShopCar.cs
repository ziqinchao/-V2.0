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
    public class DB_ShopCar
    {
        string ConnectionStringName = "WeyiShow_Connection";

        /// <summary>
        /// 表【ShopCar】的添加方法
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="ProductId"></param>
        /// <param name="ProductName"></param>
        /// <param name="ImageUrl"></param>
        /// <param name="Price"></param>
        /// <param name="Number"></param>
        /// <param name="SumPrice"></param>
        public bool Insert(string UserGuid, string ProductId, string ProductName, string ImageUrl, double Price, int Number, double SumPrice)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO ShopCar(UserGuid,ProductId,ProductName,ImageUrl,Price,Number,SumPrice) VALUES(@UserGuid,@ProductId,@ProductName,@ImageUrl,@Price,@Number,@SumPrice) " :
                "INSERT INTO ShopCar(UserGuid,ProductId,ProductName,ImageUrl,Price,Number,SumPrice) VALUES(:UserGuid,:ProductId,:ProductName,:ImageUrl,:Price,:Number,:SumPrice)";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            try
            {
                db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
                db.AddInParameter(cmd, "ProductId", DbType.String, ProductId);
                db.AddInParameter(cmd, "ProductName", DbType.String, ProductName);
                db.AddInParameter(cmd, "ImageUrl", DbType.String, ImageUrl);
                db.AddInParameter(cmd, "Price", DbType.Double, Price);
                db.AddInParameter(cmd, "Number", DbType.Int32, Number);
                db.AddInParameter(cmd, "SumPrice", DbType.Double, SumPrice);
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            
        }




    }
}
