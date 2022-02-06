namespace Gadgetry.Channels
{
	public static class GadgetRuntimeExtensions
	{
		public static ChannelReader<TModel> OpenReader<TModel>(
			this GadgetRuntime gadgetRuntime,
			GadgetChannelReader<TModel> channelReader)
		{
			var reader = gadgetRuntime.GetReader(channelReader);

			return reader.Source.InnerChannel.Reader;
		}

		public static ChannelWriter<TModel> OpenWriter<TModel>(
			this GadgetRuntime gadgetRuntime,
			GadgetChannelWriter<TModel> channelWriter)
		{
			var writer = gadgetRuntime.GetWriter(channelWriter);

			return writer.Destination.InnerChannel.Writer;
		}

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
}
