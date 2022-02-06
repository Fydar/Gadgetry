namespace Gadgetry.Visualisation
{
	public class VisualiserRate : IVisualiser
	{
		public VisualiserTerm Term { get; set; }

		private VisualiserRate(VisualiserTerm term)
		{
			Term = term;
		}

		public static VisualiserRate Create(VisualiserTerm term)
		{
			return new VisualiserRate(term);
		}
	}
}
