using Microsoft.AspNetCore.Mvc;
using PeopleManager.Web.ControllerLogic;
using PeopleManager.Web.Models;
using PeopleManager.Web.Models.AddPerson;

namespace PeopleManager.Web.Controllers
{
    public class AddPersonController : Controller
    {
        private readonly IAddPersonControllerLogic _logic;

        public AddPersonController(IAddPersonControllerLogic logic)
        {
            _logic = logic;
        }
        
        public IActionResult Index()
        {
            return View(_logic.GetIndexModel());
        }
        
        [HttpPost]
        public IActionResult AddPerson(AddPersonIndexModel input)
        {
            if (ModelState.IsValid)
            {
                return View(_logic.AddPerson(input));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
