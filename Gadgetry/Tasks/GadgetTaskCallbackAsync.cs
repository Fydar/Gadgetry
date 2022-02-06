using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Tasks
{
	public delegate Task GadgetTaskCallbackAsync(
		GadgetRuntime gadgetRuntime,
		CancellationToken cancellationToken = default);
}
