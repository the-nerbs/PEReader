﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Flags describing a CLR assembly's characteristics.
    /// </summary>
    [Flags]
    public enum ClrHeaderFlags : uint
    {
        /// <summary>
        /// No flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// Assembly is pure IL.
        /// </summary>
        PureIL = 0x00000001,

        /// <summary>
        /// Assembly requires a 32-bit process.
        /// </summary>
        Requires32Bit = 0x00000002,

        /// <summary>
        /// Assembly is signed with a strong name key.  
        /// </summary>
        StrongNameSigned = 0x00000004,

        /// <summary>
        /// Indicates that the assembly entry point is native code.
        /// </summary>
        NativeEntryPoint = 0x00000010,

        /// <summary>
        /// Informs the JIT that it should track debugging information.
        /// </summary>
        TrackDebugData = 0x00010000,

        /// <summary>
        /// The assembly is platform-neutral, but prefers a 32-bit environment.
        /// </summary>
        Prefer32Bit = 0x00020000,
    }

    /// <summary>
    /// Describes the attributes of a CLR type.
    /// </summary>
    [Flags]
    public enum ClrTypeAttributes
    {
        /// <summary>
        /// No flags defined.
        /// </summary>
        None = 0,

        /// <summary>
        /// Bit 0 of the visibility. The visibility bits make up a value of
        /// the type <see cref="ClrTypeVisibility"/>.
        /// </summary>
        VisibilityBit0 = 0x00000001,

        /// <summary>
        /// Bit 1 of the visibility. The visibility bits make up a value of
        /// the type <see cref="ClrTypeVisibility"/>.
        /// </summary>
        VisibilityBit1 = 0x00000002,

        /// <summary>
        /// Bit 2 of the visibility. The visibility bits make up a value of
        /// the type <see cref="ClrTypeVisibility"/>.
        /// </summary>
        VisibilityBit2 = 0x00000004,

        /// <summary>
        /// Mask for the visibility type.
        /// </summary>
        VisibilityMask = (VisibilityBit0 | VisibilityBit1 | VisibilityBit2),


        /// <summary>
        /// Fields are laid out sequentially.
        /// </summary>
        SequentialLayout = 0x00000008,

        /// <summary>
        /// Fields are laid out explicitly.
        /// </summary>
        ExplicitLayout = 0x00000010,


        /// <summary>
        /// This type is an interface.
        /// </summary>
        IsInterface = 0x00000020,


        /// <summary>
        /// Indicates if the type is abstract.
        /// </summary>
        IsAbstract = 0x00000080,

        /// <summary>
        /// Indicates if the type is sealed.
        /// </summary>
        IsSealed = 0x00000100,

        /// <summary>
        /// Indicates if the type has a special name. How it is special depends on the name.
        /// </summary>
        IsSpecialName = 0x00000400,


        /// <summary>
        /// Indicates if this type is imported.
        /// </summary>
        IsImport = 0x00001000,

        /// <summary>
        /// Indicates if this type is serializable.
        /// </summary>
        IsSerializable = 0x00002000,

        /// <summary>
        /// Indicates if this is a Windows Runtime type.
        /// </summary>
        IsWinRtType = 0x00004000,


        /// <summary>
        /// Indicates if LPTSTR is interpreted as UNICODE in this type.
        /// </summary>
        IsUnicodeClass = 0x00010000,

        /// <summary>
        /// Indicates if LPTSTR is interpreted automatically.
        /// </summary>
        IsAutoClass = 0x00020000,

        /// <summary>
        /// Indicates non-standard encoding.
        /// </summary>
        IsCustomFormatClass = IsUnicodeClass | IsAutoClass,

        /// <summary>
        /// Low-bit for the custom format information. The meaning of these bits is unspecified.
        /// </summary>
        CustomFormatBit0 = 0x00400000,

        /// <summary>
        /// Hight-bit for the custom format information. The meaning of these bits is unspecified.
        /// </summary>
        CustomFormatBit1 = 0x00800000,


        /// <summary>
        /// Indicates if the type is initialized any time before the first static field access.
        /// </summary>
        IsBeforeFieldInit = 0x00100000,

        /// <summary>
        /// Indicates if this exported type is a type forwarder.
        /// </summary>
        IsForwarder = 0x00200000,

        /// <summary>
        /// Indicates if the runtime should check name encoding.
        /// </summary>
        IsRuntimeSpecialName = 0x00000800,

        /// <summary>
        /// Indicates if the class has security associated with it.
        /// </summary>
        HasSecurity = 0x00040000,
    }

    /// <summary>
    /// Describes the attributes of a CLR method.
    /// </summary>
    [Flags]
    public enum ClrMethodAttributes
    {
        /// <summary>
        /// Bit 0 of the visibility. The visibility bits make up a value
        /// of type <see cref="ClrMemberVisibility"/>.
        /// </summary>
        VisibilityBit0 = 0x0001,

        /// <summary>
        /// Bit 1 of the visibility. The visibility bits make up a value
        /// of type <see cref="ClrMemberVisibility"/>.
        /// </summary>
        VisibilityBit1 = 0x0002,

        /// <summary>
        /// Bit 1 of the visibility. The visibility bits make up a value
        /// of type <see cref="ClrMemberVisibility"/>.
        /// </summary>
        VisibilityBit2 = 0x0004,

        /// <summary>
        /// Mask for the visibility value.
        /// </summary>
        VisibilityMask = (VisibilityBit0 | VisibilityBit1 | VisibilityBit2),


        /// <summary>
        /// Indicates if the method is static.
        /// </summary>
        IsStatic = 0x0010,

        /// <summary>
        /// Indicates if the method is sealed.
        /// </summary>
        IsFinal = 0x0020,

        /// <summary>
        /// Indicates if the method is virtual.
        /// </summary>
        IsVirtual = 0x0040,

        /// <summary>
        /// Indicates if the method hides by name and signature.
        /// </summary>
        IsHideBySig = 0x0080,


        /// <summary>
        /// Indicates if the method defines a new v-table slot.
        /// </summary>
        IsNewVtableSlot = 0x0100,


        /// <summary>
        /// Override-ability is the same as the visibility.
        /// </summary>
        CheckAccessOnOverride = 0x0200,

        /// <summary>
        /// Indicates if the method is abstract.
        /// </summary>
        IsAbstact = 0x0400,

        /// <summary>
        /// Indicates if the method is special. How the method is special is determined by the name.
        /// </summary>
        IsSpecialName = 0x0800,


        /// <summary>
        /// Implementation is forwarded through p/invoke
        /// </summary>
        IsPinvokeImpl = 0x2000,

        /// <summary>
        /// Managed method exported via a thunk to unmanaged code.
        /// </summary>
        IsUnmanagedExport = 0x0008,


        /// <summary>
        /// Indicates that the runtime should check the name encoding.
        /// </summary>
        IsRuntimeSpecialName = 0x1000,

        /// <summary>
        /// Indicates that this method has security associated with it.
        /// </summary>
        HasSecurity = 0x4000,

        /// <summary>
        /// Indicates that this method calls another method containing security code.
        /// </summary>
        RequiresSecurityObject = 0x8000,
    }


    /// <summary>
    /// Describes the attributes of a field.
    /// </summary>
    [Flags]
    public enum ClrFieldAttributes
    {
        /// <summary>
        /// Bit 0 of the visibility. The visibility bits make up a value
        /// of type <see cref="ClrMemberVisibility"/>.
        /// </summary>
        VisibilityBit0 = 0x0001,

        /// <summary>
        /// Bit 1 of the visibility. The visibility bits make up a value
        /// of type <see cref="ClrMemberVisibility"/>.
        /// </summary>
        VisibilityBit1 = 0x0002,

        /// <summary>
        /// Bit 1 of the visibility. The visibility bits make up a value
        /// of type <see cref="ClrMemberVisibility"/>.
        /// </summary>
        VisibilityBit2 = 0x0004,

        /// <summary>
        /// Mask for the visibility value.
        /// </summary>
        VisibilityMask = (VisibilityBit0 | VisibilityBit1 | VisibilityBit2),


        /// <summary>
        /// Indicates if the field is static.
        /// </summary>
        IsStatic = 0x0010,

        /// <summary>
        /// Indicates if the field can only be written to during initialization (C#'s readonly).
        /// </summary>
        IsInitOnly = 0x0020,

        /// <summary>
        /// Indicates if the field is a compile-time constant (C#'s const).
        /// </summary>
        IsLiteral = 0x0040,

        /// <summary>
        /// Indicates if the field does not serialized when the type is remoted.
        /// </summary>
        IsNotSerialized = 0x0080,


        /// <summary>
        /// Indicates if the field is special. How is determined by the name.
        /// </summary>
        IsSpecialName = 0x0200,

        /// <summary>
        /// Indicates if the field's implementation is forwarded through p/invoke.
        /// 
        /// This appears to be unused as of yet.
        /// </summary>
        IsPinvokeImpl = 0x2000,

        /// <summary>
        /// Indicates that the runtime should check the name encoding.
        /// </summary>
        IsRuntimeSpecialName = 0x0400,

        /// <summary>
        /// Indicates that the field has marshaling information.
        /// </summary>
        HasFieldMarshal = 0x1000,

        /// <summary>
        /// Indicates that the field has a default value.
        /// </summary>
        HasDefaultValue = 0x8000,

        /// <summary>
        /// Indicates that the field has an RVA.
        /// </summary>
        HasFieldRva = 0x0100,
    }

    /// <summary>
    /// Describes the attributes of a CLR parameter.
    /// </summary>
    [Flags]
    public enum ClrParameterAttributes
    {
        /// <summary>
        /// Parameter is [In]
        /// </summary>
        IsIn = 0x0001,

        /// <summary>
        /// Parameter is [Out]
        /// </summary>
        IsOut = 0x0002,

        /// <summary>
        /// Parameter is [Optional]
        /// </summary>
        IsOptional = 0x0010,


        /// <summary>
        /// Parameter has a default value.
        /// </summary>
        HasDefaultValue = 0x1000,

        /// <summary>
        /// Parameter has FieldMarshal
        /// </summary>
        HasFieldMarshal = 0x2000,
    }

    /// <summary>
    /// Describes the attributes of a CLR property.
    /// </summary>
    [Flags]
    public enum ClrPropertyAttributes
    {
        /// <summary>
        /// Indicates if this property has a special name. How is determined by the name.
        /// </summary>
        IsSpecialName = 0x0200,

        /// <summary>
        /// Indicates that the runtime should check the name encoding.
        /// </summary>
        IsRuntimeSpecialName = 0x0400,

        /// <summary>
        /// Indicates that the property has a default value.
        /// </summary>
        HasDefault = 0x1000,
    }


    /// <summary>
    /// Describes the attributes of a CLR event.
    /// </summary>
    [Flags]
    public enum ClrEventAttributes
    {
        /// <summary>
        /// Indicates if this event has a special name. How is determined by the name.
        /// </summary>
        IsSpecialName = 0x0200,

        /// <summary>
        /// Indicates that the runtime should check the name encoding.
        /// </summary>
        IsRuntimeSpecialName = 0x0400,
    }

    /// <summary>
    /// Describes the attributes of a p/invoke mapping.
    /// </summary>
    /// <seealso cref="System.Runtime.InteropServices.DllImportAttribute"/>
    [Flags]
    public enum ClrPinvokeMapAttributes
    {
        /// <summary>
        /// Indicates that the member name is to be used as is.
        /// </summary>
        NoMangle = 0x0001,


        /// <summary>
        /// Bit 1 of the character set type. The code type bits make up a value of 
        /// the type <see cref="ClrCharacterSet"/>.
        /// </summary>
        CharSetBit0 = 0x0002,

        /// <summary>
        /// Bit 1 of the character set type. The code type bits make up a value of 
        /// the type <see cref="ClrCharacterSet"/>.
        /// </summary>
        CharSetBit1 = 0x0004,

        /// <summary>
        /// Mask for the character set type.
        /// </summary>
        CharSetMask = (CharSetBit0 | CharSetBit1),


        /// <summary>
        /// Indicates that best fit mapping is enabled.
        /// </summary>
        IsBestFitEnabled = 0x0010,

        /// <summary>
        /// Indicates that best fit mapping is disabled.
        /// </summary>
        IsBestFitDisabled = 0x0020,


        /// <summary>
        /// Indicates that the function will throw when an unmappable character is encountered.
        /// </summary>
        ThrowOnUnmappableCharEnabled = 0x1000,

        /// <summary>
        /// Indicates that the function will not throw when an unmappable character is encountered.
        /// </summary>
        ThrowOnUnmappableCharDisabled = 0x2000,


        /// <summary>
        /// Indicates that the function may set the last Win32 error code.
        /// </summary>
        SupportsLastError = 0x0040,


        /// <summary>
        /// Bit 0 of the calling convention type. The code type bits make up a
        /// value of the type <see cref="ClrCallingConvention"/>.
        /// </summary>
        CallingConventionBit0 = 0x0100,

        /// <summary>
        /// Bit 1 of the calling convention type. The code type bits make up a
        /// value of the type <see cref="ClrCallingConvention"/>.
        /// </summary>
        CallingConventionBit1 = 0x0200,

        /// <summary>
        /// Bit 2 of the calling convention type. The code type bits make up a
        /// value of the type <see cref="ClrCallingConvention"/>.
        /// </summary>
        CallingConventionBit2 = 0x0400,

        /// <summary>
        /// Mask for the calling convention type.
        /// </summary>
        CallingConventionMask = 0x0700,
    }
}
