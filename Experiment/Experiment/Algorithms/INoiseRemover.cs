using System.Drawing;

namespace Experiment.Algorithms
{
	interface INoiseRemover
	{
		Bitmap RemoveNoise(Bitmap image);
	}
}
