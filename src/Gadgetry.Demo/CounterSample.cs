using Gadgetry.Channels;
using Gadgetry.Documentation;
using Gadgetry.Resources;
using Gadgetry.Steps;
using Gadgetry.Tasks;
using Gadgetry.Workers;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Gadgetry.Demo;

public static class CounterSample
{
	public static Gadget CreateCounterSample()
	{
		return Gadget.Create()
			.UseDocumentation(options =>
			{
				options.DisplayName = "Demo";
				options.Description = "A demo long-running task.";
			})
			.UseStep(CalculateAverageStep(out var resultA, 10))
			.UseStep(CalculateAverageStep(out var resultB, 20))
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				var resultAValue = gadgetRuntime.Require(resultA);

				Console.WriteLine($"Step A complete, average {await resultAValue.ReadAsync(cancellationToken)}");
			})
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				var resultBValue = gadgetRuntime.Require(resultB);

				Console.WriteLine($"Step B complete, average {await resultBValue.ReadAsync(cancellationToken)}");
			})
			.Build("demo");
	}

	public static IGadgetBuilder CalculateAverageStep(
		out IResourceKey<double> average,
		int countTo)
	{
		var averageResource = ResourceKey.ReadBlocking<double>();
		average = averageResource;

		return Gadget.Create()
			.UseDocumentation(options =>
			{
				options.DisplayName = "Average";
				options.Description = "Averages all input values.";
			})
			.UseWorker(CreateCountingMechanism(countTo, out var numbersChannel), new GadgetWorkerOptions(2))
			.UseWorker(CreateAddMechanism(numbersChannel, out var addedNumbersChannel))
			.ReadFrom(addedNumbersChannel, out var addedNumbersChannelReader)
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				var addedNumbersReader = gadgetRuntime.OpenReader(addedNumbersChannelReader);

				int total = 0, count = 0;

				await foreach (int number in addedNumbersReader.ReadAllAsync(cancellationToken))
				{
					total += number;
					count++;

					Console.WriteLine($"Total: {total}");
				}

				var averageResult = gadgetRuntime.Require(averageResource);
				averageResult.SetResult((double)total / count);
			});
	}

	private static IGadgetBuilder CreateCountingMechanism(
		int countTo,
		out GadgetChannel<int> numbersChannel)
	{
		numbersChannel = GadgetChannel.Create<int>("numbers")
			.UseDocumentation(options =>
			{
				options.DisplayName = "Numbers";
				options.Description = "A channel containing a sequence of numbers.";
			})
			.UseChannelCapacity(options =>
			{
				options.Capacity = 4096;
				options.FullMode = BoundedChannelFullMode.Wait;
			});

		return Gadget.Create()
			.UseDocumentation(options =>
			{
				options.DisplayName = "Counter";
				options.Description = "Counts upwards.";
			})
			.WriteTo(numbersChannel, out var numbersChannelWriter)
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				var numbersWriter = gadgetRuntime.OpenWriter(numbersChannelWriter);

				for (int i = 1; i < countTo + 1; i++)
				{
					await Task.Delay(10, cancellationToken);

					Console.WriteLine($"Count: {i}");
					await numbersWriter.WriteAsync(i, cancellationToken);
				}
			});
	}

	private static IGadgetBuilder CreateAddMechanism(
		GadgetChannel<int> inputChannel,
		out GadgetChannel<int> outputChannel)
	{
		outputChannel = GadgetChannel.Create<int>("added-numbers")
			.UseDocumentation(options =>
			{
				options.DisplayName = "Added Numbers";
				options.Description = "A channel contained all added numbers.";
			})
			.UseChannelCapacity(options =>
			{
				options.Capacity = 4096;
				options.FullMode = BoundedChannelFullMode.Wait;
			});

		return Gadget.Create()
			.UseDocumentation(options =>
			{
				options.DisplayName = "Adder";
				options.Description = "Adds all of the input values.";
			})
			.ReadFrom(inputChannel, out var inputChannelReader)
			.WriteTo(outputChannel, out var outputChannelWriter)
			.UseTask(async (gadgetRuntime, cancellationToken) =>
			{
				var inputReader = gadgetRuntime.OpenReader(inputChannelReader);
				var outputWriter = gadgetRuntime.OpenWriter(outputChannelWriter);

				await Task.Delay(500, cancellationToken);

				await foreach (int item in inputReader.ReadAllAsync(cancellationToken))
				{
					await Task.Delay(10, cancellationToken);

					await outputWriter.WriteAsync(item + 1, cancellationToken);
				}
			});
	}
}
