namespace Gadgetry.Resources;

public class AutoInitialisedResourceKey<TModel> : IResourceKey<TModel>
{
	internal readonly ResourceFactoryCallbackAsync<TModel> factory;

	internal AutoInitialisedResourceKey(ResourceFactoryCallbackAsync<TModel> factory)
	{
		this.factory = factory;
	}
}
