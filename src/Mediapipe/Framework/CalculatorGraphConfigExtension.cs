using Google.Protobuf;
using Mediapipe.Core;
using Mediapipe.PInvoke;

namespace Mediapipe.Framework;

public static class CalculatorGraphConfigExtension
{
    public static CalculatorGraphConfig ParseFromTextFormat(this MessageParser<CalculatorGraphConfig> _, string configText)
    {
        if (UnsafeNativeMethods.mp_api__ConvertFromCalculatorGraphConfigTextFormat(configText, out var serializedProto))
        {
            var config = serializedProto.Deserialize(CalculatorGraphConfig.Parser);
            serializedProto.Dispose();
            return config;
        }
        throw new MediaPipeException("Failed to parse config text. See error logs for more details");
    }
}
