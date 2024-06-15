
using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using cricket_statistics.Areas.Admin.Models;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class AdminSchedule : DAL_Helper
    {

        #region SelectAllSchedules

        public DataTable  SelectAllSchedules(ScheduleFilterModel filterModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Schedule_SelectAll");
                sqlDatabase.AddInParameter(dbCommand, "Team1ID", DbType.Int64, filterModel.Team1ID);
                sqlDatabase.AddInParameter(dbCommand, "Team2ID", DbType.Int64, filterModel.Team2ID);
                sqlDatabase.AddInParameter(dbCommand, "VenueID", DbType.Int64, filterModel.VenueID);
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                
            }
            catch (Exception ex) {
                return null;
            }
        }
        #endregion

        #region SelectScheduleByPK

        public ScheduleModel SelectScheduleByPK(int ScheduleID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Schedule_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "ScheduleID", DbType.Int64, ScheduleID);
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    ScheduleModel model = new ScheduleModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                       
                        model.ScheduleID = int.Parse(dr["ScheduleID"].ToString());
                        model.Team1ID = int.Parse(dr["Team1ID"].ToString());
                        model.Team2ID = int.Parse(dr["Team2ID"].ToString());
                        model.ScheduleDate = Convert.ToDateTime(dr["ScheduleDate"]);
                        model.Timing = dr["Timing"].ToString();
                        model.Result = dr["Result"].ToString();
                        model.VenueID = int.Parse(dr["VanueID"].ToString());
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

        #region AddUpdateSchedule 
        public int AddUpdateSchedule(ScheduleModel schedule_model,int ScheduleID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand;
                if (ScheduleID == 0)
                {
                    dbCommand =  sqlDatabase.GetStoredProcCommand("PR_Schedule_Insert");
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_Schedule_Update");
                    sqlDatabase.AddInParameter(dbCommand, "ScheduleID", DbType.Int64, ScheduleID);
                }
                sqlDatabase.AddInParameter(dbCommand, "Team1ID", DbType.String, schedule_model.Team1ID);
                sqlDatabase.AddInParameter(dbCommand, "Team2ID", DbType.String, schedule_model.Team2ID);
                sqlDatabase.AddInParameter(dbCommand, "ScheduleDate", DbType.DateTime, schedule_model.ScheduleDate);
                sqlDatabase.AddInParameter(dbCommand, "Timing", DbType.String, schedule_model.Timing);
                sqlDatabase.AddInParameter(dbCommand, "FormatID", DbType.String, schedule_model.FormatID);
                sqlDatabase.AddInParameter(dbCommand, "VanueID", DbType.String, schedule_model.VenueID);
                sqlDatabase.AddInParameter(dbCommand, "Result", DbType.String, schedule_model.Result);


                return sqlDatabase.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        #endregion

        #region DeleteSchedule

        public int DeleteSchedule(int ScheduleID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Schedule_Delete");
                sqlDatabase.AddInParameter(dbCommand, "ScheduleID", DbType.Int64, ScheduleID);
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
