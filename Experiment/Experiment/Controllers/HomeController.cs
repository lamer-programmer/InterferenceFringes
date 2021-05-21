using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Experiment.Managers;
using Experiment.Models;
using Microsoft.AspNetCore.Http;

namespace Experiment.Controllers
{
	public class HomeController : Controller
	{
		private readonly ImageManager imageManager;

		public HomeController(ImageManager imageManager)
		{
			this.imageManager = imageManager;
		}

		public IActionResult Index()
		{
			return View(imageManager.Image);
		}

		[HttpPost]
		public async Task<IActionResult> AddFile(IFormFile uploadedFile)
		{
			if (uploadedFile == null)
			{
				return RedirectToAction("Index");
			}

			await using (var memoryStream = new MemoryStream())
			{
				await uploadedFile.CopyToAsync(memoryStream);
				imageManager.Image = (Bitmap)Image.FromStream(memoryStream);
			}

			return RedirectToAction("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}

	public static class ImageExtensions
	{
		public static byte[] ToByteArray(this Image image, ImageFormat format)
		{
			using var stream = new MemoryStream();
			image.Save(stream, format);
			return stream.ToArray();
		}
	}
}