using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Experiment.Models;
using Experiment.ViewModels;
using Microsoft.AspNetCore.Http;
using Experiment.Extensions;

namespace Experiment.Controllers
{
	public class HomeController : Controller
	{
		private Bitmap GetImageSession(string key)
		{
			var session = HttpContext.Session;
			var dataImage = session.Get(key);

			if (dataImage == null)
			{
				return null;
			}

			using var memoryStream = new MemoryStream(dataImage);
			return new Bitmap(memoryStream);
		}

		public IActionResult Index()
		{
			var viewModel = new FormHomeModel();

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> AddFile(FormOutputModel model)
		{
			if (model.File == null)
			{
				return RedirectToAction("Index");
			}

			await using (var memoryStream = new MemoryStream())
			{
				await model.File.CopyToAsync(memoryStream);
				HttpContext.Session.Set("inputImage", memoryStream.GetBuffer());
			}

			HttpContext.Session.Set("noiseRemovalMethod", model.NoiseRemovalMethod);
			HttpContext.Session.Set("zernikeComputeMethod", model.ZernikeComputeMethod);

			return Redirect("~/ResultHome/Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
