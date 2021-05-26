using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Experiment.Models;
using Experiment.ViewModels;
using Microsoft.AspNetCore.Http;

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
			var viewModel = new FormIndexModel {Image = GetImageSession("inputImage")};

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> AddFile(FormOutputModel model)
		{
			Console.WriteLine(model.NoiseRemovalMethod);
			Console.WriteLine(model.ShowWaveFront);
			Console.WriteLine(model.ZernikeComputeMethod);
			
			if (model.File == null)
			{
				return RedirectToAction("Index");
			}

			await using (var memoryStream = new MemoryStream())
			{
				await model.File.CopyToAsync(memoryStream);
				HttpContext.Session.Set("inputImage", memoryStream.GetBuffer());
			}

			return RedirectToAction("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
