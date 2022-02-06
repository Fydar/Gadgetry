namespace Gadgetry.Channels;

/// <summary>
/// Represents a writer for a <see cref="IGadgetRuntimeChannel"/> during a <see cref="GadgetRuntime"/> execution.
/// </summary>
public interface IGadgetRuntimeChannelWriter
{
	/// <summary>
	/// The template used to construct this <see cref="IGadgetRuntimeChannelWriter"/>.
	/// </summary>
	public IGadgetChannelWriter Template { get; }

	/// <summary>
	/// The <see cref="IGadgetRuntimeChannel"/> destination that this <see cref="IGadgetRuntimeChannelWriter"/> writes to.
	/// </summary>
	public IGadgetRuntimeChannel Destination { get; }

	/// <summary>
	/// A boolean value indicating whether this <see cref="IGadgetRuntimeChannelWriter"/> has completed writing.
	/// </summary>
	/// <returns><c>true</c> if this <see cref="IGadgetRuntimeChannelWriter"/> has completed writing; otherwise <c>false</c>.</returns>
	public bool HasCompletedWriting { get; }

	/// <summary>
	/// Informs the channel that this writer will not write any additional content to the channel.
	/// </summary>
	void CompleteWriting();
}
