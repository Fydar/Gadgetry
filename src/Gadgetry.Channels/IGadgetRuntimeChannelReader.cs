namespace Gadgetry.Channels;

/// <summary>
/// Represents a hard-typed reader for a <see cref="IGadgetRuntimeChannel"/> during a <see cref="GadgetRuntime"/> execution.
/// </summary>
public interface IGadgetRuntimeChannelReader
{
	/// <summary>
	/// The template used to construct this <see cref="IGadgetRuntimeChannelReader"/>.
	/// </summary>
	public IGadgetChannelReader Template { get; }

	/// <summary>
	/// The <see cref="IGadgetRuntimeChannel"/> source that this <see cref="IGadgetRuntimeChannelReader"/> reads from.
	/// </summary>
	public IGadgetRuntimeChannel Source { get; }
}
