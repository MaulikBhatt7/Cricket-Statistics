using cricket_statistics.Areas.Admin.DAL;
using cricket_statistics.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPlayerWiseBowlingStatisticsController : Controller
    {
        #region Index

        [Route("AdminPlayerWiseBowlingStatistics/Index")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region BowlingStatisticsList

        [Route("AdminPlayerWiseBowlingStatistics/PlayerWiseBowlingStatisticsList")]
        public IActionResult PlayerWiseBowlingStatisticsList()
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            DataTable dt = obj.SelectAll("PlayerWiseBowlingStatistics");
            return View(dt);
        }

        #endregion

        #region BowlingStatisticsAddEdit

        [Route("AdminPlayerWiseBowlingStatistics/PlayerWiseBowlingStatisticsAddEdit")]
        public IActionResult PlayerWiseBowlingStatisticsAddEdit(int BowlStatID)
        {
            PlayerWiseBowlingStatisticsModel bowlingStatsModel = new PlayerWiseBowlingStatisticsModel();
            if (BowlStatID > 0)
            {
                AdminPlayerWiseBowlingStatistics adminBowlingStats = new AdminPlayerWiseBowlingStatistics();
                bowlingStatsModel = adminBowlingStats.SelectPlayerWiseBowlingStatisticsByPK(BowlStatID);
            }
            Common_Operations_For_DropDown obj = new Common_Operations_For_DropDown();
            ViewBag.PlayerList2 = obj.PlayerDropDown();
            ViewBag.FormatList2 = obj.FormatDropDown();
            return View(bowlingStatsModel);
        }

        #endregion

        #region InsertUpdateBowlingStatistics

        [Route("AdminPlayerWiseBowlingStatistics/InsertUpdateBowlingStatistics")]
        public IActionResult InsertUpdateBowlingStatistics(PlayerWiseBowlingStatisticsModel bowlingStatsModel, int BowlStatID = 0)
        {
            AdminPlayerWiseBowlingStatistics adminBowlingStats = new AdminPlayerWiseBowlingStatistics();
            int insert_or_update = adminBowlingStats.AddUpdatePlayerWiseBowlingStatistics(bowlingStatsModel, BowlStatID);
            return RedirectToAction("PlayerWiseBowlingStatisticsList");
        }

        #endregion

        #region DeleteBowlingStatistics

        [Route("AdminPlayerWiseBowlingStatistics/DeleteBowlingStatistics")]
        public IActionResult DeleteBowlingStatistics(int BowlStatID)
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            int delete = obj.Delete("PlayerWiseBowlingStatistics", BowlStatID);
            return RedirectToAction("PlayerWiseBowlingStatisticsList");
        }

        #endregion
    }

}
