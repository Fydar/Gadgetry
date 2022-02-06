using Gadgetry.Resources;

namespace Gadgetry.Wrappers;

/// <summary>
/// Extension methods that provide wrapping of <see cref="Gadget"/> with hard-typed requests and responses.
/// </summary>
public static class GadgetExtensions
{
	/// <summary>
	/// Wraps a <see cref="Gadget"/> with a hard-typed request resources.
	/// </summary>
	/// <typeparam name="TOutput">Represents the response model of the <see cref="GadgetFunc{TInput, TOutput}"/>.</typeparam>
	/// <param name="gadget">The <see cref="Gadget"/> to wrap with a new signature.</param>
	/// <param name="outputResourceKey">The key of the resource which the <paramref name="gadget"/> is expected to output to.</param>
	/// <returns>The <paramref name="gadget"/> wrapped with the new signature.</returns>
	public static GadgetFunc<TOutput> WrapFunc<TOutput>(
		this Gadget gadget,
		IResourceKey<TOutput> outputResourceKey)
	{
		return new GadgetFunc<TOutput>(gadget, outputResourceKey);
	}

	/// <summary>
	/// Wraps a <see cref="Gadget"/> with hard-typed request and response resources.
	/// </summary>
	/// <typeparam name="TInput">Represents the request model of the <see cref="GadgetFunc{TInput, TOutput}"/>.</typeparam>
	/// <typeparam name="TOutput">Represents the response model of the <see cref="GadgetFunc{TInput, TOutput}"/>.</typeparam>
	/// <param name="gadget">The <see cref="Gadget"/> to wrap with a new signature.</param>
	/// <param name="inputResourceKey">The key of the resource which the <paramref name="gadget"/> is expected to read from.</param>
	/// <param name="outputResourceKey">The key of the resource which the <paramref name="gadget"/> is expected to output to.</param>
	/// <returns>The <paramref name="gadget"/> wrapped with the new signature.</returns>
	public static GadgetFunc<TInput, TOutput> WrapFunc<TInput, TOutput>(
		this Gadget gadget,
		ReadBlockingResourceKey<TInput> inputResourceKey,
		IResourceKey<TOutput> outputResourceKey)
	{
		return new GadgetFunc<TInput, TOutput>(gadget, inputResourceKey, outputResourceKey);
	}
}
