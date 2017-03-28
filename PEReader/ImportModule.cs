using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PEReader.Native;

namespace PEReader
{
    /// <summary>
    /// Provides data on a module from which symbols are imported.
    /// </summary>
    [DebuggerDisplay("{DebugDisplay,nq}")]
    public sealed class ImportModule
    {
        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the collection of symbols imported from this module.
        /// </summary>
        public IList<ImportedSymbol> Symbols { get; }


        private string DebugDisplay
        {
            get
            {
                return $"{Name} ({Symbols.Count} symbols)";
            }
        }


        internal ImportModule(string name, ImportedSymbol[] symbols)
        {
            Name = name;
            Symbols = symbols;
        }
    }
}
