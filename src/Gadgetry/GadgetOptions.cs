namespace Gadgetry;

public class GadgetOptions
{
	public string Identifier { get; }
	public IFeatureCollection<IGadgetFeature> Features { get; } = new FeatureCollection<IGadgetFeature>();

	internal GadgetOptions(string identifier)
	{
		Identifier = identifier;
	}
}
