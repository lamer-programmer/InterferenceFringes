using Microsoft.AspNetCore.Mvc;

namespace Experiment.Controllers
{
	public class ResultController : Controller
	{
		

		public IActionResult Result()
		{
			return View();
		}
	}
}
