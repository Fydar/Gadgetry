namespace Gadgetry.Documentation;

/// <summary>
/// A feature used to interact with the <b>documentation</b> associated with a <see cref="Gadget"/>.
/// </summary>
public class GadgetDocumentationFeature : IGadgetFeature
{
	/// <summary>
	/// Options used to configure the documentation associated with the <see cref="Gadget"/>.
	/// </summary>
	public GadgetDocumentationOptions Options { get; }

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetDocumentationFeature"/> class.
	/// </summary>
	public GadgetDocumentationFeature()
	{
		Options = new GadgetDocumentationOptions();
	}
}
