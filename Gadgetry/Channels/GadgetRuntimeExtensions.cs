using System.Threading.Channels;

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
			var channelsFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeChannelsFeature>();

			channelsFeature.mutex.WaitOne();

			foreach (var reader in channelsFeature.readers)
			{
				if (reader.Template == channelReader)
				{
					channelsFeature.mutex.ReleaseMutex();
					return (GadgetRuntimeChannelReader<TModel>)reader;
				}
			}

			var channelsStateFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateChannelsFeature>();
			var runtimeSourceChannel = channelsStateFeature.GetOrCreateChannel(channelReader.Source);

			var newReader = new GadgetRuntimeChannelReader<TModel>(channelReader, runtimeSourceChannel);
			channelsFeature.readers.Add(newReader);
			runtimeSourceChannel.readers.Add(newReader);

			channelsFeature.mutex.ReleaseMutex();
			return newReader;
		}

		public static GadgetRuntimeChannelWriter<TModel> GetWriter<TModel>(
			this GadgetRuntime gadgetRuntime,
			GadgetChannelWriter<TModel> channelWriter)
		{
			var channelsFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeChannelsFeature>();

			channelsFeature.mutex.WaitOne();

			foreach (var writer in channelsFeature.writers)
			{
				if (writer.Template == channelWriter)
				{
					channelsFeature.mutex.ReleaseMutex();
					return (GadgetRuntimeChannelWriter<TModel>)writer;
				}
			}

			var channelsStateFeature = gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateChannelsFeature>();
			var runtimeDestinationChannel = channelsStateFeature.GetOrCreateChannel(channelWriter.Destination);

			var newWriter = new GadgetRuntimeChannelWriter<TModel>(channelWriter, runtimeDestinationChannel);
			channelsFeature.writers.Add(newWriter);
			runtimeDestinationChannel.writers.Add(newWriter);

			channelsFeature.mutex.ReleaseMutex();
			return newWriter;
		}
	}
}
