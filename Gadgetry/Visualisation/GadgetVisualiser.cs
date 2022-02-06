using System.Diagnostics;

namespace Gadgetry.Visualisation;

public class GadgetVisualiser<TVisualiser> : IGadgetVisualiser
	where TVisualiser : IVisualiser
{
	public TVisualiser Visualiser { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	IVisualiser IGadgetVisualiser.Visualiser => Visualiser;

	public GadgetVisualiser(TVisualiser visualiser)
	{
		Visualiser = visualiser;
	}
}
