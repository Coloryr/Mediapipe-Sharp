using System.Runtime.InteropServices;
using Google.Protobuf;
using Mediapipe.Core;
using Mediapipe.Framework.Packet;
using Mediapipe.PInvoke;

namespace Mediapipe.Framework;

public enum NodeType : int
{
    Unknown = 0,
    Calculator = 1,
    PacketGenerator = 2,
    GraphInputStream = 3,
    StatusHandler = 4,
};

[StructLayout(LayoutKind.Sequential)]
public readonly struct NodeRef
{
    public readonly NodeType type;
    public readonly int index;
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct EdgeInfo
{
    public readonly int upstream;
    public readonly NodeRef parentNode;
    public readonly string? name;
    public readonly bool backEdge;

    internal EdgeInfo(int upstream, NodeRef parentNode, string? name, bool backEdge)
    {
        this.upstream = upstream;
        this.parentNode = parentNode;
        this.name = name;
        this.backEdge = backEdge;
    }
}

[StructLayout(LayoutKind.Sequential)]
internal readonly struct EdgeInfoVector
{
    private readonly nint _data;
    private readonly int _size;

    public void Dispose()
    {
        UnsafeNativeMethods.mp_api_EdgeInfoArray__delete(_data, _size);
    }

    public List<EdgeInfo> Copy()
    {
        var edgeInfos = new List<EdgeInfo>(_size);

        unsafe
        {
            var edgeInfoPtr = (EdgeInfoTmp*)_data;

            for (var i = 0; i < _size; i++)
            {
                var edgeInfoTmp = System.Runtime.InteropServices.Marshal.PtrToStructure<EdgeInfoTmp>((nint)edgeInfoPtr++);
                edgeInfos.Add(edgeInfoTmp.Copy());
            }
        }

        return edgeInfos;
    }

    [StructLayout(LayoutKind.Sequential)]
    private readonly struct EdgeInfoTmp
    {
        private readonly int _upstream;
        private readonly NodeRef _parentNode;
        private readonly nint _name;

        [MarshalAs(UnmanagedType.U1)]
        private readonly bool _backEdge;

        public EdgeInfo Copy()
        {
            var name = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(_name);
            return new EdgeInfo(_upstream, _parentNode, name, _backEdge);
        }
    }
}

public class ValidatedGraphConfig : MpResourceHandle
{
    public ValidatedGraphConfig() : base()
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__(out var ptr).Assert();
        Ptr = ptr;
    }

    protected override void DeleteMpPtr()
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__delete(Ptr);
    }

    public void Initialize(CalculatorGraphConfig config)
    {
        var bytes = config.ToByteArray();
        UnsafeNativeMethods.mp_ValidatedGraphConfig__Initialize__Rcgc(MpPtr, bytes, bytes.Length, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void Initialize(string graphType)
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__Initialize__PKc(MpPtr, graphType, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public bool Initialized()
    {
        return SafeNativeMethods.mp_ValidatedGraphConfig__Initialized(MpPtr);
    }

    public void ValidateRequiredSidePackets(PacketMap sidePacket)
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__ValidateRequiredSidePackets__Rsp(MpPtr, sidePacket.MpPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public CalculatorGraphConfig Config(ExtensionRegistry? extensionRegistry = null)
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__Config(MpPtr, out var serializedProto).Assert();

        var parser = extensionRegistry == null ? CalculatorGraphConfig.Parser : CalculatorGraphConfig.Parser.WithExtensionRegistry(extensionRegistry);
        var config = serializedProto.Deserialize(parser);
        serializedProto.Dispose();

        return config;
    }

    public List<EdgeInfo> InputStreamInfos()
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__InputStreamInfos(MpPtr, out var edgeInfoVector).Assert();

        var edgeInfos = edgeInfoVector.Copy();
        edgeInfoVector.Dispose();
        return edgeInfos;
    }

    public List<EdgeInfo> OutputStreamInfos()
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__OutputStreamInfos(MpPtr, out var edgeInfoVector).Assert();

        var edgeInfos = edgeInfoVector.Copy();
        edgeInfoVector.Dispose();
        return edgeInfos;
    }

    public List<EdgeInfo> InputSidePacketInfos()
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__InputSidePacketInfos(MpPtr, out var edgeInfoVector).Assert();

        var edgeInfos = edgeInfoVector.Copy();
        edgeInfoVector.Dispose();
        return edgeInfos;
    }

    public List<EdgeInfo> OutputSidePacketInfos()
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__OutputSidePacketInfos(MpPtr, out var edgeInfoVector).Assert();

        var edgeInfos = edgeInfoVector.Copy();
        edgeInfoVector.Dispose();
        return edgeInfos;
    }

    public int OutputStreamIndex(string name)
    {
        return SafeNativeMethods.mp_ValidatedGraphConfig__OutputStreamIndex__PKc(MpPtr, name);
    }

    public int OutputSidePacketIndex(string name)
    {
        return SafeNativeMethods.mp_ValidatedGraphConfig__OutputSidePacketIndex__PKc(MpPtr, name);
    }

    public int OutputStreamToNode(string name)
    {
        return SafeNativeMethods.mp_ValidatedGraphConfig__OutputStreamToNode__PKc(MpPtr, name);
    }

    public string? RegisteredSidePacketTypeName(string name)
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__RegisteredSidePacketTypeName(MpPtr, name, out var statusPtr, out var strPtr).Assert();

        AssertStatusOk(statusPtr);
        return MarshalStringFromNative(strPtr);
    }

    public string? RegisteredStreamTypeName(string name)
    {
        UnsafeNativeMethods.mp_ValidatedGraphConfig__RegisteredStreamTypeName(MpPtr, name, out var statusPtr, out var strPtr).Assert();

        AssertStatusOk(statusPtr);
        return MarshalStringFromNative(strPtr);
    }

    public string? Package()
    {
        return MarshalStringFromNative(UnsafeNativeMethods.mp_ValidatedGraphConfig__Package);
    }

    public static bool IsReservedExecutorName(string name)
    {
        return SafeNativeMethods.mp_ValidatedGraphConfig_IsReservedExecutorName(name);
    }

    public bool IsExternalSidePacket(string name)
    {
        return SafeNativeMethods.mp_ValidatedGraphConfig__IsExternalSidePacket__PKc(MpPtr, name);
    }
}
