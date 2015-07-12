using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinJS {
    public class JSFile {
        private List<string> paths;
        private string restr = @"require\s*\(\s*((.+)|\[\s*((.+),?)+\s*\])\s*\)\s*;";
        private Regex re;
        private string winJSHome;

        public JSFile (string winJSHome) {
            this.winJSHome = winJSHome;
            paths = new List<string> ();
            re = new Regex (restr);
            this.addPath (winJSHome);
        }

        public void addPath (string path) {
            if (!path.EndsWith (@"\")) {
                path += @"\";
            }
            Uri uri = new Uri (path, UriKind.RelativeOrAbsolute);

            if (!uri.IsAbsoluteUri) {
                path = winJSHome + @"\" + path;

            }
            
            paths.Add (path);
        }

        public void addPaths (string [] ps) {
            foreach (var path in ps) {
                this.addPath (path);
            }
        }

        public string loadFile (string path) {
            string fullpath = path;

            var len = paths.Count;
            int i = 0;

            while (!File.Exists (fullpath) && i < len) {
                fullpath = paths [i] + path;
                ++i;
            }

            if (!File.Exists (fullpath)) {
                throw new FileNotFoundException ();
            }

            string contents = File.ReadAllText (fullpath);
            foreach (Match match in re.Matches (contents)) {
                for (int ii = match.Groups.Count - 1; ii >= 0; --ii) {
                    var group = match.Groups [ii];
                    if (group.Captures.Count > 0) {
                        var names = group.Captures [0].Value.Split (',');

                        foreach (var n in names) {
                            var name = n.Trim ();
                            if (!name.EndsWith (@".js")) {
                                name += @".js";
                            }
                            name = name.Replace ('/', '\\');                            
                            contents = contents.Remove (match.Index, match.Length);
                            contents = contents.Insert (match.Index, this.loadFile (name));
                        }

                        break;
                    }
                }
            }

            return contents;
        }

    }
}
