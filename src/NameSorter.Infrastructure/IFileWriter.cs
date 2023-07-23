using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameSorter.Infrastructure
{
    public interface IFileWriter
    {
        bool WriteLines(string filename, IEnumerable<string> lines);
    }
}