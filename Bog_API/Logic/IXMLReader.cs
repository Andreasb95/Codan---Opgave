using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public interface IXMLReader
    {

        public XDocument LoadXDocument(string path);

    }
}
