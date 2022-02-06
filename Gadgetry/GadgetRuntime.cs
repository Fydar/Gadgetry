using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry
{
	public class GadgetRuntime
	{
		public IFeatureCollection<IGadgetRuntimeFeature> Features { get; } = new FeatureCollection<IGadgetRuntimeFeature>();

		/// <summary>
		/// The template used to create this <see cref="GadgetRuntime"/>.
		/// </summary>
		public Gadget Template { get; }

		/// <summary>
		/// A state used to share resources between this <see cref="GadgetRuntime"/>, the <see cref="Parent"/> task, and the <see cref="SubTasks"/>.
		/// </summary>
		public GadgetRuntimeState State { get; }

		/// <summary>
		/// The time that this <see cref="GadgetRuntime"/>. <c>null</c> if it hasn't been executed yet.
		/// </summary>
		public DateTimeOffset? StartTime { get; set; }

		/// <summary>
		/// The time that this step completed. <c>null</c> if it hasn't completed yet.
		/// </summary>
		public DateTimeOffset? EndTime { get; set; }

		/// <summary>
		/// Determines whether this step has been completed.
		/// </summary>
		/// <seealso cref="EndTime"/>
		public bool IsCompleted => EndTime != null;

		internal GadgetRuntime(
			Gadget template,
			GadgetRuntimeState? sharedState = null)
		{
			Template = template;
			State = sharedState ?? new GadgetRuntimeState();

			var initFeatures = Template.Features.GetAllFeatures<IGadgetInitFeature>();
			foreach (var initFeature in initFeatures)
			{
				initFeature.Init(this);
			}
		}

		/// <summary>
		/// Executes an additional gadget using this gadgets runtime state.
		/// </summary>
		/// <param name="gadget">The gadget to execute.</param>
		/// <returns></returns>
		public GadgetRuntime ExtendWith(Gadget gadget)
		{
			return new GadgetRuntime(gadget, State);
		}

		public async Task RunAsync(CancellationToken cancellationToken = default)
		{
			if (StartTime != null)
			{
				throw new InvalidOperationException($"Cannot run an '{nameof(GadgetRuntime)}' that has already been ran.");
			}

			StartTime = DateTimeOffset.UtcNow;

			var runFeatures = Template.Features.GetAllFeatures<IGadgetRunFeature>();

			var runFeatureTasks = new List<Task>();
			foreach (var runFeature in runFeatures)
			{
				runFeatureTasks.Add(runFeature.RunAsync(this, cancellationToken));
			}
			await Task.WhenAll(runFeatureTasks);

			var finaliseFeatures = Template.Features.GetAllFeatures<IGadgetFinaliseFeature>();

			var finaliseFeatureTasks = new List<Task>();
			foreach (var finaliseFeature in finaliseFeatures)
			{
				finaliseFeatureTasks.Add(finaliseFeature.FinaliseAsync(this, cancellationToken));
			}
			await Task.WhenAll(finaliseFeatureTasks);

			EndTime = DateTimeOffset.UtcNow;
		}

		public override string ToString()
		{
			return $"'{Template.Identifier}'";
		}
	}
}
