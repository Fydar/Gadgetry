namespace Gadgetry;

/// <summary>
/// A model representing state shared between multiple gadget runtimes.
/// </summary>
public class GadgetRuntimeState
{
	/// <summary>
	/// A collection of all <see cref="IGadgetRuntimeStateFeature"/> features associated with this <see cref="GadgetRuntimeState"/>.
	/// </summary>
	public IFeatureCollection<IGadgetRuntimeStateFeature> Features { get; } = new FeatureCollection<IGadgetRuntimeStateFeature>();
}
