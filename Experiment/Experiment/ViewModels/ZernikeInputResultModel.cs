using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Experiment.Extensions;
using Experiment.Infrastructure.Algorithms;

namespace Experiment.ViewModels
{
	public class ZernikeInputResultModel
	{
		private IEnumerable<double> coefficients;

		public ZernikeInputResultModel(ISession session)
		{
			coefficients = session.Get<IEnumerable<double>>("zernikeCoefficients");
		}

		public Bitmap OutputImage
		{
			get
			{
				var emulator = new ZernikeEmulator();
				return emulator.Emulate(coefficients).Item1;
			}
		}

		public Bitmap HeightMap
		{
			get
			{
				var emulator = new ZernikeEmulator();
				return emulator.Emulate(coefficients).Item2;
			}
		}
	}
}
