using Microsoft.AspNetCore.Mvc;

namespace DapperWebAPI.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
