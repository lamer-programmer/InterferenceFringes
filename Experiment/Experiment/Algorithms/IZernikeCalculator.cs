using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Experiment.Algorithms
{
	interface IZernikeCalculator
	{
		IEnumerable<double> CalculateCoefficients(Bitmap image);
	}
}
