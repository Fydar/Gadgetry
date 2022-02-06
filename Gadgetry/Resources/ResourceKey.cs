namespace Gadgetry.Resources
{
	public class ResourceKey
	{
		public static AutoInitialisedResourceKey<TModel> AutoInitialised<TModel>()
			where TModel : new()
		{
			return new AutoInitialisedResourceKey<TModel>((gadgetRuntime, cancellationToken) => ValueTask.FromResult(new TModel()));
		}

		public static AutoInitialisedResourceKey<TModel> AutoInitialised<TModel>(ResourceFactoryCallback<TModel> factory)
		{
			return new AutoInitialisedResourceKey<TModel>((gadgetRuntime, _) => ValueTask.FromResult(factory.Invoke(gadgetRuntime)));
		}

		public static AutoInitialisedResourceKey<TModel> AutoInitialised<TModel>(ResourceFactoryCallbackAsync<TModel> factory)
		{
			return new AutoInitialisedResourceKey<TModel>(factory);
		}

		public static ReadBlockingResourceKey<TModel> ReadBlocking<TModel>()
		{
			return new ReadBlockingResourceKey<TModel>();
		}
	}
}
