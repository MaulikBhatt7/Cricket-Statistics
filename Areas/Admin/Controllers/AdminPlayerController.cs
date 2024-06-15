using cricket_statistics.Areas.Admin.DAL;
using cricket_statistics.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPlayerController : Controller
    {
        #region Index

        [Route("AdminPlayer/Index")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region PlayerList

        [Route("AdminPlayer/PlayerList")]
        public IActionResult PlayerList()
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            DataTable dt = obj.SelectAll("Player");
            return View(dt);
        }

        #endregion

        #region PlayerAddEdit

        [Route("AdminPlayer/PlayerAddEdit")]
        public IActionResult PlayerAddEdit(int PlayerID)
        {
            Common_Operations_For_DropDown obj = new Common_Operations_For_DropDown();
            ViewBag.CityList = obj.CityDropDown();
            PlayerModel playerModel = new PlayerModel();
            if (PlayerID > 0)
            {
                AdminPlayer adminPlayer = new AdminPlayer();
                playerModel = adminPlayer.SelectPlayerByPK(PlayerID);
            }
            return View(playerModel);
        }

        #endregion

        #region InsertUpdatePlayer

        [Route("AdminPlayer/InsertUpdatePlayer")]
        public IActionResult InsertUpdatePlayer(PlayerModel player_model, int PlayerID = 0)
        {
            AdminPlayer adminPlayer = new AdminPlayer();
            int insert_or_update = adminPlayer.AddUpdatePlayer(player_model, PlayerID);
            return RedirectToAction("PlayerList");
        }

        #endregion

        #region DeletePlayer

        [Route("AdminPlayer/DeletePlayer")]
        public IActionResult DeletePlayer(int PlayerID)
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            int delete = obj.Delete("Player", PlayerID);
            return RedirectToAction("PlayerList");
        }

        #endregion
    }

}
