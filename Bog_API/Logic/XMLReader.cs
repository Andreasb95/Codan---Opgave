using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public class XMLReader : IXMLReader
    {

        //Load XMLDocument
        public XDocument LoadXDocument(string path)
        {
            XDocument doc = XDocument.Load(path);
            return doc;
        }

    }
}
