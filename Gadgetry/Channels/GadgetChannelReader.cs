using System.Diagnostics;

namespace Gadgetry.Channels;

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

	public override string ToString()
	{
		return $"read from '{Source.Identifier}'";
	}
}
