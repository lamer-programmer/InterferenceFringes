using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Experiment.Controllers
{
	public class ZernikeInputController : Controller
	{
		private const int ZernikeCoefficientsNumber = 20;

		public IActionResult Index()
		{
			return View(Enumerable.Repeat(0.0, ZernikeCoefficientsNumber).ToList());
		}

		public async Task<IActionResult> Emulate(IEnumerable<double> zernikeCoefficients)
		{
			return Redirect("~/Return/Result");
		}
	}
}
