namespace Gadgetry.Documentation;

/// <summary>
/// Options used to associate documentation with a <see cref="Gadget"/>.
/// </summary>
public class GadgetDocumentationOptions
{
	/// <summary>
	/// A user friendly display name for the <see cref="Gadget"/> for use in the user interface.
	/// </summary>
	public string DisplayName { get; set; } = string.Empty;

	/// <summary>
	/// A description of the behaviour associated with the <see cref="Gadget"/>.
	/// </summary>
	public string Description { get; set; } = string.Empty;

	/// <summary>
	/// A string identifier for an icon to use for the <see cref="Gadget"/>.
	/// </summary>
	public string Icon { get; set; } = string.Empty;

	/// <summary>
	/// Creates a new instance of the <see cref="GadgetDocumentationOptions"/> class.
	/// </summary>
	internal GadgetDocumentationOptions()
	{
	}
}
