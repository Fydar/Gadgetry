using System.Diagnostics;

namespace Gadgetry.Channels;

/// <summary>
/// Represents a hard-typed reader of a <see cref="GadgetChannel{TModel}"/>.
/// </summary>
/// <typeparam name="TModel">A model representing the content of the channel.</typeparam>
public class GadgetChannelReader<TModel> : IGadgetChannelReader
{
	/// <summary>
	/// The source channel that this reader will read from.
	/// </summary>
	public GadgetChannel<TModel> Source { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannel IGadgetChannelReader.Source => Source;

	internal GadgetChannelReader(GadgetChannel<TModel> source)
	{
		Source = source;
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"read from '{Source.Identifier}'";
	}
}
