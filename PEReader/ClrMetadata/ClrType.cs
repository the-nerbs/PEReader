using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEReader.ClrMetadata.CoreCLR;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Provides information on a CLR type definition.
    /// </summary>
    public sealed class ClrType
    {
        private readonly uint _typeIndex;
        private readonly TypeDefRec_Full _record;
        private readonly string _name;
        private readonly string _namespace;
        private readonly ClrType _enclosingType;


        /// <summary>
        /// Gets the type attribute flags.
        /// </summary>
        public ClrTypeAttributes AttributeFlags
        {
            get { return (ClrTypeAttributes)(_record.m_Flags); }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the namespace containing this type.
        /// </summary>
        public string Namespace
        {
            get { return _namespace; }
        }


        internal ClrType(PeDotNetInformation rootAccessor, uint typeDefIndex)
        {
            _typeIndex = typeDefIndex;
            _record = rootAccessor.Metadata.TypeDefTable[typeDefIndex];

            if (!rootAccessor.MetadataStrings.TryGetStringByOffset(_record.m_Name, out _name))
            {
                throw new BadImageFormatException("Type definition name is not valid.");
            }

            if (!rootAccessor.MetadataStrings.TryGetStringByOffset(_record.m_Namespace, out _namespace))
            {
                throw new BadImageFormatException("Type definition namespace is not valid.");
            }

            NestedClassRec_Full nestedType;
            if (rootAccessor.Metadata.NestedClassTable.TryGetRecordByKey(typeDefIndex, out nestedType))
            {
                _enclosingType = new ClrType(rootAccessor, nestedType.m_EnclosingClass);
            }
        }
    }
}
