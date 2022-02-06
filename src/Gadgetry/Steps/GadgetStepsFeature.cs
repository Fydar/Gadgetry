﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Steps;

public class GadgetStepsFeature : IGadgetInitFeature, IGadgetRunFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetStep> steps = new();

	public IReadOnlyList<GadgetStep> Steps => steps;

	public GadgetStepsFeature()
	{
	}

	void IGadgetInitFeature.Init(GadgetRuntime gadgetRuntime)
	{
		var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeStepsFeature>();

		foreach (var step in Steps)
		{
			var stepRuntime = gadgetRuntime.ExtendWith(step.StepGadget);

			runtimeFeature.steps.Add(stepRuntime);
		}
	}

	async Task IGadgetRunFeature.RunAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken)
	{
		var runtimeFeature = gadgetRuntime.Features.GetOrCreateFeature<GadgetRuntimeStepsFeature>();

		for (int i = 0; i < runtimeFeature.steps.Count; i++)
		{
			var stepRuntime = runtimeFeature.steps[i];

			await stepRuntime.RunAsync(cancellationToken);
		}
	}
}