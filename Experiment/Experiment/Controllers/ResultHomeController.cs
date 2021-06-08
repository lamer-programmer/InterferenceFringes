using Experiment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Experiment.Controllers
{
	public class ResultHomeController : Controller
	{
		public IActionResult Index()
		{
			var model = new ResultHomeModel(HttpContext.Session);
			return View(model);
		}
	}
}
