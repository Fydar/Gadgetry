using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gadgetry;

/// <summary>
/// Represents a single invocation of a <see cref="Gadget"/>.
/// </summary>
/// <remarks>
/// Instances of <see cref="GadgetRuntime"/> are constructed via the <see cref="Gadget.CreateRunner"/> method.
/// </remarks>
public class GadgetRuntime
{
	/// <summary>
	/// A collection of all <see cref="IGadgetRuntimeFeature"/> features associated with this <see cref="GadgetRuntime"/>.
	/// </summary>
	public IFeatureCollection<IGadgetRuntimeFeature> Features { get; } = new FeatureCollection<IGadgetRuntimeFeature>();

	/// <summary>
	/// The template used to create this <see cref="GadgetRuntime"/>.
	/// </summary>
	public Gadget Template { get; }

	/// <summary>
	/// A state used to share resources between other runtimes.
	/// </summary>
	public GadgetRuntimeState State { get; }

	/// <summary>
	/// The time that this <see cref="GadgetRuntime"/>. <c>null</c> if it hasn't been executed yet.
	/// </summary>
	public DateTimeOffset? StartTime { get; private set; }

	/// <summary>
	/// The time that this step completed. <c>null</c> if it hasn't completed yet.
	/// </summary>
	public DateTimeOffset? EndTime { get; private set; }

	/// <summary>
	/// The duration that this gadget has been running. If this step hasn't started, returns <see cref="TimeSpan.Zero"/>.
	/// </summary>
	public TimeSpan Elapsed
	{
		get
		{
			if (StartTime == null)
			{
				return TimeSpan.Zero;
			}
			return (EndTime ?? DateTimeOffset.UtcNow) - StartTime.Value;
		}
	}

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
	/// <returns>A runtime used to represent the state of the execution.</returns>
	public GadgetRuntime ExtendWith(Gadget gadget)
	{
		return new GadgetRuntime(gadget, State);
	}

	/// <summary>
	/// Attempts to run this <see cref="GadgetRuntime"/> to completion.
	/// </summary>
	/// <param name="cancellationToken">A token used to propogate notifications that an operation should be cancelled.</param>
	/// <returns>A task representing the execution.</returns>
	/// <exception cref="InvalidOperationException">Thrown when attempting to run multiple times.</exception>
	public async Task RunAsync(CancellationToken cancellationToken = default)
	{
		if (StartTime != null)
		{
			throw new InvalidOperationException($"Cannot run an '{nameof(GadgetRuntime)}' that has already been ran.");
		}

		StartTime = DateTimeOffset.UtcNow;

		try
		{
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

		}
		finally
		{
			EndTime = DateTimeOffset.UtcNow;
		}
	}

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"'{Template.Identifier}'";
	}
}
