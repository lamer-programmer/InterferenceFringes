using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Experiment.Extensions
{
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
