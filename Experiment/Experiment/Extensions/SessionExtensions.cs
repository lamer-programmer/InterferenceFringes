using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Experiment.Extensions
{
	public static class SessionExtensions
	{
		public static void Set<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonSerializer.Serialize<T>(value));
		}

		public static T Get<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
		}

		public static void Set(this ISession session, string key, Bitmap image)
		{
			using var memoryStream = new MemoryStream();
			image.Save(memoryStream, ImageFormat.Bmp);
			session.Set(key, memoryStream.GetBuffer());
		}
	}
}
