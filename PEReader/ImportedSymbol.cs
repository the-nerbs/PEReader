using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PEReader
{
    /// <summary>
    /// Provides data on an imported symbol.
    /// </summary>
    [DebuggerDisplay("{DebugDisplay,nq}")]
    public sealed class ImportedSymbol
    {
        // ordinal when _name is null, hint when name is not null.
        private readonly int _ordinalOrHint;
        private readonly string _name;


        /// <summary>
        /// Indicates if this symbol is imported by ordinal.
        /// </summary>
        public bool IsImportedByOrdinal
        {
            get { return (_name == null); }
        }

        /// <summary>
        /// Gets the ordinal of the imported symbol.
        /// </summary>
        public int Ordinal
        {
            get
            {
                if (!IsImportedByOrdinal)
                    throw new InvalidOperationException("Symbol is not imported by ordinal.");

                return _ordinalOrHint;
            }
        }


        /// <summary>
        /// Indicates if this symbol is imported by name.
        /// </summary>
        public bool IsImportedByName
        {
            get { return (_name != null); }
        }

        //TODO: I'm not sure exactly what this is. I *think* it's for forwarded symbols? Update comment when I know better.
        /// <summary>
        /// If the symbol is imported by name, this is an index into the export name table.
        /// </summary>
        public int Hint
        {
            get
            {
                if (!IsImportedByName)
                    throw new InvalidOperationException("Symbol is not imported by name.");

                return _ordinalOrHint;
            }
        }

        /// <summary>
        /// Gets the name of the symbol being imported.
        /// </summary>
        public string Name
        {
            get
            {
                if (!IsImportedByName)
                    throw new InvalidOperationException("Symbol is not imported by name.");

                return _name;
            }
        }


        private string DebugDisplay
        {
            get
            {
                if (IsImportedByOrdinal)
                {
                    return "#" + Ordinal.ToString("X4");
                }
                else
                {
                    return $"{Name} (Hint={Hint})";
                }
            }
        }


        internal ImportedSymbol(int ordinal)
        {
            _ordinalOrHint = ordinal;
            _name = null;
        }

        internal ImportedSymbol(int hint, string name)
        {
            _ordinalOrHint = hint;
            _name = name;
        }
    }
}
