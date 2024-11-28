using Mediapipe.Core;
using Mediapipe.PInvoke;

namespace Mediapipe.Gpu;

public class GlSyncPoint : MpResourceHandle
{
    private SharedPtrHandle? _sharedPtrHandle;

    public GlSyncPoint(nint ptr) : base()
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

    public void Wait()
    {
        UnsafeNativeMethods.mp_GlSyncPoint__Wait(MpPtr).Assert();
    }

    public void WaitOnGpu()
    {
        UnsafeNativeMethods.mp_GlSyncPoint__WaitOnGpu(MpPtr).Assert();
    }

    public bool IsReady()
    {
        UnsafeNativeMethods.mp_GlSyncPoint__IsReady(MpPtr, out var value).Assert();

        return value;
    }

    public GlContext GetContext()
    {
        UnsafeNativeMethods.mp_GlSyncPoint__GetContext(MpPtr, out var sharedGlContextPtr).Assert();

        return new GlContext(sharedGlContextPtr);
    }

    internal class CSharedPtr(nint ptr) : SharedPtrHandle(ptr)
    {
        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_GlSyncToken__delete(Ptr);
        }

        public override nint Get()
        {
            return SafeNativeMethods.mp_GlSyncToken__get(MpPtr);
        }

        public override void Reset()
        {
            UnsafeNativeMethods.mp_GlSyncToken__reset(MpPtr);
        }
    }
}

