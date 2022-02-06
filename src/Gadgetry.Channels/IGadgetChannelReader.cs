namespace Gadgetry.Channels;

/// <summary>
/// Represented a reader for an <see cref="IGadgetChannel"/>.
/// </summary>
public interface IGadgetChannelReader
{
	/// <summary>
	/// The source <see cref="IGadgetChannel"/> that this reader will read from.
	/// </summary>
	public IGadgetChannel Source { get; }
}
