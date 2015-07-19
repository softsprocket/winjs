using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinJS;
using System.Collections;

namespace WinJSExe {
    enum ExitCodes : int {
        Success = 0,
        InvalidCliParameter = 1,
        RequiredParameter = 2
    }
    
    class Program {
        public string configLocation;
        public string applicationName;
        public ArrayList applicationArgs = new ArrayList ();

        void usage (ExitCodes res = ExitCodes.Success) {
            Console.WriteLine ("Usage: [-c|--config] [-h|--help] <path/to/winjs/home> fileToExecute");
            Console.WriteLine (
                @"If the environment variable WINJSHOME is not set then -c 
                and the fullpath to the location of the winjs configuration
                file is required."
            );

            Environment.Exit ((int) res);
        }

        public void arguments (string [] args) {

            for (int i = 0; i < args.Length; ++i) {
                var arg = args [i];
                int pos = 0;
                if (arg [pos] == '-') {
                    ++pos;
                    if (arg [pos] == '-') {
                        ++pos;
                    }

                    var tmp = arg.Substring (pos);
                            
                    switch (tmp[0]) {
                        case 'c': // config - winjs home
                            ++i;
                            configLocation = args [i];
                            break;
                        case 'h':
                            usage ();
                            break;
                        default:
                            usage (ExitCodes.InvalidCliParameter);
                            break;
                    }
                } else {
                    applicationArgs.Add (arg);
                }
            }

            applicationName = (string) applicationArgs[0];

        }

        static void Main (string [] args) {
            string home;

            Program prog = new Program ();
            prog.arguments (args);

            if (prog.configLocation == null) {
                home = Environment.GetEnvironmentVariable ("WINJSHOME");

                if (home == null) {
                    prog.usage (ExitCodes.RequiredParameter);
                }

                prog.configLocation = home;
            }

            WinJSLib wjs = new WinJSLib (prog.configLocation);
            var lib = wjs.loadLib ();

            var app = wjs.loadApplication (prog.applicationName);

            var script = lib + app;
            Engine engine = new Engine ();
            engine.addArgumentObject (prog.applicationArgs.ToArray ());

            try { 
                engine.execute (script);
            } catch (Microsoft.ClearScript.ScriptEngineException e) {
                Console.WriteLine ();
                Console.WriteLine (e.ErrorDetails);
            }

            Console.ReadKey ();
        }
    }
}
