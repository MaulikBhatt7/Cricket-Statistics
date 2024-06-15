using cricket_statistics.Areas.Admin.DAL;
using cricket_statistics.Areas.Admin.Models;

using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.AccessControl;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminScheduleController : Controller
    {

        #region Index

        [Route("AdminSchedule/Index")]

        public IActionResult Index()
        {
            return View();
        }
        #endregion


        #region SelectAllSchedules

        [Route("AdminSchedule/ScheduleList")]
        public IActionResult ScheduleList(ScheduleFilterModel filterModel )
        {
            Common_Operations_For_DropDown obj = new Common_Operations_For_DropDown();
            ViewBag.TeamList = obj.TeamDropDown();
            ViewBag.VenueList = obj.VenueDropDown();
           AdminSchedule obj2 = new AdminSchedule();
            DataTable dt = obj2.SelectAllSchedules(filterModel);
            return View(dt);
        }

        #endregion

        #region AddEditPage

        [Route("AdminSchedule/ScheduleAddEdit")]
        public IActionResult ScheduleAddEdit(int ScheduleID)
        {
            Common_Operations_For_DropDown obj = new Common_Operations_For_DropDown();
            ViewBag.TeamList = obj.TeamDropDown();
            ViewBag.FormatList = obj.FormatDropDown();
            ViewBag.VenueList = obj.VenueDropDown();
            ScheduleModel scheduleModel = new ScheduleModel();
            if (ScheduleID > 0)
            {
                AdminSchedule adminSchedule = new AdminSchedule();
                scheduleModel=adminSchedule.SelectScheduleByPK(ScheduleID);
            }
            return View(scheduleModel);
        }

        #endregion

        #region InsertUpdateSchedule

        [Route("AdminSchedule/InsertUpdateSchedule")]
        public IActionResult InsertUpdateSchedule(ScheduleModel schedule_model,int ScheduleID=0)
        {
            AdminSchedule adminSchedule = new AdminSchedule();
            int insert_or_update = adminSchedule.AddUpdateSchedule(schedule_model,ScheduleID);
            return RedirectToAction("ScheduleList");
        }
        #endregion

        #region DeleteSchedule

        [Route("AdminSchedule/DeleteSchedule")]
        public IActionResult DeleteSchedule (int ScheduleID)
        {
            Common_Operations_For_All_Tables obj = new  Common_Operations_For_All_Tables();
            int delete = obj.Delete("Schedule",ScheduleID);
            return RedirectToAction("ScheduleList");
        }
        #endregion


    }
}
