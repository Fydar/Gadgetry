using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gadgetry.Channels
{
	public class GadgetRuntimeStateChannelsFeature : IGadgetRuntimeStateFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<IGadgetRuntimeChannel> channels = new();
		[DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Mutex mutex = new();

		public GadgetRuntimeChannel<TModel> GetOrCreateChannel<TModel>(GadgetChannel<TModel> channel)
		{
			mutex.WaitOne();
			foreach (var runtimeChannel in channels)
			{
				if (runtimeChannel.Template == channel)
				{
					mutex.ReleaseMutex();
					return (GadgetRuntimeChannel<TModel>)runtimeChannel;
				}
			}

			var newRuntimeChannel = new GadgetRuntimeChannel<TModel>(channel);
			channels.Add(newRuntimeChannel);

			mutex.ReleaseMutex();
			return newRuntimeChannel;
		}
	}
}
