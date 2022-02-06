namespace Gadgetry.Channels;

public static class IGadgetBuilderExtensions
{
	/// <summary>
	/// Creates a writer used to allow this gadget to write to a channel.
	/// </summary>
	/// <typeparam name="TModel">A model representing the content of the channel.</typeparam>
	/// <param name="channel">The channel to write to.</param>
	/// <param name="writer">A writer used to write to the channel.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
	public static IGadgetBuilder WriteTo<TModel>(
		this IGadgetBuilder gadgetBuilder,
		GadgetChannel<TModel> channel,
		out GadgetChannelWriter<TModel> writer)
	{
		writer = gadgetBuilder.WriteTo(channel);
		return gadgetBuilder;
	}

	/// <summary>
	/// Creates a reader used to allow this gadget to read from a channel.
	/// </summary>
	/// <typeparam name="TModel">A model representing the content of the channel.</typeparam>
	/// <param name="channel">The channel to read from.</param>
	/// <param name="writer">A reader used to read from the channel.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
	public static IGadgetBuilder ReadFrom<TModel>(
		this IGadgetBuilder gadgetBuilder,
		GadgetChannel<TModel> channel,
		out GadgetChannelReader<TModel> writer)
	{
		writer = gadgetBuilder.ReadFrom(channel);
		return gadgetBuilder;
	}

	/// <summary>
	/// Creates a writer used to allow this gadget to write to a channel.
	/// </summary>
	/// <typeparam name="TModel">A model representing the content of the channel.</typeparam>
	/// <param name="channel">The channel to write to.</param>
	/// <returns>A writer used to write to the channel.</returns>
	public static GadgetChannelWriter<TModel> WriteTo<TModel>(
		this IGadgetBuilder gadgetBuilder,
		GadgetChannel<TModel> channel)
	{
		var writer = new GadgetChannelWriter<TModel>(channel);

		gadgetBuilder.Configure(configure =>
		{
			var channelsFeature = configure.Features.GetOrCreateFeature<GadgetChannelsFeature>();

			if (!channelsFeature.channels.Contains(channel))
			{
				channelsFeature.channels.Add(channel);
			}
			channelsFeature.writers.Add(writer);
		});

		return writer;
	}

	/// <summary>
	/// Creates a reader used to allow this gadget to read from a channel.
	/// </summary>
	/// <typeparam name="TModel">A model representing the content of the channel.</typeparam>
	/// <param name="channel">The channel to read from.</param>
	/// <returns>A reader used to read from the channel.</returns>
	public static GadgetChannelReader<TModel> ReadFrom<TModel>(
		this IGadgetBuilder gadgetBuilder,
		GadgetChannel<TModel> channel)
	{
		var reader = new GadgetChannelReader<TModel>(channel);

		gadgetBuilder.Configure(configure =>
		{
			var channelsFeature = configure.Features.GetOrCreateFeature<GadgetChannelsFeature>();

			if (!channelsFeature.channels.Contains(channel))
			{
				channelsFeature.channels.Add(channel);
			}
			channelsFeature.readers.Add(reader);
		});

		return reader;
	}
}
