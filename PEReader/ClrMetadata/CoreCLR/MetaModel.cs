//=============================================================================
// This code is automatically generated.
//=============================================================================
using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace PEReader.ClrMetadata.CoreCLR
{
    #region Record Types

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ModuleRec
    {
        public const int COL_Generation = 0;
        public const int COL_Name = 1;
        public const int COL_Mvid = 2;
        public const int COL_EncId = 3;
        public const int COL_EncBaseId = 4;
        public const int COL_COUNT = 5;
        public const int COL_KEY = 6;

        public ushort m_Generation;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct TypeRefRec
    {
        public const int COL_ResolutionScope = 0;
        public const int COL_Name = 1;
        public const int COL_Namespace = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct TypeDefRec
    {
        public const int COL_Flags = 0;
        public const int COL_Name = 1;
        public const int COL_Namespace = 2;
        public const int COL_Extends = 3;
        public const int COL_FieldList = 4;
        public const int COL_MethodList = 5;
        public const int COL_COUNT = 6;
        public const int COL_KEY = 7;

        public uint m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct FieldPtrRec
    {
        public const int COL_Field = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct FieldRec
    {
        public const int COL_Flags = 0;
        public const int COL_Name = 1;
        public const int COL_Signature = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

        public ushort m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct MethodPtrRec
    {
        public const int COL_Method = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct MethodRec
    {
        public const int COL_RVA = 0;
        public const int COL_ImplFlags = 1;
        public const int COL_Flags = 2;
        public const int COL_Name = 3;
        public const int COL_Signature = 4;
        public const int COL_ParamList = 5;
        public const int COL_COUNT = 6;
        public const int COL_KEY = 7;

        public uint m_RVA;
        public ushort m_ImplFlags;
        public ushort m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ParamPtrRec
    {
        public const int COL_Param = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ParamRec
    {
        public const int COL_Flags = 0;
        public const int COL_Sequence = 1;
        public const int COL_Name = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

        public ushort m_Flags;
        public ushort m_Sequence;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct InterfaceImplRec
    {
        public const int COL_Class = 0;
        public const int COL_Interface = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = COL_Class;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct MemberRefRec
    {
        public const int COL_Class = 0;
        public const int COL_Name = 1;
        public const int COL_Signature = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ConstantRec
    {
        public const int COL_Type = 0;
        public const int COL_Parent = 1;
        public const int COL_Value = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = COL_Parent;

        public byte m_Type;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct CustomAttributeRec
    {
        public const int COL_Parent = 0;
        public const int COL_Type = 1;
        public const int COL_Value = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = COL_Parent;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct FieldMarshalRec
    {
        public const int COL_Parent = 0;
        public const int COL_NativeType = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = COL_Parent;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct DeclSecurityRec
    {
        public const int COL_Action = 0;
        public const int COL_Parent = 1;
        public const int COL_PermissionSet = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = COL_Parent;

        public short m_Action;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ClassLayoutRec
    {
        public const int COL_PackingSize = 0;
        public const int COL_ClassSize = 1;
        public const int COL_Parent = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = COL_Parent;

        public ushort m_PackingSize;
        public uint m_ClassSize;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct FieldLayoutRec
    {
        public const int COL_OffSet = 0;
        public const int COL_Field = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = COL_Field;

        public uint m_OffSet;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct StandAloneSigRec
    {
        public const int COL_Signature = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct EventMapRec
    {
        public const int COL_Parent = 0;
        public const int COL_EventList = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = 3;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct EventPtrRec
    {
        public const int COL_Event = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct EventRec
    {
        public const int COL_EventFlags = 0;
        public const int COL_Name = 1;
        public const int COL_EventType = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

        public ushort m_EventFlags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct PropertyMapRec
    {
        public const int COL_Parent = 0;
        public const int COL_PropertyList = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = 3;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct PropertyPtrRec
    {
        public const int COL_Property = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct PropertyRec
    {
        public const int COL_PropFlags = 0;
        public const int COL_Name = 1;
        public const int COL_Type = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

        public ushort m_PropFlags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct MethodSemanticsRec
    {
        public const int COL_Semantic = 0;
        public const int COL_Method = 1;
        public const int COL_Association = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = COL_Association;

        public ushort m_Semantic;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct MethodImplRec
    {
        public const int COL_Class = 0;
        public const int COL_MethodBody = 1;
        public const int COL_MethodDeclaration = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = COL_Class;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ModuleRefRec
    {
        public const int COL_Name = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct TypeSpecRec
    {
        public const int COL_Signature = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ENCLogRec
    {
        public const int COL_Token = 0;
        public const int COL_FuncCode = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = 3;

        public uint m_Token;
        public uint m_FuncCode;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ImplMapRec
    {
        public const int COL_MappingFlags = 0;
        public const int COL_MemberForwarded = 1;
        public const int COL_ImportName = 2;
        public const int COL_ImportScope = 3;
        public const int COL_COUNT = 4;
        public const int COL_KEY = COL_MemberForwarded;

        public ushort m_MappingFlags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ENCMapRec
    {
        public const int COL_Token = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

        public uint m_Token;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct FieldRVARec
    {
        public const int COL_RVA = 0;
        public const int COL_Field = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = COL_Field;

        public uint m_RVA;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct AssemblyRec
    {
        public const int COL_HashAlgId = 0;
        public const int COL_MajorVersion = 1;
        public const int COL_MinorVersion = 2;
        public const int COL_BuildNumber = 3;
        public const int COL_RevisionNumber = 4;
        public const int COL_Flags = 5;
        public const int COL_PublicKey = 6;
        public const int COL_Name = 7;
        public const int COL_Locale = 8;
        public const int COL_COUNT = 9;
        public const int COL_KEY = 10;

        public uint m_HashAlgId;
        public ushort m_MajorVersion;
        public ushort m_MinorVersion;
        public ushort m_BuildNumber;
        public ushort m_RevisionNumber;
        public uint m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct AssemblyProcessorRec
    {
        public const int COL_Processor = 0;
        public const int COL_COUNT = 1;
        public const int COL_KEY = 2;

        public uint m_Processor;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct AssemblyOSRec
    {
        public const int COL_OSPlatformId = 0;
        public const int COL_OSMajorVersion = 1;
        public const int COL_OSMinorVersion = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

        public uint m_OSPlatformId;
        public uint m_OSMajorVersion;
        public uint m_OSMinorVersion;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct AssemblyRefRec
    {
        public const int COL_MajorVersion = 0;
        public const int COL_MinorVersion = 1;
        public const int COL_BuildNumber = 2;
        public const int COL_RevisionNumber = 3;
        public const int COL_Flags = 4;
        public const int COL_PublicKeyOrToken = 5;
        public const int COL_Name = 6;
        public const int COL_Locale = 7;
        public const int COL_HashValue = 8;
        public const int COL_COUNT = 9;
        public const int COL_KEY = 10;

        public ushort m_MajorVersion;
        public ushort m_MinorVersion;
        public ushort m_BuildNumber;
        public ushort m_RevisionNumber;
        public uint m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct AssemblyRefProcessorRec
    {
        public const int COL_Processor = 0;
        public const int COL_AssemblyRef = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = 3;

        public uint m_Processor;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct AssemblyRefOSRec
    {
        public const int COL_OSPlatformId = 0;
        public const int COL_OSMajorVersion = 1;
        public const int COL_OSMinorVersion = 2;
        public const int COL_AssemblyRef = 3;
        public const int COL_COUNT = 4;
        public const int COL_KEY = 5;

        public uint m_OSPlatformId;
        public uint m_OSMajorVersion;
        public uint m_OSMinorVersion;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct FileRec
    {
        public const int COL_Flags = 0;
        public const int COL_Name = 1;
        public const int COL_HashValue = 2;
        public const int COL_COUNT = 3;
        public const int COL_KEY = 4;

        public uint m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ExportedTypeRec
    {
        public const int COL_Flags = 0;
        public const int COL_TypeDefId = 1;
        public const int COL_TypeName = 2;
        public const int COL_TypeNamespace = 3;
        public const int COL_Implementation = 4;
        public const int COL_COUNT = 5;
        public const int COL_KEY = 6;

        public uint m_Flags;
        public uint m_TypeDefId;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct ManifestResourceRec
    {
        public const int COL_Offset = 0;
        public const int COL_Flags = 1;
        public const int COL_Name = 2;
        public const int COL_Implementation = 3;
        public const int COL_COUNT = 4;
        public const int COL_KEY = 5;

        public uint m_Offset;
        public uint m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct NestedClassRec
    {
        public const int COL_NestedClass = 0;
        public const int COL_EnclosingClass = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = COL_NestedClass;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct GenericParamRec
    {
        public const int COL_Number = 0;
        public const int COL_Flags = 1;
        public const int COL_Owner = 2;
        public const int COL_Name = 3;
        public const int COL_COUNT = 4;
        public const int COL_KEY = COL_Owner;

        public ushort m_Number;
        public ushort m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct GenericParamV1_1Rec
    {
        public const int COL_Number = 0;
        public const int COL_Flags = 1;
        public const int COL_Owner = 2;
        public const int COL_Name = 3;
        public const int COL_Kind = 4;
        public const int COL_COUNT = 5;
        public const int COL_KEY = COL_Owner;

        public ushort m_Number;
        public ushort m_Flags;
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct MethodSpecRec
    {
        public const int COL_Method = 0;
        public const int COL_Instantiation = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = 3;

    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct GenericParamConstraintRec
    {
        public const int COL_Owner = 0;
        public const int COL_Constraint = 1;
        public const int COL_COUNT = 2;
        public const int COL_KEY = COL_Owner;

    }

    #endregion

    #region Full Record Types

    // CS0649 field is never assigned
    // disable since these are populated through reflection.
#pragma warning disable 0649

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ModuleRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_Generation;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.Guid)]
        public uint m_Mvid;

        [ColumnIndex(3, ColumnType.Guid)]
        public uint m_EncId;

        [ColumnIndex(4, ColumnType.Guid)]
        public uint m_EncBaseId;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The Module table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class TypeRefRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.CodedToken, SubType = 11)]
        public uint m_ResolutionScope;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.String)]
        public uint m_Namespace;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The TypeRef table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class TypeDefRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Flags;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.String)]
        public uint m_Namespace;

        [ColumnIndex(3, ColumnType.CodedToken, SubType = 0)]
        public uint m_Extends;

        [ColumnIndex(4, ColumnType.Rid, SubType = 4)]
        public uint m_FieldList;

        [ColumnIndex(5, ColumnType.Rid, SubType = 6)]
        public uint m_MethodList;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The TypeDef table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class FieldPtrRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 4)]
        public uint m_Field;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The FieldPtr table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class FieldRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_Flags;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.Blob)]
        public uint m_Signature;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The Field table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class MethodPtrRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 6)]
        public uint m_Method;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The MethodPtr table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class MethodRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_RVA;

        [ColumnIndex(1, ColumnType.USHORT)]
        public ushort m_ImplFlags;

        [ColumnIndex(2, ColumnType.USHORT)]
        public ushort m_Flags;

        [ColumnIndex(3, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(4, ColumnType.Blob)]
        public uint m_Signature;

        [ColumnIndex(5, ColumnType.Rid, SubType = 8)]
        public uint m_ParamList;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The Method table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ParamPtrRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 8)]
        public uint m_Param;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The ParamPtr table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ParamRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_Flags;

        [ColumnIndex(1, ColumnType.USHORT)]
        public ushort m_Sequence;

        [ColumnIndex(2, ColumnType.String)]
        public uint m_Name;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The Param table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class InterfaceImplRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 2)]
        public uint m_Class;

        [ColumnIndex(1, ColumnType.CodedToken, SubType = 0)]
        public uint m_Interface;


        public long Key
        {
            get
            {
                return m_Class;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class MemberRefRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.CodedToken, SubType = 5)]
        public uint m_Class;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.Blob)]
        public uint m_Signature;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The MemberRef table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ConstantRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.BYTE)]
        public byte m_Type;

        [ColumnIndex(1, ColumnType.CodedToken, SubType = 1)]
        public uint m_Parent;

        [ColumnIndex(2, ColumnType.Blob)]
        public uint m_Value;


        public long Key
        {
            get
            {
                return m_Parent;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class CustomAttributeRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.CodedToken, SubType = 2)]
        public uint m_Parent;

        [ColumnIndex(1, ColumnType.CodedToken, SubType = 10)]
        public uint m_Type;

        [ColumnIndex(2, ColumnType.Blob)]
        public uint m_Value;


        public long Key
        {
            get
            {
                return m_Parent;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class FieldMarshalRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.CodedToken, SubType = 3)]
        public uint m_Parent;

        [ColumnIndex(1, ColumnType.Blob)]
        public uint m_NativeType;


        public long Key
        {
            get
            {
                return m_Parent;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class DeclSecurityRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.SHORT)]
        public short m_Action;

        [ColumnIndex(1, ColumnType.CodedToken, SubType = 4)]
        public uint m_Parent;

        [ColumnIndex(2, ColumnType.Blob)]
        public uint m_PermissionSet;


        public long Key
        {
            get
            {
                return m_Parent;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ClassLayoutRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_PackingSize;

        [ColumnIndex(1, ColumnType.ULONG)]
        public uint m_ClassSize;

        [ColumnIndex(2, ColumnType.Rid, SubType = 2)]
        public uint m_Parent;


        public long Key
        {
            get
            {
                return m_Parent;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class FieldLayoutRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_OffSet;

        [ColumnIndex(1, ColumnType.Rid, SubType = 4)]
        public uint m_Field;


        public long Key
        {
            get
            {
                return m_Field;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class StandAloneSigRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Blob)]
        public uint m_Signature;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The StandAloneSig table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class EventMapRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 2)]
        public uint m_Parent;

        [ColumnIndex(1, ColumnType.Rid, SubType = 20)]
        public uint m_EventList;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The EventMap table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class EventPtrRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 20)]
        public uint m_Event;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The EventPtr table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class EventRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_EventFlags;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.CodedToken, SubType = 0)]
        public uint m_EventType;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The Event table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class PropertyMapRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 2)]
        public uint m_Parent;

        [ColumnIndex(1, ColumnType.Rid, SubType = 23)]
        public uint m_PropertyList;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The PropertyMap table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class PropertyPtrRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 23)]
        public uint m_Property;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The PropertyPtr table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class PropertyRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_PropFlags;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.Blob)]
        public uint m_Type;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The Property table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class MethodSemanticsRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_Semantic;

        [ColumnIndex(1, ColumnType.Rid, SubType = 6)]
        public uint m_Method;

        [ColumnIndex(2, ColumnType.CodedToken, SubType = 6)]
        public uint m_Association;


        public long Key
        {
            get
            {
                return m_Association;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class MethodImplRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 2)]
        public uint m_Class;

        [ColumnIndex(1, ColumnType.CodedToken, SubType = 7)]
        public uint m_MethodBody;

        [ColumnIndex(2, ColumnType.CodedToken, SubType = 7)]
        public uint m_MethodDeclaration;


        public long Key
        {
            get
            {
                return m_Class;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ModuleRefRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.String)]
        public uint m_Name;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The ModuleRef table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class TypeSpecRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Blob)]
        public uint m_Signature;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The TypeSpec table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ENCLogRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Token;

        [ColumnIndex(1, ColumnType.ULONG)]
        public uint m_FuncCode;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The ENCLog table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ImplMapRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_MappingFlags;

        [ColumnIndex(1, ColumnType.CodedToken, SubType = 8)]
        public uint m_MemberForwarded;

        [ColumnIndex(2, ColumnType.String)]
        public uint m_ImportName;

        [ColumnIndex(3, ColumnType.Rid, SubType = 26)]
        public uint m_ImportScope;


        public long Key
        {
            get
            {
                return m_MemberForwarded;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ENCMapRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Token;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The ENCMap table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class FieldRVARec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_RVA;

        [ColumnIndex(1, ColumnType.Rid, SubType = 4)]
        public uint m_Field;


        public long Key
        {
            get
            {
                return m_Field;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class AssemblyRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_HashAlgId;

        [ColumnIndex(1, ColumnType.USHORT)]
        public ushort m_MajorVersion;

        [ColumnIndex(2, ColumnType.USHORT)]
        public ushort m_MinorVersion;

        [ColumnIndex(3, ColumnType.USHORT)]
        public ushort m_BuildNumber;

        [ColumnIndex(4, ColumnType.USHORT)]
        public ushort m_RevisionNumber;

        [ColumnIndex(5, ColumnType.ULONG)]
        public uint m_Flags;

        [ColumnIndex(6, ColumnType.Blob)]
        public uint m_PublicKey;

        [ColumnIndex(7, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(8, ColumnType.String)]
        public uint m_Locale;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The Assembly table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class AssemblyProcessorRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Processor;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The AssemblyProcessor table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class AssemblyOSRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_OSPlatformId;

        [ColumnIndex(1, ColumnType.ULONG)]
        public uint m_OSMajorVersion;

        [ColumnIndex(2, ColumnType.ULONG)]
        public uint m_OSMinorVersion;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The AssemblyOS table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class AssemblyRefRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_MajorVersion;

        [ColumnIndex(1, ColumnType.USHORT)]
        public ushort m_MinorVersion;

        [ColumnIndex(2, ColumnType.USHORT)]
        public ushort m_BuildNumber;

        [ColumnIndex(3, ColumnType.USHORT)]
        public ushort m_RevisionNumber;

        [ColumnIndex(4, ColumnType.ULONG)]
        public uint m_Flags;

        [ColumnIndex(5, ColumnType.Blob)]
        public uint m_PublicKeyOrToken;

        [ColumnIndex(6, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(7, ColumnType.String)]
        public uint m_Locale;

        [ColumnIndex(8, ColumnType.Blob)]
        public uint m_HashValue;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The AssemblyRef table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class AssemblyRefProcessorRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Processor;

        [ColumnIndex(1, ColumnType.Rid, SubType = 35)]
        public uint m_AssemblyRef;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The AssemblyRefProcessor table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class AssemblyRefOSRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_OSPlatformId;

        [ColumnIndex(1, ColumnType.ULONG)]
        public uint m_OSMajorVersion;

        [ColumnIndex(2, ColumnType.ULONG)]
        public uint m_OSMinorVersion;

        [ColumnIndex(3, ColumnType.Rid, SubType = 35)]
        public uint m_AssemblyRef;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The AssemblyRefOS table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class FileRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Flags;

        [ColumnIndex(1, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(2, ColumnType.Blob)]
        public uint m_HashValue;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The File table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ExportedTypeRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Flags;

        [ColumnIndex(1, ColumnType.ULONG)]
        public uint m_TypeDefId;

        [ColumnIndex(2, ColumnType.String)]
        public uint m_TypeName;

        [ColumnIndex(3, ColumnType.String)]
        public uint m_TypeNamespace;

        [ColumnIndex(4, ColumnType.CodedToken, SubType = 9)]
        public uint m_Implementation;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The ExportedType table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class ManifestResourceRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.ULONG)]
        public uint m_Offset;

        [ColumnIndex(1, ColumnType.ULONG)]
        public uint m_Flags;

        [ColumnIndex(2, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(3, ColumnType.CodedToken, SubType = 9)]
        public uint m_Implementation;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The ManifestResource table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class NestedClassRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 2)]
        public uint m_NestedClass;

        [ColumnIndex(1, ColumnType.Rid, SubType = 2)]
        public uint m_EnclosingClass;


        public long Key
        {
            get
            {
                return m_NestedClass;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class GenericParamRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_Number;

        [ColumnIndex(1, ColumnType.USHORT)]
        public ushort m_Flags;

        [ColumnIndex(2, ColumnType.CodedToken, SubType = 12)]
        public uint m_Owner;

        [ColumnIndex(3, ColumnType.String)]
        public uint m_Name;


        public long Key
        {
            get
            {
                return m_Owner;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class GenericParamV1_1Rec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.USHORT)]
        public ushort m_Number;

        [ColumnIndex(1, ColumnType.USHORT)]
        public ushort m_Flags;

        [ColumnIndex(2, ColumnType.CodedToken, SubType = 12)]
        public uint m_Owner;

        [ColumnIndex(3, ColumnType.String)]
        public uint m_Name;

        [ColumnIndex(4, ColumnType.CodedToken, SubType = 0)]
        public uint m_Kind;


        public long Key
        {
            get
            {
                return m_Owner;
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class MethodSpecRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.CodedToken, SubType = 7)]
        public uint m_Method;

        [ColumnIndex(1, ColumnType.Blob)]
        public uint m_Instantiation;


        public long Key
        {
            get
            {
                throw new InvalidOperationException("The MethodSpec table does not define a key field.");
            }
        }
    }

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal sealed class GenericParamConstraintRec_Full : IMetadataRecord
    {
        [ColumnIndex(0, ColumnType.Rid, SubType = 42)]
        public uint m_Owner;

        [ColumnIndex(1, ColumnType.CodedToken, SubType = 0)]
        public uint m_Constraint;


        public long Key
        {
            get
            {
                return m_Owner;
            }
        }
    }


#pragma warning restore 0649

    #endregion

    #region Schema Enums

    internal enum ClrTable
    {
        Module,
        TypeRef,
        TypeDef,
        FieldPtr,
        Field,
        MethodPtr,
        Method,
        ParamPtr,
        Param,
        InterfaceImpl,
        MemberRef,
        Constant,
        CustomAttribute,
        FieldMarshal,
        DeclSecurity,
        ClassLayout,
        FieldLayout,
        StandAloneSig,
        EventMap,
        EventPtr,
        Event,
        PropertyMap,
        PropertyPtr,
        Property,
        MethodSemantics,
        MethodImpl,
        ModuleRef,
        TypeSpec,
        ImplMap,
        FieldRVA,
        ENCLog,
        ENCMap,
        Assembly,
        AssemblyProcessor,
        AssemblyOS,
        AssemblyRef,
        AssemblyRefProcessor,
        AssemblyRefOS,
        File,
        ExportedType,
        ManifestResource,
        NestedClass,
        GenericParam,
        MethodSpec,
        GenericParamConstraint,
    }

    internal enum ClrCodedToken
    {
        TypeDefOrRef,
        HasConstant,
        HasCustomAttribute,
        HasFieldMarshal,
        HasDeclSecurity,
        MemberRefParent,
        HasSemantic,
        MethodDefOrRef,
        MemberForwarded,
        Implementation,
        CustomAttributeType,
        ResolutionScope,
        TypeOrMethodDef,
    }

    #endregion

    #region Schema Definitions

    [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
    internal static class MetaModel
    {
        public const int MajorVersion = 2;
        public const int MinorVersion = 0;

        #region Constants

        public const int iRidMax = 63;
        public const int iCodedToken = 64;
        public const int iCodedTokenMax = 95;
        public const int iSHORT = 96;
        public const int iUSHORT = 97;
        public const int iLONG = 98;
        public const int iULONG = 99;
        public const int iBYTE = 100;
        public const int iSTRING = 101;
        public const int iGUID = 102;
        public const int iBLOB = 103;

        public const int CDTKN_TypeDefOrRef = 0;
        public const int CDTKN_HasConstant = 1;
        public const int CDTKN_HasCustomAttribute = 2;
        public const int CDTKN_HasFieldMarshal = 3;
        public const int CDTKN_HasDeclSecurity = 4;
        public const int CDTKN_MemberRefParent = 5;
        public const int CDTKN_HasSemantic = 6;
        public const int CDTKN_MethodDefOrRef = 7;
        public const int CDTKN_MemberForwarded = 8;
        public const int CDTKN_Implementation = 9;
        public const int CDTKN_CustomAttributeType = 10;
        public const int CDTKN_ResolutionScope = 11;
        public const int CDTKN_TypeOrMethodDef = 12;
        public const int CDTKN_COUNT = 13;

        public const int TBL_Module = 0;
        public const int TBL_TypeRef = 1;
        public const int TBL_TypeDef = 2;
        public const int TBL_FieldPtr = 3;
        public const int TBL_Field = 4;
        public const int TBL_MethodPtr = 5;
        public const int TBL_Method = 6;
        public const int TBL_ParamPtr = 7;
        public const int TBL_Param = 8;
        public const int TBL_InterfaceImpl = 9;
        public const int TBL_MemberRef = 10;
        public const int TBL_Constant = 11;
        public const int TBL_CustomAttribute = 12;
        public const int TBL_FieldMarshal = 13;
        public const int TBL_DeclSecurity = 14;
        public const int TBL_ClassLayout = 15;
        public const int TBL_FieldLayout = 16;
        public const int TBL_StandAloneSig = 17;
        public const int TBL_EventMap = 18;
        public const int TBL_EventPtr = 19;
        public const int TBL_Event = 20;
        public const int TBL_PropertyMap = 21;
        public const int TBL_PropertyPtr = 22;
        public const int TBL_Property = 23;
        public const int TBL_MethodSemantics = 24;
        public const int TBL_MethodImpl = 25;
        public const int TBL_ModuleRef = 26;
        public const int TBL_TypeSpec = 27;
        public const int TBL_ImplMap = 28;
        public const int TBL_FieldRVA = 29;
        public const int TBL_ENCLog = 30;
        public const int TBL_ENCMap = 31;
        public const int TBL_Assembly = 32;
        public const int TBL_AssemblyProcessor = 33;
        public const int TBL_AssemblyOS = 34;
        public const int TBL_AssemblyRef = 35;
        public const int TBL_AssemblyRefProcessor = 36;
        public const int TBL_AssemblyRefOS = 37;
        public const int TBL_File = 38;
        public const int TBL_ExportedType = 39;
        public const int TBL_ManifestResource = 40;
        public const int TBL_NestedClass = 41;
        public const int TBL_GenericParam = 42;
        public const int TBL_MethodSpec = 43;
        public const int TBL_GenericParamConstraint = 44;
        public const int TBL_COUNT = 45;
        public const int TBL_COUNT_V1 = TBL_NestedClass + 1;
        public const int TBL_COUNT_V2 = TBL_GenericParamConstraint + 1;

        #endregion


        #region Column Definitions

        public static readonly CMiniColDef[] rModuleCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iGUID),
            new CMiniColDef(iGUID),
            new CMiniColDef(iGUID),
        };

        public static readonly CMiniColDef[] rTypeRefCols = {
            new CMiniColDef(iCodedToken+CDTKN_ResolutionScope),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iSTRING),
        };

        public static readonly CMiniColDef[] rTypeDefCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iCodedToken+CDTKN_TypeDefOrRef),
            new CMiniColDef(TBL_Field),
            new CMiniColDef(TBL_Method),
        };

        public static readonly CMiniColDef[] rFieldPtrCols = {
            new CMiniColDef(TBL_Field),
        };

        public static readonly CMiniColDef[] rFieldCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rMethodPtrCols = {
            new CMiniColDef(TBL_Method),
        };

        public static readonly CMiniColDef[] rMethodCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iUSHORT, 4, 2),
            new CMiniColDef(iUSHORT, 6, 2),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iBLOB),
            new CMiniColDef(TBL_Param),
        };

        public static readonly CMiniColDef[] rParamPtrCols = {
            new CMiniColDef(TBL_Param),
        };

        public static readonly CMiniColDef[] rParamCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iUSHORT, 2, 2),
            new CMiniColDef(iSTRING),
        };

        public static readonly CMiniColDef[] rInterfaceImplCols = {
            new CMiniColDef(TBL_TypeDef),
            new CMiniColDef(iCodedToken+CDTKN_TypeDefOrRef),
        };

        public static readonly CMiniColDef[] rMemberRefCols = {
            new CMiniColDef(iCodedToken+CDTKN_MemberRefParent),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rConstantCols = {
            new CMiniColDef(iBYTE, 0, 1),
            new CMiniColDef(iCodedToken+CDTKN_HasConstant),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rCustomAttributeCols = {
            new CMiniColDef(iCodedToken+CDTKN_HasCustomAttribute),
            new CMiniColDef(iCodedToken+CDTKN_CustomAttributeType),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rFieldMarshalCols = {
            new CMiniColDef(iCodedToken+CDTKN_HasFieldMarshal),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rDeclSecurityCols = {
            new CMiniColDef(iSHORT, 0, 2),
            new CMiniColDef(iCodedToken+CDTKN_HasDeclSecurity),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rClassLayoutCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iULONG, 2, 4),
            new CMiniColDef(TBL_TypeDef),
        };

        public static readonly CMiniColDef[] rFieldLayoutCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(TBL_Field),
        };

        public static readonly CMiniColDef[] rStandAloneSigCols = {
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rEventMapCols = {
            new CMiniColDef(TBL_TypeDef),
            new CMiniColDef(TBL_Event),
        };

        public static readonly CMiniColDef[] rEventPtrCols = {
            new CMiniColDef(TBL_Event),
        };

        public static readonly CMiniColDef[] rEventCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iCodedToken+CDTKN_TypeDefOrRef),
        };

        public static readonly CMiniColDef[] rPropertyMapCols = {
            new CMiniColDef(TBL_TypeDef),
            new CMiniColDef(TBL_Property),
        };

        public static readonly CMiniColDef[] rPropertyPtrCols = {
            new CMiniColDef(TBL_Property),
        };

        public static readonly CMiniColDef[] rPropertyCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rMethodSemanticsCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(TBL_Method),
            new CMiniColDef(iCodedToken+CDTKN_HasSemantic),
        };

        public static readonly CMiniColDef[] rMethodImplCols = {
            new CMiniColDef(TBL_TypeDef),
            new CMiniColDef(iCodedToken+CDTKN_MethodDefOrRef),
            new CMiniColDef(iCodedToken+CDTKN_MethodDefOrRef),
        };

        public static readonly CMiniColDef[] rModuleRefCols = {
            new CMiniColDef(iSTRING),
        };

        public static readonly CMiniColDef[] rTypeSpecCols = {
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rENCLogCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iULONG, 4, 4),
        };

        public static readonly CMiniColDef[] rImplMapCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iCodedToken+CDTKN_MemberForwarded),
            new CMiniColDef(iSTRING),
            new CMiniColDef(TBL_ModuleRef),
        };

        public static readonly CMiniColDef[] rENCMapCols = {
            new CMiniColDef(iULONG, 0, 4),
        };

        public static readonly CMiniColDef[] rFieldRVACols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(TBL_Field),
        };

        public static readonly CMiniColDef[] rAssemblyCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iUSHORT, 4, 2),
            new CMiniColDef(iUSHORT, 6, 2),
            new CMiniColDef(iUSHORT, 8, 2),
            new CMiniColDef(iUSHORT, 10, 2),
            new CMiniColDef(iULONG, 12, 4),
            new CMiniColDef(iBLOB),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iSTRING),
        };

        public static readonly CMiniColDef[] rAssemblyProcessorCols = {
            new CMiniColDef(iULONG, 0, 4),
        };

        public static readonly CMiniColDef[] rAssemblyOSCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iULONG, 4, 4),
            new CMiniColDef(iULONG, 8, 4),
        };

        public static readonly CMiniColDef[] rAssemblyRefCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iUSHORT, 2, 2),
            new CMiniColDef(iUSHORT, 4, 2),
            new CMiniColDef(iUSHORT, 6, 2),
            new CMiniColDef(iULONG, 8, 4),
            new CMiniColDef(iBLOB),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rAssemblyRefProcessorCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(TBL_AssemblyRef),
        };

        public static readonly CMiniColDef[] rAssemblyRefOSCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iULONG, 4, 4),
            new CMiniColDef(iULONG, 8, 4),
            new CMiniColDef(TBL_AssemblyRef),
        };

        public static readonly CMiniColDef[] rFileCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rExportedTypeCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iULONG, 4, 4),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iCodedToken+CDTKN_Implementation),
        };

        public static readonly CMiniColDef[] rManifestResourceCols = {
            new CMiniColDef(iULONG, 0, 4),
            new CMiniColDef(iULONG, 4, 4),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iCodedToken+CDTKN_Implementation),
        };

        public static readonly CMiniColDef[] rNestedClassCols = {
            new CMiniColDef(TBL_TypeDef),
            new CMiniColDef(TBL_TypeDef),
        };

        public static readonly CMiniColDef[] rGenericParamCols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iUSHORT, 2, 2),
            new CMiniColDef(iCodedToken+CDTKN_TypeOrMethodDef),
            new CMiniColDef(iSTRING),
        };

        public static readonly CMiniColDef[] rGenericParamV1_1Cols = {
            new CMiniColDef(iUSHORT, 0, 2),
            new CMiniColDef(iUSHORT, 2, 2),
            new CMiniColDef(iCodedToken+CDTKN_TypeOrMethodDef),
            new CMiniColDef(iSTRING),
            new CMiniColDef(iCodedToken+CDTKN_TypeDefOrRef),
        };

        public static readonly CMiniColDef[] rMethodSpecCols = {
            new CMiniColDef(iCodedToken+CDTKN_MethodDefOrRef),
            new CMiniColDef(iBLOB),
        };

        public static readonly CMiniColDef[] rGenericParamConstraintCols = {
            new CMiniColDef(TBL_GenericParam),
            new CMiniColDef(iCodedToken+CDTKN_TypeDefOrRef),
        };

        #endregion

        #region Column Name Definitions

        public static readonly string[] rModuleColNames = {
            "Generation",
            "Name",
            "Mvid",
            "EncId",
            "EncBaseId",
        };

        public static readonly string[] rTypeRefColNames = {
            "ResolutionScope",
            "Name",
            "Namespace",
        };

        public static readonly string[] rTypeDefColNames = {
            "Flags",
            "Name",
            "Namespace",
            "Extends",
            "FieldList",
            "MethodList",
        };

        public static readonly string[] rFieldPtrColNames = {
            "Field",
        };

        public static readonly string[] rFieldColNames = {
            "Flags",
            "Name",
            "Signature",
        };

        public static readonly string[] rMethodPtrColNames = {
            "Method",
        };

        public static readonly string[] rMethodColNames = {
            "RVA",
            "ImplFlags",
            "Flags",
            "Name",
            "Signature",
            "ParamList",
        };

        public static readonly string[] rParamPtrColNames = {
            "Param",
        };

        public static readonly string[] rParamColNames = {
            "Flags",
            "Sequence",
            "Name",
        };

        public static readonly string[] rInterfaceImplColNames = {
            "Class",
            "Interface",
        };

        public static readonly string[] rMemberRefColNames = {
            "Class",
            "Name",
            "Signature",
        };

        public static readonly string[] rConstantColNames = {
            "Type",
            "Parent",
            "Value",
        };

        public static readonly string[] rCustomAttributeColNames = {
            "Parent",
            "Type",
            "Value",
        };

        public static readonly string[] rFieldMarshalColNames = {
            "Parent",
            "NativeType",
        };

        public static readonly string[] rDeclSecurityColNames = {
            "Action",
            "Parent",
            "PermissionSet",
        };

        public static readonly string[] rClassLayoutColNames = {
            "PackingSize",
            "ClassSize",
            "Parent",
        };

        public static readonly string[] rFieldLayoutColNames = {
            "OffSet",
            "Field",
        };

        public static readonly string[] rStandAloneSigColNames = {
            "Signature",
        };

        public static readonly string[] rEventMapColNames = {
            "Parent",
            "EventList",
        };

        public static readonly string[] rEventPtrColNames = {
            "Event",
        };

        public static readonly string[] rEventColNames = {
            "EventFlags",
            "Name",
            "EventType",
        };

        public static readonly string[] rPropertyMapColNames = {
            "Parent",
            "PropertyList",
        };

        public static readonly string[] rPropertyPtrColNames = {
            "Property",
        };

        public static readonly string[] rPropertyColNames = {
            "PropFlags",
            "Name",
            "Type",
        };

        public static readonly string[] rMethodSemanticsColNames = {
            "Semantic",
            "Method",
            "Association",
        };

        public static readonly string[] rMethodImplColNames = {
            "Class",
            "MethodBody",
            "MethodDeclaration",
        };

        public static readonly string[] rModuleRefColNames = {
            "Name",
        };

        public static readonly string[] rTypeSpecColNames = {
            "Signature",
        };

        public static readonly string[] rENCLogColNames = {
            "Token",
            "FuncCode",
        };

        public static readonly string[] rImplMapColNames = {
            "MappingFlags",
            "MemberForwarded",
            "ImportName",
            "ImportScope",
        };

        public static readonly string[] rENCMapColNames = {
            "Token",
        };

        public static readonly string[] rFieldRVAColNames = {
            "RVA",
            "Field",
        };

        public static readonly string[] rAssemblyColNames = {
            "HashAlgId",
            "MajorVersion",
            "MinorVersion",
            "BuildNumber",
            "RevisionNumber",
            "Flags",
            "PublicKey",
            "Name",
            "Locale",
        };

        public static readonly string[] rAssemblyProcessorColNames = {
            "Processor",
        };

        public static readonly string[] rAssemblyOSColNames = {
            "OSPlatformId",
            "OSMajorVersion",
            "OSMinorVersion",
        };

        public static readonly string[] rAssemblyRefColNames = {
            "MajorVersion",
            "MinorVersion",
            "BuildNumber",
            "RevisionNumber",
            "Flags",
            "PublicKeyOrToken",
            "Name",
            "Locale",
            "HashValue",
        };

        public static readonly string[] rAssemblyRefProcessorColNames = {
            "Processor",
            "AssemblyRef",
        };

        public static readonly string[] rAssemblyRefOSColNames = {
            "OSPlatformId",
            "OSMajorVersion",
            "OSMinorVersion",
            "AssemblyRef",
        };

        public static readonly string[] rFileColNames = {
            "Flags",
            "Name",
            "HashValue",
        };

        public static readonly string[] rExportedTypeColNames = {
            "Flags",
            "TypeDefId",
            "TypeName",
            "TypeNamespace",
            "Implementation",
        };

        public static readonly string[] rManifestResourceColNames = {
            "Offset",
            "Flags",
            "Name",
            "Implementation",
        };

        public static readonly string[] rNestedClassColNames = {
            "NestedClass",
            "EnclosingClass",
        };

        public static readonly string[] rGenericParamColNames = {
            "Number",
            "Flags",
            "Owner",
            "Name",
        };

        public static readonly string[] rGenericParamV1_1ColNames = {
            "Number",
            "Flags",
            "Owner",
            "Name",
            "Kind",
        };

        public static readonly string[] rMethodSpecColNames = {
            "Method",
            "Instantiation",
        };

        public static readonly string[] rGenericParamConstraintColNames = {
            "Owner",
            "Constraint",
        };


        #endregion


        #region Coded Token Definitions

        public static readonly CorTokenType[] mdtTypeDefOrRef = {
            CorTokenType.mdtTypeDef,
            CorTokenType.mdtTypeRef,
            CorTokenType.mdtTypeSpec,
        };

        public static readonly CorTokenType[] mdtHasConstant = {
            CorTokenType.mdtFieldDef,
            CorTokenType.mdtParamDef,
            CorTokenType.mdtProperty,
        };

        public static readonly CorTokenType[] mdtHasCustomAttribute = {
            CorTokenType.mdtMethodDef,
            CorTokenType.mdtFieldDef,
            CorTokenType.mdtTypeRef,
            CorTokenType.mdtTypeDef,
            CorTokenType.mdtParamDef,
            CorTokenType.mdtInterfaceImpl,
            CorTokenType.mdtMemberRef,
            CorTokenType.mdtModule,
            CorTokenType.mdtPermission,
            CorTokenType.mdtProperty,
            CorTokenType.mdtEvent,
            CorTokenType.mdtSignature,
            CorTokenType.mdtModuleRef,
            CorTokenType.mdtTypeSpec,
            CorTokenType.mdtAssembly,
            CorTokenType.mdtAssemblyRef,
            CorTokenType.mdtFile,
            CorTokenType.mdtExportedType,
            CorTokenType.mdtManifestResource,
            CorTokenType.mdtGenericParam,
            CorTokenType.mdtGenericParamConstraint,
            CorTokenType.mdtMethodSpec,
        };

        public static readonly CorTokenType[] mdtHasFieldMarshal = {
            CorTokenType.mdtFieldDef,
            CorTokenType.mdtParamDef,
        };

        public static readonly CorTokenType[] mdtHasDeclSecurity = {
            CorTokenType.mdtTypeDef,
            CorTokenType.mdtMethodDef,
            CorTokenType.mdtAssembly,
        };

        public static readonly CorTokenType[] mdtMemberRefParent = {
            CorTokenType.mdtTypeDef,
            CorTokenType.mdtTypeRef,
            CorTokenType.mdtModuleRef,
            CorTokenType.mdtMethodDef,
            CorTokenType.mdtTypeSpec,
        };

        public static readonly CorTokenType[] mdtHasSemantic = {
            CorTokenType.mdtEvent,
            CorTokenType.mdtProperty,
        };

        public static readonly CorTokenType[] mdtMethodDefOrRef = {
            CorTokenType.mdtMethodDef,
            CorTokenType.mdtMemberRef,
        };

        public static readonly CorTokenType[] mdtMemberForwarded = {
            CorTokenType.mdtFieldDef,
            CorTokenType.mdtMethodDef,
        };

        public static readonly CorTokenType[] mdtImplementation = {
            CorTokenType.mdtFile,
            CorTokenType.mdtAssemblyRef,
            CorTokenType.mdtExportedType,
        };

        public static readonly CorTokenType[] mdtCustomAttributeType = {
            0,
            0,
            CorTokenType.mdtMethodDef,
            CorTokenType.mdtMemberRef,
            0,
        };

        public static readonly CorTokenType[] mdtResolutionScope = {
            CorTokenType.mdtModule,
            CorTokenType.mdtModuleRef,
            CorTokenType.mdtAssemblyRef,
            CorTokenType.mdtTypeRef,
        };

        public static readonly CorTokenType[] mdtTypeOrMethodDef = {
            CorTokenType.mdtTypeDef,
            CorTokenType.mdtMethodDef,
        };


        public static readonly CCodedTokenDef[] g_CodedTokens = {
            new CCodedTokenDef(mdtTypeDefOrRef, "TypeDefOrRef"),
            new CCodedTokenDef(mdtHasConstant, "HasConstant"),
            new CCodedTokenDef(mdtHasCustomAttribute, "HasCustomAttribute"),
            new CCodedTokenDef(mdtHasFieldMarshal, "HasFieldMarshal"),
            new CCodedTokenDef(mdtHasDeclSecurity, "HasDeclSecurity"),
            new CCodedTokenDef(mdtMemberRefParent, "MemberRefParent"),
            new CCodedTokenDef(mdtHasSemantic, "HasSemantic"),
            new CCodedTokenDef(mdtMethodDefOrRef, "MethodDefOrRef"),
            new CCodedTokenDef(mdtMemberForwarded, "MemberForwarded"),
            new CCodedTokenDef(mdtImplementation, "Implementation"),
            new CCodedTokenDef(mdtCustomAttributeType, "CustomAttributeType"),
            new CCodedTokenDef(mdtResolutionScope, "ResolutionScope"),
            new CCodedTokenDef(mdtTypeOrMethodDef, "TypeOrMethodDef"),
        };

        #endregion


        #region Table Definitions

        public static readonly CMiniTableDefEx[] g_Tables = new CMiniTableDefEx[TBL_COUNT] {
            new CMiniTableDefEx(rModuleCols, ModuleRec.COL_KEY, 0, rModuleColNames, "Module", typeof(ModuleRec_Full)),
            new CMiniTableDefEx(rTypeRefCols, TypeRefRec.COL_KEY, 0, rTypeRefColNames, "TypeRef", typeof(TypeRefRec_Full)),
            new CMiniTableDefEx(rTypeDefCols, TypeDefRec.COL_KEY, 0, rTypeDefColNames, "TypeDef", typeof(TypeDefRec_Full)),
            new CMiniTableDefEx(rFieldPtrCols, FieldPtrRec.COL_KEY, 0, rFieldPtrColNames, "FieldPtr", typeof(FieldPtrRec_Full)),
            new CMiniTableDefEx(rFieldCols, FieldRec.COL_KEY, 0, rFieldColNames, "Field", typeof(FieldRec_Full)),
            new CMiniTableDefEx(rMethodPtrCols, MethodPtrRec.COL_KEY, 0, rMethodPtrColNames, "MethodPtr", typeof(MethodPtrRec_Full)),
            new CMiniTableDefEx(rMethodCols, MethodRec.COL_KEY, 0, rMethodColNames, "Method", typeof(MethodRec_Full)),
            new CMiniTableDefEx(rParamPtrCols, ParamPtrRec.COL_KEY, 0, rParamPtrColNames, "ParamPtr", typeof(ParamPtrRec_Full)),
            new CMiniTableDefEx(rParamCols, ParamRec.COL_KEY, 0, rParamColNames, "Param", typeof(ParamRec_Full)),
            new CMiniTableDefEx(rInterfaceImplCols, InterfaceImplRec.COL_KEY, 0, rInterfaceImplColNames, "InterfaceImpl", typeof(InterfaceImplRec_Full)),
            new CMiniTableDefEx(rMemberRefCols, MemberRefRec.COL_KEY, 0, rMemberRefColNames, "MemberRef", typeof(MemberRefRec_Full)),
            new CMiniTableDefEx(rConstantCols, ConstantRec.COL_KEY, 0, rConstantColNames, "Constant", typeof(ConstantRec_Full)),
            new CMiniTableDefEx(rCustomAttributeCols, CustomAttributeRec.COL_KEY, 0, rCustomAttributeColNames, "CustomAttribute", typeof(CustomAttributeRec_Full)),
            new CMiniTableDefEx(rFieldMarshalCols, FieldMarshalRec.COL_KEY, 0, rFieldMarshalColNames, "FieldMarshal", typeof(FieldMarshalRec_Full)),
            new CMiniTableDefEx(rDeclSecurityCols, DeclSecurityRec.COL_KEY, 0, rDeclSecurityColNames, "DeclSecurity", typeof(DeclSecurityRec_Full)),
            new CMiniTableDefEx(rClassLayoutCols, ClassLayoutRec.COL_KEY, 0, rClassLayoutColNames, "ClassLayout", typeof(ClassLayoutRec_Full)),
            new CMiniTableDefEx(rFieldLayoutCols, FieldLayoutRec.COL_KEY, 0, rFieldLayoutColNames, "FieldLayout", typeof(FieldLayoutRec_Full)),
            new CMiniTableDefEx(rStandAloneSigCols, StandAloneSigRec.COL_KEY, 0, rStandAloneSigColNames, "StandAloneSig", typeof(StandAloneSigRec_Full)),
            new CMiniTableDefEx(rEventMapCols, EventMapRec.COL_KEY, 0, rEventMapColNames, "EventMap", typeof(EventMapRec_Full)),
            new CMiniTableDefEx(rEventPtrCols, EventPtrRec.COL_KEY, 0, rEventPtrColNames, "EventPtr", typeof(EventPtrRec_Full)),
            new CMiniTableDefEx(rEventCols, EventRec.COL_KEY, 0, rEventColNames, "Event", typeof(EventRec_Full)),
            new CMiniTableDefEx(rPropertyMapCols, PropertyMapRec.COL_KEY, 0, rPropertyMapColNames, "PropertyMap", typeof(PropertyMapRec_Full)),
            new CMiniTableDefEx(rPropertyPtrCols, PropertyPtrRec.COL_KEY, 0, rPropertyPtrColNames, "PropertyPtr", typeof(PropertyPtrRec_Full)),
            new CMiniTableDefEx(rPropertyCols, PropertyRec.COL_KEY, 0, rPropertyColNames, "Property", typeof(PropertyRec_Full)),
            new CMiniTableDefEx(rMethodSemanticsCols, MethodSemanticsRec.COL_KEY, 0, rMethodSemanticsColNames, "MethodSemantics", typeof(MethodSemanticsRec_Full)),
            new CMiniTableDefEx(rMethodImplCols, MethodImplRec.COL_KEY, 0, rMethodImplColNames, "MethodImpl", typeof(MethodImplRec_Full)),
            new CMiniTableDefEx(rModuleRefCols, ModuleRefRec.COL_KEY, 0, rModuleRefColNames, "ModuleRef", typeof(ModuleRefRec_Full)),
            new CMiniTableDefEx(rTypeSpecCols, TypeSpecRec.COL_KEY, 0, rTypeSpecColNames, "TypeSpec", typeof(TypeSpecRec_Full)),
            new CMiniTableDefEx(rImplMapCols, ImplMapRec.COL_KEY, 0, rImplMapColNames, "ImplMap", typeof(ImplMapRec_Full)),
            new CMiniTableDefEx(rFieldRVACols, FieldRVARec.COL_KEY, 0, rFieldRVAColNames, "FieldRVA", typeof(FieldRVARec_Full)),
            new CMiniTableDefEx(rENCLogCols, ENCLogRec.COL_KEY, 0, rENCLogColNames, "ENCLog", typeof(ENCLogRec_Full)),
            new CMiniTableDefEx(rENCMapCols, ENCMapRec.COL_KEY, 0, rENCMapColNames, "ENCMap", typeof(ENCMapRec_Full)),
            new CMiniTableDefEx(rAssemblyCols, AssemblyRec.COL_KEY, 0, rAssemblyColNames, "Assembly", typeof(AssemblyRec_Full)),
            new CMiniTableDefEx(rAssemblyProcessorCols, AssemblyProcessorRec.COL_KEY, 0, rAssemblyProcessorColNames, "AssemblyProcessor", typeof(AssemblyProcessorRec_Full)),
            new CMiniTableDefEx(rAssemblyOSCols, AssemblyOSRec.COL_KEY, 0, rAssemblyOSColNames, "AssemblyOS", typeof(AssemblyOSRec_Full)),
            new CMiniTableDefEx(rAssemblyRefCols, AssemblyRefRec.COL_KEY, 0, rAssemblyRefColNames, "AssemblyRef", typeof(AssemblyRefRec_Full)),
            new CMiniTableDefEx(rAssemblyRefProcessorCols, AssemblyRefProcessorRec.COL_KEY, 0, rAssemblyRefProcessorColNames, "AssemblyRefProcessor", typeof(AssemblyRefProcessorRec_Full)),
            new CMiniTableDefEx(rAssemblyRefOSCols, AssemblyRefOSRec.COL_KEY, 0, rAssemblyRefOSColNames, "AssemblyRefOS", typeof(AssemblyRefOSRec_Full)),
            new CMiniTableDefEx(rFileCols, FileRec.COL_KEY, 0, rFileColNames, "File", typeof(FileRec_Full)),
            new CMiniTableDefEx(rExportedTypeCols, ExportedTypeRec.COL_KEY, 0, rExportedTypeColNames, "ExportedType", typeof(ExportedTypeRec_Full)),
            new CMiniTableDefEx(rManifestResourceCols, ManifestResourceRec.COL_KEY, 0, rManifestResourceColNames, "ManifestResource", typeof(ManifestResourceRec_Full)),
            new CMiniTableDefEx(rNestedClassCols, NestedClassRec.COL_KEY, 0, rNestedClassColNames, "NestedClass", typeof(NestedClassRec_Full)),
            new CMiniTableDefEx(rGenericParamCols, GenericParamRec.COL_KEY, 0, rGenericParamColNames, "GenericParam", typeof(GenericParamRec_Full)),
            new CMiniTableDefEx(rMethodSpecCols, MethodSpecRec.COL_KEY, 0, rMethodSpecColNames, "MethodSpec", typeof(MethodSpecRec_Full)),
            new CMiniTableDefEx(rGenericParamConstraintCols, GenericParamConstraintRec.COL_KEY, 0, rGenericParamConstraintColNames, "GenericParamConstraint", typeof(GenericParamConstraintRec_Full)),
        };

        public static readonly CMiniTableDefEx g_Table_GenericParamV1_1 =
            new CMiniTableDefEx(rGenericParamV1_1Cols, GenericParamV1_1Rec.COL_KEY, 0, rGenericParamV1_1ColNames, "GenericParamV1_", typeof(GenericParamV1_1Rec_Full));

        #endregion
    }

    #endregion
}

namespace PEReader.ClrMetadata
{
    using PEReader.ClrMetadata.CoreCLR;

    #region ClrMetadataAccessor Table Properties

    sealed partial class ClrMetadataAccessor
    {
        /// <summary>
        /// Gets the Module table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ModuleRec_Full> ModuleTable
        {
            get { return (MetadataTable<ModuleRec_Full>)(_tables[0]); }
        }

        /// <summary>
        /// Gets the TypeRef table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<TypeRefRec_Full> TypeRefTable
        {
            get { return (MetadataTable<TypeRefRec_Full>)(_tables[1]); }
        }

        /// <summary>
        /// Gets the TypeDef table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<TypeDefRec_Full> TypeDefTable
        {
            get { return (MetadataTable<TypeDefRec_Full>)(_tables[2]); }
        }

        /// <summary>
        /// Gets the FieldPtr table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<FieldPtrRec_Full> FieldPtrTable
        {
            get { return (MetadataTable<FieldPtrRec_Full>)(_tables[3]); }
        }

        /// <summary>
        /// Gets the Field table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<FieldRec_Full> FieldTable
        {
            get { return (MetadataTable<FieldRec_Full>)(_tables[4]); }
        }

        /// <summary>
        /// Gets the MethodPtr table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<MethodPtrRec_Full> MethodPtrTable
        {
            get { return (MetadataTable<MethodPtrRec_Full>)(_tables[5]); }
        }

        /// <summary>
        /// Gets the Method table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<MethodRec_Full> MethodTable
        {
            get { return (MetadataTable<MethodRec_Full>)(_tables[6]); }
        }

        /// <summary>
        /// Gets the ParamPtr table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ParamPtrRec_Full> ParamPtrTable
        {
            get { return (MetadataTable<ParamPtrRec_Full>)(_tables[7]); }
        }

        /// <summary>
        /// Gets the Param table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ParamRec_Full> ParamTable
        {
            get { return (MetadataTable<ParamRec_Full>)(_tables[8]); }
        }

        /// <summary>
        /// Gets the InterfaceImpl table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<InterfaceImplRec_Full> InterfaceImplTable
        {
            get { return (MetadataTable<InterfaceImplRec_Full>)(_tables[9]); }
        }

        /// <summary>
        /// Gets the MemberRef table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<MemberRefRec_Full> MemberRefTable
        {
            get { return (MetadataTable<MemberRefRec_Full>)(_tables[10]); }
        }

        /// <summary>
        /// Gets the Constant table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ConstantRec_Full> ConstantTable
        {
            get { return (MetadataTable<ConstantRec_Full>)(_tables[11]); }
        }

        /// <summary>
        /// Gets the CustomAttribute table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<CustomAttributeRec_Full> CustomAttributeTable
        {
            get { return (MetadataTable<CustomAttributeRec_Full>)(_tables[12]); }
        }

        /// <summary>
        /// Gets the FieldMarshal table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<FieldMarshalRec_Full> FieldMarshalTable
        {
            get { return (MetadataTable<FieldMarshalRec_Full>)(_tables[13]); }
        }

        /// <summary>
        /// Gets the DeclSecurity table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<DeclSecurityRec_Full> DeclSecurityTable
        {
            get { return (MetadataTable<DeclSecurityRec_Full>)(_tables[14]); }
        }

        /// <summary>
        /// Gets the ClassLayout table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ClassLayoutRec_Full> ClassLayoutTable
        {
            get { return (MetadataTable<ClassLayoutRec_Full>)(_tables[15]); }
        }

        /// <summary>
        /// Gets the FieldLayout table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<FieldLayoutRec_Full> FieldLayoutTable
        {
            get { return (MetadataTable<FieldLayoutRec_Full>)(_tables[16]); }
        }

        /// <summary>
        /// Gets the StandAloneSig table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<StandAloneSigRec_Full> StandAloneSigTable
        {
            get { return (MetadataTable<StandAloneSigRec_Full>)(_tables[17]); }
        }

        /// <summary>
        /// Gets the EventMap table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<EventMapRec_Full> EventMapTable
        {
            get { return (MetadataTable<EventMapRec_Full>)(_tables[18]); }
        }

        /// <summary>
        /// Gets the EventPtr table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<EventPtrRec_Full> EventPtrTable
        {
            get { return (MetadataTable<EventPtrRec_Full>)(_tables[19]); }
        }

        /// <summary>
        /// Gets the Event table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<EventRec_Full> EventTable
        {
            get { return (MetadataTable<EventRec_Full>)(_tables[20]); }
        }

        /// <summary>
        /// Gets the PropertyMap table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<PropertyMapRec_Full> PropertyMapTable
        {
            get { return (MetadataTable<PropertyMapRec_Full>)(_tables[21]); }
        }

        /// <summary>
        /// Gets the PropertyPtr table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<PropertyPtrRec_Full> PropertyPtrTable
        {
            get { return (MetadataTable<PropertyPtrRec_Full>)(_tables[22]); }
        }

        /// <summary>
        /// Gets the Property table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<PropertyRec_Full> PropertyTable
        {
            get { return (MetadataTable<PropertyRec_Full>)(_tables[23]); }
        }

        /// <summary>
        /// Gets the MethodSemantics table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<MethodSemanticsRec_Full> MethodSemanticsTable
        {
            get { return (MetadataTable<MethodSemanticsRec_Full>)(_tables[24]); }
        }

        /// <summary>
        /// Gets the MethodImpl table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<MethodImplRec_Full> MethodImplTable
        {
            get { return (MetadataTable<MethodImplRec_Full>)(_tables[25]); }
        }

        /// <summary>
        /// Gets the ModuleRef table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ModuleRefRec_Full> ModuleRefTable
        {
            get { return (MetadataTable<ModuleRefRec_Full>)(_tables[26]); }
        }

        /// <summary>
        /// Gets the TypeSpec table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<TypeSpecRec_Full> TypeSpecTable
        {
            get { return (MetadataTable<TypeSpecRec_Full>)(_tables[27]); }
        }

        /// <summary>
        /// Gets the ImplMap table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ImplMapRec_Full> ImplMapTable
        {
            get { return (MetadataTable<ImplMapRec_Full>)(_tables[28]); }
        }

        /// <summary>
        /// Gets the FieldRVA table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<FieldRVARec_Full> FieldRVATable
        {
            get { return (MetadataTable<FieldRVARec_Full>)(_tables[29]); }
        }

        /// <summary>
        /// Gets the ENCLog table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ENCLogRec_Full> ENCLogTable
        {
            get { return (MetadataTable<ENCLogRec_Full>)(_tables[30]); }
        }

        /// <summary>
        /// Gets the ENCMap table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ENCMapRec_Full> ENCMapTable
        {
            get { return (MetadataTable<ENCMapRec_Full>)(_tables[31]); }
        }

        /// <summary>
        /// Gets the Assembly table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<AssemblyRec_Full> AssemblyTable
        {
            get { return (MetadataTable<AssemblyRec_Full>)(_tables[32]); }
        }

        /// <summary>
        /// Gets the AssemblyProcessor table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<AssemblyProcessorRec_Full> AssemblyProcessorTable
        {
            get { return (MetadataTable<AssemblyProcessorRec_Full>)(_tables[33]); }
        }

        /// <summary>
        /// Gets the AssemblyOS table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<AssemblyOSRec_Full> AssemblyOSTable
        {
            get { return (MetadataTable<AssemblyOSRec_Full>)(_tables[34]); }
        }

        /// <summary>
        /// Gets the AssemblyRef table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<AssemblyRefRec_Full> AssemblyRefTable
        {
            get { return (MetadataTable<AssemblyRefRec_Full>)(_tables[35]); }
        }

        /// <summary>
        /// Gets the AssemblyRefProcessor table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<AssemblyRefProcessorRec_Full> AssemblyRefProcessorTable
        {
            get { return (MetadataTable<AssemblyRefProcessorRec_Full>)(_tables[36]); }
        }

        /// <summary>
        /// Gets the AssemblyRefOS table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<AssemblyRefOSRec_Full> AssemblyRefOSTable
        {
            get { return (MetadataTable<AssemblyRefOSRec_Full>)(_tables[37]); }
        }

        /// <summary>
        /// Gets the File table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<FileRec_Full> FileTable
        {
            get { return (MetadataTable<FileRec_Full>)(_tables[38]); }
        }

        /// <summary>
        /// Gets the ExportedType table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ExportedTypeRec_Full> ExportedTypeTable
        {
            get { return (MetadataTable<ExportedTypeRec_Full>)(_tables[39]); }
        }

        /// <summary>
        /// Gets the ManifestResource table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<ManifestResourceRec_Full> ManifestResourceTable
        {
            get { return (MetadataTable<ManifestResourceRec_Full>)(_tables[40]); }
        }

        /// <summary>
        /// Gets the NestedClass table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<NestedClassRec_Full> NestedClassTable
        {
            get { return (MetadataTable<NestedClassRec_Full>)(_tables[41]); }
        }

        /// <summary>
        /// Gets the GenericParam table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<GenericParamRec_Full> GenericParamTable
        {
            get { return (MetadataTable<GenericParamRec_Full>)(_tables[42]); }
        }

        /// <summary>
        /// Gets the MethodSpec table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<MethodSpecRec_Full> MethodSpecTable
        {
            get { return (MetadataTable<MethodSpecRec_Full>)(_tables[43]); }
        }

        /// <summary>
        /// Gets the GenericParamConstraint table.
        /// </summary>
        [GeneratedCode("MetaModelSchemaGenerator", "1.0")]
        internal MetadataTable<GenericParamConstraintRec_Full> GenericParamConstraintTable
        {
            get { return (MetadataTable<GenericParamConstraintRec_Full>)(_tables[44]); }
        }

    }

    #endregion
}
