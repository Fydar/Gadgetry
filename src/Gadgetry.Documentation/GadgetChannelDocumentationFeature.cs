using Gadgetry.Channels;

namespace Gadgetry.Documentation;

/// <summary>
/// A feature used to interact with the <b>documentation</b> associated with an <see cref="IGadgetChannel"/>.
/// </summary>
public class GadgetChannelDocumentationFeature : IGadgetChannelFeature
{
	public GadgetChannelDocumentationOptions Options { get; }

	public GadgetChannelDocumentationFeature()
	{
		Options = new GadgetChannelDocumentationOptions();
	}
}
