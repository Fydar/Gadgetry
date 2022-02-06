using System.Diagnostics;
using System.Linq;

namespace Gadgetry.Channels;

/// <summary>
/// Represents a hard-typed writer for a <see cref="GadgetRuntimeChannel{TModel}"/> during a <see cref="GadgetRuntime"/> execution.
/// </summary>
public class GadgetRuntimeChannelWriter<TModel> : IGadgetRuntimeChannelWriter
{
	/// <summary>
	/// The template used to construct this <see cref="GadgetRuntimeChannelWriter{TModel}"/>.
	/// </summary>
	public GadgetChannelWriter<TModel> Template { get; }

	/// <summary>
	/// The <see cref="GadgetRuntimeChannel{TModel}"/> destination that this <see cref="GadgetRuntimeChannelWriter{TModel}"/> writes to.
	/// </summary>
	public GadgetRuntimeChannel<TModel> Destination { get; }

	/// <summary>
	/// A boolean value indicating whether this <see cref="GadgetRuntimeChannelWriter{TModel}"/> has completed writing.
	/// </summary>
	/// <returns><c>true</c> if this <see cref="GadgetRuntimeChannelWriter{TModel}"/> has completed writing; otherwise <c>false</c>.</returns>
	public bool HasCompletedWriting { get; private set; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannelWriter IGadgetRuntimeChannelWriter.Template => Template;
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetRuntimeChannel IGadgetRuntimeChannelWriter.Destination => Destination;

	internal GadgetRuntimeChannelWriter(
		GadgetChannelWriter<TModel> template,
		GadgetRuntimeChannel<TModel> destination)
	{
		Template = template;
		Destination = destination;
	}

	/// <inheritdoc/>
	public void CompleteWriting()
	{
		Destination.state.mutex.WaitOne();
		try
		{
			HasCompletedWriting = true;

			if (Destination.Writers.All(writer => writer.HasCompletedWriting))
			{
				Destination.InnerChannel.Writer.TryComplete();
			}
		}
		finally
		{
			Destination.state.mutex.ReleaseMutex();
		}
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"'write to '{Destination.Template.Identifier}'";
	}
}
