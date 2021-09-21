namespace Gadgetry.Tasks
{
	public static class IGadgetBuilderExtensions
	{
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
}
