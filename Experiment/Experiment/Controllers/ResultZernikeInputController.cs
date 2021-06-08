using Experiment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Experiment.Controllers
{
	public class ResultZernikeInputController : Controller
	{
		public IActionResult Index()
		{
			var model = new ZernikeInputResultModel(HttpContext.Session);
			return View(model);
		}
	}
}
