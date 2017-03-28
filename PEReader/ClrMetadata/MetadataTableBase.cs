using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.ClrMetadata.CoreCLR;

namespace PEReader.ClrMetadata
{
    internal abstract class MetadataTableBase
    {
        private readonly CMiniMdBase _md;

        protected readonly CMiniTableDefEx _tableDef;
        private readonly long _recordCount;


        public string Name
        {
            get { return _tableDef.m_pName; }
        }

        public ClrTable Table { get; }

        public int ColumnCount
        {
            get { return _tableDef.m_Def.m_cCols; }
        }

        public long RowCount
        {
            get { return _recordCount; }
        }

        public bool DefinesKey
        {
            get { return (_tableDef.m_Def.m_iKey < _tableDef.m_Def.m_cCols); }
        }

        internal CMiniMdSchema Schema
        {
            get { return _md.Schema;}
        }


        protected MetadataTableBase(CMiniMdBase md, ClrTable table)
        {
            _md = md;
            Table = table;

            _tableDef = MetaModel.g_Tables[(int)table];

            _tableDef = new CMiniTableDefEx(
                md[table],
                _tableDef.m_pColNames,
                _tableDef.m_pName
            );

            _recordCount = md.Schema.RowCount[table];
        }
    }
}
