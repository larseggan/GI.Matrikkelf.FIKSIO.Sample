using System;

using KS.Fiks.IO.Client.Models;
using KS.Fiks.IO.Client;

using KS.Fiks.ASiC_E;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibFIKSIO
{
    // try to owervrite encoding
    public sealed class ExtentedStringWriter : StringWriter
    {
        private readonly Encoding stringWriterEncoding;
        public ExtentedStringWriter(Encoding desiredEncoding)
            : base()
        {
            this.stringWriterEncoding = desiredEncoding;
        }

        public override Encoding Encoding
        {
            get
            {
                return this.stringWriterEncoding;
            }
        }
    }
}
