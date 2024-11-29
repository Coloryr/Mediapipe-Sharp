namespace Mediapipe.Tasks.Core;

public sealed class CoreBaseOptions(CoreBaseOptions.Delegate delegateCase = CoreBaseOptions.Delegate.CPU, string? modelAssetPath = null, byte[]? modelAssetBuffer = null)
{
    public enum Delegate
    {
        CPU,
        GPU,
    }

    public Delegate DelegateCase { get; } = delegateCase;
    public string? ModelAssetPath { get; } = modelAssetPath;
    public byte[]? ModelAssetBuffer { get; } = modelAssetBuffer;

    private Proto.Acceleration? Acceleration
    {
        get
        {
            return DelegateCase switch
            {
                Delegate.CPU => new Proto.Acceleration
                {
                    Tflite = new InferenceCalculatorOptions.Types.Delegate.Types.TfLite { },
                },
                Delegate.GPU => new Proto.Acceleration
                {
                    Gpu = new InferenceCalculatorOptions.Types.Delegate.Types.Gpu { },
                },
                _ => null,
            };
        }
    }

    private Proto.ExternalFile ModelAsset
    {
        get
        {
            var file = new Proto.ExternalFile { };

            if (ModelAssetPath != null)
            {
                file.FileName = ModelAssetPath;
            }
            if (ModelAssetBuffer != null)
            {
                file.FileContent = Google.Protobuf.ByteString.CopyFrom(ModelAssetBuffer);
            }

            return file;
        }
    }

    internal Proto.BaseOptions ToProto()
    {
        return new Proto.BaseOptions
        {
            ModelAsset = ModelAsset,
            Acceleration = Acceleration,
        };
    }
}
