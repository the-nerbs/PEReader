using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Describes the visibility of a CLR type.
    /// </summary>
    public enum ClrTypeVisibility
    {
        /// <summary>
        /// Type is not public,
        /// </summary>
        NotPublic = 0,

        /// <summary>
        /// Type is public.
        /// </summary>
        Public = 1,

        /// <summary>
        /// Type is nested with public visibility.
        /// </summary>
        NestedPublic = 2,

        /// <summary>
        /// Type is nested with private visibility.
        /// </summary>
        NestedPrivate = 3,

        /// <summary>
        /// Type is nested with family (protected) visibility.
        /// </summary>
        NestedFamily = 4,

        /// <summary>
        /// Type is nested with assembly (internal) visibility.
        /// </summary>
        NestedAssembly = 5,

        /// <summary>
        /// Type is nested with family and assembly visibility.
        /// 
        /// This is not exposed to C#, but there is a proposal that would name it "private protected":
        ///     https://github.com/dotnet/csharplang/blob/fab2157f7e13c8f12a781172d9b870f846a442b9/proposals/private-protected.md
        /// </summary>
        NestedFamilyAndAssembly = 6,

        /// <summary>
        /// Type is nested with family or assembly (protected internal) visibility.
        /// </summary>
        NestedFamilyOrAssembly = 7,
    }

    /// <summary>
    /// Describes the visibility of a CLR methods and fields.
    /// </summary>
    public enum ClrMemberVisibility
    {
        /// <summary>
        /// Member not referenceable.
        /// </summary>
        /// <devdoc>
        /// I'm assuming this is used for C# 7's local functions?
        /// </devdoc>
        PrivateScope = 0,

        /// <summary>
        /// Private
        /// </summary>
        Private = 1,

        /// <summary>
        /// Private protected
        /// </summary>
        FamilyAndAssembly = 2,

        /// <summary>
        /// Internal
        /// </summary>
        Assembly = 3,

        /// <summary>
        /// Protected
        /// </summary>
        Family = 4,

        /// <summary>
        /// Protected internal
        /// </summary>
        FamilyOrAssembly = 5,

        /// <summary>
        /// Public
        /// </summary>
        Public = 6,
    }

    /// <summary>
    /// Describes the semantics of a method.
    /// </summary>
    [Flags]
    public enum ClrMethodSemantics
    {
        /// <summary>
        /// Property setter method.
        /// </summary>
        Setter = 0x0001,

        /// <summary>
        /// Property getter method.
        /// </summary>
        Getter = 0x0002,

        /// <summary>
        /// Additional property method (not exposed in C#).
        /// </summary>
        Other = 0x0004,

        /// <summary>
        /// Event add method.
        /// </summary>
        AddOn = 0x0008,

        /// <summary>
        /// Event remove method.
        /// </summary>
        RemoveOn = 0x0010,

        /// <summary>
        /// Event fire method (not exposed in C#).
        /// </summary>
        Fire = 0x0020,
    }

    /// <summary>
    /// Describes declared code security.
    /// </summary>
    public enum ClrDeclSecurity
    {
        /// <summary>
        /// No security.
        /// </summary>
        None = 0,


        /// <summary>
        /// Request action
        /// </summary>
        Request,

        /// <summary>
        /// Demand action
        /// </summary>
        Demand,

        /// <summary>
        /// Assert action
        /// </summary>
        Assert,

        /// <summary>
        /// Deny action
        /// </summary>
        Deny,


        //TODO: figure out what these really are and update comments accordingly...

        /// <summary>
        /// Permit only
        /// </summary>
        PermitOnly,

        /// <summary>
        /// Link-time check
        /// </summary>
        LinktimeCheck,

        /// <summary>
        /// Inheritance check
        /// </summary>
        InheritanceCheck,
        
        /// <summary>
        /// Request minimum
        /// </summary>
        RequestMinimum,

        /// <summary>
        /// Request optional
        /// </summary>
        RequestOptional,

        /// <summary>
        /// Request refuse
        /// </summary>
        RequestRefuse,

        /// <summary>
        /// Persisted grant set at pre-JIT time.
        /// </summary>
        PrejitGrant,

        /// <summary>
        /// Persisted denial set at pre-JIT time.
        /// </summary>
        PrejitDenied,

        /// <summary>
        /// Non-CAS demand
        /// </summary>
        NonCasDemand,

        /// <summary>
        /// Non-CAS link demand
        /// </summary>
        NonCasLinkDemand,

        /// <summary>
        /// Non-CAS inheritance
        /// </summary>
        NonCasInheritance,
    }

    /// <summary>
    /// Describes the type of code a method is implemented in.
    /// </summary>
    /// <seealso cref="System.Runtime.CompilerServices.MethodCodeType"/>
    public enum ClrCodeType
    {
        /// <summary>
        /// Method code is IL
        /// </summary>
        IL = 0,

        /// <summary>
        /// Method code is native.
        /// </summary>
        Native = 1,

        /// <summary>
        /// Method code is optimized IL
        /// </summary>
        OptimizedIL = 2,

        /// <summary>
        /// Method code is provided by the runtime.
        /// </summary>
        Runtime = 3
    }

    /// <summary>
    /// CLR method implementation flags.
    /// </summary>
    /// <seealso cref="System.Runtime.CompilerServices.MethodImplOptions"/>
    [Flags]
    public enum ClrMethodImplFlags
    {
        /// <summary>
        /// Bit 0 of the code type. The code type bits make up a value of 
        /// the type <see cref="ClrCodeType"/>.
        /// </summary>
        CodeTypeBit0 = 0x0001,

        /// <summary>
        /// Bit 1 of the code type. The code type bits make up a value of 
        /// the type <see cref="ClrCodeType"/>.
        /// </summary>
        CodeTypeBit1 = 0x0002,

        /// <summary>
        /// Mask for the code type.
        /// </summary>
        CodeTypeMask = (CodeTypeBit0 | CodeTypeBit1),


        /// <summary>
        /// Indicates that the method implementation is unmanaged.
        /// </summary>
        IsUnmanaged = 0x0004,


        /// <summary>
        /// Indicates that the method if defined in another netmodule.
        /// </summary>
        IsForwardReference = 0x0010,


        /// <summary>
        /// Indicates that the method signature is not to be mangled to do an HRESULT conversion.
        /// </summary>
        IsPreserveSig = 0x0080,


        /// <summary>
        /// Indicates that the method is provided by the runtime.
        /// </summary>
        IsInternalCall = 0x1000,


        /// <summary>
        /// Indicates that the method is single-threaded.
        /// </summary>
        IsSynchronized = 0x0020,

        /// <summary>
        /// Indicates that the method cannot be inlined.
        /// </summary>
        NoInlining = 0x0008,

        /// <summary>
        /// Indicates that the method should be inlined if possible.
        /// </summary>
        AggressiveInlining = 0x0100,

        /// <summary>
        /// Indicates that the method cannot be optimized.
        /// </summary>
        NoOptimization = 0x0040,
    }


    /// <summary>
    /// Describes a character set.
    /// </summary>
    public enum ClrCharacterSet
    {
        /// <summary>
        /// The character set is not specified.
        /// </summary>
        NotSpecified,

        /// <summary>
        /// The ANSI character set.
        /// </summary>
        Ansi,

        /// <summary>
        /// The Windows UNICODE character set (UTF16-LE).
        /// </summary>
        Unicode,

        /// <summary>
        /// The character set is automatically determined.
        /// </summary>
        Auto,
    }

    /// <summary>
    /// Specifies the calling convention of a p/invoke function.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue",
                     Justification = "0 is not a valid value, and this is not a flags enum; 'None' makes no sense here.")]
    public enum ClrCallingConvention
    {
        /// <summary>
        /// Native Windows calling convention.
        /// </summary>
        WinApi = 1,

        /// <summary>
        /// cdecl calling convention.
        /// </summary>
        Cdecl = 2,

        /// <summary>
        /// stdcall calling convention.
        /// </summary>
        StdCall = 3,

        /// <summary>
        /// thiscall calling convention.
        /// </summary>
        ThisCall = 4,

        /// <summary>
        /// fastcall calling convention.
        /// </summary>
        FastCall = 5,
    }
}
