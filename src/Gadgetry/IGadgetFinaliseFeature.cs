using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry;

public interface IGadgetFinaliseFeature : IGadgetFeature
{
	Task FinaliseAsync(GadgetRuntime gadgetRuntime, CancellationToken cancellationToken = default);
}
