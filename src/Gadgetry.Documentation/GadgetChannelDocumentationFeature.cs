using Gadgetry.Channels;

namespace Gadgetry.Documentation;

/// <summary>
/// A feature used to interact with the <b>documentation</b> associated with an <see cref="IGadgetChannel"/>.
/// </summary>
public class GadgetChannelDocumentationFeature : IGadgetChannelFeature
{
	/// <summary>
	/// Options used to configure the documentation associated with the <see cref="IGadgetChannel"/>.
	/// </summary>
	public GadgetChannelDocumentationOptions Options { get; }

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetChannelDocumentationFeature"/> class.
	/// </summary>
	public GadgetChannelDocumentationFeature()
	{
		Options = new GadgetChannelDocumentationOptions();
	}
}
