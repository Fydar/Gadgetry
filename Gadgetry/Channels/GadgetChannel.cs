namespace Gadgetry.Channels;

public class GadgetChannel<TModel> : IGadgetChannel
{
	public IFeatureCollection<IGadgetChannelFeature> Features { get; } = new FeatureCollection<IGadgetChannelFeature>();

	/// <summary>
	/// A unique identifier for this channel.
	/// </summary>
	public string Identifier { get; }

	public GadgetChannel(string identifier)
	{
		Identifier = identifier;
	}

	public override string ToString()
	{
		return $"'{Identifier}'";
	}
}
