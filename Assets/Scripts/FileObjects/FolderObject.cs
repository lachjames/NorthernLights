using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AuroraEngine
{
	public class FolderObject : AuroraArchive
	{
		public const int HEADER_SIZE = 160, RES_SIZE = 32;

		public Dictionary<(string, ResourceType), string> resources = new Dictionary<(string, ResourceType), string>();

		public FolderObject(string filepath) : base(filepath, false) { }

		public override void SetupArchive()
		{
			foreach (string file in Directory.EnumerateFiles(filePath))
			{
				string resref = Path.GetFileNameWithoutExtension(file).ToLower();
				string ext = Path.GetExtension(file).Replace(".", "").Replace("2", "T").ToUpper();

				try
                {
					ResourceType rt = (ResourceType)Enum.Parse(typeof(ResourceType), ext);
					resources[(resref, rt)] = file;
				}
				catch
                {
					UnityEngine.Debug.Log("Could not convert ext " + ext + " to ResourceType");
                }
			}
		}

		public override Stream GetResource(string resref, ResourceType type)
		{
			if (!resources.ContainsKey((resref, type)))
			{
				return null;
			}
			return new FileStream(resources[(resref, type)], FileMode.Open, FileAccess.Read);
		}
	}
}