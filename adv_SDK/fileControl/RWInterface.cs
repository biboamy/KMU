using UnityEngine;

namespace cqplayart.amy.RWControl
{
	public interface myRWControl
	{
		void writefile(string filename, string message);
		string readfile(string filename);
		void deleteFile(string filename);
	}


}