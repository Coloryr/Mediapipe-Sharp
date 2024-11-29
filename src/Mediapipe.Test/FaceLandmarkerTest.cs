using Mediapipe.Framework.Formats;
using Mediapipe.Tasks.Components.Containers;
using Mediapipe.Tasks.Core;
using Mediapipe.Tasks.Vision.Core;
using Mediapipe.Tasks.Vision.FaceLandmarker;
using StbImageSharp;

namespace Mediapipe.Test;

public class FaceLandmarkerTest
{
    private const string ModelsPath = "Models/face_landmarker_v2.bytes";
    private const string BlendModelsPath = "Models/face_landmarker_v2_with_blendshapes.bytes";

    private FaceLandmarker faceDetector;

    public void Init()
    {
        var options = new FaceLandmarkerOptions(new CoreBaseOptions(CoreBaseOptions.Delegate.CPU, modelAssetPath: ModelsPath),
            outputFaceTransformationMatrixes: true);

        faceDetector = FaceLandmarker.CreateFromOptions(options);
    }

    public void InitBlend()
    {
        var options = new FaceLandmarkerOptions(new CoreBaseOptions(CoreBaseOptions.Delegate.CPU, modelAssetPath: BlendModelsPath), outputFaceBlendshapes: true,
            outputFaceTransformationMatrixes: true);

        faceDetector = FaceLandmarker.CreateFromOptions(options);
    }


    public void InitVideo()
    {
        var options = new FaceLandmarkerOptions(new CoreBaseOptions(CoreBaseOptions.Delegate.CPU, modelAssetPath: ModelsPath),
            runningMode: VisionRunningMode.VIDEO,
            outputFaceTransformationMatrixes: true);

        faceDetector = FaceLandmarker.CreateFromOptions(options);
    }

    public List<NormalizedLandmarks>? PutImage(string file)
    {
        var temp = File.ReadAllBytes(file);
        var data = ImageResult.FromMemory(temp);
        var format = ImageFormat.Types.Format.Sbgra;
        int width = data.Width * 4;
        if (data.SourceComp == ColorComponents.RedGreenBlue)
        {
            format = ImageFormat.Types.Format.Srgb;
            width = data.Width * 3;
        }
        using var image = new Image(format, data.Width, data.Height, width, data.Data);
        var result = DetectionResult.Alloc(0);
        var found = faceDetector.Detect(image, null);

        return found.FaceLandmarks;
    }
}
