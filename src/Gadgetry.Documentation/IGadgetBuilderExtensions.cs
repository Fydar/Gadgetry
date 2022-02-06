using System;

namespace Gadgetry.Documentation;

/// <summary>
/// Extension methods of <see cref="IGadgetBuilder"/> for adding <b>"documentation"</b> support.
/// </summary>
public static class IGadgetBuilderExtensions
{
	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> to include documentation.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="options">Options used to configure the documentation associated with the <see cref="Gadget"/>.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
	public static IGadgetBuilder UseDocumentation(
		this IGadgetBuilder gadgetBuilder,
		Action<GadgetDocumentationOptions> options)
	{
		gadgetBuilder.Configure(configure =>
		{
			var feature = configure.Features.GetOrCreateFeature<GadgetDocumentationFeature>();

			options.Invoke(feature.Options);
		});

		return gadgetBuilder;
	}
}
