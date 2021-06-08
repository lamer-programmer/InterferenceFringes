using System.Collections.Generic;
using System.Drawing;

namespace Experiment.Infrastructure.Algorithms
{
	public interface IZernikeEmulator
	{
		// Восстановленное изображение и карта высот
		(Bitmap, Bitmap) Emulate(IEnumerable<double> zernikeCoefficients);
	}
}
