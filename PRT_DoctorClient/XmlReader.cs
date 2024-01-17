using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace PRT_DoctorClient
{
    public class XmlReader
    {
        // Example of calling the method
        public List<KeyValuePair<string, string>> ParseCdaFile(string filePath)
        {
            var extractedData = new List<KeyValuePair<string, string>>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList patientNodes = doc.GetElementsByTagName("patient");
            foreach (XmlNode patient in patientNodes)
            {
                string patientName = patient["name"].InnerText; // Adjust as necessary
                string patientId = patient["id"].InnerText; // Adjust as necessary

                extractedData.Add(new KeyValuePair<string, string>(patientId, patientName));
                // Add more data as needed
            }

            return extractedData;
        }
    }

}
