using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covid19.DependencyService
{
    public interface IFileReadWrite
    {
        void WriteData(string fileName, string data);
        Task<string> ReadData(string filename);

    }
}
