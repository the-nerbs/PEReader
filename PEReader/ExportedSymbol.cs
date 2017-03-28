using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader
{
    /// <summary>
    /// Provides data on an exported symbol.
    /// </summary>
    public sealed class ExportedSymbol
    {
        private readonly long _rva;
        private readonly string _forwardedName;


        /// <summary>
        /// Indicates if the symbol is an RVA into this module.
        /// </summary>
        public bool IsRva
        {
            get { return !IsForwarded; }
        }

        /// <summary>
        /// Gets the RVA of this symbol's definition within this module.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw if this symbol does not have an RVA.</exception>
        public long Rva
        {
            get
            {
                if (!IsRva)
                    throw new InvalidOperationException("Exported symbol does not have an RVA");

                return _rva;
            }
        }


        /// <summary>
        /// Indicates if the symbol is forwarded from another module.
        /// </summary>
        public bool IsForwarded
        {
            get { return (_forwardedName != null); }
        }

        /// <summary>
        /// Gets the name of the symbol this module is forwarding.
        /// </summary>
        public string ForwardedName
        {
            get
            {
                if (_forwardedName == null)
                    throw new InvalidOperationException("Exported symbol is not forwarded.");

                return _forwardedName;
            }
        }


        internal ExportedSymbol(long rva)
        {
            _rva = rva;
            _forwardedName = null;
        }

        internal ExportedSymbol(string forwardedName)
        {
            _rva = default(long);
            _forwardedName = forwardedName;
        }
    }
}
