using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberbankProject
{
    class Logger
    {
        protected FileStream fileStream;

        public Logger(string pathToLogFile)
        {
            this.fileStream = new FileStream(pathToLogFile, FileMode.Append);
        }

        public void writeLine(string text)
        {
            byte[] bdata = Encoding.Default.GetBytes(text);
            this.fileStream.Write(bdata, 0, bdata.Length);
        }
    }
}
