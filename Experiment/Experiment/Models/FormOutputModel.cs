using Microsoft.AspNetCore.Http;

namespace Experiment.Models
{
	public class FormOutputModel
	{
		public IFormFile File { get; set; }
		public string NoiseRemovalMethod { get; set; }
		public bool ShowWaveFront { get; set; }
		public string ZernikeComputeMethod { get; set; }
	}
}
