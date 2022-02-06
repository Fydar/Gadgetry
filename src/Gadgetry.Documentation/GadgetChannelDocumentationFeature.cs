using Gadgetry.Channels;

namespace Gadgetry.Documentation;

public class GadgetChannelDocumentationFeature : IGadgetChannelFeature
{
	public GadgetChannelDocumentationOptions Options { get; }

	public GadgetChannelDocumentationFeature()
	{
		Options = new GadgetChannelDocumentationOptions();
	}
}
