using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeyiShow.MODELS;

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
                db.AddInParameter(cmd, "Price", DbType.Double, decimal.Round(decimal.Parse(Price.ToString()),2));
                db.AddInParameter(cmd, "Number", DbType.Int32, Number);
                db.AddInParameter(cmd, "SumPrice", DbType.Double, decimal.Round(decimal.Parse(SumPrice.ToString()), 2));
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            
        }


        /// <summary>
        /// ShopCar实体类
        /// 编写日期：2017/9/14
        /// 编写人：訾钦朝
        /// </summary>
        [Serializable]
        public class Detail_ShopCar
        {


            /// <summary>
            /// 默认的类的初始化
            /// </summary>
            public Detail_ShopCar() : this("") { }




            /// <summary>
            /// 默认的类的初始化
            /// </summary>
            public Detail_ShopCar(string tenantID)  { }


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

            private string _ProductId = "";

            /// <summary>
            /// 属性ProductId
            /// </summary>
            public string ProductId
            {
                set
                {
                    _ProductId = value;
                }
                get { return _ProductId; }
            }

            private string _ProductName = "";

            /// <summary>
            /// 属性ProductName
            /// </summary>
            public string ProductName
            {
                set
                {
                    _ProductName = value;
                }
                get { return _ProductName; }
            }

            private string _ImageUrl = "";

            /// <summary>
            /// 属性ImageUrl
            /// </summary>
            public string ImageUrl
            {
                set
                {
                    _ImageUrl = value;
                }
                get { return _ImageUrl; }
            }

            private double _Price;

            /// <summary>
            /// 属性Price
            /// </summary>
            public double Price
            {
                set
                {
                    _Price = value;
                }
                get { return _Price; }
            }

            private int _Number;

            /// <summary>
            /// 属性Number
            /// </summary>
            public int Number
            {
                set
                {
                    _Number = value;
                }
                get { return _Number; }
            }

            private double _SumPrice;

            /// <summary>
            /// 属性SumPrice
            /// </summary>
            public double SumPrice
            {
                set
                {
                    _SumPrice = value;
                }
                get { return _SumPrice; }
            }


        }//class


        /// <summary>
        /// 
        /// 编写日期：2017/9/14
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public Detail_ShopCar GetDetail(string UserGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM ShopCar WHERE  UserGuid=@UserGuid " :
                "SELECT * FROM ShopCar WHERE  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);

            Detail_ShopCar myDetail = new Detail_ShopCar();

            using (IDataReader myReader = db.ExecuteReader(cmd))
            {
                if (myReader.Read())
                {
                    if (!Convert.IsDBNull(myReader["UserGuid"]))
                    {
                        myDetail.UserGuid = Convert.ToString(myReader["UserGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["ProductId"]))
                    {
                        myDetail.ProductId = Convert.ToString(myReader["ProductId"]);
                    }
                    if (!Convert.IsDBNull(myReader["ProductName"]))
                    {
                        myDetail.ProductName = Convert.ToString(myReader["ProductName"]);
                    }
                    if (!Convert.IsDBNull(myReader["ImageUrl"]))
                    {
                        myDetail.ImageUrl = Convert.ToString(myReader["ImageUrl"]);
                    }
                    if (!Convert.IsDBNull(myReader["Price"]))
                    {
                        myDetail.Price = Convert.ToDouble(myReader["Price"]);
                    }
                    if (!Convert.IsDBNull(myReader["Number"]))
                    {
                        myDetail.Number = Convert.ToInt32(myReader["Number"]);
                    }
                    if (!Convert.IsDBNull(myReader["SumPrice"]))
                    {
                        myDetail.SumPrice = Convert.ToDouble(myReader["SumPrice"]);
                    }
                }
            }
            return myDetail;
        }




        /// <summary>
        /// 根据相应条件，获取表【ShopCar】的记录
        /// 编写日期：2017/9/14
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public List<ShopCar> GetShopCar(string UserGuid)
        {
            List<ShopCar> list = new List<ShopCar>();
            
            ShopCar model = new ShopCar();
            model.UserName = GetDetail(UserGuid).UserGuid;
            model.GoodId = GetDetail(UserGuid).ProductId;
            model.ProductName = GetDetail(UserGuid).ProductName;
            model.ImageUrl = GetDetail(UserGuid).ImageUrl;
            model.Price = GetDetail(UserGuid).Price;
            model.Number = GetDetail(UserGuid).Number;
            model.SumPrice = GetDetail(UserGuid).SumPrice;
            list.Add(model);

            return list;

        }



        /// <summary>
        /// 根据相应条件，获取表【ShopCar】的记录
        /// 编写日期：2017/9/20
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        public DataView SelectByUserGuid(string UserGuid)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT UserGuid,ProductId,ProductName,ImageUrl,Price,Number,SumPrice FROM ShopCar Where  UserGuid=@UserGuid order by ProductId " :
                "SELECT UserGuid,ProductId,ProductName,ImageUrl,Price,Number,SumPrice FROM ShopCar Where  UserGuid=:UserGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            return db.ExecuteDataView(cmd);
        }



        /// <summary>
        /// 更新下订单后，付款前的购物车
        /// 编写日期：2017/9/22
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="ProductId"></param>
        /// <param name="Number"></param>
        public void UpdateNum(string UserGuid, string ProductId, int Number)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE ShopCar SET Number=@Number WHERE  UserGuid=@UserGuid AND ProductId=@ProductId " :
                "UPDATE ShopCar SET Number=:Number WHERE  UserGuid=:UserGuid AND ProductId=:ProductId ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "Number", DbType.Int32, Number);

            db.AddInParameter(cmd, "UserGuid", DbType.String, UserGuid);
            db.AddInParameter(cmd, "ProductId", DbType.String, ProductId);
            db.ExecuteNonQuery(cmd);
        }








    }
}
