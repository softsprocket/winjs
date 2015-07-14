// winjs entry point 

var console = new (function () {
    var rstr = "winjs_log_object_recursion_str_winjs"; 
    this.log = function () {
        var recursion = false;
        if (arguments[arguments.length - 1] == rstr) {
            recursion = true;
            arguments = Array.prototype.slice.call(arguments, 0, arguments.length - 1);
        }


        for (var ea in arguments) {
            if (arguments[ea] == null) {
                dotnet.System.Console.Write('null');
            } else if (typeof arguments[ea] === 'object') {
                var obj = arguments[ea];
                if (obj instanceof Array) {
                    dotnet.System.Console.Write ("[ ");
                    for (var i = 0; i < obj.length - 1; ++i) {
                        this.log (obj[i], rstr);
                        dotnet.System.Console.Write (", ");
                    }
                    this.log (obj[i], rstr);
                    dotnet.System.Console.Write("]");
                } else {
                    dotnet.System.Console.Write("{ ");
                 
                    var sep = "";
                    for (var i in obj) {
                        dotnet.System.Console.Write(sep);
                        sep = ", ";
                        if (obj.hasOwnProperty (i)) {
                            var k = "" + i;
                            dotnet.System.Console.Write(k + " : ");
                            this.log (obj[i], rstr);


                        }

                    }
                    
                    dotnet.System.Console.Write ("}");
                }

            } else if (typeof arguments[ea] === 'function') {
                dotnet.System.Console.Write ('<function>');
            } else if (typeof arguments[ea] === 'boolean') {
                dotnet.System.Console.Write (arguments[ea] ? 'true' : 'false');
            } else if (typeof arguments[ea] === 'undefined') {
                dotnet.System.Console.Write ('undefined');
            } else {
                dotnet.System.Console.Write (arguments[ea]);
            }
            dotnet.System.Console.Write (" ");
        }

        if (!recursion) {
            dotnet.System.Console.WriteLine ();
        }
    };

    this.read = function () {
        return WinJS_KeyUtil.read ();
    };

    this.readline = function () {
        return dotnet.System.Console.ReadLine ();
    };

}) ();

require (os);




