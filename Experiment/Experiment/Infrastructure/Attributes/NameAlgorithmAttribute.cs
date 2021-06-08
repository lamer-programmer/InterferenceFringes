using System;

namespace Experiment.Infrastructure.Attributes
{
	public class NameAlgorithmAttribute : Attribute
	{
		public string Name { get; }

		public NameAlgorithmAttribute(string name)
		{
			Name = name;
		}
	}
}
