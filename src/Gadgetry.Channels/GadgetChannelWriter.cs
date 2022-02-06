using System.Diagnostics;

namespace Gadgetry.Channels;

/// <summary>
/// Represented a hard-type writer for a <see cref="GadgetChannel{TModel}"/>.
/// </summary>
/// <typeparam name="TModel">A model representing the content of the channel.</typeparam>
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
