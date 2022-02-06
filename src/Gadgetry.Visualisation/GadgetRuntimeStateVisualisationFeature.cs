using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gadgetry.Visualisation;

/// <summary>
/// A feature used to interact with the <b>visualisations</b> associated with an <see cref="GadgetRuntimeState"/>.
/// </summary>
public class GadgetRuntimeStateVisualisationFeature : IGadgetRuntimeStateFeature
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Dictionary<VisualiserTerm, double> terms = new();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Mutex mutex = new();

	/// <summary>
	/// A collection of all known terms associated with the visualisation feature.
	/// </summary>
	public IReadOnlyDictionary<VisualiserTerm, double> Terms => terms;

	public void SetTerm(
		VisualiserTermWriter term,
		double value)
	{
		mutex.WaitOne();
		terms[term.ForTerm] = value;
		mutex.ReleaseMutex();
	}

	public void IncrementTerm(
		VisualiserTermWriter term,
		double increment)
	{
		mutex.WaitOne();
		if (terms.TryGetValue(term.ForTerm, out double currentValue))
		{
			terms[term.ForTerm] = currentValue + increment;
		}
		else
		{
			terms[term.ForTerm] = increment;
		}
		mutex.ReleaseMutex();
	}

	public double? GetTerm(
		VisualiserTerm term)
	{
		if (terms.TryGetValue(term, out double value))
		{
			return value;
		}
		return null;
	}
}
