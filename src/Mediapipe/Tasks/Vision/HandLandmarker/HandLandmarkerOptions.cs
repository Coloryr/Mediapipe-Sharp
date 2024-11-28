using Mediapipe.Framework.Formats;

namespace Mediapipe.Tasks.Vision.HandLandmarker;

/// <summary>
///   Options for the hand landmarker task.
/// </summary>
public sealed class HandLandmarkerOptions(
  Tasks.Core.BaseOptions baseOptions,
  Core.RunningMode runningMode = Core.RunningMode.IMAGE,
  int numHands = 1,
  float minHandDetectionConfidence = 0.5f,
  float minHandPresenceConfidence = 0.5f,
  float minTrackingConfidence = 0.5f,
HandLandmarkerOptions.ResultCallbackFunc? resultCallback = null) : Tasks.Core.ITaskOptions
{
    /// <param name="handLandmarksResult">
    ///   The hand landmarks detection results.
    /// </param>
    /// <param name="image">
    ///   The input image that the hand landmarker runs on.
    /// </param>
    /// <param name="timestampMillisec">
    ///   The input timestamp in milliseconds.
    /// </param>
    public delegate void ResultCallbackFunc(HandLandmarkerResult handLandmarksResult, Image image, long timestampMillisec);

    /// <summary>
    ///   Base options for the hand landmarker task.
    /// </summary>
    public Tasks.Core.BaseOptions BaseOptions { get; } = baseOptions;
    /// <summary>
    ///   The running mode of the task. Default to the image mode.
    ///   HandLandmarker has three running modes:
    ///   <list type="number">
    ///     <item>
    ///       <description>The image mode for detecting hand landmarks on single image inputs.</description>
    ///     </item>
    ///     <item>
    ///       <description>The video mode for detecting hand landmarks on the decoded frames of a video.</description>
    ///     </item>
    ///     <item>
    ///       <description>
    ///         The live stream mode or detecting hand landmarks on the live stream of input data, such as from camera.
    ///         In this mode, the <see cref="ResultCallback" /> below must be specified to receive the detection results asynchronously.
    ///       </description>
    ///     </item>
    ///   </list>
    /// </summary>
    public Core.RunningMode RunningMode { get; } = runningMode;
    /// <summary>
    ///   The maximum number of hands can be detected by the hand landmarker.
    /// </summary>
    public int NumHands { get; } = numHands;
    /// <summary>
    ///   The minimum confidence score for the hand detection to be considered successful.
    /// </summary>
    public float MinHandDetectionConfidence { get; } = minHandDetectionConfidence;
    /// <summary>
    ///   The minimum confidence score of hand presence score in the hand landmark detection.
    /// </summary>
    public float MinHandPresenceConfidence { get; } = minHandPresenceConfidence;
    /// <summary>
    ///   The minimum confidence score for the hand tracking to be considered successful.
    /// </summary>
    public float MinTrackingConfidence { get; } = minTrackingConfidence;
    /// <summary>
    ///   The user-defined result callback for processing live stream data.
    ///   The result callback should only be specified when the running mode is set to the live stream mode.
    /// </summary>
    public ResultCallbackFunc? ResultCallback { get; } = resultCallback;

    internal Proto.HandLandmarkerGraphOptions ToProto()
    {
        var baseOptionsProto = BaseOptions.ToProto();
        baseOptionsProto.UseStreamMode = RunningMode != Core.RunningMode.IMAGE;

        return new Proto.HandLandmarkerGraphOptions
        {
            BaseOptions = baseOptionsProto,
            HandDetectorGraphOptions = new HandDetector.Proto.HandDetectorGraphOptions
            {
                NumHands = NumHands,
                MinDetectionConfidence = MinHandDetectionConfidence,
            },
            HandLandmarksDetectorGraphOptions = new Proto.HandLandmarksDetectorGraphOptions
            {
                MinDetectionConfidence = MinHandPresenceConfidence,
            },
            MinTrackingConfidence = MinTrackingConfidence,
        };
    }

    CalculatorOptions Tasks.Core.ITaskOptions.ToCalculatorOptions()
    {
        var options = new CalculatorOptions();
        options.SetExtension(Proto.HandLandmarkerGraphOptions.Extensions.Ext, ToProto());
        return options;
    }
}
