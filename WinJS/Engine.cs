using System;
using Microsoft.ClearScript.V8;


namespace WinJS {
    public class Engine {
        private V8ScriptEngine engine = null;

        public Engine () { 
            engine = new V8ScriptEngine (V8ScriptEngineFlags.EnableDebugging);
            engine.AddHostObject ("dotnet", new Microsoft.ClearScript.HostTypeCollection ("mscorlib", "System.Core")); 
            engine.AddHostType ("WinJS_KeyUtil", typeof (KeyUtil));
        }

        public void execute (string script) {
            engine.Execute (script);
        }
    }

}
