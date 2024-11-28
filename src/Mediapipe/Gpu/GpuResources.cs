using Mediapipe.Core;
using Mediapipe.PInvoke;

namespace Mediapipe.Gpu;

public class GpuResources : MpResourceHandle
{
    private SharedPtrHandle? _sharedPtrHandle;

    /// <param name="ptr">Shared pointer of mediapipe::GpuResources</param>
    public GpuResources(nint ptr) : base()
    {
        _sharedPtrHandle = new CSharedPtr(ptr);
        Ptr = _sharedPtrHandle.Get();
    }

    protected override void DisposeManaged()
    {
        if (_sharedPtrHandle != null)
        {
            _sharedPtrHandle.Dispose();
            _sharedPtrHandle = null;
        }
        base.DisposeManaged();
    }

    protected override void DeleteMpPtr()
    {
        // Do nothing
    }

    public nint SharedPtr => _sharedPtrHandle == null ? nint.Zero : _sharedPtrHandle.MpPtr;

    public static GpuResources Create()
    {
        UnsafeNativeMethods.mp_GpuResources_Create(out var statusPtr, out var gpuResourcesPtr).Assert();
        AssertStatusOk(statusPtr);

        return new GpuResources(gpuResourcesPtr);
    }

    public static GpuResources Create(nint externalContext)
    {
        UnsafeNativeMethods.mp_GpuResources_Create__Pv(externalContext, out var statusPtr, out var gpuResourcesPtr).Assert();
        AssertStatusOk(statusPtr);

        return new GpuResources(gpuResourcesPtr);
    }

    private class CSharedPtr(nint ptr) : SharedPtrHandle(ptr)
    {
        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_SharedGpuResources__delete(Ptr);
        }

        public override nint Get()
        {
            return SafeNativeMethods.mp_SharedGpuResources__get(MpPtr);
        }

        public override void Reset()
        {
            UnsafeNativeMethods.mp_SharedGpuResources__reset(MpPtr);
        }
    }
}
