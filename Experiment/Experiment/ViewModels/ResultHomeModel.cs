using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Experiment.Extensions;
using Experiment.Infrastructure.Algorithms;
using Experiment.Infrastructure.Attributes;
using Microsoft.AspNetCore.Http;

namespace Experiment.ViewModels
{
	public class ResultHomeModel
	{
		private ISession session;

		private Func<Bitmap, Bitmap> noiseRemoveFunc;
		private Func<Bitmap, IEnumerable<double>> zernikeCalcFunc;
		private Func<IEnumerable<double>, Bitmap> emulatorFunc;

		public ResultHomeModel(ISession session)
		{
			this.session = session;
			(noiseRemoveFunc, zernikeCalcFunc, emulatorFunc) = GetTypes();
		}

		// Порядок: NoiseRemover, ZernikeCalculator, ZernikeEmulator
		private (Func<Bitmap, Bitmap>,
			Func<Bitmap, IEnumerable<double>>,
			Func<IEnumerable<double>, Bitmap>) GetTypes()
		{
			var noiseRemoverName = session.Get<string>("noiseRemovalMethod");
			var noiseRemoveClass = typeof(Program)
				.Assembly
				.GetExportedTypes()
				.Where(x => x.IsClass && x.GetInterface("INoiseRemover") != null)
				.First(x => ((NameAlgorithmAttribute)x.GetCustomAttributes(true).First()).Name == noiseRemoverName);

			var noiseRemoveMethod = noiseRemoveClass.GetMethod("RemoveNoise");

			var noiseRemoveInstance = Activator.CreateInstance(noiseRemoveClass);
			var noiseRemoveFunc = (Func<Bitmap, Bitmap>)Delegate.CreateDelegate(typeof(Func<Bitmap, Bitmap>),
				noiseRemoveInstance, noiseRemoveMethod);


			var calculatorName = session.Get<string>("zernikeComputeMethod");
			var calcClass = typeof(Program)
				.Assembly
				.GetExportedTypes()
				.Where(x => x.IsClass && x.GetInterface("IZernikeCalculator") != null)
				.First(x => ((NameAlgorithmAttribute)x.GetCustomAttributes(true).First()).Name == calculatorName);

			var calcMethod = calcClass.GetMethod("CalculateCoefficients");

			var calcInstance = Activator.CreateInstance(calcClass);
			var calcFunc =
				(Func<Bitmap, IEnumerable<double>>)Delegate.CreateDelegate(typeof(Func<Bitmap, IEnumerable<double>>),
					calcInstance, calcMethod);


			var emulatorMethod = typeof(ZernikeEmulator).GetMethod("Emulate");
			var emulatorInstance = new ZernikeEmulator();
			var emulatorZFunc = (Func<IEnumerable<double>, Bitmap>)Delegate.CreateDelegate(
				typeof(Func<IEnumerable<double>, Bitmap>), emulatorInstance, emulatorMethod);

			return (noiseRemoveFunc, calcFunc, emulatorZFunc);
		}


		public Bitmap InputImage
		{
			get
			{
				// Хрен знает. Может, сработает.
				using var memoryStream = new MemoryStream(session.Get("inputImage"));
				return new Bitmap(memoryStream);
			}
		}

		public Bitmap OutputImage
		{
			get
			{
				var image = noiseRemoveFunc(InputImage);
				var coefficients = zernikeCalcFunc(image);
				return emulatorFunc(coefficients);
			}
		}

		public Bitmap HeightMap => OutputImage;

		public IEnumerable<double> ZernikeCoefficients
		{
			get
			{
				var image = noiseRemoveFunc(InputImage);
				return zernikeCalcFunc(image);
			}
		}
	}
}
