namespace Gadgetry.Visualisation;

public class VisualiserProgressBar : IVisualiser
{
	public VisualiserSplitSeries Series { get; set; }
	public VisualiserTerm? Count { get; }

	private VisualiserProgressBar(VisualiserSplitSeries data, VisualiserTerm? count)
	{
		Series = data;
		Count = count;
	}

	public static VisualiserProgressBar Create(VisualiserTerm term)
	{
		var series = Visualiser.SplitSeries(term);
		return Create(series);
	}

	public static VisualiserProgressBar Create(VisualiserTerm term, out VisualiserTermWriter count)
	{
		var series = Visualiser.SplitSeries(term);
		return Create(series, out count);
	}

	public static VisualiserProgressBar Create(VisualiserSplitSeries series)
	{
		return new VisualiserProgressBar(series, null);
	}

	public static VisualiserProgressBar Create(VisualiserSplitSeries series, out VisualiserTermWriter count)
	{
		var countTerm = new VisualiserTerm("Count", "");
		count = new VisualiserTermWriter(countTerm);
		return new VisualiserProgressBar(series, countTerm);
	}
}
