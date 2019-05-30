using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Enum
{
    public class Log
    {
        public void WriteLog(string exception)
        {
            string path = @"D:/Log.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            string errorMessage = string.Concat("Tarih: ", DateTime.Now,"  ", exception);
            File.AppendAllText(path, errorMessage + Environment.NewLine);
        }
    }
}
