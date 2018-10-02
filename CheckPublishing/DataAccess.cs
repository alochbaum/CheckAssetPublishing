using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CheckPublishing
{
    public class DataAccess
    {
        public List<Asset> GetDAssets(string AssetName, string db ="XMS", string strIP = "")
        {
            string strConn;
            AssetName = AssetName.Replace("'", "");
            if (db != "XMS")
            {
                strConn = Helper.CnnVal(db).Replace("{IP from form}", strIP);
            } else { strConn = Helper.CnnVal("XMS"); }
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(strConn))
            {
                try
                {
                    return connection.Query<Asset>($"select top 1 * from vx_asset where name='{AssetName}'").ToList();
                }
                catch(Exception e)
                {
                    MessageBox.Show($" Datatbase error {e.Message}");
                    return null;
                }
            }
        }
    }
}
