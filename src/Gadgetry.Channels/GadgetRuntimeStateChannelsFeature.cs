using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gadgetry.Channels;

/// <summary>
/// A feature used to interact with the "channels" associated with a <see cref="GadgetRuntimeState"/>.
/// </summary>
public class GadgetRuntimeStateChannelsFeature : IGadgetRuntimeStateFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] internal readonly Mutex mutex = new();

	private readonly List<IGadgetRuntimeChannel> runtimeChannels = new();

	/// <summary>
	/// Gets or creates a <see cref="GadgetRuntimeChannel{TModel}"/> identified by a <see cref="GadgetChannel{TModel}"/>.
	/// </summary>
	/// <typeparam name="TModel">The type of model contained within the channel.</typeparam>
	/// <param name="channel">The channel used to identify the newly created channel.</param>
	/// <returns>A <see cref="GadgetRuntimeChannel{TModel}"/> associated with the <see cref="GadgetChannel{TModel}"/>.</returns>
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

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetRuntimeStateChannelsFeature"/> class.
	/// </summary>
	public GadgetRuntimeStateChannelsFeature()
	{
	}
}
