using System;

namespace Gadgetry.Channels;

/// <summary>
/// Extension methods of <see cref="GadgetChannel{TModel}"/> for adding <b>channel capacity</b> support.
/// </summary>
public static class GadgetChannelCapacityBuilderExtensions
{
	/// <summary>
	/// Associates a capacity with a <see cref="GadgetChannel{TModel}"/> to limit the amount of data it can contain.
	/// </summary>
	/// <param name="gadgetChannel">The <see cref="GadgetChannel{TModel}"/> to configure.</param>
	/// <param name="options">Options used to configure the capacity of the <see cref="GadgetChannel{TModel}"/>.</param>
	/// <returns>The current instance of this <see cref="GadgetChannel{TModel}"/>.</returns>
	public static GadgetChannel<TModel> UseChannelCapacity<TModel>(
		this GadgetChannel<TModel> gadgetChannel,
		Action<GadgetChannelCapacityOptions> options)
	{
		var feature = gadgetChannel.Features.GetOrCreateFeature<GadgetChannelCapacityFeature>();

		options.Invoke(feature.Options);

		return gadgetChannel;
	}

	/// <summary>
	/// Associates a capacity with a <see cref="GadgetChannel{TModel}"/> to limit the amount of data it can contain.
	/// </summary>
	/// <param name="gadgetChannel">The <see cref="GadgetChannel{TModel}"/> to configure.</param>
	/// <param name="capacity">The desired capacity for the channel.</param>
	/// <returns>The current instance of this <see cref="GadgetChannel{TModel}"/>.</returns>
	public static GadgetChannel<TModel> UseChannelCapacity<TModel>(
		this GadgetChannel<TModel> gadgetChannel,
		int capacity)
	{
		var feature = gadgetChannel.Features.GetOrCreateFeature<GadgetChannelCapacityFeature>();

		feature.Options.Capacity = capacity;

		return gadgetChannel;
	}
}
