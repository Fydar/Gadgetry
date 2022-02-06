namespace Gadgetry.Visualisation
{
	public static class Visualiser
	{
		public static VisualiserSplitSeries SplitSeries(params IVisualiserData[] elements)
		{
			return new VisualiserSplitSeries(elements);
		}

		public static VisualiserTerm Term(string name, string colour, out VisualiserTermWriter visualiserTermWriter)
		{
			var term = new VisualiserTerm(name, colour);

			visualiserTermWriter = new VisualiserTermWriter(term);

			return term;
		}
	}
}
