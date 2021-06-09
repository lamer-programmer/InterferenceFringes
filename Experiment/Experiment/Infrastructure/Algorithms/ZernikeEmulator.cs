using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using Experiment.Infrastructure.Attributes;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Experiment.Infrastructure.Algorithms
{
	[NameAlgorithm("ZernikeEmulator")]
	public class ZernikeEmulator : IZernikeEmulator
	{
		private Mat data;
		private double tiltX;
		private double tiltY;
		private double defocus;
		private double comaX;
		private double comaY;
		private double sphera;
		private double astigmX;
		private double astigmY;
		private double trefoilX;
		private double trefoilY;
		private int w = 512;
		private int h = 512;
		private double contrast;

		private static int MyClamp(int val, int low, int hi)
		{
			if (val < low)
			{
				return low;
			}

			return val > hi ? hi : val;
		}

		private double F(double x, double y)
		{
			var xx = x / (0.5 * h) - 1;
			var yy = 1.0 - y / (0.5 * h);
			var r2 = xx * xx + yy * yy;

			yy = -yy;

			var r = Math.Sqrt(r2);
			var fi = Math.Atan2(yy, xx);

			return 0.5 * (
				tiltX * xx + tiltY * yy +
				defocus * (2 * r2 - 1)
				+ (3 * r2 - 2) * (comaX * xx + comaY * yy)
				+ sphera * (6 * (r2 * r2 - r2) + 1)
				+ r2 * (astigmX * Math.Cos(2 * fi) + astigmY * Math.Sin(2 * fi))
				+ r2 * r * (trefoilX * Math.Cos(3 * fi) + trefoilY * Math.Sin(3 * fi)));
		}

		private void InitZernikeCoefficients(IEnumerable<double> zernikeCoefficients)
		{
			var coefficients = zernikeCoefficients as double[] ?? zernikeCoefficients.ToArray();
			var tupleCoefficients = (coefficients.ElementAt(0),
				coefficients.ElementAt(1),
				coefficients.ElementAt(2),
				coefficients.ElementAt(3),
				coefficients.ElementAt(4),
				coefficients.ElementAt(5),
				coefficients.ElementAt(6),
				coefficients.ElementAt(7),
				coefficients.ElementAt(8),
				coefficients.ElementAt(9));
			(tiltX, tiltY, defocus, comaX, comaY, sphera, astigmX, astigmY, trefoilX, trefoilY) = tupleCoefficients;
		}

        unsafe public (Bitmap, Bitmap) Emulate(IEnumerable<double> zernikeCoefficients)
        {
	        InitZernikeCoefficients(zernikeCoefficients);

	        contrast = 1;

	        data = new Mat(h, w, 24);
			data.ForEachAsInt32((a, b) =>
			{
				var y = b[0];
				var x = b[1];

				var vv = -Math.PI * 2 * F(x, y);
				var v = Math.Cos(vv);

				var k = (short.MaxValue) / 2.0 - contrast * v;
				var v2 = MyClamp((int) k, 0, (short.MaxValue));

				*a = (short) v2;
			});

			return (data.ToBitmap(), new Bitmap(200, 200));
		}
	}
}
