using cricket_statistics.Areas.Admin.Models;
using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class AdminPlayer : DAL_Helper
    {


        #region SelectPlayerByPK

        public PlayerModel SelectPlayerByPK(int PlayerID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Player_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "PlayerID", DbType.Int64, PlayerID);
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    PlayerModel model = new PlayerModel();
                    foreach (DataRow dr in dt.Rows)
                    {

                        model.PlayerID = int.Parse(dr["PlayerID"].ToString());
                        model.Age = int.Parse(dr["Age"].ToString());
                        model.Role = dr["Role"].ToString();
                        model.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                        model.PlayerName = dr["PlayerName"].ToString();
                        model.Description = dr["Description"].ToString();
                        model.BattingStyle = dr["BattingStyle"].ToString();
                        model.BowlingStyle = dr["BowlingStyle"].ToString();
                        model.CityID = int.Parse(dr["CItyID"].ToString());
                        model.PlayerImage = dr["PlayerImage"].ToString();
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

        #region AddUpdatePlayer 
        public int AddUpdatePlayer(PlayerModel Player_model, int PlayerID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand;
                if (PlayerID == 0)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_Player_Insert");
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_Player_Update");
                    sqlDatabase.AddInParameter(dbCommand, "PlayerID", DbType.Int64, PlayerID);
                }

                sqlDatabase.AddInParameter(dbCommand, "PlayerName", DbType.String, Player_model.PlayerName);
                sqlDatabase.AddInParameter(dbCommand, "PlayerImage", DbType.String, Player_model.PlayerImage);
                sqlDatabase.AddInParameter(dbCommand, "BirthDate", DbType.DateTime, Player_model.BirthDate);
                sqlDatabase.AddInParameter(dbCommand, "Age", DbType.Int64, Player_model.Age);
                sqlDatabase.AddInParameter(dbCommand, "CityID", DbType.Int64, Player_model.CityID);
                sqlDatabase.AddInParameter(dbCommand, "Role", DbType.String, Player_model.Role);
                sqlDatabase.AddInParameter(dbCommand, "BattingStyle", DbType.String, Player_model.BattingStyle);
                sqlDatabase.AddInParameter(dbCommand, "BowlingStyle", DbType.String, Player_model.BowlingStyle);
                sqlDatabase.AddInParameter(dbCommand, "Description", DbType.String, Player_model.Description);

                

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

