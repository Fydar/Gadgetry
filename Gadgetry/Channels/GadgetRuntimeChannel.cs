using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Channels
{
	public class GadgetRuntimeChannel<TModel> : IGadgetRuntimeChannel
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<GadgetRuntimeChannelWriter<TModel>> writers = new();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly List<GadgetRuntimeChannelReader<TModel>> readers = new();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly GadgetRuntimeStateChannelsFeature state;

		public GadgetChannel<TModel> Template { get; }
		public Channel<TModel> InnerChannel { get; }

		public IEnumerable<GadgetRuntimeChannelWriter<TModel>> Writers => writers;
		public IEnumerable<GadgetRuntimeChannelReader<TModel>> Readers => readers;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IGadgetChannel IGadgetRuntimeChannel.Template => Template;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IEnumerable<IGadgetRuntimeChannelWriter> IGadgetRuntimeChannel.Writers => writers;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] IEnumerable<IGadgetRuntimeChannelReader> IGadgetRuntimeChannel.Readers => readers;

		public GadgetRuntimeChannel(
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

		public override string ToString()
		{
			return $"'{Template.Identifier}' {readers.Count}r {writers.Count}w";
		}
	}
}
