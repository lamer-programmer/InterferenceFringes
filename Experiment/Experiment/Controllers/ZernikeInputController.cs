using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Experiment.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Experiment.Controllers
{
	public class ZernikeInputController : Controller
	{
		private const int CoefficientsNumber = 10;

		public ZernikeInputController()
		{
			ViewData["Title"] = "Ввод коэффициентов";
		}

		public IActionResult Index()
		{
			return View(Enumerable.Repeat(0.0, CoefficientsNumber).ToList());
		}

		public async Task<IActionResult> Emulate(IEnumerable<double> zernikeCoefficients)
		{
			HttpContext.Session.Set("zernikeCoefficients", zernikeCoefficients);
			return Redirect("~/ResultZernikeInput/Index");
		}
	}
}
