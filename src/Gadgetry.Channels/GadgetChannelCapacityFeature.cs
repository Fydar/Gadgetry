namespace Gadgetry.Channels;

/// <summary>
/// A feature used to describe channel capacity associated with an <see cref="IGadgetChannel"/>.
/// </summary>
public class GadgetChannelCapacityFeature : IGadgetChannelFeature
{
	/// <summary>
	/// Options used to configure this feature.
	/// </summary>
	public GadgetChannelCapacityOptions Options { get; }

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetChannelCapacityFeature"/> class.
	/// </summary>
	public GadgetChannelCapacityFeature()
	{
		Options = new GadgetChannelCapacityOptions();
	}
}
