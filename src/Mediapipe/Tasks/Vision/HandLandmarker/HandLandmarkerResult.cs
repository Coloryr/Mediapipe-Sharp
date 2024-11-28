using Mediapipe.Tasks.Components.Containers;

namespace Mediapipe.Tasks.Vision.HandLandmarker;

/// <summary>
///   The hand landmarks result from HandLandmarker, where each vector element represents a single hand detected in the image.
/// </summary>
public readonly struct HandLandmarkerResult
{
    /// <summary>
    ///   Classification of handedness.
    /// </summary>
    public readonly List<Classifications> Handedness;
    /// <summary>
    ///   Detected hand landmarks in normalized image coordinates.
    /// </summary>
    public readonly List<NormalizedLandmarks> HandLandmarks;
    /// <summary>
    ///   Detected hand landmarks in world coordinates.
    /// </summary>
    public readonly List<Landmarks> HandWorldLandmarks;

    internal HandLandmarkerResult(List<Classifications> handedness,
        List<NormalizedLandmarks> handLandmarks, List<Landmarks> handWorldLandmarks)
    {
        Handedness = handedness;
        HandLandmarks = handLandmarks;
        HandWorldLandmarks = handWorldLandmarks;
    }

    public static HandLandmarkerResult Alloc(int capacity)
    {
        var handedness = new List<Classifications>(capacity);
        var handLandmarks = new List<NormalizedLandmarks>(capacity);
        var handWorldLandmarks = new List<Landmarks>(capacity);
        return new HandLandmarkerResult(handedness, handLandmarks, handWorldLandmarks);
    }

    public void CloneTo(ref HandLandmarkerResult destination)
    {
        if (HandLandmarks == null)
        {
            destination = default;
            return;
        }

        var dstHandedness = destination.Handedness ?? new List<Classifications>(Handedness.Count);
        dstHandedness.Clear();
        dstHandedness.AddRange(Handedness);

        var dstHandLandmarks = destination.HandLandmarks ?? new List<NormalizedLandmarks>(HandLandmarks.Count);
        dstHandLandmarks.Clear();
        dstHandLandmarks.AddRange(HandLandmarks);

        var dstHandWorldLandmarks = destination.HandWorldLandmarks ?? new List<Landmarks>(HandWorldLandmarks.Count);
        dstHandWorldLandmarks.Clear();
        dstHandWorldLandmarks.AddRange(HandWorldLandmarks);

        destination = new HandLandmarkerResult(dstHandedness, dstHandLandmarks, dstHandWorldLandmarks);
    }

    public override string ToString()
      => $"{{ \"handedness\": {Util.Format(Handedness)}, \"handLandmarks\": {Util.Format(HandLandmarks)}, \"handWorldLandmarks\": {Util.Format(HandWorldLandmarks)} }}";
}
