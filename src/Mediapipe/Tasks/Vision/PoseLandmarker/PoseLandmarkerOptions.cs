using Mediapipe.Framework.Formats;

namespace Mediapipe.Tasks.Vision.PoseLandmarker;

/// <summary>
///   Options for the pose landmarker task.
/// </summary>
public sealed class PoseLandmarkerOptions(
    Tasks.Core.CoreBaseOptions baseOptions,
    Core.VisionRunningMode runningMode = Core.VisionRunningMode.IMAGE,
    int numPoses = 1,
    float minPoseDetectionConfidence = 0.5f,
    float minPosePresenceConfidence = 0.5f,
    float minTrackingConfidence = 0.5f,
    bool outputSegmentationMasks = false,
PoseLandmarkerOptions.ResultCallbackFunc? resultCallback = null) : Tasks.Core.ITaskOptions
{
    /// <param name="poseLandmarksResult">
    ///   The pose landmarker detection results.
    /// </param>
    /// <param name="image">
    ///   The input image that the pose landmarker runs on.
    /// </param>
    /// <param name="timestampMillisec">
    ///   The input timestamp in milliseconds.
    /// </param>
    public delegate void ResultCallbackFunc(PoseLandmarkerResult poseLandmarksResult, Image image, long timestampMillisec);

    /// <summary>
    ///   Base options for the pose landmarker task.
    /// </summary>
    public Tasks.Core.CoreBaseOptions BaseOptions { get; } = baseOptions;
    /// <summary>
    ///   The running mode of the task. Default to the image mode.
    ///   PoseLandmarker has three running modes:
    ///   <list type="number">
    ///     <item>
    ///       <description>The image mode for detecting pose landmarks on single image inputs.</description>
    ///     </item>
    ///     <item>
    ///       <description>The video mode for detecting pose landmarks on the decoded frames of a video.</description>
    ///     </item>
    ///     <item>
    ///       <description>
    ///         The live stream mode or detecting pose landmarks on the live stream of input data, such as from camera.
    ///         In this mode, the <see cref="ResultCallback" /> below must be specified to receive the detection results asynchronously.
    ///       </description>
    ///     </item>
    ///   </list>
    /// </summary>
    public Core.VisionRunningMode RunningMode { get; } = runningMode;
    /// <summary>
    ///   The maximum number of poses can be detected by the pose landmarker.
    /// </summary>
    public int NumPoses { get; } = numPoses;
    /// <summary>
    ///   The minimum confidence score for the pose detection to be considered successful.
    /// </summary>
    public float MinPoseDetectionConfidence { get; } = minPoseDetectionConfidence;
    /// <summary>
    ///   The minimum confidence score of pose presence score in the pose landmark detection.
    /// </summary>
    public float MinPosePresenceConfidence { get; } = minPosePresenceConfidence;
    /// <summary>
    ///   The minimum confidence score for the pose tracking to be considered successful.
    /// </summary>
    public float MinTrackingConfidence { get; } = minTrackingConfidence;
    /// <summary>
    ///   whether to output segmentation masks.
    /// </summary>
    public bool OutputSegmentationMasks { get; } = outputSegmentationMasks;
    /// <summary>
    ///   The user-defined result callback for processing live stream data.
    ///   The result callback should only be specified when the running mode is set to the live stream mode.
    /// </summary>
    public ResultCallbackFunc? ResultCallback { get; } = resultCallback;

    internal Proto.PoseLandmarkerGraphOptions ToProto()
    {
        var baseOptionsProto = BaseOptions.ToProto();
        baseOptionsProto.UseStreamMode = RunningMode != Core.VisionRunningMode.IMAGE;

        return new Proto.PoseLandmarkerGraphOptions
        {
            BaseOptions = baseOptionsProto,
            PoseDetectorGraphOptions = new PoseDetector.Proto.PoseDetectorGraphOptions
            {
                NumPoses = NumPoses,
                MinDetectionConfidence = MinPoseDetectionConfidence,
            },
            PoseLandmarksDetectorGraphOptions = new Proto.PoseLandmarksDetectorGraphOptions
            {
                MinDetectionConfidence = MinPosePresenceConfidence,
            },
            MinTrackingConfidence = MinTrackingConfidence,
        };
    }

    CalculatorOptions Tasks.Core.ITaskOptions.ToCalculatorOptions()
    {
        var options = new CalculatorOptions();
        options.SetExtension(Proto.PoseLandmarkerGraphOptions.Extensions.Ext, ToProto());
        return options;
    }
}
