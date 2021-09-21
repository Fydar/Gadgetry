using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry
{
	public interface IGadgetRunFeature : IGadgetFeature
	{
		Task RunAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken = default);
	}
}
