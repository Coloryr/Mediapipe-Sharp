using Mediapipe.Core;
using Mediapipe.PInvoke;

namespace Mediapipe.Framework;

public class Timestamp : MpResourceHandle, IEquatable<Timestamp>
{
    public Timestamp(nint ptr) : base(ptr) { }

    public Timestamp(long value) : base()
    {
        UnsafeNativeMethods.mp_Timestamp__l(value, out var ptr).Assert();
        Ptr = ptr;
    }

    protected override void DeleteMpPtr()
    {
        UnsafeNativeMethods.mp_Timestamp__delete(Ptr);
    }

    #region IEquatable<Timestamp>
    public bool Equals(Timestamp? other)
    {
        return other is not null && Microseconds() == other.Microseconds();
    }

    public override bool Equals(object? obj)
    {
        var timestampObj = obj == null ? null : obj as Timestamp;

        return timestampObj is not null && Equals(timestampObj);
    }

    public static bool operator ==(Timestamp x, Timestamp y)
    {
        return x is null || y is null ? Equals(x, y) : x.Equals(y);
    }

    public static bool operator !=(Timestamp x, Timestamp y)
    {
        return x is null || y is null ? !Equals(x, y) : !x.Equals(y);
    }

    public override int GetHashCode()
    {
        return Microseconds().GetHashCode();
    }
    #endregion

    public long Value()
    {
        return SafeNativeMethods.mp_Timestamp__Value(MpPtr);
    }

    public double Seconds()
    {
        return SafeNativeMethods.mp_Timestamp__Seconds(MpPtr);
    }

    public long Microseconds()
    {
        return SafeNativeMethods.mp_Timestamp__Microseconds(MpPtr);
    }

    public bool IsSpecialValue()
    {
        return SafeNativeMethods.mp_Timestamp__IsSpecialValue(MpPtr);
    }

    public bool IsRangeValue()
    {
        return SafeNativeMethods.mp_Timestamp__IsRangeValue(MpPtr);
    }

    public bool IsAllowedInStream()
    {
        return SafeNativeMethods.mp_Timestamp__IsAllowedInStream(MpPtr);
    }

    public string? DebugString()
    {
        return MarshalStringFromNative(UnsafeNativeMethods.mp_Timestamp__DebugString);
    }

    public Timestamp NextAllowedInStream()
    {
        UnsafeNativeMethods.mp_Timestamp__NextAllowedInStream(MpPtr, out var nextPtr).Assert();

        GC.KeepAlive(this);
        return new Timestamp(nextPtr);
    }

    public Timestamp PreviousAllowedInStream()
    {
        UnsafeNativeMethods.mp_Timestamp__PreviousAllowedInStream(MpPtr, out var prevPtr).Assert();

        GC.KeepAlive(this);
        return new Timestamp(prevPtr);
    }

    public static Timestamp FromSeconds(double seconds)
    {
        UnsafeNativeMethods.mp_Timestamp_FromSeconds__d(seconds, out var ptr).Assert();

        return new Timestamp(ptr);
    }

    #region SpecialValues
    public static Timestamp Unset()
    {
        UnsafeNativeMethods.mp_Timestamp_Unset(out var ptr).Assert();

        return new Timestamp(ptr);
    }

    public static Timestamp Unstarted()
    {
        UnsafeNativeMethods.mp_Timestamp_Unstarted(out var ptr).Assert();

        return new Timestamp(ptr);
    }

    public static Timestamp PreStream()
    {
        UnsafeNativeMethods.mp_Timestamp_PreStream(out var ptr).Assert();

        return new Timestamp(ptr);
    }

    public static Timestamp Min()
    {
        UnsafeNativeMethods.mp_Timestamp_Min(out var ptr).Assert();

        return new Timestamp(ptr);
    }

    public static Timestamp Max()
    {
        UnsafeNativeMethods.mp_Timestamp_Max(out var ptr).Assert();

        return new Timestamp(ptr);
    }

    public static Timestamp PostStream()
    {
        UnsafeNativeMethods.mp_Timestamp_PostStream(out var ptr).Assert();

        return new Timestamp(ptr);
    }

    public static Timestamp OneOverPostStream()
    {
        UnsafeNativeMethods.mp_Timestamp_OneOverPostStream(out var ptr).Assert();

        return new Timestamp(ptr);
    }

    public static Timestamp Done()
    {
        UnsafeNativeMethods.mp_Timestamp_Done(out var ptr).Assert();

        return new Timestamp(ptr);
    }
    #endregion
}
