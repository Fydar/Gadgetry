using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Visualisation
{
	public class GadgetVisualisationFeature : IGadgetFeature, IGadgetInitFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly List<IGadgetVisualiser> visualisers = new();

		public IReadOnlyList<IGadgetVisualiser> Visualisers => visualisers;

		public void Init(GadgetRuntime gadgetRuntime)
		{
			gadgetRuntime.State.Features.GetOrCreateFeature<GadgetRuntimeStateVisualisationFeature>();
		}
	}
}
