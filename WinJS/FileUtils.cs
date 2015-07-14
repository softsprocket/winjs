using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinJS {
    public static class FileUtils {
        public static Dictionary<string, Boolean> GetFileAttributes (string str) {
            var dict = new Dictionary<string, Boolean> ();
            var attr = File.GetAttributes (str);
        
            dict.Add ("isDirectory",  ((attr & FileAttributes.Directory) == FileAttributes.Directory));
            dict.Add ("isNormal", ((attr & FileAttributes.Directory) == FileAttributes.Normal));
            dict.Add ("isReadOnly", ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly));
            dict.Add ("isHidden", ((attr & FileAttributes.Hidden) == FileAttributes.Hidden));
            dict.Add ("isArchive", ((attr & FileAttributes.Archive) == FileAttributes.Archive));
            dict.Add ("isSystem", ((attr & FileAttributes.System) == FileAttributes.System));
            dict.Add ("isCompressed", ((attr & FileAttributes.Compressed) == FileAttributes.Compressed));
            dict.Add ("isTemporary", ((attr & FileAttributes.Temporary) == FileAttributes.Temporary));
      
            return dict;
        }
    }
}
