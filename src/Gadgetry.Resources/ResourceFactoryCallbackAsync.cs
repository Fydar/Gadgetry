using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Resources;

public delegate Task<TModel> ResourceFactoryCallbackAsync<TModel>(
	GadgetRuntime gadgetRuntime,
	CancellationToken cancellationToken = default);
