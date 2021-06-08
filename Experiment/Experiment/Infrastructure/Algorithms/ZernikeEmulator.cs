using System.Collections.Generic;
using System.Drawing;
using Experiment.Infrastructure.Attributes;

namespace Experiment.Infrastructure.Algorithms
{
	[NameAlgorithm("ZernikeEmulator")]
	public class ZernikeEmulator : IZernikeEmulator
	{
		public Bitmap Emulate(IEnumerable<double> zernikeCoefficients)
		{
			return new Bitmap(100, 100);
		}
	}
}
