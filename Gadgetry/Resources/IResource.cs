using System.Threading;

namespace Gadgetry.Resources
{
	public interface IResource
	{
		public IResourceKey Key { get; }
	}

	public interface IResource<TModel> : IResource
	{
		ValueTask<TModel> ReadAsync(CancellationToken cancellationToken = default);
	}
}
