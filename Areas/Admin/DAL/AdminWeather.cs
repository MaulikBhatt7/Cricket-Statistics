using cricket_statistics.Areas.Admin.Models;
using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class AdminWeather : DAL_Helper
    {
        #region SelectWeatherByPK

        public WeatherModel SelectWeatherByPK(int WeatherID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Weather_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "WeatherID", DbType.Int32, WeatherID);

                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    WeatherModel model = new WeatherModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        model.WeatherID = int.Parse(dr["WeatherID"].ToString());
                        model.WeatherTemperature = dr["WeatherTemperature"].ToString();
                        model.Date = Convert.ToDateTime(dr["Date"]);
                        model.CityID = int.Parse(dr["CityID"].ToString());
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

        #region AddUpdateWeather

        public int AddUpdateWeather(WeatherModel weatherModel, int WeatherID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand;

                if (WeatherID == 0)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_Weather_Insert");
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("PR_Weather_Update");
                    sqlDatabase.AddInParameter(dbCommand, "WeatherID", DbType.Int32, WeatherID);
                }

                sqlDatabase.AddInParameter(dbCommand, "WeatherTemperature", DbType.String, weatherModel.WeatherTemperature);
                sqlDatabase.AddInParameter(dbCommand, "Date", DbType.DateTime, weatherModel.Date);
                sqlDatabase.AddInParameter(dbCommand, "CityID", DbType.Int32, weatherModel.CityID);

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
