namespace Gadgetry;

/// <summary>
/// Options used to configure the behaviour of a <see cref="Gadget"/>.
/// </summary>
public class GadgetOptions
{
	/// <summary>
	/// An identifier associated with the <see cref="Gadget"/>.
	/// </summary>
	public string Identifier { get; }

	/// <summary>
	/// A collection of all <see cref="IGadgetFeature"/> features associated with the <see cref="Gadget"/>.
	/// </summary>
	public IFeatureCollection<IGadgetFeature> Features { get; } = new FeatureCollection<IGadgetFeature>();

	internal GadgetOptions(string identifier)
	{
		Identifier = identifier;
	}
}
