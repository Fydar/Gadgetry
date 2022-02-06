using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gadgetry.Channels;

public class GadgetRuntimeStateChannelsFeature : IGadgetRuntimeStateFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly Mutex mutex = new();

	private readonly List<IGadgetRuntimeChannel> runtimeChannels = new();

	public GadgetRuntimeChannel<TModel> GetOrCreateChannel<TModel>(GadgetChannel<TModel> channel)
	{
		mutex.WaitOne();
		foreach (var runtimeChannel in runtimeChannels)
		{
			if (runtimeChannel.Template == channel)
			{
				mutex.ReleaseMutex();
				return (GadgetRuntimeChannel<TModel>)runtimeChannel;
			}
		}

		var newRuntimeChannel = new GadgetRuntimeChannel<TModel>(this, channel);
		runtimeChannels.Add(newRuntimeChannel);

		mutex.ReleaseMutex();
		return newRuntimeChannel;
	}
}
