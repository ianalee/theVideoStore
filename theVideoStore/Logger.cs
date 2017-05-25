using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theVideoStore
{
    public class logger
    {
        public static void Log(string message)
        {
            using (StreamWriter sr = new StreamWriter("log.txt", true))
            {
                sr.WriteLine(message);
                sr.Close();
            }
        }
    }
}
