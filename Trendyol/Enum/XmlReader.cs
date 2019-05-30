using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Trendyol.Enum
{
    class XmlReader
    {
        public string[] Reader(string type)
        {
            string[] information=new string [1];
            XmlDocument xml = new XmlDocument();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (path.Contains("bin"))
            {
                path = path.Substring(0, path.Length - 11);
            }
            var fileName = Path.Combine(path, Path.Combine("DataSource", "TrendyolData.xml"));
            var doc = XDocument.Load(fileName);
            var result = doc.Descendants("root").Elements(type);
            foreach (var item in result)
            {
                information[0] = item.Value;
            }
            return information;

        }
    }
}
