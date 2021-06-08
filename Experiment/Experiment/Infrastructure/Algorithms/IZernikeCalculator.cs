using System.Collections.Generic;
using System.Drawing;

namespace Experiment.Infrastructure.Algorithms
{
	interface IZernikeCalculator
	{
		IEnumerable<double> CalculateCoefficients(Bitmap image);
	}
}
