using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class Login : DAL_Helper
    {
        public bool? checkLogin(string username, string password)
        {
            try
            {
                int check = 0;
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Login_By_Username_Password");
                sqlDatabase.AddInParameter(dbCommand, "username", DbType.String, username);
                sqlDatabase.AddInParameter(dbCommand, "password", DbType.String, password);
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while(dr.Read())
                    {
                        check++;
                    }
                }
                if(check > 0)
                {
                    return true;
                }
                else { 
                    return false; 
                }
            }
            catch (Exception ex) {

                return null;
            }
        }
    }
}
