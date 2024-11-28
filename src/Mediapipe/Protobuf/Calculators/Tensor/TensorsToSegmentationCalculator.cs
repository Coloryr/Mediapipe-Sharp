// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: mediapipe/calculators/tensor/tensors_to_segmentation_calculator.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Mediapipe {

  /// <summary>Holder for reflection information generated from mediapipe/calculators/tensor/tensors_to_segmentation_calculator.proto</summary>
  public static partial class TensorsToSegmentationCalculatorReflection {

    #region Descriptor
    /// <summary>File descriptor for mediapipe/calculators/tensor/tensors_to_segmentation_calculator.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TensorsToSegmentationCalculatorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CkVtZWRpYXBpcGUvY2FsY3VsYXRvcnMvdGVuc29yL3RlbnNvcnNfdG9fc2Vn",
            "bWVudGF0aW9uX2NhbGN1bGF0b3IucHJvdG8SCW1lZGlhcGlwZRokbWVkaWFw",
            "aXBlL2ZyYW1ld29yay9jYWxjdWxhdG9yLnByb3RvGh5tZWRpYXBpcGUvZ3B1",
            "L2dwdV9vcmlnaW4ucHJvdG8i4gIKJlRlbnNvcnNUb1NlZ21lbnRhdGlvbkNh",
            "bGN1bGF0b3JPcHRpb25zEi0KCmdwdV9vcmlnaW4YASABKA4yGS5tZWRpYXBp",
            "cGUuR3B1T3JpZ2luLk1vZGUSVgoKYWN0aXZhdGlvbhgCIAEoDjI8Lm1lZGlh",
            "cGlwZS5UZW5zb3JzVG9TZWdtZW50YXRpb25DYWxjdWxhdG9yT3B0aW9ucy5B",
            "Y3RpdmF0aW9uOgROT05FEh0KEm91dHB1dF9sYXllcl9pbmRleBgDIAEoBToB",
            "MSIwCgpBY3RpdmF0aW9uEggKBE5PTkUQABILCgdTSUdNT0lEEAESCwoHU09G",
            "VE1BWBACMmAKA2V4dBIcLm1lZGlhcGlwZS5DYWxjdWxhdG9yT3B0aW9ucxjC",
            "kb6yASABKAsyMS5tZWRpYXBpcGUuVGVuc29yc1RvU2VnbWVudGF0aW9uQ2Fs",
            "Y3VsYXRvck9wdGlvbnM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Mediapipe.CalculatorReflection.Descriptor, global::Mediapipe.GpuOriginReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Mediapipe.TensorsToSegmentationCalculatorOptions), global::Mediapipe.TensorsToSegmentationCalculatorOptions.Parser, new[]{ "GpuOrigin", "Activation", "OutputLayerIndex" }, null, new[]{ typeof(global::Mediapipe.TensorsToSegmentationCalculatorOptions.Types.Activation) }, new pb::Extension[] { global::Mediapipe.TensorsToSegmentationCalculatorOptions.Extensions.Ext }, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class TensorsToSegmentationCalculatorOptions : pb::IMessage<TensorsToSegmentationCalculatorOptions>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TensorsToSegmentationCalculatorOptions> _parser = new pb::MessageParser<TensorsToSegmentationCalculatorOptions>(() => new TensorsToSegmentationCalculatorOptions());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TensorsToSegmentationCalculatorOptions> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Mediapipe.TensorsToSegmentationCalculatorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TensorsToSegmentationCalculatorOptions() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TensorsToSegmentationCalculatorOptions(TensorsToSegmentationCalculatorOptions other) : this() {
      _hasBits0 = other._hasBits0;
      gpuOrigin_ = other.gpuOrigin_;
      activation_ = other.activation_;
      outputLayerIndex_ = other.outputLayerIndex_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TensorsToSegmentationCalculatorOptions Clone() {
      return new TensorsToSegmentationCalculatorOptions(this);
    }

    /// <summary>Field number for the "gpu_origin" field.</summary>
    public const int GpuOriginFieldNumber = 1;
    private readonly static global::Mediapipe.GpuOrigin.Types.Mode GpuOriginDefaultValue = global::Mediapipe.GpuOrigin.Types.Mode.Default;

    private global::Mediapipe.GpuOrigin.Types.Mode gpuOrigin_;
    /// <summary>
    /// For CONVENTIONAL mode in OpenGL, textures start at bottom and needs
    /// to be flipped vertically as tensors are expected to start at top.
    /// (DEFAULT or unset is interpreted as CONVENTIONAL.)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Mediapipe.GpuOrigin.Types.Mode GpuOrigin {
      get { if ((_hasBits0 & 1) != 0) { return gpuOrigin_; } else { return GpuOriginDefaultValue; } }
      set {
        _hasBits0 |= 1;
        gpuOrigin_ = value;
      }
    }
    /// <summary>Gets whether the "gpu_origin" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasGpuOrigin {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "gpu_origin" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearGpuOrigin() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "activation" field.</summary>
    public const int ActivationFieldNumber = 2;
    private readonly static global::Mediapipe.TensorsToSegmentationCalculatorOptions.Types.Activation ActivationDefaultValue = global::Mediapipe.TensorsToSegmentationCalculatorOptions.Types.Activation.None;

    private global::Mediapipe.TensorsToSegmentationCalculatorOptions.Types.Activation activation_;
    /// <summary>
    /// Activation function to apply to input tensor.
    /// Softmax requires a 2-channel tensor, see output_layer_index below.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Mediapipe.TensorsToSegmentationCalculatorOptions.Types.Activation Activation {
      get { if ((_hasBits0 & 2) != 0) { return activation_; } else { return ActivationDefaultValue; } }
      set {
        _hasBits0 |= 2;
        activation_ = value;
      }
    }
    /// <summary>Gets whether the "activation" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasActivation {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "activation" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearActivation() {
      _hasBits0 &= ~2;
    }

    /// <summary>Field number for the "output_layer_index" field.</summary>
    public const int OutputLayerIndexFieldNumber = 3;
    private readonly static int OutputLayerIndexDefaultValue = 1;

    private int outputLayerIndex_;
    /// <summary>
    /// Channel to use for processing tensor.
    /// Only applies when using activation=SOFTMAX.
    /// Works on two channel input tensor only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int OutputLayerIndex {
      get { if ((_hasBits0 & 4) != 0) { return outputLayerIndex_; } else { return OutputLayerIndexDefaultValue; } }
      set {
        _hasBits0 |= 4;
        outputLayerIndex_ = value;
      }
    }
    /// <summary>Gets whether the "output_layer_index" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasOutputLayerIndex {
      get { return (_hasBits0 & 4) != 0; }
    }
    /// <summary>Clears the value of the "output_layer_index" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearOutputLayerIndex() {
      _hasBits0 &= ~4;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TensorsToSegmentationCalculatorOptions);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TensorsToSegmentationCalculatorOptions other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (GpuOrigin != other.GpuOrigin) return false;
      if (Activation != other.Activation) return false;
      if (OutputLayerIndex != other.OutputLayerIndex) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasGpuOrigin) hash ^= GpuOrigin.GetHashCode();
      if (HasActivation) hash ^= Activation.GetHashCode();
      if (HasOutputLayerIndex) hash ^= OutputLayerIndex.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (HasGpuOrigin) {
        output.WriteRawTag(8);
        output.WriteEnum((int) GpuOrigin);
      }
      if (HasActivation) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Activation);
      }
      if (HasOutputLayerIndex) {
        output.WriteRawTag(24);
        output.WriteInt32(OutputLayerIndex);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasGpuOrigin) {
        output.WriteRawTag(8);
        output.WriteEnum((int) GpuOrigin);
      }
      if (HasActivation) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Activation);
      }
      if (HasOutputLayerIndex) {
        output.WriteRawTag(24);
        output.WriteInt32(OutputLayerIndex);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasGpuOrigin) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) GpuOrigin);
      }
      if (HasActivation) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Activation);
      }
      if (HasOutputLayerIndex) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(OutputLayerIndex);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TensorsToSegmentationCalculatorOptions other) {
      if (other == null) {
        return;
      }
      if (other.HasGpuOrigin) {
        GpuOrigin = other.GpuOrigin;
      }
      if (other.HasActivation) {
        Activation = other.Activation;
      }
      if (other.HasOutputLayerIndex) {
        OutputLayerIndex = other.OutputLayerIndex;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            GpuOrigin = (global::Mediapipe.GpuOrigin.Types.Mode) input.ReadEnum();
            break;
          }
          case 16: {
            Activation = (global::Mediapipe.TensorsToSegmentationCalculatorOptions.Types.Activation) input.ReadEnum();
            break;
          }
          case 24: {
            OutputLayerIndex = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            GpuOrigin = (global::Mediapipe.GpuOrigin.Types.Mode) input.ReadEnum();
            break;
          }
          case 16: {
            Activation = (global::Mediapipe.TensorsToSegmentationCalculatorOptions.Types.Activation) input.ReadEnum();
            break;
          }
          case 24: {
            OutputLayerIndex = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

    #region Nested types
    /// <summary>Container for nested types declared in the TensorsToSegmentationCalculatorOptions message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static partial class Types {
      /// <summary>
      /// Supported activation functions for filtering.
      /// </summary>
      public enum Activation {
        /// <summary>
        /// Assumes 1-channel input tensor.
        /// </summary>
        [pbr::OriginalName("NONE")] None = 0,
        /// <summary>
        /// Assumes 1-channel input tensor.
        /// </summary>
        [pbr::OriginalName("SIGMOID")] Sigmoid = 1,
        /// <summary>
        /// Assumes 2-channel input tensor.
        /// </summary>
        [pbr::OriginalName("SOFTMAX")] Softmax = 2,
      }

    }
    #endregion

    #region Extensions
    /// <summary>Container for extensions for other messages declared in the TensorsToSegmentationCalculatorOptions message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static partial class Extensions {
      public static readonly pb::Extension<global::Mediapipe.CalculatorOptions, global::Mediapipe.TensorsToSegmentationCalculatorOptions> Ext =
        new pb::Extension<global::Mediapipe.CalculatorOptions, global::Mediapipe.TensorsToSegmentationCalculatorOptions>(374311106, pb::FieldCodec.ForMessage(2994488850, global::Mediapipe.TensorsToSegmentationCalculatorOptions.Parser));
    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
