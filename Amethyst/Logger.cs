using System;
using System.IO;

namespace Amethyst
{
    /// <summary>
    /// Static class for logging, all entries goes to a file named Amethyst.log
    /// </summary>
    public static class Logger
    {
        const string LOGFILENAME = "Amethyst.log";

        static TextWriter m_TextWriter = File.CreateText(LOGFILENAME);
        
        /// <summary>
        /// Stop logging
        /// </summary>
        public static void StopLog()
        {
            if (m_TextWriter != null)
            {
                m_TextWriter.Close();
                m_TextWriter.Dispose();
                m_TextWriter = null; 
            }
        }
        /// <summary>
        /// Stop logging and delete log file
        /// </summary>
        public static void DeleteLog()
        {
            StopLog();
            File.Delete(LOGFILENAME);
        }
        /// <summary>
        /// Writes a line to the log file
        /// </summary>
        /// <param name="line">The line to write in the log file</param>
        public static void WriteLine(string line)
        {
            if (m_TextWriter != null)
            {
                m_TextWriter.WriteLine(line);
                m_TextWriter.Flush();
            }
        }
    }
}
