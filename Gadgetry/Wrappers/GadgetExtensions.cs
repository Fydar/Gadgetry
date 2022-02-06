using Gadgetry.Resources;

namespace Gadgetry.Wrappers
{
	public static class GadgetExtensions
	{
		public static GadgetFunc<TInput, TOutput> WrapFunc<TInput, TOutput>(
			this Gadget gadget,
			ReadBlockingResourceKey<TInput> inputResourceKey,
			IResourceKey<TOutput> outputResourceKey)
		{
			return new GadgetFunc<TInput, TOutput>(gadget, inputResourceKey, outputResourceKey);
		}

		public static GadgetFunc<TOutput> WrapFunc<TOutput>(
			this Gadget gadget,
			IResourceKey<TOutput> outputResourceKey)
		{
			return new GadgetFunc<TOutput>(gadget, outputResourceKey);
		}
	}
}
