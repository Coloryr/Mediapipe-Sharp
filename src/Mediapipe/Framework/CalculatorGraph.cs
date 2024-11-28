using System.Runtime.InteropServices;
using Google.Protobuf;
using Mediapipe.Core;
using Mediapipe.Framework.Packet;
using Mediapipe.Framework.Port;
using Mediapipe.Gpu;
using Mediapipe.PInvoke;

namespace Mediapipe.Framework;

public class CalculatorGraph : MpResourceHandle
{
    public delegate StatusArgs NativePacketCallback(nint graphPtr, int streamId, nint packetPtr);
    public delegate void PacketCallback<T>(Packet<T> packet);

    public CalculatorGraph() : base()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__(out var ptr).Assert();
        Ptr = ptr;
    }

    private CalculatorGraph(byte[] serializedConfig) : base()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__PKc_i(serializedConfig, serializedConfig.Length, out var ptr).Assert();
        Ptr = ptr;
    }

    public CalculatorGraph(CalculatorGraphConfig config) : this(config.ToByteArray()) { }

    public CalculatorGraph(string textFormatConfig) : this(CalculatorGraphConfig.Parser.ParseFromTextFormat(textFormatConfig)) { }

    protected override void DeleteMpPtr()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__delete(Ptr);
    }

    public void Initialize(CalculatorGraphConfig config)
    {
        var bytes = config.ToByteArray();
        UnsafeNativeMethods.mp_CalculatorGraph__Initialize__PKc_i(MpPtr, bytes, bytes.Length, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void Initialize(CalculatorGraphConfig config, Framework.Packet.PacketMap sidePacket)
    {
        var bytes = config.ToByteArray();
        UnsafeNativeMethods.mp_CalculatorGraph__Initialize__PKc_i_Rsp(MpPtr, bytes, bytes.Length, sidePacket.MpPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    /// <remarks>Crashes if config is not set</remarks>
    public CalculatorGraphConfig Config()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__Config(MpPtr, out var serializedProto).Assert();

        var config = serializedProto.Deserialize(CalculatorGraphConfig.Parser);
        serializedProto.Dispose();

        return config;
    }

    public void ObserveOutputStream(string streamName, int streamId, NativePacketCallback nativePacketCallback, bool observeTimestampBounds = false)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__ObserveOutputStream__PKc_PF_b(MpPtr, streamName, streamId, nativePacketCallback, observeTimestampBounds, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void ObserveOutputStream<T>(string streamName, PacketCallback<T> packetCallback, bool observeTimestampBounds, out GCHandle callbackHandle)
    {
        NativePacketCallback nativePacketCallback = (graphPtr, streamId, packetPtr) =>
        {
            try
            {
                var packet = Packet<T>.CreateForReference(packetPtr);
                packetCallback(packet);
                return StatusArgs.Ok();
            }
            catch (Exception e)
            {
                return StatusArgs.Internal(e.ToString());
            }
        };
        callbackHandle = GCHandle.Alloc(nativePacketCallback, GCHandleType.Pinned);

        ObserveOutputStream(streamName, 0, nativePacketCallback, observeTimestampBounds);
    }

    public void ObserveOutputStream<T>(string streamName, PacketCallback<T> packetCallback, out GCHandle callbackHandle)
    {
        ObserveOutputStream(streamName, packetCallback, false, out callbackHandle);
    }

    public OutputStreamPoller<T> AddOutputStreamPoller<T>(string streamName, bool observeTimestampBounds = false)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__AddOutputStreamPoller__PKc_b(MpPtr, streamName, observeTimestampBounds, out var statusPtr, out var pollerPtr).Assert();

        AssertStatusOk(statusPtr);
        return new OutputStreamPoller<T>(pollerPtr);
    }

    public void Run()
    {
        Run(new Framework.Packet.PacketMap());
    }

    public void Run(Framework.Packet.PacketMap sidePacket)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__Run__Rsp(MpPtr, sidePacket.MpPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void StartRun()
    {
        StartRun(new Framework.Packet.PacketMap());
    }

    public void StartRun(Framework.Packet.PacketMap sidePacket)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__StartRun__Rsp(MpPtr, sidePacket.MpPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void WaitUntilIdle()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__WaitUntilIdle(MpPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void WaitUntilDone()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__WaitUntilDone(MpPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public bool HasError()
    {
        return SafeNativeMethods.mp_CalculatorGraph__HasError(MpPtr);
    }

    public void AddPacketToInputStream<T>(string streamName, Packet<T> packet)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__AddPacketToInputStream__PKc_Ppacket(MpPtr, streamName, packet.MpPtr, out var statusPtr).Assert();
        packet.Dispose(); // respect move semantics

        AssertStatusOk(statusPtr);
    }

    public void SetInputStreamMaxQueueSize(string streamName, int maxQueueSize)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__SetInputStreamMaxQueueSize__PKc_i(MpPtr, streamName, maxQueueSize, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void CloseInputStream(string streamName)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__CloseInputStream__PKc(MpPtr, streamName, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void CloseAllPacketSources()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__CloseAllPacketSources(MpPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }

    public void Cancel()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__Cancel(MpPtr).Assert();
    }

    public bool GraphInputStreamsClosed()
    {
        return SafeNativeMethods.mp_CalculatorGraph__GraphInputStreamsClosed(MpPtr);
    }

    public bool IsNodeThrottled(int nodeId)
    {
        return SafeNativeMethods.mp_CalculatorGraph__IsNodeThrottled__i(MpPtr, nodeId);
    }

    public bool UnthrottleSources()
    {
        return SafeNativeMethods.mp_CalculatorGraph__UnthrottleSources(MpPtr);
    }

    public GpuResources GetGpuResources()
    {
        UnsafeNativeMethods.mp_CalculatorGraph__GetGpuResources(MpPtr, out var gpuResourcesPtr).Assert();

        return new GpuResources(gpuResourcesPtr);
    }

    public void SetGpuResources(GpuResources gpuResources)
    {
        UnsafeNativeMethods.mp_CalculatorGraph__SetGpuResources__SPgpu(MpPtr, gpuResources.SharedPtr, out var statusPtr).Assert();

        AssertStatusOk(statusPtr);
    }
}
