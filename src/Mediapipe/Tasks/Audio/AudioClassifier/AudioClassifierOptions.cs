using AudioClassifierResult = Mediapipe.Tasks.Components.Containers.ClassificationResult;

namespace Mediapipe.Tasks.Audio.AudioClassifier;

/// <summary>
///   Options for the audio classifier task.
/// </summary>
public sealed class AudioClassifierOptions(
  Tasks.Core.BaseOptions baseOptions,
  Core.RunningMode runningMode = Core.RunningMode.AUDIO_CLIPS,
  string? displayNamesLocale = null,
  int? maxResults = null,
  float? scoreThreshold = null,
  List<string>? categoryAllowList = null,
  List<string>? categoryDenyList = null,
AudioClassifierOptions.ResultCallbackFunc? resultCallback = null) : Tasks.Core.ITaskOptions
{
    /// <remarks>
    ///   Some field of <paramref name="classificationResult"/> can be reused to reduce GC.Alloc.
    ///   If you need to refer to the data later, copy the data.
    /// </remarks>
    /// <param name="classificationResult">
    ///   An `<see cref="AudioClassifierResult"/> object that contains a list of classifications.
    /// </param>
    /// <param name="timestampMillisec">
    ///   The input timestamp in milliseconds.
    /// </param>
    public delegate void ResultCallbackFunc(AudioClassifierResult classificationResult, long timestampMillisec);

    /// <summary>
    ///   Base options for the audio classifier task.
    /// </summary>
    public Tasks.Core.BaseOptions BaseOptions { get; init; } = baseOptions;
    /// <summary>
    ///   The running mode of the task. Default to the audio clips mode.
    ///   Audio classifier task has two running modes:
    ///   <list type="number">
    ///     <item>
    ///       <description>The audio clips mode for running classification on independent audio clips.</description>
    ///     </item>
    ///     <item>
    ///       <description>
    ///         The audio stream mode for running classification on the audio stream, such as from microphone.
    ///         In this mode,  the <see cref="ResultCallback"/> below must be specified to receive the classification results asynchronously.
    ///        </description>
    ///     </item>
    ///   </list>
    /// </summary>
    public Core.RunningMode RunningMode { get; } = runningMode;
    /// <summary>
    ///   The locale to use for display names specified through the TFLite Model Metadata.
    /// </summary>
    public string? DisplayNamesLocale { get; } = displayNamesLocale;
    /// <summary>
    ///   The maximum number of top-scored classification results to return.
    /// </summary>
    public int? MaxResults { get; } = maxResults;
    /// <summary>
    ///   Overrides the ones provided in the model metadata. Results below this value are rejected.
    /// </summary>
    public float? ScoreThreshold { get; } = scoreThreshold;
    /// <summary>
    ///   Allowlist of category names.
    ///   If non-empty, classification results whose category name is not in this set will be filtered out.
    ///   Duplicate or unknown category names are ignored. Mutually exclusive with <see cref="categoryDenylist"/>.
    /// </summary>
    public List<string>? CategoryAllowList { get; } = categoryAllowList;
    /// <summary>
    ///   Denylist of category names.
    ///   If non-empty, classification results whose category name is in this set will be filtered out.
    ///   Duplicate or unknown category names are ignored. Mutually exclusive with <see cref="CategoryAllowList"/>.
    /// </summary>
    public List<string>? CategoryDenyList { get; } = categoryDenyList;
    /// <summary>
    ///   The user-defined result callback for processing audio stream data.
    ///   The result callback should only be specified when the running mode is set to the audio stream mode.
    /// </summary>
    public ResultCallbackFunc? ResultCallback { get; } = resultCallback;

    internal Proto.AudioClassifierGraphOptions ToProto()
    {
        var baseOptionsProto = BaseOptions.ToProto();
        baseOptionsProto.UseStreamMode = RunningMode != Core.RunningMode.AUDIO_CLIPS;

        var classifierOptions = new Components.Processors.Proto.ClassifierOptions();
        if (DisplayNamesLocale != null)
        {
            classifierOptions.DisplayNamesLocale = DisplayNamesLocale;
        }
        if (MaxResults is int maxResultsValue)
        {
            classifierOptions.MaxResults = maxResultsValue;
        }
        if (ScoreThreshold is float scoreThresholdValue)
        {
            classifierOptions.ScoreThreshold = scoreThresholdValue;
        }
        if (CategoryAllowList != null)
        {
            classifierOptions.CategoryAllowlist.AddRange(CategoryAllowList);
        }
        if (CategoryDenyList != null)
        {
            classifierOptions.CategoryDenylist.AddRange(CategoryDenyList);
        }

        return new Proto.AudioClassifierGraphOptions
        {
            BaseOptions = baseOptionsProto,
            ClassifierOptions = classifierOptions,
        };
    }

    CalculatorOptions Tasks.Core.ITaskOptions.ToCalculatorOptions()
    {
        var options = new CalculatorOptions();
        options.SetExtension(Proto.AudioClassifierGraphOptions.Extensions.Ext, ToProto());
        return options;
    }
}
