using System.Security;
using System.Runtime.InteropServices;

namespace Mediapipe.PInvoke;

[SuppressUnmanagedCodeSecurity]
internal static partial class UnsafeNativeMethods
{
    static UnsafeNativeMethods()
    {
        mp_api__SetFreeHGlobal(FreeHGlobal);
    }

    private delegate void FreeHGlobalDelegate(IntPtr hglobal);

    private static void FreeHGlobal(IntPtr hglobal)
    {
        Marshal.FreeHGlobal(hglobal);
    }

    [DllImport(LibName.MediaPipeLibrary, ExactSpelling = true)]
    private static extern void mp_api__SetFreeHGlobal([MarshalAs(UnmanagedType.FunctionPtr)] FreeHGlobalDelegate freeHGlobal);
}
