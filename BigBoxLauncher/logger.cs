using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BigBoxLauncher
{
    static public class Logger
    {
        static System.IO.StreamWriter _logger;

        static public void Open(string filename)
        {
            _logger = new StreamWriter(filename);
        }

        static public void Close()
        {
            _logger.Close();
        }

        static public void WriteLine(string value)
        {
            string output = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|" + value;
            Console.WriteLine(output);
            _logger.WriteLine(output);
            _logger.Flush();
        }

    }
}
