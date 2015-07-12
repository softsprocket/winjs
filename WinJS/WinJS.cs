using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinJS {
    public class Config {
        public string [] paths;
    }

    public class WinJSLib {
        JSFile jsFile;
        string winJSHome;

        public WinJSLib (string winJSHome) {
            this.winJSHome = winJSHome;
            var configFileName = winJSHome + @"\" + "config.json";

            var contents = File.ReadAllText (configFileName);

            Config config = JsonConvert.DeserializeObject<Config> (contents);
            this.jsFile = new JSFile (winJSHome);

            this.jsFile.addPaths (config.paths);
        }

        public string loadLib () {
            return this.jsFile.loadFile ("winlib.js");
        }

        public string loadApplication (string appPath) {
            return this.jsFile.loadFile (appPath);
        }
    }
}
