using System;

namespace Gadgetry.Channels;

public static class GadgetChannelCapacityBuilderExtensions
{
	public static GadgetChannel<TModel> UseChannelCapacity<TModel>(
		this GadgetChannel<TModel> gadgetChannel,
		Action<GadgetChannelCapacityOptions> options)
	{
		var feature = gadgetChannel.Features.GetOrCreateFeature<GadgetChannelCapacityFeature>();

		options.Invoke(feature.Options);

		return gadgetChannel;
	}

	public static GadgetChannel<TModel> UseChannelCapacity<TModel>(
		this GadgetChannel<TModel> gadgetChannel,
		int capacity)
	{
		var feature = gadgetChannel.Features.GetOrCreateFeature<GadgetChannelCapacityFeature>();

		feature.Options.Capacity = capacity;

		return gadgetChannel;
	}
}
