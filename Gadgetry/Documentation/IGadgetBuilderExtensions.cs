using System;

namespace Gadgetry.Documentation;

public static class IGadgetBuilderExtensions
{
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
