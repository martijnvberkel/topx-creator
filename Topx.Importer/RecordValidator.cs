using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.Importer
{
    internal class RecordValidator
    {
        private readonly Record _record;
        public List<string> ValidationErrors = new List<string>();

        public RecordValidator(Record record)
        {
            _record = record;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
