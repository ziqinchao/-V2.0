using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeyiShow.MODELS;

namespace WeyiShow.Libraries
{
    public class DB_ProductGood
    {
        string ConnectionStringName = "WeyiShow_Connection";
        /// <summary>
        /// 根据相应条件，获取表【ProductGood】的记录
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        public DataSet Select()
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT TJRGuid,ProductId,ProductName,Title,ImageUrl,Price,Class,DropDown,Topceng,FBData,Decriptions FROM ProductGood" :
                "SELECT TJRGuid,ProductId,ProductName,Title,ImageUrl,Price,Class,DropDown,Topceng,FBData,Decriptions FROM ProductGood";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            return db.ExecuteDataSet(cmd);
        }


        /// <summary>
        /// 根据相应条件，获取表【ProductGood】的记录
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="DropDown"></param>
        public DataSet SelectByDropDown(string DropDown)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT top 4 * FROM ProductGood Where  DropDown=@DropDown Order by Topceng desc,ProductId desc" :
                "SELECT top 4 * FROM ProductGood Where  DropDown=:DropDown Order by Topceng desc,ProductId desc";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "DropDown", DbType.String, DropDown);
            return db.ExecuteDataSet(cmd);
        }

        /// <summary>
        /// ProductGood实体类
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        [Serializable]
        public class Detail_ProductGood 
        {


            /// <summary>
            /// 默认的类的初始化
            /// </summary>
            public Detail_ProductGood() : this("") { }




            /// <summary>
            /// 默认的类的初始化
            /// </summary>
            public Detail_ProductGood(string tenantID)  { }


            //一些类的属性的定义
            private string _TJRGuid = "";

            /// <summary>
            /// 属性TJRGuid
            /// </summary>
        
            public string TJRGuid
            {
                set
                {
                   
                    _TJRGuid = value;
                }
                get { return _TJRGuid; }
            }

            private string _ProductId = "";

            /// <summary>
            /// 属性ProductId
            /// </summary>
           
            public string ProductId
            {
                set
                {
                   
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

            private string _Title = "";

            /// <summary>
            /// 属性Title
            /// </summary>
         
            public string Title
            {
                set
                {
                    
                    _Title = value;
                }
                get { return _Title; }
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

            private string _Price = "";

            /// <summary>
            /// 属性Price
            /// </summary>
            public string Price
            {
                set
                {
                    
                    _Price = value;
                }
                get { return _Price; }
            }

            private string _Class = "";

            /// <summary>
            /// 属性Class
            /// </summary>
           
            public string Class
            {
                set
                {
                   
                    _Class = value;
                }
                get { return _Class; }
            }

            private string _DropDown = "";

            /// <summary>
            /// 属性DropDown
            /// </summary>
          
            public string DropDown
            {
                set
                {
                 
                    _DropDown = value;
                }
                get { return _DropDown; }
            }

            private int _Topceng;

            /// <summary>
            /// 属性Topceng
            /// </summary>
          
            public int Topceng
            {
                set
                {
                 
                    _Topceng = value;
                }
                get { return _Topceng; }
            }

            private DateTime _FBData;

            /// <summary>
            /// 属性FBData
            /// </summary>
          
            public DateTime FBData
            {
                set
                {
                   
                    _FBData = value;
                }
                get { return _FBData; }
            }

            private string _Decriptions = "";

            /// <summary>
            /// 属性Decriptions
            /// </summary>
           
            public string Decriptions
            {
                set
                {
                   
                    _Decriptions = value;
                }
                get { return _Decriptions; }
            }


        }//class


        /// <summary>
        /// 
        /// 编写日期：2017/9/13
        /// 编写人：訾钦朝
        /// </summary>
        public Detail_ProductGood GetDetail(string ProductId)
        {
            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM ProductGood WHERE ProductId=@ProductId " :
                "SELECT * FROM ProductGood WHERE ProductId=:ProductId";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "ProductId", DbType.String, ProductId);
            Detail_ProductGood myDetail = new Detail_ProductGood();
            //IDataReader myReader = db.ExecuteReader(cmd);
            using (IDataReader myReader = db.ExecuteReader(cmd))
            {
                if (myReader.Read())
                {
                    if (!Convert.IsDBNull(myReader["TJRGuid"]))
                    {
                        myDetail.TJRGuid = Convert.ToString(myReader["TJRGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["ProductId"]))
                    {
                        myDetail.ProductId = Convert.ToString(myReader["ProductId"]);
                    }
                    if (!Convert.IsDBNull(myReader["ProductName"]))
                    {
                        myDetail.ProductName = Convert.ToString(myReader["ProductName"]);
                    }
                    if (!Convert.IsDBNull(myReader["Title"]))
                    {
                        myDetail.Title = Convert.ToString(myReader["Title"]);
                    }
                    if (!Convert.IsDBNull(myReader["ImageUrl"]))
                    {
                        myDetail.ImageUrl = Convert.ToString(myReader["ImageUrl"]);
                    }
                    if (!Convert.IsDBNull(myReader["Price"]))
                    {
                        myDetail.Price = Convert.ToString(myReader["Price"]);
                    }
                    if (!Convert.IsDBNull(myReader["Class"]))
                    {
                        myDetail.Class = Convert.ToString(myReader["Class"]);
                    }
                    if (!Convert.IsDBNull(myReader["DropDown"]))
                    {
                        myDetail.DropDown = Convert.ToString(myReader["DropDown"]);
                    }
                    if (!Convert.IsDBNull(myReader["Topceng"]))
                    {
                        myDetail.Topceng = Convert.ToInt32(myReader["Topceng"]);
                    }
                    if (!Convert.IsDBNull(myReader["FBData"]))
                    {
                        myDetail.FBData = Convert.ToDateTime(myReader["FBData"]);
                    }
                    if (!Convert.IsDBNull(myReader["Decriptions"]))
                    {
                        myDetail.Decriptions = Convert.ToString(myReader["Decriptions"]);
                    }
                }
            }
            return myDetail;
        }




        /// <summary>
        /// 根据用户名查询当前物品信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public commProduct getGoodInfo(string id)
        {
            commProduct model = null;
            model = new commProduct();
            model.ProductId = GetDetail(id).ProductId;
            model.ProductName = GetDetail(id).ProductName;
            model.ImageUrl = GetDetail(id).ImageUrl;
            model.Price = GetDetail(id).Price;
            model.Class = GetDetail(id).Class;
            model.dorpdown = GetDetail(id).DropDown;           
            return model;
        }


        /// <summary>
        /// 根据商品的id，获取表【ProductGood】的所有信息
        /// 编写日期：2017/9/20
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="ProductId"></param>
        public DataView SelectByProductId(string ProductId)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT TJRGuid,ProductId,ProductName,Title,ImageUrl,Price,Class,DropDown,Topceng,FBData,Decriptions FROM ProductGood Where  ProductId=@ProductId " :
                "SELECT TJRGuid,ProductId,ProductName,Title,ImageUrl,Price,Class,DropDown,Topceng,FBData,Decriptions FROM ProductGood Where  ProductId=:ProductId ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "ProductId", DbType.String, ProductId);
            return db.ExecuteDataView(cmd);
        }



        /// <summary>
        /// 根据商品的id，获取表【ProductGood】的所有信息
        /// 编写日期：2017/9/20
        /// 编写人：訾钦朝
        /// </summary>
        /// <param name="ProductId"></param>
        public DataView SelectByProductIds(string sqlwhere)
        {

            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT ProductId,ProductName,Title,ImageUrl,Price,Class,DropDown,Decriptions FROM ProductGood Where 1=1 " :
                "SELECT TJRGuid,ProductId,ProductName,Title,ImageUrl,Price,Class,DropDown,Topceng,FBData,Decriptions FROM ProductGood Where 1=1 ";
            strSql += sqlwhere;
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }









    }
}
