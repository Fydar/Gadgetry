using Gadgetry.Internal;

namespace Gadgetry
{
	public class Gadget
	{
		public string Identifier { get; }
		public IReadOnlyFeatureCollection<IGadgetFeature> Features { get; }

		internal Gadget(GadgetOptions options)
		{
			Identifier = options.Identifier;
			Features = options.Features;
		}

		public GadgetRuntime CreateRunner()
		{
			return new GadgetRuntime(this);
		}

		public static IGadgetBuilder Create()
		{
			return new GadgetBuilder();
		}

		public override string ToString()
		{
			return $"Gadget({Identifier})";
		}
	}
}
