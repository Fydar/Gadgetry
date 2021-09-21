using System.Threading.Channels;
using System.Threading.Tasks;

namespace Gadgetry.Resources
{
	public class ResourceKey
	{
		public static AutoInitialisedResourceKey<Channel<TModel>> UnboundedChannel<TModel>()
		{
			return new AutoInitialisedResourceKey<Channel<TModel>>((gadgetRuntime, cancellationToken) =>
			{
				return ValueTask.FromResult(Channel.CreateUnbounded<TModel>());
			});
		}

		public static AutoInitialisedResourceKey<Channel<TModel>> UnboundedChannel<TModel>(UnboundedChannelOptions options)
		{
			return new AutoInitialisedResourceKey<Channel<TModel>>((gadgetRuntime, cancellationToken) =>
			{
				return ValueTask.FromResult(Channel.CreateUnbounded<TModel>(options));
			});
		}

		public static AutoInitialisedResourceKey<Channel<TModel>> BoundedChannel<TModel>(int capacity)
		{
			return new AutoInitialisedResourceKey<Channel<TModel>>((gadgetRuntime, cancellationToken) =>
			{
				return ValueTask.FromResult(Channel.CreateBounded<TModel>(capacity));
			});
		}

		public static AutoInitialisedResourceKey<Channel<TModel>> BoundedChannel<TModel>(BoundedChannelOptions options)
		{
			return new AutoInitialisedResourceKey<Channel<TModel>>((gadgetRuntime, cancellationToken) =>
			{
				return ValueTask.FromResult(Channel.CreateBounded<TModel>(options));
			});
		}

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
