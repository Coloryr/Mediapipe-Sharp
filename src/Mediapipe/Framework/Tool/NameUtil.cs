namespace Mediapipe.Framework.Tool;

/// <summary>
///   translated version of mediapipe/framework/tool/name_util.cc
/// <summary/>
public static partial class Tool
{
    public static string GetUnusedNodeName(CalculatorGraphConfig config, string nodeNameBase)
    {
        var nodeNames = new HashSet<string>(config.Node.Select(node => node.Name).Where(name => name.Length > 0));

        var candidate = nodeNameBase;
        var iter = 1;

        while (nodeNames.Contains(candidate))
        {
            candidate = $"{nodeNameBase}_{++iter:D2}";
        }

        return candidate;
    }

    public static string GetUnusedSidePacketName(CalculatorGraphConfig config, string inputSidePacketNameBase)
    {
        var inputSidePackets = new HashSet<string>(
          config.Node.SelectMany(node => node.InputSidePacket)
            .Select(sidePacket =>
            {
                ParseTagIndexName(sidePacket, out var tag, out var index, out var name);
                return name;
            }));

        var candidate = inputSidePacketNameBase;
        var iter = 1;

        while (inputSidePackets.Contains(candidate))
        {
            candidate = $"{inputSidePacketNameBase}_{++iter:D2}";
        }

        return candidate;
    }

    public static string GetUnusedStreamName(CalculatorGraphConfig config, string streamNameBase)
    {
        var outputStreamNames = config.Node.SelectMany(node => node.OutputStream)
          .Select(outputStream =>
          {
              ParseTagIndexName(outputStream, out var tag, out var index, out var name);
              return name;
          });

        var candidate = streamNameBase;
        var iter = 1;

        while (config.InputStream.Contains(candidate))
        {
            candidate = $"{streamNameBase}_{++iter:D2}";
        }

        while (outputStreamNames.Contains(candidate))
        {
            candidate = $"{streamNameBase}_{++iter:D2}";
        }

        return candidate;
    }

    /// <exception cref="ArgumentOutOfRangeException">
    ///   Thrown when <paramref name="nodeId" /> is invalid
    /// </exception>
    public static string CanonicalNodeName(CalculatorGraphConfig graphConfig, int nodeId)
    {
        var nodeConfig = graphConfig.Node[nodeId];
        var nodeName = nodeConfig.Name.Length == 0 ? nodeConfig.Calculator : nodeConfig.Name;

        var nodesWithSameName = graphConfig.Node
          .Select((node, i) => (node.Name.Length == 0 ? node.Calculator : node.Name, i))
          .Where(pair => pair.Item1 == nodeName);

        if (nodesWithSameName.Count() <= 1)
        {
            return nodeName;
        }

        var seq = nodesWithSameName.Count(pair => pair.i <= nodeId);
        return $"{nodeName}_{seq}";
    }

    /// <exception cref="ArgumentException">
    ///   Thrown when the format of <paramref cref="stream" /> is invalid
    /// </exception>
    public static string ParseNameFromStream(string stream)
    {
        ParseTagIndexName(stream, out var _, out var _, out var name);
        return name;
    }

    /// <exception cref="ArgumentException">
    ///   Thrown when the format of <paramref cref="tagIndex" /> is invalid
    /// </exception>
    public static (string, int) ParseTagIndex(string tagIndex)
    {
        ParseTagIndex(tagIndex, out var tag, out var index);
        return (tag, index);
    }

    /// <exception cref="ArgumentException">
    ///   Thrown when the format of <paramref cref="stream" /> is invalid
    /// </exception>
    public static (string, int) ParseTagIndexFromStream(string stream)
    {
        ParseTagIndexName(stream, out var tag, out var index, out var _);
        return (tag, index);
    }

    public static string CatTag(string tag, int index)
    {
        var colonIndex = index <= 0 || tag.Length == 0 ? "" : $":{index}";
        return $"{tag}{colonIndex}";
    }

    public static string CatStream((string, int) tagIndex, string name)
    {
        var tag = CatTag(tagIndex.Item1, tagIndex.Item2);

        return tag.Length == 0 ? name : $"{tag}:{name}";
    }
}
