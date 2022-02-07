using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Channels;

namespace Gadgetry.Channels;

/// <summary>
/// Represents a runtime channel in a producer-consumer data model.
/// </summary>
public class GadgetRuntimeChannel<TModel> : IGadgetRuntimeChannel
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<GadgetRuntimeChannelWriter<TModel>> writers = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<GadgetRuntimeChannelReader<TModel>> readers = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly GadgetRuntimeStateChannelsFeature state;

	/// <summary>
	/// The template used to create this <see cref="GadgetChannel{TModel}"/>.
	/// </summary>
	public GadgetChannel<TModel> Template { get; }

	/// <summary>
	/// A collection of all <see cref="GadgetRuntimeChannelWriter{TModel}"/> that are writing to this <see cref="GadgetRuntimeChannel{TModel}"/>.
	/// </summary>
	public IReadOnlyList<GadgetRuntimeChannelWriter<TModel>> Writers => writers;

	/// <summary>
	/// A collection of all <see cref="GadgetRuntimeChannelReader{TModel}"/> that are reading from this <see cref="GadgetRuntimeChannel{TModel}"/>.
	/// </summary>
	public IReadOnlyList<GadgetRuntimeChannelReader<TModel>> Readers => readers;

	/// <summary>
	/// The raw channel wrapped by this <see cref="GadgetRuntimeChannelReader{TModel}"/>.
	/// </summary>
	internal Channel<TModel> InnerChannel { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannel IGadgetRuntimeChannel.Template => Template;
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IEnumerable<IGadgetRuntimeChannelWriter> IGadgetRuntimeChannel.Writers => writers;
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] IEnumerable<IGadgetRuntimeChannelReader> IGadgetRuntimeChannel.Readers => readers;

	internal GadgetRuntimeChannel(
		GadgetRuntimeStateChannelsFeature state,
		GadgetChannel<TModel> template)
	{
		this.state = state;
		Template = template;

		var capacityFeature = template.Features.GetFeature<GadgetChannelCapacityFeature>();

		if (capacityFeature != null)
		{
			InnerChannel = Channel.CreateBounded<TModel>(
				new BoundedChannelOptions(capacityFeature.Options.Capacity)
				{
					FullMode = capacityFeature.Options.FullMode
				});
		}
		else
		{
			InnerChannel = Channel.CreateUnbounded<TModel>();
		}
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"'{Template.Identifier}' {readers.Count}r {writers.Count}w";
	}
}
