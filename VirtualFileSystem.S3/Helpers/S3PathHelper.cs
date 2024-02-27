using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.S3.Helpers
{
    internal class S3PathHelper
    {
        public static string GetFileName(string path) {
            // we use / as path separator path char regardless to the OS we are running on

            if (path != null)
            {
                int i = path.Length - 1;
                while (i > 0) 
                {
                    char ch = path[i];
                    CheckValidChar(ch);
                    if (ch == '/')
                        return path[(i + 1)..];

                    i--;
                }
            }

            return path ?? string.Empty;
        }

        private static void CheckValidChar(char ch)
        {
            if (ch < ' ')
            {
                throw new ArgumentException($"{ch} is an invalid path char");
            }
        }
    }
}
