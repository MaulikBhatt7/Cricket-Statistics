using cricket_statistics.Areas.Admin.DAL;
using cricket_statistics.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPlayerWiseBattingStatisticsController : Controller
    {
        #region Index

        [Route("AdminPlayerWiseBattingStatistics/Index")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region BattingStatisticsList

        [Route("AdminPlayerWiseBattingStatistics/PlayerWiseBattingStatisticsList")]
        public IActionResult PlayerWiseBattingStatisticsList()
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            DataTable dt = obj.SelectAll("PlayerWiseBattingStatistics");
            return View(dt);
        }

        #endregion

        #region BattingStatisticsAddEdit

        [Route("AdminPlayerWiseBattingStatistics/PlayerWiseBattingStatisticsAddEdit")]
        public IActionResult PlayerWiseBattingStatisticsAddEdit(int BatStatID)
        {
            PlayerWiseBattingStatisticsModel battingStatsModel = new PlayerWiseBattingStatisticsModel();
            if (BatStatID > 0)
            {
                AdminPlayerWiseBattingStatistics adminBattingStats = new AdminPlayerWiseBattingStatistics();
                battingStatsModel = adminBattingStats.SelectPlayerWiseBattingStatisticsByPK(BatStatID);
            }
            Common_Operations_For_DropDown obj = new Common_Operations_For_DropDown();
            ViewBag.PlayerList = obj.PlayerDropDown();
            ViewBag.FormatList = obj.FormatDropDown();
            return View(battingStatsModel);
        }

        #endregion

        #region InsertUpdateBattingStatistics

        [Route("AdminPlayerWiseBattingStatistics/InsertUpdateBattingStatistics")]
        public IActionResult InsertUpdateBattingStatistics(PlayerWiseBattingStatisticsModel battingStatsModel, int BatStatID = 0)
        {
            AdminPlayerWiseBattingStatistics adminBattingStats = new AdminPlayerWiseBattingStatistics();
            int insert_or_update = adminBattingStats.AddUpdatePlayerWiseBattingStatistics(battingStatsModel, BatStatID);
            return RedirectToAction("PlayerWiseBattingStatisticsList");
        }

        #endregion

        #region DeleteBattingStatistics

        [Route("AdminPlayerWiseBattingStatistics/DeleteBattingStatistics")]
        public IActionResult DeleteBattingStatistics(int BatStatID)
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            int delete = obj.Delete("PlayerWiseBattingStatistics", BatStatID);
            return RedirectToAction("PlayerWiseBattingStatisticsList");
        }

        #endregion
    }

}
