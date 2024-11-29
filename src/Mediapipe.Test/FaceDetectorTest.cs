using Mediapipe.Framework.Formats;
using Mediapipe.Tasks.Components.Containers;
using Mediapipe.Tasks.Core;
using Mediapipe.Tasks.Vision.FaceDetector;
using StbImageSharp;

namespace Mediapipe.Test;

public class FaceDetectorTest
{
    private const string ModelsPath = "Models/blaze_face_short_range.bytes";

    private FaceDetector faceDetector;

    public void Init()
    {
        var options = new FaceDetectorOptions(new CoreBaseOptions(CoreBaseOptions.Delegate.CPU, modelAssetPath: ModelsPath));

        faceDetector = FaceDetector.CreateFromOptions(options);
    }

    public void InitVideo()
    {
        var options = new FaceDetectorOptions(new CoreBaseOptions(CoreBaseOptions.Delegate.CPU, modelAssetPath: ModelsPath), runningMode: Tasks.Vision.Core.VisionRunningMode.VIDEO);

        faceDetector = FaceDetector.CreateFromOptions(options);
    }

    public List<DetectionResultItem>? PutImage(string file)
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

        return found.Detections;
    }
}