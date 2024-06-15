using cricket_statistics.Areas.Admin.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cricket_statistics.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AdminDashboardController : Controller
    {
        [Route("/Admin/AdminDashboard/RecordCount")]
        public IActionResult RecordCount()
        {
            AdminDashboard obj = new AdminDashboard();
            DataTable dt = obj.RecordCounts();
            return View("Dashboard",dt);
        }
    }
}
