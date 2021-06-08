using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Experiment.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Experiment.Controllers
{
	public class ZernikeInputController : Controller
	{
		private const int CoefficientsNumber = 20;

		public IActionResult Index()
		{
			return View(Enumerable.Repeat(0.0, CoefficientsNumber).ToList());
		}

		public async Task<IActionResult> Emulate(IEnumerable<double> zernikeCoefficients)
		{
			// var coefficientsString = string
			//	.Join('|', zernikeCoefficients.Select(Convert.ToString));
			HttpContext.Session.Set("zernikeCoefficients", zernikeCoefficients);
			return Redirect("~/ResultZernikeInput/Index");
		}
	}
}
