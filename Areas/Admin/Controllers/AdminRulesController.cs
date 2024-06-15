using cricket_statistics.Areas.Admin.DAL;
using cricket_statistics.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRulesController : Controller
    {
        #region Index

        [Route("AdminRules/Index")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region RulesList

        [Route("AdminRules/RulesList")]
        public IActionResult RulesList()
        
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            DataTable dt = obj.SelectAll("Rules");
            return View(dt);
        }

        #endregion

        #region RulesAddEdit

        [Route("AdminRules/RulesAddEdit")]
        public IActionResult RulesAddEdit(int RuleID)
        {
            Common_Operations_For_DropDown obj =    new Common_Operations_For_DropDown();
            ViewBag.FormatList = obj.FormatDropDown();
            RulesModel rulesModel = new RulesModel();
            if (RuleID > 0)
            {
                AdminRules adminRules = new AdminRules();
                rulesModel = adminRules.SelectRulesByPK(RuleID);
            }
            return View(rulesModel);
        }

        #endregion

        #region InsertUpdateRules

        [Route("AdminRules/InsertUpdateRules")]
        public IActionResult InsertUpdateRules(RulesModel rulesModel, int RuleID = 0)
        {
            AdminRules adminRules = new AdminRules();
            int insert_or_update = adminRules.AddUpdateRules(rulesModel, RuleID);
            return RedirectToAction("RulesList");
        }

        #endregion

        #region DeleteRules

        [Route("AdminRules/DeleteRules")]
        public IActionResult DeleteRules(int RuleID)
        {
            Common_Operations_For_All_Tables obj = new Common_Operations_For_All_Tables();
            int delete = obj.Delete("Rules", RuleID);
            return RedirectToAction("RulesList");
        }

        #endregion
    }

}
