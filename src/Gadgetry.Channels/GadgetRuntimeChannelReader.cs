using System.Diagnostics;

namespace Gadgetry.Channels;

/// <summary>
/// Represents a hard-typed reader for a <see cref="GadgetRuntimeChannel{TModel}"/> during a <see cref="GadgetRuntime"/> execution.
/// </summary>
public class GadgetRuntimeChannelReader<TModel> : IGadgetRuntimeChannelReader
{
	/// <summary>
	/// The template used to construct this <see cref="GadgetRuntimeChannelReader{TModel}"/>.
	/// </summary>
	public GadgetChannelReader<TModel> Template { get; }

	/// <summary>
	/// The <see cref="GadgetRuntimeChannel{TModel}"/> source that this <see cref="GadgetRuntimeChannelReader{TModel}"/> reads from.
	/// </summary>
	public GadgetRuntimeChannel<TModel> Source { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannelReader IGadgetRuntimeChannelReader.Template => Template;
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetRuntimeChannel IGadgetRuntimeChannelReader.Source => Source;

	internal GadgetRuntimeChannelReader(
		GadgetChannelReader<TModel> template,
		GadgetRuntimeChannel<TModel> source)
	{
		Template = template;
		Source = source;
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"read from '{Source.Template.Identifier}'";
	}
}
