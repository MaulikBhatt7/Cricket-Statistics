using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using cricket_statistics.Areas.Admin.Models;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class Common_Operations_For_All_Tables : DAL_Helper
    {
        #region SelectAll

        public DataTable SelectAll(string table)
        {
            try
            {
                string proc = "PR_" + table + "_SelectAll";
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand(proc);
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Delete

        public int Delete(string table,int ID)
        {
            try
            {
                string proc = "PR_" + table + "_Delete";
                string id = table + "ID";
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand(proc);
                sqlDatabase.AddInParameter(dbCommand, id, DbType.Int64, ID);
                return sqlDatabase.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        #endregion
    }
}
