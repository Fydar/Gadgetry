using Gadgetry.Channels;
using System;

namespace Gadgetry.Documentation;

/// <summary>
/// Extension methods of <see cref="IGadgetBuilder"/> for adding <b>"task"</b> support.
/// </summary>
public static class GadgetChannelBuilderExtensions
{
	/// <summary>
	/// Configures the <see cref="GadgetChannel{TModel}"/> to include documentation.
	/// </summary>
	/// <param name="gadgetChannel">The <see cref="GadgetChannel{TModel}"/> to configure.</param>
	/// <param name="options">Options used to configure the documentation associated with the <see cref="IGadgetChannel"/>.</param>
	/// <returns>The current instance of this <see cref="GadgetChannel{TModel}"/>.</returns>
	public static GadgetChannel<TModel> UseDocumentation<TModel>(
		this GadgetChannel<TModel> gadgetChannel,
		Action<GadgetChannelDocumentationOptions> options)
	{
		var feature = gadgetChannel.Features.GetOrCreateFeature<GadgetChannelDocumentationFeature>();

		options.Invoke(feature.Options);

		return gadgetChannel;
	}
}
