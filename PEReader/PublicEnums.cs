using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader
{
    /// <summary>
    /// The architecture the PE file is built for.
    /// </summary>
    public enum ImageFileMachine : ushort
    {
        /// <summary>
        /// Machine is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Intel 386 (x86)
        /// </summary>
        I386 = 0x014C,

        /// <summary>
        /// MIPS big-endian
        /// </summary>
        R3000_BE = 0x0160,

        /// <summary>
        /// MIPS little-endian
        /// </summary>
        R3000 = 0x0162,

        /// <summary>
        /// MIPS little-endian
        /// </summary>
        R4000 = 0x0166,

        /// <summary>
        /// MIPS little-endian
        /// </summary>
        R10000 = 0x0168,

        /// <summary>
        /// MIPS little-endian WCE v2
        /// </summary>
        WCEMIPSV2 = 0x0169,

        /// <summary>
        /// Alpha_AXP
        /// </summary>
        Alpha = 0x0184,

        /// <summary>
        /// SH3 little-endian
        /// </summary>
        SH3 = 0x01A2,

        /// <summary>
        /// SH3DSP
        /// </summary>
        SH3DSP = 0x01A3,

        /// <summary>
        /// SH3E little-endian
        /// </summary>
        SH3E = 0x01A4,

        /// <summary>
        /// SH4 little-endian
        /// </summary>
        SH4 = 0x01A6,

        /// <summary>
        /// SH5
        /// </summary>
        SH5 = 0x01A8,

        /// <summary>
        /// ARM Little-Endian
        /// </summary>
        ARM = 0x01C0,

        /// <summary>
        /// THUMB
        /// </summary>
        THUMB = 0x01C2,

        /// <summary>
        /// AM33
        /// </summary>
        AM33 = 0x01D3,

        /// <summary>
        /// IBM PowerPC Little-Endian
        /// </summary>
        PowerPC = 0x01F0,

        /// <summary>
        /// PowerPCFP
        /// </summary>
        PowerPCFP = 0x01F1,

        /// <summary>
        /// Intel 64 (Itanium)
        /// </summary>
        IA64 = 0x0200,

        /// <summary>
        /// MIPS
        /// </summary>
        MIPS16 = 0x0266,

        /// <summary>
        /// ALPHA64
        /// </summary>
        Alpha64 = 0x0284,

        /// <summary>
        /// MIPS
        /// </summary>
        MIPSFPU = 0x0366,

        /// <summary>
        /// MIPS
        /// </summary>
        MIPSFPU16 = 0x0466,

        /// <summary>
        /// AXP64
        /// </summary>
        AXP64 = Alpha64,

        /// <summary>
        /// Infineon
        /// </summary>
        TRICORE = 0x0520,

        /// <summary>
        /// CEF
        /// </summary>
        CEF = 0x0CEF,

        /// <summary>
        /// EFI Byte Code
        /// </summary>
        EBC = 0x0EBC,

        /// <summary>
        /// AMD64 (K8) (x64)
        /// </summary>
        AMD64 = 0x8664,

        /// <summary>
        /// M32R little-endian
        /// </summary>
        M32R = 0x9041,

        /// <summary>
        /// CEE
        /// </summary>
        CEE = 0xC0EE,
    }

    /// <summary>
    /// PE image file characteristics flags.
    /// </summary>
    [Flags]
    public enum ImageCharacteristics : ushort
    {
        /// <summary>
        /// Relocation information was stripped from the file. The file must be
        /// loaded at its preferred base address. If the base address is not
        /// available, the loader reports an error.
        /// </summary>
        RelocsStripped = 0x0001,

        /// <summary>
        /// File is executable  (i.e. no unresolved external references).
        /// </summary>
        ExecutableImage = 0x0002,

        /// <summary>
        /// COFF Line numbers stripped from file.
        /// </summary>
        LineNumsStripped = 0x0004,

        /// <summary>
        /// COFF Local symbols stripped from file.
        /// </summary>
        LocalSymbolsStripped = 0x0008,

        /// <summary>
        /// Aggressively trim working set. This flag is obsolete.
        /// </summary>
        AggresiveWorkingSetTrim = 0x0010,

        /// <summary>
        /// App can handle >2gb addresses
        /// </summary>
        LargeAddressAware = 0x0020,

        /// <summary>
        /// Bytes of machine word are reversed. This flag is obsolete.
        /// </summary>
        BytesReversedLo = 0x0080,

        /// <summary>
        /// 32 bit word machine.
        /// </summary>
        Machine32Bit = 0x0100,

        /// <summary>
        /// Debugging info stripped from file in another file
        /// </summary>
        DebugInfoStripped = 0x0200,

        /// <summary>
        /// If Image is on removable media, copy and run from the swap file.
        /// </summary>
        RemovableRunFromSwap = 0x0400,

        /// <summary>
        /// If Image is on Net, copy and run from the swap file.
        /// </summary>
        NetRunFromSwap = 0x0800,

        /// <summary>
        /// The image is a system file.
        /// </summary>
        System = 0x1000,

        /// <summary>
        /// The image is a DLL file. While it is an executable file, it cannot be run directly.
        /// </summary>
        Dll = 0x2000,

        /// <summary>
        /// File should only be run on a uniprocessor machine
        /// </summary>
        UniprocessorSystemOnly = 0x4000,

        /// <summary>
        /// Bytes of machine word are reversed. This flag is obsolete.
        /// </summary>
        BytesReversedHigh = 0x8000,
    }

    /// <summary>
    /// The subsystem under which the PE is executed.
    /// </summary>
    public enum ImageSubsystem : ushort
    {
        /// <summary>
        /// Unknown subsystem
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// No subsystem required.
        /// </summary>
        Native = 1,

        /// <summary>
        /// Windows GUI-mode subsystem.
        /// </summary>
        /// <remarks>
        /// This does not imply the application has a GUI, just that it is not console-based.
        /// </remarks>
        WindowsGui = 2,

        /// <summary>
        /// Windows console subsystem.
        /// </summary>
        WindowsConsole = 3,

        /// <summary>
        /// OS/2 console subsystem.
        /// </summary>
        OS2Console = 5,

        /// <summary>
        /// POSIX console subsystem.
        /// </summary>
        PosixConsole = 7,

        /// <summary>
        /// Native Win9x driver
        /// </summary>
        NativeWindows = 8,

        /// <summary>
        /// Windows CE subsystem.
        /// </summary>
        WindowsCeGui = 9,

        /// <summary>
        /// Extensible-Firmware Interface (EFI) application.
        /// </summary>
        EFIApplication = 10,

        /// <summary>
        /// Extensible-Firmware Interface (EFI) driver with boot services.
        /// </summary>
        EFIBootServiceDriver = 11,

        /// <summary>
        /// Extensible-Firmware Interface (EFI) driver with runtime services..
        /// </summary>
        EFIRuntimeDriver = 12,

        /// <summary>
        /// Extensible-Firmware Interface (EFI) ROM image.
        /// </summary>
        EFIRom = 13,

        /// <summary>
        /// XBox subsystem.
        /// </summary>
        XBox = 14,

        /// <summary>
        /// Boot application.
        /// </summary>
        WindowsBootApplication = 16,
    }

    /// <summary>
    /// The DLL characteristics of the image.
    /// </summary>
    [Flags]
    public enum DllCharacteristics : ushort
    {
        /// <summary>
        /// Image can handle a high entropy 64-bit virtual address space.
        /// </summary>
        HighEntropyVirtualAddresses = 0x0020,

        /// <summary>
        /// DLL can be relocated at load time.
        /// </summary>
        DynamicBase = 0x0040,

        /// <summary>
        /// Code Integrity checks are enforced.
        /// </summary>
        ForceIntegrityChecks = 0x0080,

        /// <summary>
        /// The image is compatible with data execution prevention (DEP).
        /// </summary>
        NxCompatible = 0x0100,

        /// <summary>
        /// The image is isolation aware, but should not be isolated.
        /// </summary>
        NoIsolation = 0x0200,

        /// <summary>
        /// The image does not use structured exception handling (SEH).
        /// No handlers can be called in this image.
        /// </summary>
        NoStructuredExceptionHandling = 0x0400,

        /// <summary>
        /// Do not bind the image.
        /// </summary>
        NoBind = 0x0800,

        /// <summary>
        /// Image must execute in an AppContainer.
        /// </summary>
        AppContainer = 0x1000,

        /// <summary>
        /// A WDM driver.
        /// </summary>
        WdmDriver = 0x2000,

        /// <summary>
        /// Image supports Control Flow Guard.
        /// </summary>
        GuardControlFlow = 0x4000,

        /// <summary>
        /// The image is terminal server aware.
        /// </summary>
        TerminalServerAware = 0x8000,
    }
}
