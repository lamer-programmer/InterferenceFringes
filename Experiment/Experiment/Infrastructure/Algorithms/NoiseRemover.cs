using System.Drawing;
using Experiment.Infrastructure.Attributes;

namespace Experiment.Infrastructure.Algorithms
{
	[NameAlgorithm("NoiseRemover1")]
	public class NoiseRemover : INoiseRemover
	{
		public Bitmap RemoveNoise(Bitmap image)
		{
			// Это заглушка
			return image;
		}
	}
}
