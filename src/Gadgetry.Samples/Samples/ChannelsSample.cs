using Gadgetry.Channels;
using Gadgetry.Resources;
using Gadgetry.Steps;
using Gadgetry.Tasks;
using Gadgetry.Workers;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Gadgetry.Samples.Samples;

internal class ChannelsSample
{
	#region create_parent
	public static Gadget CreateParentGadget(
		out IResourceKey<double> averageResourceKey)
	{
		return Gadget.Create()
			.UseWorker(CreateProducerGadget(out var numbersChannel), new GadgetWorkerOptions(4))
			.UseStep(CreateConsumerGadget(in numbersChannel, out averageResourceKey))
			.Build("producer-consumer-sample");
	}
	#endregion create_parent

	#region create_producer
	public static Gadget CreateProducerGadget(
		out GadgetChannel<int> numbersChannel)
	{
		numbersChannel = new GadgetChannel<int>("numbers")
			.UseChannelCapacity(options =>
			{
				options.Capacity = 512;
				options.FullMode = BoundedChannelFullMode.Wait;
			});

		return Gadget.Create()
			.WriteTo(numbersChannel, out var numbersChannelWriter)
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				var numbersWriter = gadgetRuntime.OpenWriter(numbersChannelWriter);

				for (int i = 1; i < 1000 + 1; i++)
				{
					await Task.Delay(5, cancellationToken);

					await numbersWriter.WriteAsync(i, cancellationToken);
				}
			})
			.Build("producer-gadget");
	}
	#endregion create_producer

	#region create_consumer
	public static Gadget CreateConsumerGadget(
		in GadgetChannel<int> numbersChannel,
		out IResourceKey<double> averageResourceKey)
	{
		var averageReadBlockingResourceKey = ResourceKey.ReadBlocking<double>();
		averageResourceKey = averageReadBlockingResourceKey;

		return Gadget.Create()
			.ReadFrom(numbersChannel, out var numbersChannelReader)
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				var numbersReader = gadgetRuntime.OpenReader(numbersChannelReader);

				int total = 0;
				int count = 0;
				for (int i = 1; i < 1000 + 1; i++)
				{
					int number = await numbersReader.ReadAsync(cancellationToken);

					total += number;
					count++;
				}

				var averageResource = gadgetRuntime.Require(averageReadBlockingResourceKey);
				averageResource.SetResult((double)total / count);
			})
			.Build("consumer-gadget");
	}
	#endregion create_consumer
}
