using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEReader
{
    /// <summary>
    /// Provides access to a PE file's import data.
    /// </summary>
    public interface IPeImportData
    {
        /// <summary>
        /// Gets a collection of module import data.
        /// </summary>
        IList<ImportModule> Modules { get; }
    }
}
