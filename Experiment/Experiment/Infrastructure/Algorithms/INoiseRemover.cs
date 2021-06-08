using System.Drawing;

namespace Experiment.Infrastructure.Algorithms
{
	interface INoiseRemover
	{
		Bitmap RemoveNoise(Bitmap image);
	}
}
