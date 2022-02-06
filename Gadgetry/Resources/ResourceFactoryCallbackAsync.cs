using System.Threading;

namespace Gadgetry.Resources
{
	public delegate ValueTask<TModel> ResourceFactoryCallbackAsync<TModel>(
		GadgetRuntime gadgetRuntime,
		CancellationToken cancellationToken = default);
}
