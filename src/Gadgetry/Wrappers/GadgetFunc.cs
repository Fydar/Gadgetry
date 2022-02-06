using Gadgetry.Resources;

namespace Gadgetry.Wrappers;

public class GadgetFunc<TOutput>
{
	public IResourceKey<TOutput> OutputResourceKey { get; }
	public Gadget InnerGadget { get; }

	internal GadgetFunc(
		Gadget innerGadget,
		IResourceKey<TOutput> outputResourceKey)
	{
		InnerGadget = innerGadget;
		OutputResourceKey = outputResourceKey;
	}

	public GadgetRuntime<TOutput> CreateRunner()
	{
		return new GadgetRuntime<TOutput>(InnerGadget.CreateRunner(), OutputResourceKey);
	}

	public override string ToString()
	{
		return InnerGadget.ToString();
	}
}

public class GadgetFunc<TInput, TOutput>
{
	public ReadBlockingResourceKey<TInput> InputResourceKey { get; }
	public IResourceKey<TOutput> OutputResourceKey { get; }
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

	public GadgetRuntime<TInput, TOutput> CreateRunner()
	{
		return new GadgetRuntime<TInput, TOutput>(InnerGadget.CreateRunner(), InputResourceKey, OutputResourceKey);
	}

	public override string ToString()
	{
		return InnerGadget.ToString();
	}
}
