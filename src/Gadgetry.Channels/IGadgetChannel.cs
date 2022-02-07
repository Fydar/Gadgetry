namespace Gadgetry.Channels;

/// <summary>
/// Represents a channel in a producer-consumer data model.
/// </summary>
public interface IGadgetChannel
{
	/// <summary>
	/// An identifier for this <see cref="IGadgetChannel"/>.
	/// </summary>
	string Identifier { get; }

	/// <summary>
	/// A collection of all <see cref="IGadgetChannelFeature"/> features associated with this <see cref="IGadgetChannel"/>.
	/// </summary>
	IFeatureCollection<IGadgetChannelFeature> Features { get; }
}
