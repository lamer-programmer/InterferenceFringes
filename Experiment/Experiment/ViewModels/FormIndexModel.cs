using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace Experiment.ViewModels
{
	public class FormIndexModel
	{
		public Bitmap Image { get; set; }
		public IEnumerable<string> NoiseRemovalMethods
		{
			get
			{
				yield return "None";
				yield return "None1";
				yield return "None2";
			}
		}
		public bool ShowWavefront { get; set; }
		public IEnumerable<string> ZernikeComputeMethods
		{
			get
			{
				yield return "Zernike1";
				yield return "Zernike2";
				yield return "Zernike3";
				yield return "Zernike4";
			}
		}
	}
}