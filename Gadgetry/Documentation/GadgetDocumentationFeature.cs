namespace Gadgetry.Documentation
{
	public class GadgetDocumentationFeature : IGadgetFeature
	{
		public GadgetDocumentationOptions Options { get; }

		public GadgetDocumentationFeature()
		{
			Options = new GadgetDocumentationOptions();
		}
	}
}
