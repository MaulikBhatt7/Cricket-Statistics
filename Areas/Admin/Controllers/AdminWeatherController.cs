using cricket_statistics.Areas.Admin.DAL;
using cricket_statistics.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminWeatherController : Controller
    {
        #region Index

        [Route("AdminWeather/Index")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region WeatherList

        [Route("AdminWeather/WeatherList")]
        public IActionResult WeatherList()
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            DataTable dt = obj.SelectAll("Weather");
            return View(dt);
        }

        #endregion

        #region WeatherAddEdit

        [Route("AdminWeather/WeatherAddEdit")]
        public IActionResult WeatherAddEdit(int WeatherID)
        {
            WeatherModel weatherModel = new WeatherModel();
            if (WeatherID > 0)
            {
                AdminWeather adminWeather = new AdminWeather();
                weatherModel = adminWeather.SelectWeatherByPK(WeatherID);
            }
            Common_Operations_For_DropDown obj = new Common_Operations_For_DropDown();
            ViewBag.CityList2 = obj.CityDropDown();


            return View(weatherModel);
        }

        #endregion

        #region InsertUpdateWeather

        [Route("AdminWeather/InsertUpdateWeather")]
        public IActionResult InsertUpdateWeather(WeatherModel weatherModel, int WeatherID = 0)
        {
            AdminWeather adminWeather = new AdminWeather();
            int insert_or_update = adminWeather.AddUpdateWeather(weatherModel, WeatherID);
            return RedirectToAction("WeatherList");
        }

        #endregion

        #region DeleteWeather

        [Route("AdminWeather/DeleteWeather")]
        public IActionResult DeleteWeather(int WeatherID)
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            int delete = obj.Delete("Weather", WeatherID);
            return RedirectToAction("WeatherList");
        }

        #endregion
    }
}
    

