﻿using Gadgetry.Resources;
using Gadgetry.Steps;

namespace Gadgetry.Wrappers.Steps;

public static class IGadgetBuilderExtensions
{
	public static IGadgetBuilder UseStep<TOutput>(
		this IGadgetBuilder gadgetBuilder,
		GadgetFunc<TOutput> stepGadget,
		out IResourceKey<TOutput> outputResourceKey)
	{
		gadgetBuilder.UseStep(stepGadget.InnerGadget);

		outputResourceKey = stepGadget.OutputResourceKey;
		return gadgetBuilder;
	}

	public static IGadgetBuilder UseStep<TInput, TOutput>(
		this IGadgetBuilder gadgetBuilder,
		GadgetFunc<TInput, TOutput> stepGadget,
		out ReadBlockingResourceKey<TInput> inputResourceKey,
		out IResourceKey<TOutput> outputResourceKey)
	{
		gadgetBuilder.UseStep(stepGadget.InnerGadget);

		inputResourceKey = stepGadget.InputResourceKey;
		outputResourceKey = stepGadget.OutputResourceKey;
		return gadgetBuilder;
	}
}
