namespace Gadgetry.Visualisation;

public class VisualiserSplitSeries : IVisualiserData
{
	public IVisualiserData[] Elements { get; set; }

	internal VisualiserSplitSeries(params IVisualiserData[] elements)
	{
		Elements = elements;
	}
}
