using System.Diagnostics;

namespace Gadgetry.Channels;

public class GadgetChannelWriter<TModel> : IGadgetChannelWriter
{
	/// <summary>
	/// The destination channel that this writer will write to.
	/// </summary>
	public GadgetChannel<TModel> Destination { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannel IGadgetChannelWriter.Destination => Destination;

	internal GadgetChannelWriter(
		GadgetChannel<TModel> destination)
	{
		Destination = destination;
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"write to '{Destination.Identifier}'";
	}
}
