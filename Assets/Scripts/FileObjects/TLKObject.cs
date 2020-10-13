using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;

namespace AuroraEngine
{
	public class TLKObject
	{
        public Dictionary<int, TLKEntry> strings = new Dictionary<int, TLKEntry>();

		public TLKEntry this[int index] {
			get {
                if (!strings.ContainsKey(index))
                {
                    return new TLKEntry();
                }

                return strings[index];
			}
		}

        public TLKObject (string xml)
        {
            // Read the XML file using xoreos-tools 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;

            int i = 0;
            foreach (XmlNode node in root.ChildNodes)
            {
                int id = int.Parse(node.Attributes["id"].Value);
                string s = node.InnerText;
                string soundRef = "";
                if (node.Attributes["sound"] != null)
                {
                    soundRef = node.Attributes["sound"].Value;
                }
                float soundLength = 0;
                if (node.Attributes["soundlength"] != null)
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                    soundLength = float.Parse(node.Attributes["soundlength"].Value);
                }

                strings[id] = new TLKEntry()
                {
                    str = s,
                    sound = soundRef,
                    length = soundLength
                };

                i += 1;
            }

            UnityEngine.Debug.Log("Loaded " + i + " strings from the TLK file");
        }
	}

    public struct TLKEntry
    {
        public string str;
        public string sound;
        public float length;
    }
}
