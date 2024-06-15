using cricket_statistics.Areas.Admin.Models;
using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class AdminPlayerWiseBowlingStatistics : DAL_Helper
    {
        #region SelectPlayerWiseBowlingStatisticsByPK

        public PlayerWiseBowlingStatisticsModel SelectPlayerWiseBowlingStatisticsByPK(int BowlStatID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_PlayerWiseBowlingStatistics_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "BowlStatID", DbType.Int32, BowlStatID);

                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    PlayerWiseBowlingStatisticsModel model = new PlayerWiseBowlingStatisticsModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        model.BowlStatID = int.Parse(dr["BowlStatID"].ToString());
                        model.PlayerID = int.Parse(dr["PlayerID"].ToString());
                        model.FormatID = int.Parse(dr["FormatID"].ToString());
                        model.Matches = int.Parse(dr["Matches"].ToString());
                        model.Innings = int.Parse(dr["Innings"].ToString());
                        model.Balls = int.Parse(dr["Balls"].ToString());
                        model.Runs = int.Parse(dr["Runs"].ToString());
                        model.Wickets = int.Parse(dr["Wickets"].ToString());
                        model.BBI = dr["BBI"].ToString();
                        model.BBM = dr["BBM"].ToString();
                        model.Economy = decimal.Parse(dr["Economy"].ToString());
                        model.Average = decimal.Parse(dr["Average"].ToString());
                        model.StrikeRate = decimal.Parse(dr["StrikeRate"].ToString());
                        model.FiveW = int.Parse(dr["FiveW"].ToString());
                        model.TenW = int.Parse(dr["TenW"].ToString());
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

        #region AddUpdatePlayerWiseBowlingStatistics

        public int AddUpdatePlayerWiseBowlingStatistics(PlayerWiseBowlingStatisticsModel bowlingStatsModel, int BowlStatID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand;

                if (BowlStatID == 0)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_PlayerWiseBowlingStatistics_Insert");
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_PlayerWiseBowlingStatistics_Update");
                    sqlDatabase.AddInParameter(dbCommand, "BowlStatID", DbType.Int32, BowlStatID);
                }

                sqlDatabase.AddInParameter(dbCommand, "PlayerID", DbType.Int32, bowlingStatsModel.PlayerID);
                sqlDatabase.AddInParameter(dbCommand, "FormatID", DbType.Int32, bowlingStatsModel.FormatID);
                sqlDatabase.AddInParameter(dbCommand, "Matches", DbType.Int32, bowlingStatsModel.Matches);
                sqlDatabase.AddInParameter(dbCommand, "Innings", DbType.Int32, bowlingStatsModel.Innings);
                sqlDatabase.AddInParameter(dbCommand, "Balls", DbType.Int32, bowlingStatsModel.Balls);
                sqlDatabase.AddInParameter(dbCommand, "Runs", DbType.Int32, bowlingStatsModel.Runs);
                sqlDatabase.AddInParameter(dbCommand, "Wickets", DbType.Int32, bowlingStatsModel.Wickets);
                sqlDatabase.AddInParameter(dbCommand, "BBI", DbType.String, bowlingStatsModel.BBI);
                sqlDatabase.AddInParameter(dbCommand, "BBM", DbType.String, bowlingStatsModel.BBM);
                sqlDatabase.AddInParameter(dbCommand, "Economy", DbType.Decimal, bowlingStatsModel.Economy);
                sqlDatabase.AddInParameter(dbCommand, "Average", DbType.Decimal, bowlingStatsModel.Average);
                sqlDatabase.AddInParameter(dbCommand, "StrikeRate", DbType.Decimal, bowlingStatsModel.StrikeRate);
                sqlDatabase.AddInParameter(dbCommand, "FiveW", DbType.Int32, bowlingStatsModel.FiveW);
                sqlDatabase.AddInParameter(dbCommand, "TenW", DbType.Int32, bowlingStatsModel.TenW);

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
