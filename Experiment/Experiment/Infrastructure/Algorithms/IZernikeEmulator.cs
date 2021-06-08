using System.Collections.Generic;
using System.Drawing;

namespace Experiment.Infrastructure.Algorithms
{
	public interface IZernikeEmulator
	{
		Bitmap Emulate(IEnumerable<double> zernikeCoefficients);
	}
}
