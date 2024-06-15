using cricket_statistics.Areas.Admin.Models;
using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class AdminPlayerWiseBattingStatistics : DAL_Helper
    {
        #region SelectPlayerWiseBattingStatisticsByPK

        public PlayerWiseBattingStatisticsModel SelectPlayerWiseBattingStatisticsByPK(int BatStatID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_PlayerWiseBattingStatistics_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "BatStatID", DbType.Int32, BatStatID);

                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    PlayerWiseBattingStatisticsModel model = new PlayerWiseBattingStatisticsModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        model.BatStatID = int.Parse(dr["BatStatID"].ToString());
                        model.PlayerID = int.Parse(dr["PlayerID"].ToString());
                        model.FormatID = int.Parse(dr["FormatID"].ToString());
                        model.Matches = int.Parse(dr["Matches"].ToString());
                        model.Innings = int.Parse(dr["Innings"].ToString());
                        model.NotOuts = int.Parse(dr["NotOuts"].ToString());
                        model.Runs = int.Parse(dr["Runs"].ToString());
                        model.HighestScore = int.Parse(dr["HighestScore"].ToString());
                        model.BattingAverage = decimal.Parse(dr["BattingAverage"].ToString());
                        model.BallsFaced = int.Parse(dr["BallsFaced"].ToString());
                        model.StrikeRate = decimal.Parse(dr["StrikeRate"].ToString());
                        model.Centuries = int.Parse(dr["Centuries"].ToString());
                        model.HalfCenturies = int.Parse(dr["HalfCenturies"].ToString());
                        model.Fours = int.Parse(dr["Fours"].ToString());
                        model.Sixes = int.Parse(dr["Sixes"].ToString());
                        model.Catches = int.Parse(dr["Catches"].ToString());
                        model.Stumpings = int.Parse(dr["Stumpings"].ToString());
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

        #region AddUpdatePlayerWiseBattingStatistics

        public int AddUpdatePlayerWiseBattingStatistics(PlayerWiseBattingStatisticsModel battingStatsModel, int BatStatID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand;

                if (BatStatID == 0)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_PlayerWiseBattingStatistics_Insert");
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_PlayerWiseBattingStatistics_Update");
                    sqlDatabase.AddInParameter(dbCommand, "BatStatID", DbType.Int32, BatStatID);
                }

                sqlDatabase.AddInParameter(dbCommand, "PlayerID", DbType.Int32, battingStatsModel.PlayerID);
                sqlDatabase.AddInParameter(dbCommand, "FormatID", DbType.Int32, battingStatsModel.FormatID);
                sqlDatabase.AddInParameter(dbCommand, "Matches", DbType.Int32, battingStatsModel.Matches);
                sqlDatabase.AddInParameter(dbCommand, "Innings", DbType.Int32, battingStatsModel.Innings);
                sqlDatabase.AddInParameter(dbCommand, "NotOuts", DbType.Int32, battingStatsModel.NotOuts);
                sqlDatabase.AddInParameter(dbCommand, "Runs", DbType.Int32, battingStatsModel.Runs);
                sqlDatabase.AddInParameter(dbCommand, "HighestScore", DbType.Int32, battingStatsModel.HighestScore);
                sqlDatabase.AddInParameter(dbCommand, "BattingAverage", DbType.Decimal, battingStatsModel.BattingAverage);
                sqlDatabase.AddInParameter(dbCommand, "BallsFaced", DbType.Int32, battingStatsModel.BallsFaced);
                sqlDatabase.AddInParameter(dbCommand, "StrikeRate", DbType.Decimal, battingStatsModel.StrikeRate);
                sqlDatabase.AddInParameter(dbCommand, "Centuries", DbType.Int32, battingStatsModel.Centuries);
                sqlDatabase.AddInParameter(dbCommand, "HalfCenturies", DbType.Int32, battingStatsModel.HalfCenturies);
                sqlDatabase.AddInParameter(dbCommand, "Fours", DbType.Int32, battingStatsModel.Fours);
                sqlDatabase.AddInParameter(dbCommand, "Sixes", DbType.Int32, battingStatsModel.Sixes);
                sqlDatabase.AddInParameter(dbCommand, "Catches", DbType.Int32, battingStatsModel.Catches);
                sqlDatabase.AddInParameter(dbCommand, "Stumpings", DbType.Int32, battingStatsModel.Stumpings);

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
