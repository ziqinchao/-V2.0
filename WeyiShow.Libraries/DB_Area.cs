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
    public class DB_Area
    {
        string ConnectionStringName = "WeyiShow_Connection";
        public DataTable GetZoneInfo(int fatherID)
        {
            
            Database db = DatabaseFactory.CreateDatabase(this.ConnectionStringName);
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "select * from Area where parentID ='"+fatherID+"' ":
                "SELECT UserGuid,RowGuid,ReceiveName,ReceivePhone,ReceivePost,ReceiveAddress,ReceiveRemark FROM ReceiveInfo Where  RowGuid=:RowGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataSet(cmd).Tables[0];
        }
    }
}
