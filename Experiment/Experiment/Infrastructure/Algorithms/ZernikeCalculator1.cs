using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Experiment.Infrastructure.Attributes;

namespace Experiment.Infrastructure.Algorithms
{
	[NameAlgorithm("ZernikeCalculator1")]
	public class ZernikeCalculator1 : IZernikeCalculator
	{
		public IEnumerable<double> CalculateCoefficients(Bitmap image)
		{
			// Это заглушка.
			return Enumerable.Repeat(2.0, 20);
		}
	}
}
