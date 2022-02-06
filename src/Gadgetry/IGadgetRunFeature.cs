using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry;

/// <summary>
/// A feature that controls the <b>"running"</b> behaviour of a <see cref="GadgetRuntime"/>.
/// </summary>
public interface IGadgetRunFeature : IGadgetFeature
{
	/// <summary>
	/// Invoked during the <b>"running"</b> of a <see cref="GadgetRuntime"/>.
	/// </summary>
	/// <param name="gadgetRuntime">The <see cref="GadgetRuntime"/> that is being executed.</param>
	/// <param name="cancellationToken">A token used to propogate notifications that an operation should be cancelled.</param>
	/// <returns>A task which will extend the <b>"running"</b> behaviour of a <see cref="GadgetRuntime"/> until it completes.</returns>
	Task RunAsync(
		GadgetRuntime gadgetRuntime,
		CancellationToken cancellationToken = default);
}
