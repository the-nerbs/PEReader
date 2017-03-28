using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEReader.ClrMetadata.CoreCLR;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Contains extension methods for the CLR metadata types.
    /// </summary>
    public static class ClrExtensionMethods
    {
        internal static ClrTable GetTable(this CorTokenType mdToken)
        {
            if (mdToken > CorTokenType.mdtString)
                throw new InvalidOperationException("Token does not have an associated table.");

            // table = the high byte of the MD token
            return (ClrTable)(((int)mdToken) >> 24);
        }


        /// <summary>
        /// Gets the visibility from a type's attributes.
        /// </summary>
        /// <param name="attrs">[this] The type attributes.</param>
        /// <returns>The type visibility.</returns>
        public static ClrTypeVisibility GetVisibility(this ClrTypeAttributes attrs)
        {
            const int mask = (int)ClrTypeAttributes.VisibilityMask;
            const int shift = 0;

            return (ClrTypeVisibility)(((int)attrs & mask) >> shift);
        }

        /// <summary>
        /// Determines if a type is nested.
        /// </summary>
        /// <param name="attrs">[this] The type attributes.</param>
        /// <returns>True if the type is nested; false if not.</returns>
        public static bool IsNested(this ClrTypeAttributes attrs)
        {
            return (attrs.GetVisibility() >= ClrTypeVisibility.NestedPublic);
        }


        /// <summary>
        /// Gets a method's visibility.
        /// </summary>
        /// <param name="attrs">[this] The method attributes.</param>
        /// <returns>The visibility of the method.</returns>
        public static ClrMemberVisibility GetVisibility(this ClrMethodAttributes attrs)
        {
            const int mask = (int)ClrMethodAttributes.VisibilityMask;
            const int shift = 0;

            return (ClrMemberVisibility)(((int)attrs & mask) >> shift);
        }

        /// <summary>
        /// Gets a field's visibility.
        /// </summary>
        /// <param name="attrs">[this] The field attributes.</param>
        /// <returns>The visibility of the field.</returns>
        public static ClrMemberVisibility GetVisibility(this ClrFieldAttributes attrs)
        {
            const int mask = (int)ClrFieldAttributes.VisibilityMask;
            const int shift = 0;

            return (ClrMemberVisibility)(((int)attrs & mask) >> shift);
        }


        /// <summary>
        /// Gets the character set for a p/invoke mapping.
        /// </summary>
        /// <param name="attrs">The p/invoke mapping attributes.</param>
        /// <returns>The character set used by the mapping.</returns>
        public static ClrCharacterSet GetCharacterSet(this ClrPinvokeMapAttributes attrs)
        {
            const int mask = (int)ClrPinvokeMapAttributes.CharSetMask;
            const int shift = 1;

            return (ClrCharacterSet)(((int)attrs & mask) >> shift);
        }

        /// <summary>
        /// Gets the calling convention for a p/invoke mapping.
        /// </summary>
        /// <param name="attrs">The p/invoke mapping attributes.</param>
        /// <returns>The calling convention used by the mapping.</returns>
        public static ClrCallingConvention GetCallingConvention(this ClrPinvokeMapAttributes attrs)
        {
            const int mask = (int)ClrPinvokeMapAttributes.CallingConventionMask;
            const int shift = 8;

            return (ClrCallingConvention)(((int)attrs & mask) >> shift);
        }
    }
}
