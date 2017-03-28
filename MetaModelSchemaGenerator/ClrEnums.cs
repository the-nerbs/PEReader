﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaModelSchemaGenerator
{
    public enum CorTokenType : uint
    {
        mdtModule                 = 0x00000000,       //
        mdtTypeRef                = 0x01000000,       //
        mdtTypeDef                = 0x02000000,       //
        mdtFieldDef               = 0x04000000,       //
        mdtMethodDef              = 0x06000000,       //
        mdtParamDef               = 0x08000000,       //
        mdtInterfaceImpl          = 0x09000000,       //
        mdtMemberRef              = 0x0a000000,       //
        mdtCustomAttribute        = 0x0c000000,       //
        mdtPermission             = 0x0e000000,       //
        mdtSignature              = 0x11000000,       //
        mdtEvent                  = 0x14000000,       //
        mdtProperty               = 0x17000000,       //
        mdtMethodImpl             = 0x19000000,       //
        mdtModuleRef              = 0x1a000000,       //
        mdtTypeSpec               = 0x1b000000,       //
        mdtAssembly               = 0x20000000,       //
        mdtAssemblyRef            = 0x23000000,       //
        mdtFile                   = 0x26000000,       //
        mdtExportedType           = 0x27000000,       //
        mdtManifestResource       = 0x28000000,       //
        mdtGenericParam           = 0x2a000000,       //
        mdtMethodSpec             = 0x2b000000,       //
        mdtGenericParamConstraint = 0x2c000000,

        mdtString                 = 0x70000000,       //
        mdtName                   = 0x71000000,       //
        mdtBaseType               = 0x72000000,       // Leave this on the high end value. This does not correspond to metadata table
    }

    public enum TBL
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


    public enum CDTKN
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
}
