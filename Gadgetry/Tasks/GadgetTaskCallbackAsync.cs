using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Tasks
{
	public delegate ValueTask GadgetTaskCallbackAsync(
		GadgetRuntime gadgetRuntime,
		CancellationToken cancellationToken = default);
}
