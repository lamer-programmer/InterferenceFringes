using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Experiment.Infrastructure.Attributes;
using Microsoft.AspNetCore.Http;

namespace Experiment.ViewModels
{
	public class FormHomeModel
	{
		public IEnumerable<string> NoiseRemovalMethods
		{
			get
			{
				return typeof(Program)
					.Assembly
					.GetExportedTypes()
					.Where(x => x.IsClass && x.GetInterface("INoiseRemover") != null)
					.Select(x => ((NameAlgorithmAttribute) x.GetCustomAttributes(true).First()).Name);
			}
		}

		public bool ShowWavefront { get; set; }

		public IEnumerable<string> ZernikeComputeMethods
		{
			get
			{
				return typeof(Program)
					.Assembly
					.GetExportedTypes()
					.Where(x => x.IsClass && x.GetInterface("IZernikeCalculator") != null)
					.Select(x => ((NameAlgorithmAttribute)x.GetCustomAttributes(true).First()).Name);
			}
		}
	}
}