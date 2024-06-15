using cricket_statistics.Areas.Admin.Models;
using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class AdminRules : DAL_Helper
    {
        #region SelectRulesByPK

        public RulesModel SelectRulesByPK(int RuleID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Rules_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "RuleID", DbType.Int32, RuleID);

                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    RulesModel model = new RulesModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        model.RuleID = int.Parse(dr["RuleID"].ToString());
                        model.RuleDetails = dr["RuleDetails"].ToString();
                        model.FormatID = int.Parse(dr["FormatID"].ToString());
                    }

                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region AddUpdateRules

        public int AddUpdateRules(RulesModel rulesModel, int RuleID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand;

                if (RuleID == 0)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_Rules_Insert");
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_Rules_Update");
                    sqlDatabase.AddInParameter(dbCommand, "RuleID", DbType.Int32, RuleID);
                }

                sqlDatabase.AddInParameter(dbCommand, "RuleDetails", DbType.String, rulesModel.RuleDetails);
                sqlDatabase.AddInParameter(dbCommand, "FormatID", DbType.Int32, rulesModel.FormatID);

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
