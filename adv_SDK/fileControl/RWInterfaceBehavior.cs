using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace cqplayart.amy.RWControl
{
	public class RWInterfaceBehavior : myRWControl
	{
		public void writefile(string filename, string message)
		{
			StreamWriter write = null;

			string filePath = Application.persistentDataPath + "/" + filename + ".txt";
			FileInfo file = new FileInfo(filePath);
			if (!file.Exists)
			{
				write = file.CreateText();
			}
			else
			{
				File.Delete(Application.persistentDataPath + "/" + filename + ".txt");
				write = file.CreateText();
			}
			write.WriteLine(message);
			write.Close();
		}

		public string readfile(string filename)
		{
			string filePath = Application.persistentDataPath + "/" + filename + ".txt";

			if (File.Exists(filePath))
			{
				FileInfo file = new FileInfo(filePath);
				StreamReader reader = file.OpenText();
				string info = reader.ReadToEnd();

				reader.Close();
				return info;
			}

			return null;
		}

		public void deleteFile(string filename)
		{
			string filePath = Application.persistentDataPath + "/" + filename + ".txt";
			File.Delete(filePath);
		}
	}
}
