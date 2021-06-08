using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Experiment.Algorithms
{
	public interface IZernikeEmulator
	{
		Bitmap Emulate(IEnumerable<double> zernikeCoefficients);
	}
}
