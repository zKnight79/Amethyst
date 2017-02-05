using System.Collections.Generic;
using System.IO;

namespace Amethyst.Graphics
{
    /// <summary>
    /// Hold all path used to store texture files for the game. Current directory is added by default
    /// </summary>
    public static class TexturePath
    {
        static List<string> m_PathList = new List<string>(new string[] { "" });

        /// <summary>
        /// Add a path to the TexturePath
        /// </summary>
        /// <param name="path">A relative or absolute folder path</param>
        public static void AddPath(string path)
        {
            if (!m_PathList.Contains(path))
            {
                m_PathList.Add(path);
            }
        }

        /// <summary>
        /// Search for the file in the TexturePath.
        /// </summary>
        /// <param name="fileName">The name of the file to search for</param>
        /// <returns>The path of the found file, or fileName if nothing found</returns>
        public static string GetFilePath(string fileName)
        {
            foreach (string path in m_PathList)
            {
                string p = Path.Combine(path, fileName);
                if (File.Exists(p))
                {
                    return p;
                }
            }
            return fileName;
        }
    }
}
