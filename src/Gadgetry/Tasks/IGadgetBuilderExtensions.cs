namespace Gadgetry.Tasks;

/// <summary>
/// Extension methods of <see cref="IGadgetBuilder"/> for adding <b>"task"</b> support.
/// </summary>
public static class IGadgetBuilderExtensions
{
	/// <summary>
	/// Configures the <see cref="IGadgetBuilder"/> with a task executed during the <see cref="GadgetRuntime"/> execution.
	/// </summary>
	/// <param name="gadgetBuilder">The <see cref="IGadgetBuilder"/> to configure.</param>
	/// <param name="task">The task executed during the <see cref="GadgetRuntime"/> execution.</param>
	/// <returns>The current instance of this <see cref="IGadgetBuilder"/>.</returns>
	public static IGadgetBuilder UseTask(
		this IGadgetBuilder gadgetBuilder,
		GadgetTaskCallbackAsync task)
	{
		gadgetBuilder.Configure(configure =>
		{
			var feature = configure.Features.GetOrCreateFeature<GadgetTasksFeature>();

			feature.tasks.Add(new GadgetTask(task));
		});
		return gadgetBuilder;
	}
}
