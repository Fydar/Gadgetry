using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry.Tasks;

/// <summary>
/// Signature used to add a <see cref="Task"/> to a <see cref="GadgetRuntime"/> execution.
/// </summary>
/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> that is being executed.</param>
/// <param name="cancellationToken">A token used to propogate notifications that an operation should be cancelled.</param>
/// <returns></returns>
public delegate Task GadgetTaskCallbackAsync(
	GadgetRuntime gadgetRuntime,
	CancellationToken cancellationToken = default);
