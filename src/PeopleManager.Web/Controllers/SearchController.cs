using Microsoft.AspNetCore.Mvc;
using PeopleManager.Web.ControllerLogic;

namespace PeopleManager.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchControllerLogic _logic;

        public SearchController(ISearchControllerLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            return View(_logic.GetIndexModel(searchTerm));
        }
    }
}
