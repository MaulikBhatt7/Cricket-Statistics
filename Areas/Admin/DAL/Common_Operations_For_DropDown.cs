using cricket_statistics.Areas.Admin.Models;
using cricket_statistics.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace cricket_statistics.Areas.Admin.DAL
{
    public class Common_Operations_For_DropDown:DAL_Helper
    {
        #region TeamDropDown

        public List<TeamModel> TeamDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Team_DropDown");
                List<TeamModel> team = new List<TeamModel>();
                using(IDataReader  reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (reader.Read()) { 
                        
                        TeamModel model = new TeamModel();
                        model.TeamID = int.Parse(reader["TeamID"].ToString());
                        model.TeamName = reader["TeamName"].ToString();
                        team.Add(model);

                    }
                    return team;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        #endregion

        #region FormatDropDown

        public List<FormatModel> FormatDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Format_DropDown");
                List<FormatModel> format = new List<FormatModel>();
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {

                        FormatModel model = new FormatModel();
                        model.FormatID = int.Parse(reader["FormatID"].ToString());
                        model.FormatName = reader["FormatName"].ToString();
                        format.Add(model);

                    }
                    return format;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        #endregion

        #region VanueDropDown

        public List<VenueModel> VenueDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Vanue_DropDown");
                List<VenueModel> vanue = new List<VenueModel>();
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        Common_Operations_For_DropDown obj = new Common_Operations_For_DropDown();
                      
                        VenueModel model = new VenueModel();
                        model.VenueID = int.Parse(reader["VanueID"].ToString());
                        model.VenueName = reader["VanueName"].ToString();
                        vanue.Add(model);

                    }
                    return vanue;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        #endregion

        #region CityDropDown

        public List<CityModel> CityDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_DropDown");
                List<CityModel> city = new List<CityModel>();
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {

                        CityModel model = new CityModel();
                        model.CityID = int.Parse(reader["CityID"].ToString());
                        model.CityName = reader["CityName"].ToString();
                        city.Add(model);

                    }
                    return city;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        #endregion

        #region PlayerDropDown

        public List<PlayerModel> PlayerDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Player_DropDown");
                List<PlayerModel> city = new List<PlayerModel>();
                using (IDataReader reader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        PlayerModel model = new PlayerModel();
                        model.PlayerID = int.Parse(reader["PlayerID"].ToString());
                        model.PlayerName = reader["PlayerName"].ToString();
                        city.Add(model);
                    }
                    return city;
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
