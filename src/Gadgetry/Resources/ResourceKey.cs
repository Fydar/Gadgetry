using System.Threading.Tasks;

namespace Gadgetry.Resources;

public class ResourceKey
{
	public static AutoInitialisedResourceKey<TModel> AutoInitialised<TModel>()
		where TModel : new()
	{
		return new AutoInitialisedResourceKey<TModel>((gadgetRuntime, cancellationToken) =>
		{
			return new ValueTask<TModel>(new TModel());
		});
	}

	public static AutoInitialisedResourceKey<TModel> AutoInitialised<TModel>(ResourceFactoryCallback<TModel> factory)
	{
		return new AutoInitialisedResourceKey<TModel>((gadgetRuntime, _) =>
		{
			return new ValueTask<TModel>(factory.Invoke(gadgetRuntime));
		});
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
