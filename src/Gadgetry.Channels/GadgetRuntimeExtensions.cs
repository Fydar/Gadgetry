using System.Threading.Channels;

namespace Gadgetry.Channels;

/// <summary>
/// Extension methods of <see cref="GadgetRuntime"/> for interacting with <b>"channel"</b> support.
/// </summary>
public static class GadgetRuntimeExtensions
{
	/// <summary>
	/// Gets a <see cref="ChannelReader{TModel}"/> that can read from the channel represented by <paramref name="channelReader"/>.
	/// </summary>
	/// <typeparam name="TModel">A type that represents the content of the channel.</typeparam>
	/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> to provide read context.</param>
	/// <param name="channelReader">The reader to open.</param>
	/// <returns>A <see cref="ChannelReader{TModel}"/> that can read from the channel represented by <paramref name="channelReader"/>.</returns>
	public static ChannelReader<TModel> OpenReader<TModel>(
		this GadgetRuntime gadgetRuntime,
		GadgetChannelReader<TModel> channelReader)
	{
		var reader = gadgetRuntime.GetReader(channelReader);

		return reader.Source.InnerChannel.Reader;
	}

	/// <summary>
	/// Gets a <see cref="ChannelWriter{TModel}"/> that can write to the channel represented by <paramref name="channelWriter"/>.
	/// </summary>
	/// <typeparam name="TModel">A type that represents the content of the channel.</typeparam>
	/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> to provide read context.</param>
	/// <param name="channelWriter">The writer to open.</param>
	/// <returns>A <see cref="ChannelWriter{TModel}"/> that can write to the channel represented by <paramref name="channelWriter"/>.</returns>
	public static ChannelWriter<TModel> OpenWriter<TModel>(
		this GadgetRuntime gadgetRuntime,
		GadgetChannelWriter<TModel> channelWriter)
	{
		var writer = gadgetRuntime.GetWriter(channelWriter);

		return writer.Destination.InnerChannel.Writer;
	}

	/// <summary>
	/// Gets a <see cref="GadgetRuntimeChannelReader{TModel}"/> that can be used to read from the channel represented by <paramref name="channelReader"/>.
	/// </summary>
	/// <typeparam name="TModel">A type that represents the content of the channel.</typeparam>
	/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> to provide read context.</param>
	/// <param name="channelReader">The reader to get the runtime version of.</param>
	/// <returns>A <see cref="GadgetRuntimeChannelReader{TModel}"/> that can be used to read from the channel represented by <paramref name="channelReader"/>.</returns>
	public static GadgetRuntimeChannelReader<TModel> GetReader<TModel>(
		this GadgetRuntime gadgetRuntime,
		GadgetChannelReader<TModel> channelReader)
	{
		var stateFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateChannelsFeature>();
		var channelsFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeChannelsFeature>();

		stateFeature.mutex.WaitOne();

		foreach (var reader in channelsFeature.readers)
		{
			if (reader.Template == channelReader)
			{
				stateFeature.mutex.ReleaseMutex();
				return (GadgetRuntimeChannelReader<TModel>)reader;
			}
		}

		var channelsStateFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateChannelsFeature>();
		var runtimeSourceChannel = channelsStateFeature.GetOrCreateChannel(channelReader.Source);

		var newReader = new GadgetRuntimeChannelReader<TModel>(channelReader, runtimeSourceChannel);
		channelsFeature.readers.Add(newReader);
		runtimeSourceChannel.readers.Add(newReader);

		stateFeature.mutex.ReleaseMutex();
		return newReader;
	}

	/// <summary>
	/// Gets a <see cref="GadgetRuntimeChannelWriter{TModel}"/> that can be used to write to the channel represented by <paramref name="channelWriter"/>.
	/// </summary>
	/// <typeparam name="TModel">A type that represents the content of the channel.</typeparam>
	/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> to provide read context.</param>
	/// <param name="channelWriter">The writer to get the runtime version of.</param>
	/// <returns>A <see cref="GadgetRuntimeChannelWriter{TModel}"/> that can be used to write to the channel represented by <paramref name="channelWriter"/>.</returns>
	public static GadgetRuntimeChannelWriter<TModel> GetWriter<TModel>(
		this GadgetRuntime gadgetRuntime,
		GadgetChannelWriter<TModel> channelWriter)
	{
		var stateFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateChannelsFeature>();
		var channelsFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeChannelsFeature>();

		stateFeature.mutex.WaitOne();

		foreach (var writer in channelsFeature.writers)
		{
			if (writer.Template == channelWriter)
			{
				stateFeature.mutex.ReleaseMutex();
				return (GadgetRuntimeChannelWriter<TModel>)writer;
			}
		}

		var channelsStateFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateChannelsFeature>();
		var runtimeDestinationChannel = channelsStateFeature.GetOrCreateChannel(channelWriter.Destination);

		var newWriter = new GadgetRuntimeChannelWriter<TModel>(channelWriter, runtimeDestinationChannel);
		channelsFeature.writers.Add(newWriter);
		runtimeDestinationChannel.writers.Add(newWriter);

		stateFeature.mutex.ReleaseMutex();
		return newWriter;
	}
}
