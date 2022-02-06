using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Steps;

/// <summary>
/// A feature used to interact with the <b>workers</b> associated with an <see cref="Gadget"/>.
/// </summary>
public class GadgetStepsFeature : IGadgetInitFeature, IGadgetRunFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<GadgetStep> steps = new();

	/// <summary>
	/// A collection of all steps associated with the <see cref="Gadget"/>
	/// </summary>
	public IReadOnlyList<GadgetStep> Steps => steps;

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetStepsFeature"/> class.
	/// </summary>
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
