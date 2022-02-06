using Gadgetry.Resources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry;

/// <summary>
/// Wraps a <see cref="GadgetRuntime"/> with a hard-typed response resource.
/// </summary>
/// <typeparam name="TOutput">Represents the response model of the <see cref="GadgetFuncRuntime{TOutput}"/>.</typeparam>
public class GadgetFuncRuntime<TOutput>
{
	private readonly IResourceKey<TOutput> outputResourceKey;

	/// <summary>
	/// The <see cref="GadgetRuntime"/> that this <see cref="GadgetFuncRuntime{TOutput}"/> wraps.
	/// </summary>
	public GadgetRuntime InnerGadgetRuntime { get; }

	internal GadgetFuncRuntime(
		GadgetRuntime runtime,
		IResourceKey<TOutput> outputResourceKey)
	{
		InnerGadgetRuntime = runtime;
		this.outputResourceKey = outputResourceKey;
	}

	/// <summary>
	/// Executes an additional gadget using this gadgets runtime state.
	/// </summary>
	/// <param name="gadget">The gadget to execute.</param>
	/// <returns>A runtime used to represent the state of the execution.</returns>
	public GadgetRuntime ExtendWith(Gadget gadget)
	{
		return InnerGadgetRuntime.ExtendWith(gadget);
	}

	/// <summary>
	/// Attempts to run this <see cref="GadgetFuncRuntime{TOutput}"/> to completion.
	/// </summary>
	/// <param name="cancellationToken">A token used to propogate notifications that an operation should be cancelled.</param>
	/// <returns>A task representing the execution.</returns>
	/// <exception cref="InvalidOperationException">Thrown when attempting to run multiple times.</exception>
	public async Task<TOutput> RunAsync(CancellationToken cancellationToken = default)
	{
		await InnerGadgetRuntime.RunAsync(cancellationToken);

		var outputResource = InnerGadgetRuntime.Require(outputResourceKey);
		return await outputResource.ReadAsync(cancellationToken);
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return InnerGadgetRuntime.ToString();
	}
}

/// <summary>
/// Wraps a <see cref="GadgetRuntime"/> with hard-typed request and response resources.
/// </summary>
/// <typeparam name="TInput">Represents the request model of the <see cref="GadgetFuncRuntime{TInput, TOutput}"/>.</typeparam>
/// <typeparam name="TOutput">Represents the response model of the <see cref="GadgetFuncRuntime{TInput, TOutput}"/>.</typeparam>
public class GadgetFuncRuntime<TInput, TOutput>
{
	private readonly ReadBlockingResourceKey<TInput> inputResourceKey;
	private readonly IResourceKey<TOutput> outputResourceKey;

	/// <summary>
	/// The <see cref="GadgetRuntime"/> that this <see cref="GadgetFuncRuntime{TOutput}"/> wraps.
	/// </summary>
	public GadgetRuntime InnerGadgetRuntime { get; }

	internal GadgetFuncRuntime(
		GadgetRuntime runtime,
		ReadBlockingResourceKey<TInput> inputResourceKey,
		IResourceKey<TOutput> outputResourceKey)
	{
		InnerGadgetRuntime = runtime;
		this.inputResourceKey = inputResourceKey;
		this.outputResourceKey = outputResourceKey;
	}

	/// <summary>
	/// Executes an additional gadget using this gadgets runtime state.
	/// </summary>
	/// <param name="gadget">The gadget to execute.</param>
	/// <returns>A runtime used to represent the state of the execution.</returns>
	public GadgetRuntime ExtendWith(Gadget gadget)
	{
		return InnerGadgetRuntime.ExtendWith(gadget);
	}

	/// <summary>
	/// Attempts to run this <see cref="GadgetFuncRuntime{TOutput}"/> to completion.
	/// </summary>
	/// <param name="input">The request model to be passed into the inner <see cref="GadgetRuntime"/>.</param>
	/// <param name="cancellationToken">A token used to propogate notifications that an operation should be cancelled.</param>
	/// <returns>A task representing the execution.</returns>
	/// <exception cref="InvalidOperationException">Thrown when attempting to run multiple times.</exception>
	public async Task<TOutput> RunAsync(TInput input, CancellationToken cancellationToken = default)
	{
		var inputResource = InnerGadgetRuntime.Require(inputResourceKey);
		inputResource.SetResult(input);

		await InnerGadgetRuntime.RunAsync(cancellationToken);

		var outputResource = InnerGadgetRuntime.Require(outputResourceKey);
		return await outputResource.ReadAsync(cancellationToken);
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return InnerGadgetRuntime.ToString();
	}
}
