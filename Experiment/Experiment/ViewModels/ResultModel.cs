using System.Collections.Generic;
using System.Drawing;

namespace Experiment.ViewModels
{
	public class ResultModel
	{
		public Bitmap InputImage { get; set; }
		public Bitmap OutputImage { get; set; }
		public Bitmap HeightMap { get; set; }
		public IEnumerable<double> ZernikeCoefficients { get; set; }
	}
}
