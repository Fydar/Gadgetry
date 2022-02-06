using Gadgetry.Resources;

namespace Gadgetry.Wrappers;

/// <summary>
/// Wraps a <see cref="Gadget"/> with a hard-typed request resources.
/// </summary>
/// <typeparam name="TOutput">Represents the response model of the <see cref="GadgetFunc{TInput, TOutput}"/>.</typeparam>
public class GadgetFunc<TOutput>
{
	/// <summary>
	/// The key of the resource which the <see cref="InnerGadget"/> is expected to output to.
	/// </summary>
	public IResourceKey<TOutput> OutputResourceKey { get; }

	/// <summary>
	/// The <see cref="GadgetRuntime"/> that this <see cref="GadgetFunc{TOutput}"/> wraps.
	/// </summary>
	public Gadget InnerGadget { get; }

	internal GadgetFunc(
		Gadget innerGadget,
		IResourceKey<TOutput> outputResourceKey)
	{
		InnerGadget = innerGadget;
		OutputResourceKey = outputResourceKey;
	}

	/// <summary>
	/// Creates a <see cref="GadgetFuncRuntime{TOutput}"/> to execute the behaviour associated with this <see cref="GadgetFunc{TOutput}"/>.
	/// </summary>
	/// <returns>A <see cref="GadgetFuncRuntime{TOutput}"/> configured to execute the behaviour associated with this <see cref="GadgetFunc{TOutput}"/>.</returns>
	public GadgetFuncRuntime<TOutput> CreateRunner()
	{
		return new GadgetFuncRuntime<TOutput>(InnerGadget.CreateRunner(), OutputResourceKey);
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return InnerGadget.ToString();
	}
}

/// <summary>
/// Wraps a <see cref="Gadget"/> with hard-typed request and response resources.
/// </summary>
/// <typeparam name="TInput">Represents the request model of the <see cref="GadgetFunc{TInput, TOutput}"/>.</typeparam>
/// <typeparam name="TOutput">Represents the response model of the <see cref="GadgetFunc{TInput, TOutput}"/>.</typeparam>
public class GadgetFunc<TInput, TOutput>
{
	/// <summary>
	/// The key of the resource which the <see cref="InnerGadget"/> is expected to read from.
	/// </summary>
	public ReadBlockingResourceKey<TInput> InputResourceKey { get; }

	/// <summary>
	/// The key of the resource which the <see cref="InnerGadget"/> is expected to output to.
	/// </summary>
	public IResourceKey<TOutput> OutputResourceKey { get; }

	/// <summary>
	/// The <see cref="GadgetRuntime"/> that this <see cref="GadgetFunc{TInput,TOutput}"/> wraps.
	/// </summary>
	public Gadget InnerGadget { get; }

	internal GadgetFunc(
		Gadget innerGadget,
		ReadBlockingResourceKey<TInput> inputResourceKey,
		IResourceKey<TOutput> outputResourceKey)
	{
		InnerGadget = innerGadget;
		InputResourceKey = inputResourceKey;
		OutputResourceKey = outputResourceKey;
	}

	/// <summary>
	/// Creates a <see cref="GadgetFuncRuntime{TInput, TOutput}"/> to execute the behaviour associated with this <see cref="GadgetFunc{TInput, TOutput}"/>.
	/// </summary>
	/// <returns>A <see cref="GadgetFuncRuntime{TInput, TOutput}"/> configured to execute the behaviour associated with this <see cref="GadgetFunc{TInput, TOutput}"/>.</returns>
	public GadgetFuncRuntime<TInput, TOutput> CreateRunner()
	{
		return new GadgetFuncRuntime<TInput, TOutput>(InnerGadget.CreateRunner(), InputResourceKey, OutputResourceKey);
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return InnerGadget.ToString();
	}
}
