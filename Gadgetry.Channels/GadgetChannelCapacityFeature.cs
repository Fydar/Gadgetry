namespace Gadgetry.Channels;

public class GadgetChannelCapacityFeature : IGadgetChannelFeature
{
	public GadgetChannelCapacityOptions Options { get; }

	public GadgetChannelCapacityFeature()
	{
		Options = new GadgetChannelCapacityOptions();
	}
}
