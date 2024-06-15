using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class AdminDashboard : DAL_Helper
    {
        #region RecordCounts

        public DataTable RecordCounts()
        {
            try
            {
                
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_RecordCount");
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
    }
}