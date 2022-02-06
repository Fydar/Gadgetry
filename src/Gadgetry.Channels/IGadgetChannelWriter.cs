namespace Gadgetry.Channels;

/// <summary>
/// Represented a writer for an <see cref="IGadgetChannel"/>.
/// </summary>
public interface IGadgetChannelWriter
{
	/// <summary>
	/// The destination <see cref="IGadgetChannel"/> that this writer will write to.
	/// </summary>
	public IGadgetChannel Destination { get; }
}
