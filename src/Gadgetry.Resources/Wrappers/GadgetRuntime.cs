using Gadgetry.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry;

public class GadgetRuntime<TOutput>
{
	private readonly IResourceKey<TOutput> outputResourceKey;

	public GadgetRuntime InnerGadgetRuntime { get; }

	internal GadgetRuntime(
		GadgetRuntime runtime,
		IResourceKey<TOutput> outputResourceKey)
	{
		InnerGadgetRuntime = runtime;
		this.outputResourceKey = outputResourceKey;
	}

	public GadgetRuntime ExtendWith(Gadget gadget)
	{
		return InnerGadgetRuntime.ExtendWith(gadget);
	}

	public async Task<TOutput> RunAsync(CancellationToken cancellationToken = default)
	{
		await InnerGadgetRuntime.RunAsync(cancellationToken);

		var outputResource = InnerGadgetRuntime.Require(outputResourceKey);
		return await outputResource.ReadAsync(cancellationToken);
	}

	public override string ToString()
	{
		return InnerGadgetRuntime.ToString();
	}
}

public class GadgetRuntime<TInput, TOutput>
{
	private readonly ReadBlockingResourceKey<TInput> inputResourceKey;
	private readonly IResourceKey<TOutput> outputResourceKey;

	public GadgetRuntime InnerGadgetRuntime { get; }

	internal GadgetRuntime(
		GadgetRuntime runtime,
		ReadBlockingResourceKey<TInput> inputResourceKey,
		IResourceKey<TOutput> outputResourceKey)
	{
		InnerGadgetRuntime = runtime;
		this.inputResourceKey = inputResourceKey;
		this.outputResourceKey = outputResourceKey;
	}

	public GadgetRuntime ExtendWith(Gadget gadget)
	{
		return InnerGadgetRuntime.ExtendWith(gadget);
	}

	public async Task<TOutput> RunAsync(TInput input, CancellationToken cancellationToken = default)
	{
		var inputResource = InnerGadgetRuntime.Require(inputResourceKey);
		inputResource.SetResult(input);

		await InnerGadgetRuntime.RunAsync(cancellationToken);

		var outputResource = InnerGadgetRuntime.Require(outputResourceKey);
		return await outputResource.ReadAsync(cancellationToken);
	}

	public override string ToString()
	{
		return InnerGadgetRuntime.ToString();
	}
}
