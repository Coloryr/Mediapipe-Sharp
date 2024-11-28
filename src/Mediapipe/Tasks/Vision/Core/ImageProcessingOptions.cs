namespace Mediapipe.Tasks.Vision.Core;

/// <summary>
///   Options for image processing.
///
///   If both region-or-interest and rotation are specified, the crop around the
///   region-of-interest is extracted first, then the specified rotation is applied
///   to the crop.
/// </summary>
public readonly struct ImageProcessingOptions(Components.Containers.RectF? regionOfInterest = null, int rotationDegrees = 0)
{
    public readonly Components.Containers.RectF? RegionOfInterest = regionOfInterest;
    public readonly int RotationDegrees = rotationDegrees;
}
