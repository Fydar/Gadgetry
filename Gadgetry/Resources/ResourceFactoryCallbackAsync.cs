using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Resources
{
	public delegate ValueTask<TModel> ResourceFactoryCallbackAsync<TModel>(
		GadgetRuntime gadgetRuntime,
		CancellationToken cancellationToken = default);
}
