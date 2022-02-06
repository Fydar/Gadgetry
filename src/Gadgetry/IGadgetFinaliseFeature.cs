using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry;

/// <summary>
/// A feature that controls the <b>"finalisation"</b> behaviour of a <see cref="GadgetRuntime"/>.
/// </summary>
public interface IGadgetFinaliseFeature : IGadgetFeature
{
	/// <summary>
	/// Invoked during the <b>"finalisation"</b> of a <see cref="GadgetRuntime"/>.
	/// </summary>
	/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> that is being executed.</param>
	/// <param name="cancellationToken">A token used to propogate notifications that an operation should be cancelled.</param>
	/// <returns>A task which will extend the <b>"finalisation"</b> behaviour of a <see cref="GadgetRuntime"/> until it completes.</returns>
	Task FinaliseAsync(
		GadgetRuntime gadgetRuntime,
		CancellationToken cancellationToken = default);
}
