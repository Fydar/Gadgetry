using System;

namespace Gadgetry.Channels.Documentation;

public static class GadgetChannelBuilderExtensions
{
	public static GadgetChannel<TModel> UseDocumentation<TModel>(
		this GadgetChannel<TModel> modularTaskChannel,
		Action<GadgetChannelDocumentationOptions> options)
	{
		var feature = modularTaskChannel.Features.GetOrCreateFeature<GadgetChannelDocumentationFeature>();

		options.Invoke(feature.Options);

		return modularTaskChannel;
	}
}
