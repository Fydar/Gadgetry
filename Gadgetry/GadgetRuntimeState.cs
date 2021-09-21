namespace Gadgetry
{
	public class GadgetRuntimeState
	{
		public IFeatureCollection<IGadgetRuntimeStateFeature> Features { get; } = new FeatureCollection<IGadgetRuntimeStateFeature>();
	}
}
