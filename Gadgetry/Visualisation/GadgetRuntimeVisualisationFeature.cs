using System.Collections.Generic;
using System.Diagnostics;

namespace Gadgetry.Visualisation
{
	public class GadgetRuntimeVisualisationFeature : IGadgetRuntimeFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly List<GadgetRuntimeVisualiser> visualisers = new();

		public IReadOnlyList<GadgetRuntimeVisualiser> Visualisers => visualisers;
	}
}
