using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Resources;

public interface IResource
{
	public IResourceKey Key { get; }
}

public interface IResource<TModel> : IResource
{
	Task<TModel> ReadAsync(CancellationToken cancellationToken = default);
}
